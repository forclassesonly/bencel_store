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
    public partial class addItem : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;

        Form3 f4;
        public addItem(Form3 frm3)
        {
            InitializeComponent();
            //LoadRecords2();
            f4 = frm3;
        }

        private void addItem_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select product_id, Product_name, Stocks, Price from products order by Product_name ASC", con);
                da = new MySqlDataAdapter();
                dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
            //object[] rowData = new object[row.Cells.Count];
            //for (int i = 0; i < rowData.Length; ++i)
            //{
            //rowData[i] = row.Cells[i].Value;

            //}
            //f4.dataGridView1.Rows.Add(rowData);
            //}

            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string id = Convert.ToString(selectedRow.Cells["product_id"].Value);
            string name = Convert.ToString(selectedRow.Cells["Product_name"].Value);
            int price = Convert.ToInt32(selectedRow.Cells["Price"].Value);
            int stock= Convert.ToInt32(selectedRow.Cells["Stocks"].Value);
            int count = Convert.ToInt32(quannumeric.Value);

            
                if (dataGridView1.SelectedCells.Count > 0)
                {
                if(count == 0)
                {
                    MessageBox.Show("Warning: Please add quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(count > stock)
                {
                    MessageBox.Show("Warning: Quantity should not exceed stocks!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
                else
                {
                    for (int i = 0; i < f4.dataGridView1.Rows.Count; i++)
                    {
                        if (name == f4.dataGridView1.Rows[i].Cells["prod_namecolumn"].Value.ToString())
                        {
                            int a = Convert.ToInt32(f4.dataGridView1.Rows[i].Cells["quantity_column"].Value);
                            int b = a + count;
                            if (b > stock)
                            {
                                MessageBox.Show("Warning: Quantity should not exceed stocks!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {

                                f4.dataGridView1.Rows[i].Cells["quantity_column"].Value = b;
                                return;
                            }
                        }
                   }
                
                    f4.dataGridView1.Rows.Add(id, name, price, count);
                    f4.dataGridView1.ClearSelection();
                }
                
                
            }
            quannumeric.Value = 0;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Product_name LIKE '{0}%'", searchbox.Text);

            //con.Open();
            //da = new MySqlDataAdapter("select product_id, Product_name, Quantity, Price from products where Product_name like'" + searchbox.Text + "%'", con);
            //dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //con.Close();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void quannumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
