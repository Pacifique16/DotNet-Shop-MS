namespace Shop_Management
{
	partial class sales
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView1 = new DataGridView();
			button2 = new Button();
			button1 = new Button();
			textBox2 = new TextBox();
			label4 = new Label();
			label2 = new Label();
			label1 = new Label();
			button3 = new Button();
			comboBox1 = new ComboBox();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(52, 256);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(696, 188);
			dataGridView1.TabIndex = 21;
			// 
			// button2
			// 
			button2.Location = new Point(456, 104);
			button2.Name = "button2";
			button2.Size = new Size(94, 29);
			button2.TabIndex = 19;
			button2.Text = "update";
			button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.Location = new Point(456, 58);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 18;
			button1.Text = "record sell";
			button1.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(204, 94);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(125, 27);
			textBox2.TabIndex = 16;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(308, 7);
			label4.Name = "label4";
			label4.Size = new Size(133, 20);
			label4.TabIndex = 14;
			label4.Text = "sales management";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(60, 94);
			label2.Name = "label2";
			label2.Size = new Size(66, 20);
			label2.TabIndex = 12;
			label2.Text = "quantity:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(60, 52);
			label1.Name = "label1";
			label1.Size = new Size(105, 20);
			label1.TabIndex = 11;
			label1.Text = "product name:";
			// 
			// button3
			// 
			button3.Location = new Point(456, 149);
			button3.Name = "button3";
			button3.Size = new Size(94, 29);
			button3.TabIndex = 20;
			button3.Text = "delete";
			button3.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(204, 49);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(151, 28);
			comboBox1.TabIndex = 22;
			// 
			// sales
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(comboBox1);
			Controls.Add(dataGridView1);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(textBox2);
			Controls.Add(label4);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "sales";
			Text = "sales";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private Button button2;
		private Button button1;
		private TextBox textBox2;
		private Label label4;
		private Label label2;
		private Label label1;
		private Button button3;
		private ComboBox comboBox1;
	}
}