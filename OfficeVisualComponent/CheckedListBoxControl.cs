using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace OfficeVisualComponent
{
	public partial class CheckedListBoxControl : UserControl
	{
		private event EventHandler selectedItemChanged;

		public event EventHandler SelectedItemChanged
		{
			add { selectedItemChanged += value; }
			remove { selectedItemChanged -= value; }
		}

		private ComboBox comboBox;

		public ObjectCollection Items
		{
			get
			{
				return checkedListBox.Items;
			}
		}

		public string SelectedItem
		{
			get
			{
				if (checkedListBox.SelectedItem != null)
				{
					return (string)checkedListBox.SelectedItem;
				}
				return "";
			}

			set
			{
				if (value != null)
				{
					foreach (string element in checkedListBox.Items)
					{
						if (element.Contains(value))
						{
							checkedListBox.SetItemChecked(checkedListBox.Items.IndexOf(element), true);
							break;
						}
					}
				}
			}
		}

		public void Clear()
		{
			checkedListBox.Items.Clear();
		}

		public CheckedListBoxControl()
		{
			InitializeComponent();
			checkedListBox.SelectedValueChanged += selectedItemChanged;
			comboBox = new ComboBox();
		}
	}
}
