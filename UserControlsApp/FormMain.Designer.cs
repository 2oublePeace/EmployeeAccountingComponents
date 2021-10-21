
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
			this.treeViewControl = new OfficeVisualComponent.TreeViewControl();
			this.SuspendLayout();
			// 
			// treeViewControl
			// 
			this.treeViewControl.Location = new System.Drawing.Point(12, 12);
			this.treeViewControl.Name = "treeViewControl";
			this.treeViewControl.Size = new System.Drawing.Size(206, 170);
			this.treeViewControl.TabIndex = 0;
			this.treeViewControl.Click += new System.EventHandler(this.button1_Click);
			this.treeViewControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewControl_MouseClick);
			this.treeViewControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewControl_MouseDoubleClick);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.treeViewControl);
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.ResumeLayout(false);

		}

		#endregion

		private OfficeVisualComponent.TreeViewControl treeViewControl;
	}
}

