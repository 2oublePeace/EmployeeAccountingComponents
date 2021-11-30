using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using OfficeNonVisualComponents.HelperModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;


namespace OfficeNonVisualComponents
{
	public partial class WordImageComponent : Component
	{
		public WordImageComponent()
		{
			InitializeComponent();
		}

		public WordImageComponent(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public static void CreateDoc(string fileName, string title, string[] imageFileNames)
		{
			using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
			{
				MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
				mainPart.Document = new Document();
				Body docBody = mainPart.Document.AppendChild(new Body());

				docBody.AppendChild(CreateParagraph(new WordParagraph
				{
					Texts = new List<(string, WordTextProperties)> { (title, new WordTextProperties { Bold = true, Size = "24", }) },
					TextProperties = new WordTextProperties
					{
						Size = "24",
						JustificationValues = JustificationValues.Center
					}
				}));

				ImagePart[] imageParts = new ImagePart[imageFileNames.Length];

				for (int i = 0; i < imageParts.Length; i++)
				{
					imageParts[i] = mainPart.AddImagePart(ImagePartType.Jpeg);

					using (FileStream stream = new FileStream(imageFileNames[i], FileMode.Open))
					{
						imageParts[i].FeedData(stream);
					}

					AddImageToBody(wordDocument, mainPart.GetIdOfPart(imageParts[i]));
				}

				docBody.AppendChild(CreateSectionProperties());
				wordDocument.MainDocumentPart.Document.Save();
			}
		}

		/// <summary>
		/// Настройки страницы
		/// </summary>
		/// <returns></returns>
		private static SectionProperties CreateSectionProperties()
		{
			SectionProperties properties = new SectionProperties();

			PageSize pageSize = new PageSize
			{
				Orient = PageOrientationValues.Portrait
			};

			properties.AppendChild(pageSize);

			return properties;
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

		private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
		{
			// Define the reference of the image.
			var element =
				 new Drawing(
					 new DW.Inline(
						 new DW.Extent() { Cx = 990000L, Cy = 792000L },
						 new DW.EffectExtent()
						 {
							 LeftEdge = 0L,
							 TopEdge = 0L,
							 RightEdge = 0L,
							 BottomEdge = 0L
						 },
						 new DW.DocProperties()
						 {
							 Id = (UInt32Value)1U,
							 Name = "Picture 1"
						 },
						 new DW.NonVisualGraphicFrameDrawingProperties(
							 new A.GraphicFrameLocks() { NoChangeAspect = true }),
						 new A.Graphic(
							 new A.GraphicData(
								 new PIC.Picture(
									 new PIC.NonVisualPictureProperties(
										 new PIC.NonVisualDrawingProperties()
										 {
											 Id = (UInt32Value)0U,
											 Name = "New Bitmap Image.jpg"
										 },
										 new PIC.NonVisualPictureDrawingProperties()),
									 new PIC.BlipFill(
										 new A.Blip(
											 new A.BlipExtensionList(
												 new A.BlipExtension()
												 {
													 Uri =
														"{28A0092B-C50C-407E-A947-70E740481C1C}"
												 })
										 )
										 {
											 Embed = relationshipId,
											 CompressionState =
											 A.BlipCompressionValues.Print
										 },
										 new A.Stretch(
											 new A.FillRectangle())),
									 new PIC.ShapeProperties(
										 new A.Transform2D(
											 new A.Offset() { X = 0L, Y = 0L },
											 new A.Extents() { Cx = 990000L, Cy = 792000L }),
										 new A.PresetGeometry(
											 new A.AdjustValueList()
										 )
										 { Preset = A.ShapeTypeValues.Rectangle }))
							 )
							 { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
					 )
					 {
						 DistanceFromTop = (UInt32Value)0U,
						 DistanceFromBottom = (UInt32Value)0U,
						 DistanceFromLeft = (UInt32Value)0U,
						 DistanceFromRight = (UInt32Value)0U,
						 EditId = "50D07946"
					 });

			// Append the reference to body, the element should be in a Run.
			wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
		}
	}
}
