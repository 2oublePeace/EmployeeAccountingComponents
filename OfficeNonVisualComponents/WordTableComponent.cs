using System.Collections.Generic;
using System.ComponentModel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeNonVisualComponents.HelperModels;

namespace OfficeNonVisualComponents
{
	public partial class WordTableComponent : Component
	{
		public WordTableComponent()
		{
			InitializeComponent();
		}

		public WordTableComponent(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

        public static void CreateDoc(string fileName, string title, Dictionary<(int, int), int> rowMergeInfo, Queue<string>[] headers)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
            {   
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
 
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                body.AppendChild(CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (title, new WordTextProperties { Bold = true, Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationValues = JustificationValues.Center
                    }
                }));

                Table table = CreateTable(3, 4, rowMergeInfo, headers);

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

					RunProperties properties = new RunProperties(); properties.AppendChild(new FontSize { Val = run.Item2.Size }); if (run.Item2.Bold)
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
				properties.AppendChild(new Indentation()); ParagraphMarkRunProperties paragraphMarkRunProperties = new
				ParagraphMarkRunProperties();
				if (!string.IsNullOrEmpty(paragraphProperties.Size))
				{
					paragraphMarkRunProperties.AppendChild(new FontSize { Val = paragraphProperties.Size });
				}
				properties.AppendChild(paragraphMarkRunProperties);

				return properties;
			}

			return null;
		}

		private static Table CreateTable(int rowCount, int columnCount, Dictionary<(int, int), int> rowMergeInfo, Queue<string>[] headers)
		{
            Table table = new Table();

            TableProperties tblProp = new TableProperties(
                new TableBorders(
                    new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
                    new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
                    new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
                    new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
                    new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 },
                    new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 8 }
                )
            );

            table.AppendChild(tblProp);

			TableRow[] tableRows = new TableRow[rowCount];
			TableCell[] tableCells = new TableCell[columnCount];

			Dictionary<int?, int?> rowMerge = new Dictionary<int?, int?>();
			for (int i = 0; i < tableRows.Length; i++)
			{
				tableRows[i] = new TableRow();

				for (int j = 0; j < tableCells.Length; j++)
				{
					tableCells[j] = new TableCell();

					if (j < 2)
					{
						bool skip = false;
						foreach (var row in rowMergeInfo)
						{
							if (row.Key.Item1 == i && row.Key.Item2 == j)
							{
								rowMerge.Add(row.Key.Item2, row.Value);
								tableCells[j].Append(new TableCellProperties(
									new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "4800" },
									new VerticalMerge { Val = MergedCellValues.Restart }));
								tableCells[j].Append(new Paragraph(new Run(new Text(FillTableHead(j, headers[j])))));
								skip = true;
								break;
							}
						}

						if(!skip)
						{
							if (rowMerge.ContainsKey(j) && rowMerge[j].Value > 0)
							{
								tableCells[j].Append(new TableCellProperties(
									new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "4800" },
									new VerticalMerge { Val = MergedCellValues.Continue }));
								tableCells[j].Append(new Paragraph(new Run(new Text(FillTableHead(j, headers[j])))));
								rowMerge[j]--;
							}
							else if (j == 0)
							{
								tableCells[j].Append(new TableCellProperties(
									new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "4800" },
									new HorizontalMerge { Val = MergedCellValues.Restart }));
								tableCells[j].Append(new Paragraph(new Run(new Text(FillTableHead(j, headers[j])))));
							}
							else
							{
								tableCells[j].Append(new TableCellProperties(
									new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "4800" },
									new HorizontalMerge { Val = MergedCellValues.Continue }));
								tableCells[j].Append(new Paragraph(new Run(new Text(FillTableHead(j, headers[j])))));
							}
						}
					} 
					else
					{
						tableCells[j].Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "4800" }));
						tableCells[j].Append(new Paragraph(new Run(new Text())));
					}
					
					tableRows[i].Append(tableCells[j]);
				}
				table.Append(tableRows[i]);
			}

			return table;
        }

		private static string FillTableHead(int index, Queue<string> headers)
		{
			if(headers.Count > 0)
			{
				return headers.Dequeue();
			}

			return string.Empty;
		} 
    }
}
