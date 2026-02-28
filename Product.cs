using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Shop_Management
{
	public partial class Product : Form
	{
		string connString = ConfigurationManager.ConnectionStrings["MIDTERM"].ConnectionString;
		int selectedProductID = 0;
		private TextBox textBox1, textBox2, textBox3;
		private ComboBox comboBox1;
		private Button button1, button2, button3;
		private DataGridView dataGridView1;

		public Product()
		{
			InitializeComponent();
			LoadProducts();
			LoadSuppliers();
		}

		void InitializeComponent()
		{
			this.textBox1 = new TextBox();
			this.textBox2 = new TextBox();
			this.textBox3 = new TextBox();
			this.comboBox1 = new ComboBox();
			this.button1 = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			this.dataGridView1 = new DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();

			Label label1 = new Label { Text = "Product Name:", Location = new System.Drawing.Point(50, 50), AutoSize = true };
			Label label2 = new Label { Text = "Quantity:", Location = new System.Drawing.Point(50, 90), AutoSize = true };
			Label label3 = new Label { Text = "Price:", Location = new System.Drawing.Point(50, 130), AutoSize = true };
			Label label4 = new Label { Text = "Supplier:", Location = new System.Drawing.Point(50, 170), AutoSize = true };

			this.textBox1.Location = new System.Drawing.Point(150, 50);
			this.textBox1.Size = new System.Drawing.Size(150, 27);
			this.textBox2.Location = new System.Drawing.Point(150, 90);
			this.textBox2.Size = new System.Drawing.Size(150, 27);
			this.textBox3.Location = new System.Drawing.Point(150, 130);
			this.textBox3.Size = new System.Drawing.Size(150, 27);
			this.comboBox1.Location = new System.Drawing.Point(150, 170);
			this.comboBox1.Size = new System.Drawing.Size(150, 28);

			this.button1.Location = new System.Drawing.Point(350, 50);
			this.button1.Size = new System.Drawing.Size(100, 30);
			this.button1.Text = "Add";
			this.button1.Click += button1_Click;

			this.button2.Location = new System.Drawing.Point(350, 90);
			this.button2.Size = new System.Drawing.Size(100, 30);
			this.button2.Text = "Update";
			this.button2.Click += button2_Click;

			this.button3.Location = new System.Drawing.Point(350, 130);
			this.button3.Size = new System.Drawing.Size(100, 30);
			this.button3.Text = "Delete";
			this.button3.Click += button3_Click;

			this.dataGridView1.Location = new System.Drawing.Point(50, 220);
			this.dataGridView1.Size = new System.Drawing.Size(700, 200);
			this.dataGridView1.CellClick += dataGridView1_CellClick;

			Button btnBack = new Button { Text = "Back to Dashboard", Location = new System.Drawing.Point(600, 10), Size = new System.Drawing.Size(150, 30) };
			btnBack.Click += (s, e) => { new Dashboard().Show(); this.Close(); };

			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(label1);
			this.Controls.Add(label2);
			this.Controls.Add(label3);
			this.Controls.Add(label4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(btnBack);
			this.Name = "Product";
			this.Text = "Product Management";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		void LoadProducts()
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlDataAdapter da = new SqlDataAdapter("SELECT p.prodID, p.prodName, s.supplierName, p.quantity, p.price, p.registeredDate FROM Product p LEFT JOIN Supplier s ON p.supplier = s.supplierID", conn);
				DataTable dt = new DataTable();
				da.Fill(dt);
				dataGridView1.DataSource = dt;
			}
		}

		void LoadSuppliers()
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("SELECT supplierID, supplierName FROM Supplier", conn);
				SqlDataReader reader = cmd.ExecuteReader();
				comboBox1.Items.Clear();
				while (reader.Read())
					comboBox1.Items.Add(new { ID = reader["supplierID"], Name = reader["supplierName"].ToString() });
				comboBox1.DisplayMember = "Name";
				comboBox1.ValueMember = "ID";
			}
		}

		void button1_Click(object? sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) || comboBox1.SelectedItem == null || !int.TryParse(textBox2.Text, out int qty) || !decimal.TryParse(textBox3.Text, out decimal price))
			{
				MessageBox.Show("All fields required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("INSERT INTO Product (prodName, supplier, quantity, price, registeredDate) VALUES (@name, @supplier, @qty, @price, @date)", conn);
				cmd.Parameters.AddWithValue("@name", textBox1.Text);
				cmd.Parameters.AddWithValue("@supplier", ((dynamic)comboBox1.SelectedItem).ID);
				cmd.Parameters.AddWithValue("@qty", qty);
				cmd.Parameters.AddWithValue("@price", price);
				cmd.Parameters.AddWithValue("@date", DateTime.Now);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Product added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadProducts();
			}
		}

		void button2_Click(object? sender, EventArgs e)
		{
			if (selectedProductID == 0) { MessageBox.Show("Select a product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("UPDATE Product SET prodName=@name, supplier=@supplier, quantity=@qty, price=@price WHERE prodID=@id", conn);
				cmd.Parameters.AddWithValue("@name", textBox1.Text);
				cmd.Parameters.AddWithValue("@supplier", ((dynamic)comboBox1.SelectedItem).ID);
				cmd.Parameters.AddWithValue("@qty", int.Parse(textBox2.Text));
				cmd.Parameters.AddWithValue("@price", decimal.Parse(textBox3.Text));
				cmd.Parameters.AddWithValue("@id", selectedProductID);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Product updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadProducts();
			}
		}

		void button3_Click(object? sender, EventArgs e)
		{
			if (selectedProductID == 0) { MessageBox.Show("Select a product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE prodID=@id", conn);
				cmd.Parameters.AddWithValue("@id", selectedProductID);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Product deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadProducts();
			}
		}

		void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
				selectedProductID = Convert.ToInt32(row.Cells["prodID"].Value);
				textBox1.Text = row.Cells["prodName"].Value?.ToString() ?? "";
				textBox2.Text = row.Cells["quantity"].Value?.ToString() ?? "";
				textBox3.Text = row.Cells["price"].Value?.ToString() ?? "";
			}
		}
	}
}
