using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private void button3_Click(object sender, EventArgs e)
		{
			Console.WriteLine(checkedListBoxControl.SelectedItem);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			checkedListBoxControl.SelectedItem = "string3";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Console.WriteLine(treeViewControl.GetSelectedValue<Delivery>());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Console.WriteLine(treeViewControl.SelectedIndex);
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			treeViewControl.SelectedIndex = 1;
		}
	}
}
