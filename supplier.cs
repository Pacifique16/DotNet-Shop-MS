using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Shop_Management
{
	public partial class supplier : Form
	{
		string connString = ConfigurationManager.ConnectionStrings["MIDTERM"].ConnectionString;
		int selectedSupplierID = 0;

		public supplier()
		{
			InitializeComponent();
			textBox4.Visible = false;
			textBox5.Visible = false;
			label5.Visible = false;
			label6.Visible = false;
			LoadSuppliers();
			button1.Click += button1_Click;
			button2.Click += button2_Click;
			button3.Click += button3_Click;
			dataGridView1.CellClick += dataGridView1_CellClick;
			Button btnBack = new Button { Text = "Back to Dashboard", Location = new System.Drawing.Point(600, 10), Size = new System.Drawing.Size(150, 30) };
			btnBack.Click += (s, e) => { new Dashboard().Show(); this.Close(); };
			this.Controls.Add(btnBack);
		}

		void LoadSuppliers()
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Supplier", conn);
				DataTable dt = new DataTable();
				da.Fill(dt);
				dataGridView1.DataSource = dt;
			}
		}

		void button1_Click(object? sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
			{
				MessageBox.Show("All fields required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("INSERT INTO Supplier (supplierName, country, supplierEmail) VALUES (@name, @country, @email)", conn);
				cmd.Parameters.AddWithValue("@name", textBox1.Text);
				cmd.Parameters.AddWithValue("@country", textBox2.Text);
				cmd.Parameters.AddWithValue("@email", textBox3.Text);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Supplier added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadSuppliers();
			}
		}

		void button2_Click(object? sender, EventArgs e)
		{
			if (selectedSupplierID == 0) { MessageBox.Show("Select a supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("UPDATE Supplier SET supplierName=@name, country=@country, supplierEmail=@email WHERE supplierID=@id", conn);
				cmd.Parameters.AddWithValue("@name", textBox1.Text);
				cmd.Parameters.AddWithValue("@country", textBox2.Text);
				cmd.Parameters.AddWithValue("@email", textBox3.Text);
				cmd.Parameters.AddWithValue("@id", selectedSupplierID);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Supplier updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadSuppliers();
			}
		}

		void button3_Click(object? sender, EventArgs e)
		{
			if (selectedSupplierID == 0) { MessageBox.Show("Select a supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("DELETE FROM Supplier WHERE supplierID=@id", conn);
				cmd.Parameters.AddWithValue("@id", selectedSupplierID);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Supplier deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadSuppliers();
			}
		}

		void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
				selectedSupplierID = Convert.ToInt32(row.Cells["supplierID"].Value);
				textBox1.Text = row.Cells["supplierName"].Value?.ToString() ?? "";
				textBox2.Text = row.Cells["country"].Value?.ToString() ?? "";
				textBox3.Text = row.Cells["supplierEmail"].Value?.ToString() ?? "";
			}
		}
	}
}
