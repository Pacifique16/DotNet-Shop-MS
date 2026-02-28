namespace Shop_Management
{
	partial class supplier
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
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			textBox3 = new TextBox();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			dataGridView1 = new DataGridView();
			textBox4 = new TextBox();
			textBox5 = new TextBox();
			label5 = new Label();
			label6 = new Label();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(67, 54);
			label1.Name = "label1";
			label1.Size = new Size(106, 20);
			label1.TabIndex = 0;
			label1.Text = "supplier name:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(67, 103);
			label2.Name = "label2";
			label2.Size = new Size(61, 20);
			label2.TabIndex = 1;
			label2.Text = "country:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(67, 146);
			label3.Name = "label3";
			label3.Size = new Size(106, 20);
			label3.TabIndex = 2;
			label3.Text = "supplier email:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(315, 9);
			label4.Name = "label4";
			label4.Size = new Size(154, 20);
			label4.TabIndex = 3;
			label4.Text = "supplier management";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(211, 54);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(125, 27);
			textBox1.TabIndex = 4;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(211, 103);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(125, 27);
			textBox2.TabIndex = 5;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(211, 146);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(125, 27);
			textBox3.TabIndex = 6;
			// 
			// button1
			// 
			button1.Location = new Point(463, 60);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 7;
			button1.Text = "save";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new Point(463, 99);
			button2.Name = "button2";
			button2.Size = new Size(94, 29);
			button2.TabIndex = 8;
			button2.Text = "update";
			button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			button3.Location = new Point(463, 142);
			button3.Name = "button3";
			button3.Size = new Size(94, 29);
			button3.TabIndex = 9;
			button3.Text = "delete";
			button3.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(59, 258);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(696, 188);
			dataGridView1.TabIndex = 10;
			// 
			// textBox4
			// 
			textBox4.Location = new Point(211, 229);
			textBox4.Name = "textBox4";
			textBox4.Size = new Size(125, 27);
			textBox4.TabIndex = 14;
			// 
			// textBox5
			// 
			textBox5.Location = new Point(211, 186);
			textBox5.Name = "textBox5";
			textBox5.Size = new Size(125, 27);
			textBox5.TabIndex = 13;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(67, 229);
			label5.Name = "label5";
			label5.Size = new Size(66, 20);
			label5.TabIndex = 12;
			label5.Text = "quantity:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(67, 186);
			label6.Name = "label6";
			label6.Size = new Size(105, 20);
			label6.TabIndex = 11;
			label6.Text = "product name:";
			// 
			// supplier
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(textBox4);
			Controls.Add(textBox5);
			Controls.Add(label5);
			Controls.Add(label6);
			Controls.Add(dataGridView1);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(textBox3);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "supplier";
			Text = "supplier";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private TextBox textBox1;
		private TextBox textBox2;
		private TextBox textBox3;
		private Button button1;
		private Button button2;
		private Button button3;
		private DataGridView dataGridView1;
		private TextBox textBox4;
		private TextBox textBox5;
		private Label label5;
		private Label label6;
	}
}