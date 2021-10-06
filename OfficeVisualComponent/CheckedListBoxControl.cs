using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeVisualComponent
{
	public partial class CheckedListBoxControl : UserControl
	{
		public object Items {
			get
			{
				return checkedListBox.Items;
			}
			set 
			{
				checkedListBox.DataSource = value;
			} 
		} 

		public CheckedListBoxControl()
		{
			InitializeComponent();
			
		}
	}
}
