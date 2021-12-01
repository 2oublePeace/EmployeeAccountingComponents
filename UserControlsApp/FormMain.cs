using OfficeNonVisualComponents;
using OfficeNonVisualComponents.HelperModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UserControlsApp
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();

			Delivery delivery = new Delivery();
			treeViewControl.SetHierarchy(new List<string> { "fullName", "deliveryOffice", "officePhoneNumber" });
			treeViewControl.Add(
				new Delivery { 
					fullName = "Emiryan Vladimir", 
					deliveryOffice = "Delivery",
					officePhoneNumber = "89175563364"
				},
				""
			);

			treeViewControl.Add(
				new Delivery
				{
					fullName = "Emiryan Vladimir",
					deliveryOffice = "Delivery",
					officePhoneNumber = "89175567864"
				},
				""
			);

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
			Console.WriteLine(treeViewControl.GetSelectedValue<Delivery>());
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
				Dictionary<int, int> rowHeightnfo = new Dictionary<int, int>();
				rowHeightnfo.Add(2, 2000);

				//Заголовки и присущие строкам данные
				Queue<KeyValuePair<string, string>> firstColumn = new Queue<KeyValuePair<string, string>>();
				firstColumn.Enqueue(new KeyValuePair<string, string>("Доставка", null));

				Queue<KeyValuePair<string, string>> secondColumn = new Queue<KeyValuePair<string, string>>();
				secondColumn.Enqueue(new KeyValuePair<string, string>("ФИО", "fullName"));
				secondColumn.Enqueue(new KeyValuePair<string, string>("Офис", "deliveryOffice"));
				secondColumn.Enqueue(new KeyValuePair<string, string>("Номер", "officePhoneNumber"));

				Queue<KeyValuePair<string, string>>[] headers = new Queue<KeyValuePair<string, string>>[2];
				headers[0] = firstColumn;
				headers[1] = secondColumn;

				//Данные для таблицы
				List<Delivery> deliveries = new List<Delivery>();
				deliveries.Add(new Delivery { fullName = "Emiryan Vladimir", deliveryOffice = "Delivery", officePhoneNumber = "89175563364" });
				deliveries.Add(new Delivery { fullName = "Frolov Rafael", deliveryOffice = "DHL", officePhoneNumber = "89174333162" });
				deliveries.Add(new Delivery { fullName = "Ivan Ivanov", deliveryOffice = "Express", officePhoneNumber = "89605326654" });
			


				if (dialog.ShowDialog() == DialogResult.OK)
				{
					WordTableComponent.CreateDoc(dialog.FileName, "Таблица", rowMergeInfo, rowHeightnfo, headers, deliveries);

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
