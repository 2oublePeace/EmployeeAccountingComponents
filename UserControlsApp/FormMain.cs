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
			treeViewControl.Add(new Delivery { 
				fullName = "Emiryan Vladimir", 
				deliveryOffice = "Delivery",
				officePhoneNumber = "89175563364"
			});
			treeViewControl.Add(new Delivery
			{
				fullName = "Emiryan Vladimir",
				deliveryOffice = "Delivery",
				officePhoneNumber = "89175567864"
			});

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Console.WriteLine(treeViewControl.SelectedBranch);
		}

		private void treeViewControl_MouseClick(object sender, MouseEventArgs e)
		{
			Console.WriteLine(treeViewControl.SelectedBranch);
		}

		private void treeViewControl_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Console.WriteLine(treeViewControl.SelectedBranch);
		}
	}
}
