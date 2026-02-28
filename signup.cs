using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Shop_Management
{
	public partial class signup : Form
	{
		string connString = ConfigurationManager.ConnectionStrings["MIDTERM"].ConnectionString;

		public signup()
		{
			InitializeComponent();
			comboBox1.Items.AddRange(new string[] { "Admin", "User" });
			button1.Click += button1_Click;
			linkLabel1.Click += linkLabel1_Click;
			textBox2.PasswordChar = '*';
		}

		void linkLabel1_Click(object? sender, EventArgs e)
		{
			new login().Show();
			this.Hide();
		}

		void button1_Click(object? sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || comboBox1.SelectedItem == null)
			{
				MessageBox.Show("All fields required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U') CREATE TABLE Users (userID INT PRIMARY KEY IDENTITY(1,1), username NVARCHAR(50), password NVARCHAR(50), role NVARCHAR(50))", conn);
					cmd.ExecuteNonQuery();
					cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE username=@user", conn);
					cmd.Parameters.AddWithValue("@user", textBox1.Text.Trim());
					if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
					{
						MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					cmd = new SqlCommand("INSERT INTO Users (username, password, role) VALUES (@user, @pass, @role)", conn);
					cmd.Parameters.AddWithValue("@user", textBox1.Text.Trim());
					cmd.Parameters.AddWithValue("@pass", textBox2.Text);
					cmd.Parameters.AddWithValue("@role", comboBox1.Text);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Hide();
					new login().Show();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
