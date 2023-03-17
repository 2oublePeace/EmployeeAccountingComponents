using OfficeNonVisualComponents;
using OfficeNonVisualComponents.HelperModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UserControlsApp
{
	public partial class FormMain : Form
	{
		private readonly List<Employee> _deliveries; 
		public FormMain()
		{
			InitializeComponent();

			_deliveries = new List<Employee>()
			{
				new Employee
				{
					FullName = "Зайцев Андрей",
					Skill = "Адаптируемость",
					PhoneNumber = "89962847821"
				},
				new Employee
				{
					FullName = "Петров Иван",
					Skill = "Лидерство",
					PhoneNumber = "89175563364"
				},
				new Employee
				{
					FullName = "Дьяченко Павел",
					Skill = "Адаптируемость",
					PhoneNumber = "89175563364"
				},
				new Employee
				{
					FullName = "Иванов Петр",
					Skill = "Коммуникативность",
					PhoneNumber = "89175563364"
				},
				new Employee
				{
					FullName = "Кротов Егор",
					Skill = "Адаптируемость",
					PhoneNumber = "89175563364"
				}
			};
			
			treeViewControl.SetHierarchy(new List<string> { "FullName", "Skill", "PhoneNumber" });
			foreach (var delivery in _deliveries)
			{
				treeViewControl.Add(delivery, "");
			}

			checkedListBoxControl.Items.Add("string1");
			checkedListBoxControl.Items.Add("string2");
			checkedListBoxControl.Items.Add("string3");

			numericControl.MaxValue = 10;
		    numericControl.MinValue = 1;
			numericControl.Value = 5;
		}

		private void buttonGetSelected_Click(object sender, EventArgs e)
		{
			Console.WriteLine(checkedListBoxControl.SelectedItem);
		}

		private void buttonSetSelected_Click(object sender, EventArgs e)
		{
			checkedListBoxControl.SelectedItem = "string3";
		}

		private void buttonGetSelectedValue_Click(object sender, EventArgs e)
		{
			Console.WriteLine(treeViewControl.GetSelectedValue<Employee>());
		}

		private void buttonGetSelectedIndex_Click(object sender, EventArgs e)
		{
			Console.WriteLine(treeViewControl.SelectedIndex);
		}

		private void buttonSetSelectedValue_Click(object sender, EventArgs e)
		{
			treeViewControl.SelectedIndex = 1;
		}

		private void buttonWordImage_Click(object sender, EventArgs e)
		{
			string[] fileNames = null;

			using (var dialog = new OpenFileDialog() { Filter = "Файлы изображений|*.bmp;*.png;*.jpg", Multiselect = true })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					fileNames = dialog.FileNames;
				}
			}

			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{

				if (dialog.ShowDialog() == DialogResult.OK && fileNames != null)
				{
					WordImageComponent.CreateDoc(dialog.FileName, "Изображения", fileNames);

					MessageBox.Show("Создание прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void buttonWordTable_Click(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{
				//Слияние ячеек
				Dictionary<(int, int), int> rowMergeInfo = new Dictionary<(int, int), int>();
				rowMergeInfo.Add((0, 0), 2);

				//Высота строк
				Dictionary<int, int> rowHeightInfo = new Dictionary<int, int>();
				rowHeightInfo.Add(0, 1000);
				rowHeightInfo.Add(1, 1000);
				rowHeightInfo.Add(2, 1000);

				//Заголовки и присущие строкам данные
				List<Queue<KeyValuePair<string, string>>> headers = new List<Queue<KeyValuePair<string, string>>>();
				headers.Add(
					new Queue<KeyValuePair<string, string>>(
						new List<KeyValuePair<string, string>>
						{
							new KeyValuePair<string, string>("Доставка", "Deliveries")
						}
					)
				);
				headers.Add(
					new Queue<KeyValuePair<string, string>>(
						new List<KeyValuePair<string, string>>
						{
							new KeyValuePair<string, string>("ФИО", "FullName"),
							new KeyValuePair<string, string>("Навык", "Skill"),
							new KeyValuePair<string, string>("Номер", "PhoneNumber")
						}
					)
				);
				
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					WordTableComponent.CreateDoc(dialog.FileName, "Сотрудники", rowMergeInfo, headers, _deliveries, rowHeightInfo);
					MessageBox.Show("Создание прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void buttonAddChart_Click(object sender, EventArgs e)
		{
			Dictionary<string, int> chartData = new Dictionary<string, int>();
			chartData.Add("Адаптируемость", 32);
			chartData.Add("Коммуникативность", 22);
			chartData.Add("Лидерство", 44);

			ChartDataInfo chartInfo = new ChartDataInfo() { Series = "Навыки", Data = chartData };
			
			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					WordDiagramComponent.CreateDoc(dialog.FileName, "Количество сотрудников по навыкам", "Документ с диаграммой", chartInfo, ChartLegendPosition.Bottom);

					MessageBox.Show("Создание прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
