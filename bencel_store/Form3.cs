using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace bencel_store
{
    public partial class Form3 : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        public Form3()
        {
            InitializeComponent();

        }
        private void Form3_Load(object sender, EventArgs e)
        {
           

            userbox.Text = global.username;
            numquan.Visible = false;
            change_quanbtn.Visible = false;

            




        }

        private void total_itemsbox_TextChanged(object sender, EventArgs e)
        {
           




        }

        private void total_amountbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("There is nothing to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            if (total_itemsbox.Text == string.Empty)
            {
                MessageBox.Show("There is nothing to clear!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show("Are you sure you want to clear all?", "Clear All", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ToRefresh();
            }
        }

        public void ToRefresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            total_itemsbox.Text = "";
            total_amountbox.Text = "";
            numquan.Value = 0;
            numquan.Visible = false;
            change_quanbtn.Visible = false;
            cashbox.Text = "";
            changebox.Text = "";
        }

     

        private void userbox_TextChanged(object sender, EventArgs e)
        {
           
        }
  
        private void To_computebtn_Click(object sender, EventArgs e)
        {
            if (total_itemsbox.Text == string.Empty)
            {
                MessageBox.Show("Please Enter first the products to be purchase!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cashbox.Text == "")
            {
                MessageBox.Show("Please input customer payment!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                int cash2 = Convert.ToInt32(cashbox.Text);
                int amount2 = Convert.ToInt32(total_amountbox.Text);
                if (cash2 < amount2)
                {

                    MessageBox.Show("Insufficient amount! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                else if(amount2>=200)
                {
                    if (MessageBox.Show("Is the customer a member?", "Customer Loyalty Points", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                    }
                    changebox.Text = Convert.ToString(cash2 - amount2);
                    con.Open();
                    cm = new MySqlCommand("insert into transaction(total_amount, cash_given, s_change, User) values('" + total_amountbox.Text + "','" + cashbox.Text + "','" + changebox.Text + "','" + userbox.Text + "');select @@identity;", con);
                    //cm.ExecuteNonQuery();
                    int last_insertid = int.Parse(cm.ExecuteScalar().ToString());
                    con.Close();


                    con.Open();
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        cm = new MySqlCommand("insert into transdetails(transaction_id, Product_name, quantity_sold, Price) values(@d1,@d2,@d3,@d4)", con);
                        cm.Parameters.AddWithValue("d1", last_insertid);
                        cm.Parameters.AddWithValue("d2", item.Cells["prod_namecolumn"].Value);
                        cm.Parameters.AddWithValue("d3", item.Cells["quantity_column"].Value);
                        cm.Parameters.AddWithValue("d4", item.Cells["price_column"].Value);
                        cm.ExecuteNonQuery();
                    }
                    con.Close();

                    con.Open();
                    foreach (DataGridViewRow items in dataGridView1.Rows)
                    {
                        cm = new MySqlCommand("update products set Stocks=Stocks-@a1 where product_id=@a2", con);
                        cm.Parameters.AddWithValue("a1", items.Cells["quantity_column"].Value);
                        cm.Parameters.AddWithValue("a2", items.Cells["prodid_column"].Value);
                        cm.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("Transaction has been successfully saved.", "Transaction Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToRefresh();

                }
                else
                {
                    changebox.Text = Convert.ToString(cash2 - amount2);
                    con.Open();
                    cm = new MySqlCommand("insert into transaction(total_amount, cash_given, s_change, User) values('" + total_amountbox.Text + "','" + cashbox.Text + "','" + changebox.Text + "','" + userbox.Text + "');select @@identity;", con);
                    //cm.ExecuteNonQuery();
                    int last_insertid = int.Parse(cm.ExecuteScalar().ToString());
                    con.Close();


                    con.Open();
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        cm = new MySqlCommand("insert into transdetails(transaction_id, Product_name, quantity_sold, Price) values(@d1,@d2,@d3,@d4)", con);
                        cm.Parameters.AddWithValue("d1", last_insertid);
                        cm.Parameters.AddWithValue("d2", item.Cells["prod_namecolumn"].Value);
                        cm.Parameters.AddWithValue("d3", item.Cells["quantity_column"].Value);
                        cm.Parameters.AddWithValue("d4", item.Cells["price_column"].Value);
                        cm.ExecuteNonQuery();
                    }
                    con.Close();

                    con.Open();
                    foreach (DataGridViewRow items in dataGridView1.Rows)
                    {
                        cm = new MySqlCommand("update products set Stocks=Stocks-@a1 where product_id=@a2", con);
                        cm.Parameters.AddWithValue("a1", items.Cells["quantity_column"].Value);
                        cm.Parameters.AddWithValue("a2", items.Cells["prodid_column"].Value);
                        cm.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("Transaction has been successfully saved.", "Transaction Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToRefresh();
                }
            }

        }

        private void userbox_Enter(object sender, EventArgs e)
        {
            userbox.Enabled = false;
            userbox.Enabled = true;
        }

        private void total_itemsbox_Enter(object sender, EventArgs e)
        {
            total_itemsbox.Enabled = false;
            total_itemsbox.Enabled = true;
        }

        private void total_amountbox_Enter(object sender, EventArgs e)
        {
            total_amountbox.Enabled = false;
            total_amountbox.Enabled = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            addItem productlist = new addItem(this);
            productlist.ShowDialog();

           // addItem productlist = new addItem(this);
           // {
           //     Dock = DockStyle.Bottom,
           //     TopLevel = false
          //  };

           // productlist.ShowDialog();
        }

        private void change_quanbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string p_id = Convert.ToString(selectedRow.Cells["prodid_column"].Value);
                con.Close();
                con.Open();
                cm = new MySqlCommand("select Stocks from products where product_id = '" + p_id + "'", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    int qr = Convert.ToInt32(dr["Stocks"]);
                    if (numquan.Value > qr)
                    {
                        MessageBox.Show("Quantity should not exceed the product's stocks! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (numquan.Value == 0)
                    {
                        MessageBox.Show("Warning: Please add quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        selectedRow.Cells["quantity_column"].Value = numquan.Value;
                        total_itemsbox.Text = dataGridView1.Rows.Count.ToString();
                        int ftotal = 0;
                        int fftotal = 0;
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            string col1 = dr.Cells["price_column"].Value.ToString();
                            string col2 = dr.Cells["quantity_column"].Value.ToString();
                            int price = Convert.ToInt32(col1);
                            int quant = Convert.ToInt32(col2);
                            ftotal = price * quant;
                            fftotal += ftotal;

                        }
                        total_amountbox.Text = Convert.ToString(fftotal);
                    }
                }


                dr.Close();
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                numquan.Visible = true;
                change_quanbtn.Visible = true;
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int quantity = Convert.ToInt32(selectedRow.Cells["quantity_column"].Value);
                numquan.Value = quantity;


            }
            else if (dataGridView1.SelectedCells.Count == 0)
            {
                numquan.Visible = false;
                change_quanbtn.Visible = false;
                numquan.Value = 0;
            }

            dataGridView1.RowsAdded += Rows_added;
            dataGridView1.RowsRemoved += Rows_removed;
        }

        private void Rows_added(object sender, DataGridViewRowsAddedEventArgs e)
        {
            total_itemsbox.Text = dataGridView1.Rows.Count.ToString();
            int ftotal = 0;
            int fftotal = 0;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                string col1 = dr.Cells["price_column"].Value.ToString();
                string col2 = dr.Cells["quantity_column"].Value.ToString();
                int price = Convert.ToInt32(col1);
                int quant = Convert.ToInt32(col2);
                ftotal = price * quant;
                fftotal += ftotal;

            }
            total_amountbox.Text = Convert.ToString(fftotal);
        }

      

        private void Rows_removed(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            total_itemsbox.Text = dataGridView1.Rows.Count.ToString();
            int ftotal = 0;
            int fftotal = 0;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                string col1 = dr.Cells["price_column"].Value.ToString();
                string col2 = dr.Cells["quantity_column"].Value.ToString();
                int price = Convert.ToInt32(col1);
                int quant = Convert.ToInt32(col2);
                ftotal = price * quant;
                fftotal += ftotal;

            }
            total_amountbox.Text = Convert.ToString(fftotal);
        }

        private void cashbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void changebox_Enter(object sender, EventArgs e)
        {
            changebox.Enabled = false;
            changebox.Enabled = true;
        }

        private void numquan_ValueChanged(object sender, EventArgs e)
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

        private void cashbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sale = Convert.ToInt32(total_amountbox.Text);
                int cash = Convert.ToInt32(cashbox.Text);
                int change = cash - sale;
                changebox.Text = change.ToString("#,##0");

            }
            catch
            {
                changebox.Text = " ";
            }
        }

        private void cashbox_Enter(object sender, EventArgs e)
        {
            try
            {
                if (total_itemsbox.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter first the products to be purchase!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            catch
            {

            }
        }
    }
}
