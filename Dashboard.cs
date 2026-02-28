using System;
using System.Windows.Forms;

namespace Shop_Management
{
	public partial class Dashboard : Form
	{
		public Dashboard()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.button1 = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			this.label1 = new Label();
			this.SuspendLayout();
			
			// label1
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(250, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(300, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "Shop Management System";
			
			// button1
			this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.button1.Location = new System.Drawing.Point(300, 130);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 50);
			this.button1.TabIndex = 1;
			this.button1.Text = "Supplier Management";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			
			// button2
			this.button2.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.button2.Location = new System.Drawing.Point(300, 200);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(200, 50);
			this.button2.TabIndex = 2;
			this.button2.Text = "Product Management";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			
			// button3
			this.button3.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.button3.Location = new System.Drawing.Point(300, 270);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(200, 50);
			this.button3.TabIndex = 3;
			this.button3.Text = "Sales Management";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new EventHandler(this.button3_Click);
			
			// Dashboard
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Dashboard";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Dashboard";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private Button button1;
		private Button button2;
		private Button button3;
		private Label label1;

		void button1_Click(object? sender, EventArgs e)
		{
			new supplier().Show();
			this.Hide();
		}

		void button2_Click(object? sender, EventArgs e)
		{
			new Product().Show();
			this.Hide();
		}

		void button3_Click(object? sender, EventArgs e)
		{
			new sales().Show();
			this.Hide();
		}
	}
}
