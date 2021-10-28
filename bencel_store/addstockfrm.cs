using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace bencel_store
{
    public partial class addstockfrm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        Form5 f2;
        public addstockfrm(Form5 frm5)
        {
            InitializeComponent();
            f2 = frm5;
        }

        private void addstockfrm_Load(object sender, EventArgs e)
        {
            LoadanotherRecords();
            userbox.Text = global.username;
            userbox.Visible = false;
        }
        public void LoadanotherRecords()
        {
            con.Open();
            cm = new MySqlCommand("select product_id, Product_name, Stocks, Min_stock, Max_stock from products", con);
            da = new MySqlDataAdapter();
            dt = new DataTable();
            da.SelectCommand = cm;
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void addstockbtn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            int id = Convert.ToInt32(selectedRow.Cells["product_id"].Value);
            int stock = Convert.ToInt32(selectedRow.Cells["Stocks"].Value);
            int max = Convert.ToInt32(selectedRow.Cells["Max_stock"].Value);
            int count = Convert.ToInt32(quan_numdown.Value);
            int sagot = count + stock;
            if (quan_numdown.Value == 0)//hala may mali
            {
                MessageBox.Show("Warning: Invalid Value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (sagot > max)
            {
                MessageBox.Show("Warning: On hand stocks should not exceed the maximum stock of the product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                     
                        con.Open();
                        cm = new MySqlCommand("update products set Stocks=@q1, updated_by = '" + userbox.Text + "' where product_id = '" + id + "'", con);
                        cm.Parameters.AddWithValue("q1", sagot);
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Stocks has been successfully Updated.", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadanotherRecords();
                        f2.LoadRecords();
                        
                        
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning:" + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void Clear()
        {

           

        }


       

        private void decreasebtn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            int id = Convert.ToInt32(selectedRow.Cells["product_id"].Value);
            int stock = Convert.ToInt32(selectedRow.Cells["Stocks"].Value);
            int min = Convert.ToInt32(selectedRow.Cells["Min_stock"].Value);
            int count = Convert.ToInt32(quan_numdown.Value);
            int sagot2 = stock - count;
            if (quan_numdown.Value == 0)
            {
                MessageBox.Show("Warning: Invalid Value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (sagot2 < 0)
            {
                MessageBox.Show("Warning: Invalid Value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
               
                try
                {
                    if (MessageBox.Show("Are you sure you want to reduce this product's stock?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dataGridView1.SelectedCells.Count > 0)
                        {
                            con.Open();
                            cm = new MySqlCommand("update products set Stocks= @q1, updated_by = '" + userbox.Text + "' where product_id = '" + id + "'", con);
                            cm.Parameters.AddWithValue("q1", sagot2);
                            cm.ExecuteNonQuery();
                            con.Close();


                            remarkfrm rmfrm = new remarkfrm(this);
                            rmfrm.ShowDialog();
                            MessageBox.Show("Stocks has been successfully Updated.", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            LoadanotherRecords();
                            f2.LoadRecords();

                            //f2.colorstock();
                            //this.Dispose();

                        }
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning:" + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Product_name LIKE '{0}%'", searchbox.Text);
        }

        private void userbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quan_numdown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
