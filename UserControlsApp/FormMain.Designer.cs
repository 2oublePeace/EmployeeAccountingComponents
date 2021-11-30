
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
			this.components = new System.ComponentModel.Container();
			this.buttonGetSelectedValue = new System.Windows.Forms.Button();
			this.buttonGetSelectedIndex = new System.Windows.Forms.Button();
			this.buttonGetSelected = new System.Windows.Forms.Button();
			this.buttonSetSelected = new System.Windows.Forms.Button();
			this.buttonSetSelectedValue = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBoxVisualComponents = new System.Windows.Forms.GroupBox();
			this.checkedListBoxControl = new OfficeVisualComponent.CheckedListBoxControl();
			this.treeViewControl = new OfficeVisualComponent.TreeViewControl();
			this.numericControl = new OfficeVisualComponent.NumericUpDownControl();
			this.groupBoxNonVisualComponents = new System.Windows.Forms.GroupBox();
			this.buttonWordImage = new System.Windows.Forms.Button();
			this.wordImageComponent = new OfficeNonVisualComponents.WordImageComponent(this.components);
			this.wordTableComponent = new OfficeNonVisualComponents.WordTableComponent(this.components);
			this.buttonWordTable = new System.Windows.Forms.Button();
			this.groupBoxVisualComponents.SuspendLayout();
			this.groupBoxNonVisualComponents.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonGetSelectedValue
			// 
			this.buttonGetSelectedValue.Location = new System.Drawing.Point(142, 216);
			this.buttonGetSelectedValue.Name = "buttonGetSelectedValue";
			this.buttonGetSelectedValue.Size = new System.Drawing.Size(206, 23);
			this.buttonGetSelectedValue.TabIndex = 3;
			this.buttonGetSelectedValue.Text = "Получить значение";
			this.buttonGetSelectedValue.UseVisualStyleBackColor = true;
			this.buttonGetSelectedValue.Click += new System.EventHandler(this.buttonGetSelectedValue_Click);
			// 
			// buttonGetSelectedIndex
			// 
			this.buttonGetSelectedIndex.Location = new System.Drawing.Point(142, 245);
			this.buttonGetSelectedIndex.Name = "buttonGetSelectedIndex";
			this.buttonGetSelectedIndex.Size = new System.Drawing.Size(206, 23);
			this.buttonGetSelectedIndex.TabIndex = 4;
			this.buttonGetSelectedIndex.Text = "Получить индекс";
			this.buttonGetSelectedIndex.UseVisualStyleBackColor = true;
			this.buttonGetSelectedIndex.Click += new System.EventHandler(this.buttonGetSelectedIndex_Click);
			// 
			// buttonGetSelected
			// 
			this.buttonGetSelected.Location = new System.Drawing.Point(6, 140);
			this.buttonGetSelected.Name = "buttonGetSelected";
			this.buttonGetSelected.Size = new System.Drawing.Size(120, 23);
			this.buttonGetSelected.TabIndex = 6;
			this.buttonGetSelected.Text = "Получить";
			this.buttonGetSelected.UseVisualStyleBackColor = true;
			this.buttonGetSelected.Click += new System.EventHandler(this.buttonGetSelected_Click);
			// 
			// buttonSetSelected
			// 
			this.buttonSetSelected.Location = new System.Drawing.Point(6, 169);
			this.buttonSetSelected.Name = "buttonSetSelected";
			this.buttonSetSelected.Size = new System.Drawing.Size(120, 23);
			this.buttonSetSelected.TabIndex = 7;
			this.buttonSetSelected.Text = "Установить";
			this.buttonSetSelected.UseVisualStyleBackColor = true;
			this.buttonSetSelected.Click += new System.EventHandler(this.buttonSetSelected_Click);
			// 
			// buttonSetSelectedValue
			// 
			this.buttonSetSelectedValue.Location = new System.Drawing.Point(142, 275);
			this.buttonSetSelectedValue.Name = "buttonSetSelectedValue";
			this.buttonSetSelectedValue.Size = new System.Drawing.Size(206, 23);
			this.buttonSetSelectedValue.TabIndex = 8;
			this.buttonSetSelectedValue.Text = "Установить индекс";
			this.buttonSetSelectedValue.UseVisualStyleBackColor = true;
			this.buttonSetSelectedValue.Click += new System.EventHandler(this.buttonSetSelectedValue_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Checked List Box";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 259);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Numeric Up Down";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(139, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Tree View";
			// 
			// groupBoxVisualComponents
			// 
			this.groupBoxVisualComponents.Controls.Add(this.checkedListBoxControl);
			this.groupBoxVisualComponents.Controls.Add(this.label3);
			this.groupBoxVisualComponents.Controls.Add(this.treeViewControl);
			this.groupBoxVisualComponents.Controls.Add(this.label2);
			this.groupBoxVisualComponents.Controls.Add(this.numericControl);
			this.groupBoxVisualComponents.Controls.Add(this.label1);
			this.groupBoxVisualComponents.Controls.Add(this.buttonGetSelectedValue);
			this.groupBoxVisualComponents.Controls.Add(this.buttonSetSelectedValue);
			this.groupBoxVisualComponents.Controls.Add(this.buttonGetSelectedIndex);
			this.groupBoxVisualComponents.Controls.Add(this.buttonSetSelected);
			this.groupBoxVisualComponents.Controls.Add(this.buttonGetSelected);
			this.groupBoxVisualComponents.Location = new System.Drawing.Point(12, 12);
			this.groupBoxVisualComponents.Name = "groupBoxVisualComponents";
			this.groupBoxVisualComponents.Size = new System.Drawing.Size(354, 306);
			this.groupBoxVisualComponents.TabIndex = 12;
			this.groupBoxVisualComponents.TabStop = false;
			this.groupBoxVisualComponents.Text = "Визуальные компоненты";
			// 
			// checkedListBoxControl
			// 
			this.checkedListBoxControl.Location = new System.Drawing.Point(6, 40);
			this.checkedListBoxControl.Name = "checkedListBoxControl";
			this.checkedListBoxControl.SelectedItem = "";
			this.checkedListBoxControl.Size = new System.Drawing.Size(120, 94);
			this.checkedListBoxControl.TabIndex = 5;
			// 
			// treeViewControl
			// 
			this.treeViewControl.Location = new System.Drawing.Point(142, 40);
			this.treeViewControl.Name = "treeViewControl";
			this.treeViewControl.SelectedIndex = 0;
			this.treeViewControl.Size = new System.Drawing.Size(206, 170);
			this.treeViewControl.TabIndex = 0;
			// 
			// numericControl
			// 
			this.numericControl.Location = new System.Drawing.Point(6, 275);
			this.numericControl.MaxValue = 4;
			this.numericControl.MinValue = 0;
			this.numericControl.Name = "numericControl";
			this.numericControl.Size = new System.Drawing.Size(120, 20);
			this.numericControl.TabIndex = 2;
			this.numericControl.Value = null;
			// 
			// groupBoxNonVisualComponents
			// 
			this.groupBoxNonVisualComponents.Controls.Add(this.buttonWordTable);
			this.groupBoxNonVisualComponents.Controls.Add(this.buttonWordImage);
			this.groupBoxNonVisualComponents.Location = new System.Drawing.Point(372, 12);
			this.groupBoxNonVisualComponents.Name = "groupBoxNonVisualComponents";
			this.groupBoxNonVisualComponents.Size = new System.Drawing.Size(186, 306);
			this.groupBoxNonVisualComponents.TabIndex = 13;
			this.groupBoxNonVisualComponents.TabStop = false;
			this.groupBoxNonVisualComponents.Text = "Невизуальные компоненты";
			// 
			// buttonWordImage
			// 
			this.buttonWordImage.Location = new System.Drawing.Point(7, 20);
			this.buttonWordImage.Name = "buttonWordImage";
			this.buttonWordImage.Size = new System.Drawing.Size(173, 23);
			this.buttonWordImage.TabIndex = 0;
			this.buttonWordImage.Text = "Добавить изображения";
			this.buttonWordImage.UseVisualStyleBackColor = true;
			this.buttonWordImage.Click += new System.EventHandler(this.buttonWordImage_Click);
			// 
			// buttonWordTable
			// 
			this.buttonWordTable.Location = new System.Drawing.Point(7, 50);
			this.buttonWordTable.Name = "buttonWordTable";
			this.buttonWordTable.Size = new System.Drawing.Size(173, 23);
			this.buttonWordTable.TabIndex = 1;
			this.buttonWordTable.Text = "Добавить таблицу";
			this.buttonWordTable.UseVisualStyleBackColor = true;
			this.buttonWordTable.Click += new System.EventHandler(this.buttonWordTable_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 328);
			this.Controls.Add(this.groupBoxNonVisualComponents);
			this.Controls.Add(this.groupBoxVisualComponents);
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.groupBoxVisualComponents.ResumeLayout(false);
			this.groupBoxVisualComponents.PerformLayout();
			this.groupBoxNonVisualComponents.ResumeLayout(false);
			this.ResumeLayout(false);

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
		private OfficeNonVisualComponents.WordImageComponent wordImageComponent;
		private System.Windows.Forms.GroupBox groupBoxVisualComponents;
		private System.Windows.Forms.GroupBox groupBoxNonVisualComponents;
		private System.Windows.Forms.Button buttonWordImage;
		private OfficeNonVisualComponents.WordTableComponent wordTableComponent;
		private System.Windows.Forms.Button buttonWordTable;
	}
}

