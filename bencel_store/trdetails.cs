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
    public partial class trdetails : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;

        tranrecords tr;
        public trdetails(tranrecords tr2)
        {
            InitializeComponent();
            tr = tr2;
        }

        private void trdetails_Load(object sender, EventArgs e)
        {
 
            ToLoadDetails();
            userbox.Text = global.username;
            userbox.Visible = false;
        }
        public void ToLoadDetails()
        {
            try
            {

                int selectedrowindex = tr.dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tr.dataGridView1.Rows[selectedrowindex];
                int tr_id = Convert.ToInt32(selectedRow.Cells["Transaction_id"].Value);
                con.Open();
                cm = new MySqlCommand("select transdetails_id, Product_name, quantity_sold, Price from transdetails where transaction_id = '"+tr_id+"'", con);
                da = new MySqlDataAdapter();
                dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedCells.Count > 0)
                {
                    numquan.Visible = true;
                    int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                    int quantity = Convert.ToInt32(selectedRow.Cells["quantity_sold"].Value);
                    numquan.Value = quantity;
                }
                else
                {
                    numquan.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex1 = tr.dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow1 = tr.dataGridView1.Rows[selectedrowindex1];
                int tr_id = Convert.ToInt32(selectedRow1.Cells["Transaction_id"].Value);

                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                int quan = Convert.ToInt32(selectedRow.Cells["quantity_sold"].Value);
                int td_id = Convert.ToInt32(selectedRow.Cells["transdetails_id"].Value);
                string name = Convert.ToString(selectedRow.Cells["Product_name"].Value);
                int price = Convert.ToInt32(selectedRow.Cells["Price"].Value);
                int num = Convert.ToInt32(numquan.Value);
                
                    int fquan = quan - num;
                    int fprice = price * num;
                    if(fquan < 0)
                    {
                        MessageBox.Show("Warning: Invalid Value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (num == 0)
                    {
                        MessageBox.Show("Warning: Invalid Value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (fquan == 0)
                    {
                    if (MessageBox.Show("Are you sure you want to return this product?", "Return Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cm = new MySqlCommand("delete from transdetails where transdetails_id like'" + td_id + "'", con);
                        cm.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        cm = new MySqlCommand("update products set Stocks=Stocks+@b1 where Product_name=@b2", con);
                        cm.Parameters.AddWithValue("b1", num);
                        cm.Parameters.AddWithValue("b2", name);
                        cm.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        cm = new MySqlCommand("update transaction set Total_Amount=Total_Amount-@h1 where Transaction_id=@h2", con);
                        cm.Parameters.AddWithValue("h1", fprice);
                        cm.Parameters.AddWithValue("h2", tr_id);
                        cm.ExecuteNonQuery();
                        con.Close();
                        remark2frm rmfrm2 = new remark2frm(this);
                        rmfrm2.ShowDialog();
                        selectedRow.Cells["quantity_sold"].Value = fquan;
                        MessageBox.Show("Product has been successfully returned.", "Return Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tr.ToLoadtrans();
                        //ToLoadDetails();
                        this.Dispose();
                    }
                    }
                
                    else
                    {
                    if (MessageBox.Show("Are you sure you want to return this product?", "Return Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cm = new MySqlCommand("update transdetails set quantity_sold=@h1 where Product_name=@h2", con);
                        cm.Parameters.AddWithValue("h1", fquan);
                        cm.Parameters.AddWithValue("h2", name);
                        cm.ExecuteNonQuery();
                        con.Close();


                        con.Open();
                        cm = new MySqlCommand("update products set Stocks=Stocks+@b1 where Product_name=@b2", con);
                        cm.Parameters.AddWithValue("b1", num);
                        cm.Parameters.AddWithValue("b2", name);
                        cm.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        cm = new MySqlCommand("update transaction set Total_Amount=Total_Amount-@h1 where Transaction_id=@h2", con);
                        cm.Parameters.AddWithValue("h1", fprice);
                        cm.Parameters.AddWithValue("h2", tr_id);
                        cm.ExecuteNonQuery();
                        con.Close();


                        remark2frm rmfrm2 = new remark2frm(this);
                        rmfrm2.ShowDialog();
                        selectedRow.Cells["quantity_sold"].Value = fquan;
                        MessageBox.Show("Product has been successfully returned.", "Return Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tr.ToLoadtrans();
                        //ToLoadDetails();
                        this.Dispose();
                    }
                    
                    }



                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numquan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
