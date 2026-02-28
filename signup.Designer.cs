namespace Shop_Management
{
	partial class signup
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
			linkLabel1 = new LinkLabel();
			button1 = new Button();
			textBox2 = new TextBox();
			textBox1 = new TextBox();
			label4 = new Label();
			label2 = new Label();
			label1 = new Label();
			comboBox1 = new ComboBox();
			label3 = new Label();
			SuspendLayout();
			// 
			// linkLabel1
			// 
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new Point(295, 319);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(214, 20);
			linkLabel1.TabIndex = 36;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "already have an account? login";
			// 
			// button1
			// 
			button1.Location = new Point(352, 254);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 35;
			button1.Text = "SIGN UP";
			button1.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(393, 140);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(125, 27);
			textBox2.TabIndex = 34;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(393, 98);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(125, 27);
			textBox1.TabIndex = 33;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(330, 27);
			label4.Name = "label4";
			label4.Size = new Size(104, 20);
			label4.TabIndex = 32;
			label4.Text = "SIGNUP FORM";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(249, 140);
			label2.Name = "label2";
			label2.Size = new Size(87, 20);
			label2.TabIndex = 31;
			label2.Text = "PASSWORD";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(249, 98);
			label1.Name = "label1";
			label1.Size = new Size(86, 20);
			label1.TabIndex = 30;
			label1.Text = "USERNAME";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(397, 196);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(151, 28);
			comboBox1.TabIndex = 37;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(249, 196);
			label3.Name = "label3";
			label3.Size = new Size(44, 20);
			label3.TabIndex = 38;
			label3.Text = "ROLE";
			// 
			// signup
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(label3);
			Controls.Add(comboBox1);
			Controls.Add(linkLabel1);
			Controls.Add(button1);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(label4);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "signup";
			Text = "signup";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private LinkLabel linkLabel1;
		private Button button1;
		private TextBox textBox2;
		private TextBox textBox1;
		private Label label4;
		private Label label2;
		private Label label1;
		private ComboBox comboBox1;
		private Label label3;
	}
}