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
	public partial class NumericUpDownControl : UserControl
	{
		private int value;
		private int maxValue;
		private int minValue;

		private event EventHandler valueChanged;

		public event EventHandler ValueChanged
		{
			add { valueChanged += value; }
			remove { valueChanged -= value; }
		}

		public int MaxValue
		{
			get
			{
				return maxValue;
			}

			set
			{
				if (!isInitialized(minValue) || value >= minValue)
				{
					this.maxValue = value;
				} 
			}
		}

		public int MinValue
		{
			get
			{
				return minValue;
			}

			set
			{
				if (!isInitialized(maxValue) || value <= maxValue)
				{
					this.minValue = value;
				}
			}
		}

		public int? Value
		{
			get
			{
				if (isBounded())
				{
					if (value > minValue && value < maxValue)
					{
						return value;
					}
					else if (value < minValue || value > maxValue && value != null)
					{
						MessageBox.Show("Число не входит в диапазон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return null;
					}
				}
				else if (!isInitialized(maxValue))
				{
					if (value > minValue)
					{
						return value;
					}
					else if (value < minValue && value != null)
					{
						MessageBox.Show("Число не входит в диапазон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return null;
					}
				}
				else if (!isInitialized(minValue))
				{
					if (value < maxValue)
					{
						return value;
					}
					else if (value > maxValue && value != null)
					{
						MessageBox.Show("Число не входит в диапазон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return null;
					}
				}
				return value;
			}

			set
			{
				if(isBounded())
				{
					if (value > minValue && value < maxValue && value != null)
					{
						this.value = (int)value;
						numericUpDown.Value = (int)value;
					} 
					else
					{
						MessageBox.Show("Число не входит в диапазон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} 
				else if(!isInitialized(maxValue) && isInitialized(minValue) && value != null)
				{
					if(value > minValue)
					{
						this.value = (int)value;
						numericUpDown.Value = (int)value;
					}
					else
					{
						MessageBox.Show("Число не входит в диапазон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} 
				else if(!isInitialized(minValue) && isInitialized(maxValue) && value != null)
				{
					if (value < maxValue)
					{
						this.value = (int)value;
						numericUpDown.Value = (int)value;
					}
					else
					{
						MessageBox.Show("Число не входит в диапазон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else if(value != null)
				{
					this.value = (int)value;
					numericUpDown.Value = (int)value;
				}
			}
		}

		public NumericUpDownControl()
		{
			InitializeComponent();
			numericUpDown.ValueChanged += valueChanged;
		}

		private bool isInitialized(int value)
		{
			return (!Object.Equals(value, default(int)));
		}

		private bool isBounded()
		{
			return (isInitialized(minValue) && isInitialized(maxValue));
		}

		private void numericUpDown_ValueChanged(object sender, EventArgs e)
		{
			int? oldValue = Value;
			Value = (int?)numericUpDown.Value;
			if(Value == oldValue && Value != null)
			{
				numericUpDown.Value = (decimal)Value;
			}
		}
	}
}
