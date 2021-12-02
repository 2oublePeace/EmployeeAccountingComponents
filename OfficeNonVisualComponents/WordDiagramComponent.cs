using OfficeNonVisualComponents.HelperModels;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.OfficeChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace OfficeNonVisualComponents
{
	public partial class WordDiagramComponent : Component
	{
		public WordDiagramComponent()
		{
			InitializeComponent();
		}

		public WordDiagramComponent(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

        public static void CreateDoc(string docName, string title, string docTitle, ChartDataInfo chartDataInfo, ChartLegendPosition chartLegendPosition)
        {
			WordDocument document = new WordDocument();

			IWSection sec = document.AddSection();
	
			IWParagraph paragraph = sec.AddParagraph();
			
			paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
			paragraph.AppendText(docTitle);	

			WChart chart = paragraph.AppendChart(446, 270);
			
			chart.ChartType = OfficeChartType.Pie;
			
			chart.ChartTitle = title;
			chart.ChartTitleArea.FontName = "Calibri";
			chart.ChartTitleArea.Size = 14;

			chart.ChartData.SetValue(1, 1, "");
			chart.ChartData.SetValue(1, 2, chartDataInfo.Series);
			int index = 2;
			foreach (var info in chartDataInfo.Data)
			{
				chart.ChartData.SetValue(index, 1, info.Key);
				chart.ChartData.SetValue(index, 2, info.Value);
				index++;
			}
			
			IOfficeChartSerie pieSeries = chart.Series.Add(chartDataInfo.Series);
			pieSeries.Values = chart.ChartData[2, 2, chartDataInfo.Data.Count + 1, 2];
			
			pieSeries.DataPoints.DefaultDataPoint.DataLabels.IsValue = true;
			pieSeries.DataPoints.DefaultDataPoint.DataLabels.Position = OfficeDataLabelPosition.Outside;
			
			chart.ChartArea.Fill.ForeColor = Color.FromArgb(242, 242, 242);
			chart.PlotArea.Fill.ForeColor = Color.FromArgb(242, 242, 242);
			chart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
	
			chart.PrimaryCategoryAxis.CategoryLabels = chart.ChartData[2, 1, chartDataInfo.Data.Count + 1, 1];

			chart.HasLegend = true;

			chart.Legend.Position = AlignLegend(chartLegendPosition);

			document.Save(docName, FormatType.Docx);

			document.Close();
		}

		public static OfficeLegendPosition AlignLegend(ChartLegendPosition chartLegendPosition)
		{
			if(chartLegendPosition == ChartLegendPosition.Top)
			{
				return OfficeLegendPosition.Top;
			} 
			else if(chartLegendPosition == ChartLegendPosition.Bottom)
			{
				return OfficeLegendPosition.Bottom;
			}
			else if(chartLegendPosition == ChartLegendPosition.Right)
			{
				return OfficeLegendPosition.Right;
			}
			
			return OfficeLegendPosition.Left;
		}

		public static void CheckData(Dictionary<string, int> dict)
		{
			foreach(var item in dict)
			{
				if(item.Key == null || item.Value < 0)
				{
					throw new Exception("Ошибка!");
				}
			}
		}
	}
}
