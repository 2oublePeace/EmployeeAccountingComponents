using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeNonVisualComponents.HelperModels;

namespace OfficeNonVisualComponents
{
	public partial class WordTableComponent : Component
	{
		private const int PropertyIndex = 1;
		private const int HeadersColumnCount = 2;

		public WordTableComponent()
		{
			InitializeComponent();
		}

		public WordTableComponent(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

        public static void CreateDoc<T>(string fileName, string title, Dictionary<(int, int), int> rowMergeInfo, 
	        List<Queue<KeyValuePair<string, string>>> headers, List<T> deliveries, Dictionary<int, int> rowHeightInfo)
        {
	        using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
            {   
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                body.AppendChild
                (
	                CreateParagraph
	                (
		                new WordParagraph
		                {
							Texts = new List<(string, WordTextProperties)>
							{
								(title, new WordTextProperties { Bold = true, Size = "24"})
							},
							TextProperties = new WordTextProperties
							{
								Size = "24",
								JustificationValues = JustificationValues.Center
							}
						}
		            )
	            );
                
                CheckEnterData(deliveries);
                CheckHeadersFilling(headers);
                CheckRowsPropertyValues(headers);
                Table table = CreateTable
                (
	                headers[PropertyIndex].Count, 
	                headers.Count + deliveries.Count,
	                rowMergeInfo, 
	                headers, 
	                deliveries,
	                rowHeightInfo
	            );
				body.AppendChild(table);
            }
        }

		/// <summary>
		/// Создание абзаца с текстом
		/// </summary>
		/// <param name="paragraph"></param>
		/// <returns></returns>
		private static Paragraph CreateParagraph(WordParagraph paragraph)
		{
			if (paragraph != null)
			{
				Paragraph docParagraph = new Paragraph();

				docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
				foreach (var run in paragraph.Texts)
				{
					Run docRun = new Run();

					RunProperties properties = new RunProperties(); 
					properties.AppendChild(new FontSize { Val = run.Item2.Size }); 
					if (run.Item2.Bold)
					{
						properties.AppendChild(new Bold());
					}
					docRun.AppendChild(properties);

					docRun.AppendChild(new Text { Text = run.Item1, Space = SpaceProcessingModeValues.Preserve });

					docParagraph.AppendChild(docRun);
				}

				return docParagraph;
			}
			return null;
		}

		/// <summary>
		/// Задание форматирования для абзаца
		/// </summary>
		/// <param name="paragraphProperties"></param>
		/// <returns></returns>
		private static ParagraphProperties CreateParagraphProperties(WordTextProperties paragraphProperties)
		{
			if (paragraphProperties != null)
			{
				ParagraphProperties properties = new ParagraphProperties();

				properties.AppendChild(new Justification()
				{
					Val = paragraphProperties.JustificationValues
				});

				properties.AppendChild(new SpacingBetweenLines
				{
					LineRule = LineSpacingRuleValues.Auto
				});
				properties.AppendChild(new Indentation()); 
				ParagraphMarkRunProperties paragraphMarkRunProperties = new ParagraphMarkRunProperties();
				if (!string.IsNullOrEmpty(paragraphProperties.Size))
				{
					paragraphMarkRunProperties.AppendChild(new FontSize { Val = paragraphProperties.Size });
				}
				properties.AppendChild(paragraphMarkRunProperties);

				return properties;
			}

			return null;
		}

		private static Table CreateTable<T>(int rowCount, int columnCount, Dictionary<(int, int), int> rowMergeInfo, 
			List<Queue<KeyValuePair<string, string>>> headers, List<T> deliveries, Dictionary<int, int> rowHeightInfo)
		{
			Table table = new Table();
			TableRow[] tableRows = new TableRow[rowCount];
			TableCell[] tableCells = new TableCell[columnCount];
			Dictionary<int, KeyValuePair<string, string>> headersDictionary = ToDictionary(headers);
			
            table.AppendChild(new TableProperties(
		            new TableBorders(
			            new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
			            new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
			            new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
			            new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
			            new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
			            new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 }
		            )
				)
            );

            for (int i = 0; i < tableRows.Length; i++)
			{
				tableRows[i] = new TableRow();
				if(rowHeightInfo.ContainsKey(i))
				{
					tableRows[i].Append
					(
						new TableRowProperties
						(
							new TableRowHeight
							{
								Val = (uint)rowHeightInfo[i], HeightType = HeightRuleValues.Exact
							}
						)
					);
				}
				for (int j = 0; j < tableCells.Length; j++)
				{
					tableCells[j] = new TableCell();
					foreach (var rowMerge in rowMergeInfo)
					{
						//Если ячейка находится в диапазоне слияния или выходит из него
						if (IsRestart(rowMerge.Key.Item1, rowMerge.Key.Item2, rowMerge.Value,i,j))
						{
							tableCells[j].Append(new TableCellProperties(
								new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1200" },
								new VerticalMerge { Val = MergedCellValues.Restart }));
						}
						else if (rowMerge.Key.Item1 + rowMerge.Value >= i && rowMerge.Key.Item2 == j)
						{
							tableCells[j].Append(new TableCellProperties(
								new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1200" },
								new VerticalMerge { Val = MergedCellValues.Continue }));
						}	
					}

					if (IsNotOverlapped(tableCells[j]))
					{
						if (j < headers.Count && headers[j].Count > 0)
						{
							tableCells[j].Append(
								new Paragraph(
									new Run(
										new Text(headers[j].Dequeue().Key)
									)
								)
							);
						}
						else
						{
							tableCells[j].Append(
								new Paragraph(
									new Run(
										new Text(FillTableData(i, j, deliveries, headersDictionary))
									)
								)
							);
						}	
					}
					
					tableRows[i].Append(tableCells[j]);
				}
				table.Append(tableRows[i]);
			}

			return table;
        }
		
		private static bool IsNotOverlapped(TableCell tableCell)
		{
			if (tableCell.TableCellProperties == null || 
			    tableCell.TableCellProperties.VerticalMerge?.Val != MergedCellValues.Continue)
			{
				return true;
			}
			return false;
		}
		
		private static string FillTableData<T>(int row, int column, List<T> deliveries,
			Dictionary<int, KeyValuePair<string, string>> headers)
		{
			Type type = typeof(T);
			PropertyInfo[] properties = type.GetProperties();

			foreach(PropertyInfo property in properties)
			{
				if(column - HeadersColumnCount < deliveries.Count && row < headers.Count && property.Name == headers[row].Value)
				{
					return property.GetValue(deliveries[column - HeadersColumnCount]).ToString();
				}
			}

			return string.Empty;
		}

		private static Dictionary<int, KeyValuePair<string, string>> ToDictionary(List<Queue<KeyValuePair<string, string>>> headers)
		{
			Dictionary<int, KeyValuePair<string, string>> headersDict = new Dictionary<int, KeyValuePair<string, string>>();
			int ind = 0;
			foreach (var keyValuePair in headers[PropertyIndex])
			{
				headersDict.Add(ind++, keyValuePair);
			}
			return headersDict;
		}
		
		private static bool IsRestart(int rowMerge, int columnMerge, int valueMerge , int row, int column)
		{
			if (rowMerge == row && columnMerge == column || row > (rowMerge + valueMerge) && columnMerge == column)
			{
				return true;
			}

			return false;
		}
		
		private static void CheckEnterData<T>(List<T> deliveries)
		{
			Type type = typeof(T);
			PropertyInfo[] properties = type.GetProperties();

			foreach (T item in deliveries)
			{
				foreach (PropertyInfo property in properties)
				{
					if (Equals(property.GetValue(item), null))
					{
						throw new Exception("Свойство было NULL!");
					}
				}
			}
		}
		
		private static void CheckHeadersFilling(List<Queue<KeyValuePair<string, string>>> headers)
		{
			foreach (var header in headers)
			{
				foreach (var head in header)
				{
					if (head.Key == null)
					{
						throw new Exception("Свойство было NULL!");
					}
				}
			}
		}
		
		private static void CheckRowsPropertyValues(List<Queue<KeyValuePair<string, string>>> headers)
		{
			foreach (var header in headers)
			{
				foreach (var head in header)
				{
					if (head.Value == null)
					{
						throw new Exception("Свойство было NULL!");
					}
				}
			}
		}
	}
}
