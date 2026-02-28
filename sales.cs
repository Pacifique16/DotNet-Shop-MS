using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Shop_Management
{
	public partial class sales : Form
	{
		string connString = ConfigurationManager.ConnectionStrings["MIDTERM"].ConnectionString;
		int selectedSaleID = 0;

		public sales()
		{
			InitializeComponent();
			button2.Visible = false;
			LoadSales();
			LoadProducts();
			button1.Click += button1_Click;
			button3.Click += button3_Click;
			dataGridView1.CellClick += dataGridView1_CellClick;
			Button btnBack = new Button { Text = "Back to Dashboard", Location = new System.Drawing.Point(600, 10), Size = new System.Drawing.Size(150, 30) };
			btnBack.Click += (s, e) => { new Dashboard().Show(); this.Close(); };
			this.Controls.Add(btnBack);
		}

		void LoadSales()
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlDataAdapter da = new SqlDataAdapter("SELECT s.salID, p.prodName, s.saleDate FROM Sales s LEFT JOIN Product p ON s.product = p.prodID", conn);
				DataTable dt = new DataTable();
				da.Fill(dt);
				dataGridView1.DataSource = dt;
			}
		}

		void LoadProducts()
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("SELECT prodID, prodName FROM Product", conn);
				SqlDataReader reader = cmd.ExecuteReader();
				comboBox1.Items.Clear();
				while (reader.Read())
					comboBox1.Items.Add(new { ID = reader["prodID"], Name = reader["prodName"].ToString() });
				comboBox1.DisplayMember = "Name";
				comboBox1.ValueMember = "ID";
			}
		}

		void button1_Click(object? sender, EventArgs e)
		{
			if (comboBox1.SelectedItem == null)
			{
				MessageBox.Show("Select a product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (!int.TryParse(textBox2.Text, out int saleQty) || saleQty <= 0)
			{
				MessageBox.Show("Enter valid quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				int productID = ((dynamic)comboBox1.SelectedItem).ID;
				SqlCommand cmd = new SqlCommand("SELECT quantity FROM Product WHERE prodID=@id", conn);
				cmd.Parameters.AddWithValue("@id", productID);
				int currentQty = Convert.ToInt32(cmd.ExecuteScalar());
				if (currentQty < saleQty)
				{
					MessageBox.Show($"Insufficient stock! Only {currentQty} items available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				cmd = new SqlCommand("INSERT INTO Sales (product, saleDate) VALUES (@product, @date)", conn);
				cmd.Parameters.AddWithValue("@product", productID);
				cmd.Parameters.AddWithValue("@date", DateTime.Now);
				cmd.ExecuteNonQuery();
				cmd = new SqlCommand("UPDATE Product SET quantity = quantity - @qty WHERE prodID=@id", conn);
				cmd.Parameters.AddWithValue("@qty", saleQty);
				cmd.Parameters.AddWithValue("@id", productID);
				cmd.ExecuteNonQuery();
				MessageBox.Show($"Sale recorded! {saleQty} item(s) sold.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadSales();
				textBox2.Clear();
			}
		}

		void button3_Click(object? sender, EventArgs e)
		{
			if (selectedSaleID == 0) { MessageBox.Show("Select a sale!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("DELETE FROM Sales WHERE salID=@id", conn);
				cmd.Parameters.AddWithValue("@id", selectedSaleID);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Sale deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadSales();
			}
		}

		void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				selectedSaleID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["salID"].Value);
			}
		}
	}
}
