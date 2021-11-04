
namespace UserControlsApp
{
	partial class FormMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonGetSelectedValue = new System.Windows.Forms.Button();
			this.buttonGetSelectedIndex = new System.Windows.Forms.Button();
			this.buttonGetSelected = new System.Windows.Forms.Button();
			this.buttonSetSelected = new System.Windows.Forms.Button();
			this.buttonSetSelectedValue = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.checkedListBoxControl = new OfficeVisualComponent.CheckedListBoxControl();
			this.numericControl = new OfficeVisualComponent.NumericUpDownControl();
			this.treeViewControl = new OfficeVisualComponent.TreeViewControl();
			this.SuspendLayout();
			// 
			// buttonGetSelectedValue
			// 
			this.buttonGetSelectedValue.Location = new System.Drawing.Point(148, 197);
			this.buttonGetSelectedValue.Name = "buttonGetSelectedValue";
			this.buttonGetSelectedValue.Size = new System.Drawing.Size(206, 23);
			this.buttonGetSelectedValue.TabIndex = 3;
			this.buttonGetSelectedValue.Text = "Получить значение";
			this.buttonGetSelectedValue.UseVisualStyleBackColor = true;
			this.buttonGetSelectedValue.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonGetSelectedIndex
			// 
			this.buttonGetSelectedIndex.Location = new System.Drawing.Point(148, 226);
			this.buttonGetSelectedIndex.Name = "buttonGetSelectedIndex";
			this.buttonGetSelectedIndex.Size = new System.Drawing.Size(206, 23);
			this.buttonGetSelectedIndex.TabIndex = 4;
			this.buttonGetSelectedIndex.Text = "Получить индекс";
			this.buttonGetSelectedIndex.UseVisualStyleBackColor = true;
			this.buttonGetSelectedIndex.Click += new System.EventHandler(this.button2_Click);
			// 
			// buttonGetSelected
			// 
			this.buttonGetSelected.Location = new System.Drawing.Point(12, 121);
			this.buttonGetSelected.Name = "buttonGetSelected";
			this.buttonGetSelected.Size = new System.Drawing.Size(120, 23);
			this.buttonGetSelected.TabIndex = 6;
			this.buttonGetSelected.Text = "Получить";
			this.buttonGetSelected.UseVisualStyleBackColor = true;
			this.buttonGetSelected.Click += new System.EventHandler(this.button3_Click);
			// 
			// buttonSetSelected
			// 
			this.buttonSetSelected.Location = new System.Drawing.Point(12, 150);
			this.buttonSetSelected.Name = "buttonSetSelected";
			this.buttonSetSelected.Size = new System.Drawing.Size(120, 23);
			this.buttonSetSelected.TabIndex = 7;
			this.buttonSetSelected.Text = "Установить";
			this.buttonSetSelected.UseVisualStyleBackColor = true;
			this.buttonSetSelected.Click += new System.EventHandler(this.button4_Click);
			// 
			// buttonSetSelectedValue
			// 
			this.buttonSetSelectedValue.Location = new System.Drawing.Point(148, 256);
			this.buttonSetSelectedValue.Name = "buttonSetSelectedValue";
			this.buttonSetSelectedValue.Size = new System.Drawing.Size(206, 23);
			this.buttonSetSelectedValue.TabIndex = 8;
			this.buttonSetSelectedValue.Text = "Установить индекс";
			this.buttonSetSelectedValue.UseVisualStyleBackColor = true;
			this.buttonSetSelectedValue.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Checked List Box";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 240);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Numeric Up Down";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(145, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Tree View";
			// 
			// checkedListBoxControl
			// 
			this.checkedListBoxControl.Location = new System.Drawing.Point(12, 21);
			this.checkedListBoxControl.Name = "checkedListBoxControl";
			this.checkedListBoxControl.SelectedItem = "";
			this.checkedListBoxControl.Size = new System.Drawing.Size(120, 94);
			this.checkedListBoxControl.TabIndex = 5;
			// 
			// numericControl
			// 
			this.numericControl.Location = new System.Drawing.Point(12, 256);
			this.numericControl.MaxValue = 4;
			this.numericControl.MinValue = 0;
			this.numericControl.Name = "numericControl";
			this.numericControl.Size = new System.Drawing.Size(120, 20);
			this.numericControl.TabIndex = 2;
			this.numericControl.Value = null;
			// 
			// treeViewControl
			// 
			this.treeViewControl.Location = new System.Drawing.Point(148, 21);
			this.treeViewControl.Name = "treeViewControl";
			this.treeViewControl.SelectedIndex = 0;
			this.treeViewControl.Size = new System.Drawing.Size(206, 170);
			this.treeViewControl.TabIndex = 0;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 287);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonSetSelectedValue);
			this.Controls.Add(this.buttonSetSelected);
			this.Controls.Add(this.buttonGetSelected);
			this.Controls.Add(this.checkedListBoxControl);
			this.Controls.Add(this.buttonGetSelectedIndex);
			this.Controls.Add(this.buttonGetSelectedValue);
			this.Controls.Add(this.numericControl);
			this.Controls.Add(this.treeViewControl);
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OfficeVisualComponent.TreeViewControl treeViewControl;
		private OfficeVisualComponent.NumericUpDownControl numericControl;
		private System.Windows.Forms.Button buttonGetSelectedValue;
		private System.Windows.Forms.Button buttonGetSelectedIndex;
		private OfficeVisualComponent.CheckedListBoxControl checkedListBoxControl;
		private System.Windows.Forms.Button buttonGetSelected;
		private System.Windows.Forms.Button buttonSetSelected;
		private System.Windows.Forms.Button buttonSetSelectedValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

