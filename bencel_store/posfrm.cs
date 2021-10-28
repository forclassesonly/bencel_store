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
    public partial class posfrm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        public posfrm()
        {
            InitializeComponent();
            
        }

        private void posfrm_Load(object sender, EventArgs e)
        {
            userbox.Text = global.username;
            textBox1.Focus();
           


        }
        public void ToRefresh()
        {
            
            dataGridView1.Refresh();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            itembox.Text = "";
            amountbox.Text = "";
            //numquan.Value = 0;
           // numquan.Visible = false;
           // chquanbtn.Visible = false;
            cashbox.Text = "";
            changebox.Text = "";
            custid.Text = "";
            fnamebox.Text = "";
            mnamebox.Text = "";
            lnamebox.Text = "";
            loyaltybox.Text = "";
            usedpoints.Text = "";
            cloyalbox.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           try
           {
                con.Open();
                da = new MySqlDataAdapter("select product_id, Product_name, Price from products where product_id like'" + textBox1.Text + "%'", con);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //additembtn.PerformClick();
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string id = Convert.ToString(selectedRow.Cells["product_id"].Value);
                string name = Convert.ToString(selectedRow.Cells["Product_name"].Value);
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (name == dataGridView2.Rows[i].Cells["pname_col"].Value.ToString())
                        {
                            int a = Convert.ToInt32(dataGridView2.Rows[i].Cells["quan_col"].Value);
                            int b = a + 1;
                            dataGridView2.Rows[i].Cells["quan_col"].Value = b;
                            textBox1.Clear();
                            LoadTotal();
                            return;
                            
                        }
                        
                    }
                    dataGridView2.Rows.Add(id, name, price, 1);
                    dataGridView2.ClearSelection();
                    textBox1.Clear();

                }
            }

        }

        private void additembtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {

                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string id = Convert.ToString(selectedRow.Cells["product_id"].Value);
                string name = Convert.ToString(selectedRow.Cells["Product_name"].Value);
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (name == dataGridView2.Rows[i].Cells["pname_col"].Value.ToString())
                    {
                        int a = Convert.ToInt32(dataGridView2.Rows[i].Cells["quan_col"].Value);
                        int b = a + 1;
                        dataGridView2.Rows[i].Cells["quan_col"].Value = b;
                        textBox1.Clear();
                        LoadTotal();
                        return;

                    }


                }
                dataGridView2.Rows.Add(id, name, price, 1);
                dataGridView2.ClearSelection();
                textBox1.Clear();
            }
        }

        private void additembtn_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void amountbox_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colchange = dataGridView2.Columns[e.ColumnIndex].Name;
                if (colchange == "chbtn")
                {
                    changeqtyfrm changefrm = new changeqtyfrm(this);
                    changefrm.ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
               // numquan.Visible = true;
              //  chquanbtn.Visible = true;
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                int quantity = Convert.ToInt32(selectedRow.Cells["quan_col"].Value);
             //   numquan.Value = quantity;


            }
            else if (dataGridView2.SelectedCells.Count == 0)
            {
              //  numquan.Visible = false;
              //  chquanbtn.Visible = false;
              //  numquan.Value = 0;
            }
            dataGridView2.RowsAdded += dataGridView2_RowsAdded;
            dataGridView2.RowsRemoved += dataGridView2_RowsRemoved;
        }

        public void LoadTotal()
        {
            decimal ftotal = 0;
            decimal fftotal = 0;
            int q = 0;
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                string col1 = dr.Cells["price_col"].Value.ToString();
                string col2 = dr.Cells["quan_col"].Value.ToString();
                decimal price = Convert.ToDecimal(col1);
                int quant = Convert.ToInt32(col2);
                q += quant;
                ftotal = price * quant;
                fftotal += ftotal;

            }
            amountbox.Text = Convert.ToString(fftotal);
            itembox.Text = Convert.ToString(q);
            decimal totalamount = Convert.ToDecimal(amountbox.Text);
            loyaltybox.Text = Convert.ToString(totalamount / 200);
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LoadTotal();
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LoadTotal();
        }

        

        private void cashbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal sale = Convert.ToDecimal(amountbox.Text);
                decimal cash = Convert.ToDecimal(cashbox.Text);
                decimal change = cash - sale;
                changebox.Text = change.ToString("#,##0");

            }
            catch
            {
                changebox.Text = " ";
            }
        }

        

        private void cashbtn_Click(object sender, EventArgs e)
        {
            if (itembox.Text == string.Empty)
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
                decimal cash2 = Convert.ToDecimal(cashbox.Text);
                decimal amount2 = Convert.ToDecimal(amountbox.Text);
                if (cash2 < amount2)
                {

                    MessageBox.Show("Insufficient amount! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                else if (custid.Text == "")
                {
                    if (MessageBox.Show("Is the customer a member?", "Customer Loyalty Points", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        custid.Focus();
                        MessageBox.Show("Please scan customer qr code.", "Transaction Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        changebox.Text = Convert.ToString(cash2 - amount2);
                        con.Open();
                        cm = new MySqlCommand("insert into transaction(total_amount, cash_given, s_change, User) values('" + amountbox.Text + "','" + cashbox.Text + "','" + changebox.Text + "','" + userbox.Text + "');select @@identity;", con);
                        //cm.ExecuteNonQuery();
                        int last_insertid = int.Parse(cm.ExecuteScalar().ToString());
                        con.Close();


                        con.Open();
                        foreach (DataGridViewRow item in dataGridView2.Rows)
                        {
                            cm = new MySqlCommand("insert into transdetails(transaction_id, Product_name, quantity_sold, Price) values(@d1,@d2,@d3,@d4)", con);
                            cm.Parameters.AddWithValue("d1", last_insertid);
                            cm.Parameters.AddWithValue("d2", item.Cells["pname_col"].Value);
                            cm.Parameters.AddWithValue("d3", item.Cells["quan_col"].Value);
                            cm.Parameters.AddWithValue("d4", item.Cells["price_col"].Value);
                            cm.ExecuteNonQuery();
                        }
                        con.Close();

                        con.Open();
                        foreach (DataGridViewRow items in dataGridView2.Rows)
                        {
                            cm = new MySqlCommand("update products set Stocks=Stocks-@a1 where product_id=@a2", con);
                            cm.Parameters.AddWithValue("a1", items.Cells["quan_col"].Value);
                            cm.Parameters.AddWithValue("a2", items.Cells["pid_col"].Value);
                            cm.ExecuteNonQuery();
                        }
                        con.Close();
                        MessageBox.Show("Transaction has been successfully saved.", "Transaction Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ToRefresh();
                    }

                }


                else if (custid.Text != "" && fnamebox.Text != "")
                {

                    con.Open();
                    cm = new MySqlCommand("update customer set points=points+@a1 where customer_id=@a2", con);
                    cm.Parameters.AddWithValue("a1", loyaltybox.Text);
                    cm.Parameters.AddWithValue("a2", custid.Text);
                    cm.ExecuteNonQuery();

                    con.Close();

                    changebox.Text = Convert.ToString(cash2 - amount2);
                    con.Open();
                    cm = new MySqlCommand("insert into transaction(Customer_id, total_amount, form_of_payment, cash_given, redeemed_points, s_change, User) values('" + custid.Text + "', '" + amountbox.Text + "', '" + "Cash" + "','" + cashbox.Text + "', '" + usedpoints.Text + "','" + changebox.Text + "','" + userbox.Text + "');select @@identity;", con);
                    //cm.ExecuteNonQuery();
                    int last_insertid = int.Parse(cm.ExecuteScalar().ToString());
                    con.Close();


                    con.Open();
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        cm = new MySqlCommand("insert into transdetails(transaction_id, Product_name, quantity_sold, Price) values(@d1,@d2,@d3,@d4)", con);
                        cm.Parameters.AddWithValue("d1", last_insertid);
                        cm.Parameters.AddWithValue("d2", item.Cells["pname_col"].Value);
                        cm.Parameters.AddWithValue("d3", item.Cells["quan_col"].Value);
                        cm.Parameters.AddWithValue("d4", item.Cells["price_col"].Value);
                        cm.ExecuteNonQuery();
                    }
                    con.Close();

                    con.Open();
                    foreach (DataGridViewRow items in dataGridView2.Rows)
                    {
                        cm = new MySqlCommand("update products set Stocks=Stocks-@a1 where product_id=@a2", con);
                        cm.Parameters.AddWithValue("a1", items.Cells["quan_col"].Value);
                        cm.Parameters.AddWithValue("a2", items.Cells["pid_col"].Value);
                        cm.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("Transaction has been successfully saved.", "Transaction Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToRefresh();


                }
                else
                {
                    MessageBox.Show("Customer's id is not valid.", "Transaction Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("There is nothing to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.RemoveAt(item.Index);
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            if (itembox.Text == string.Empty)
            {
                MessageBox.Show("There is nothing to clear!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show("Are you sure you want to clear all?", "Clear All", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ToRefresh();
            }
        }

        private void amountbox_Enter(object sender, EventArgs e)
        {
            amountbox.Enabled = false;
            amountbox.Enabled = true;
        }

        private void cashbox_Enter(object sender, EventArgs e)
        {
            try
            {
                if (itembox.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter first the products to be purchase!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            catch
            {

            }
        }

        private void cashbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (itembox.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter first the products to be purchase!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            catch
            {

            }
        }

        private void custid_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (custid.Text != "")
                {
                    con.Open();
                    cm = new MySqlCommand("select fname, mname, lname, points from customer where customer_id like'" + custid.Text + "'", con);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        fnamebox.Text = dr.GetValue(0).ToString();
                        mnamebox.Text = dr.GetValue(1).ToString();
                        lnamebox.Text = dr.GetValue(2).ToString();
                        cloyalbox.Text = dr.GetValue(3).ToString();

                    }

                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loyaltybtn_Click(object sender, EventArgs e)
        {
            int cloyalty = Convert.ToInt32(cloyalbox.Text);
            int amount2 = Convert.ToInt32(amountbox.Text);
            int totalamount = amount2 - cloyalty;
            if (itembox.Text == string.Empty)
            {
                MessageBox.Show("Please Enter first the products to be purchase!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if(custid.Text == "" && fnamebox.Text == "")
            {
                custid.Focus();
                MessageBox.Show("Please scan customer qr code.", "Transaction Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cloyalty == 0)
            {

                MessageBox.Show("Insufficient points!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else if(MessageBox.Show("Redeem Loyalty Points?", "Redeem Loyalty Points", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(totalamount<=0)
                {
                    
                    con.Open();
                    cm = new MySqlCommand("update customer set points=points-@c1 where customer_id=@c2", con);
                    cm.Parameters.AddWithValue("c1", amount2);
                    cm.Parameters.AddWithValue("c2", custid.Text);
                    cm.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cm = new MySqlCommand("insert into transaction(Customer_id, total_amount, Form_of_Payment, Redeemed_Points, User) values ('" + custid.Text + "','" + amountbox.Text + "','"+"Loyalty Points"+ "','" + amountbox.Text + "','" + userbox.Text + "');select @@identity;", con);
                    //cm.ExecuteNonQuery();
                    int last_insertid = int.Parse(cm.ExecuteScalar().ToString());
                    con.Close();


                    con.Open();
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        cm = new MySqlCommand("insert into transdetails(transaction_id, Product_name, quantity_sold, Price) values(@d1,@d2,@d3,@d4)", con);
                        cm.Parameters.AddWithValue("d1", last_insertid);
                        cm.Parameters.AddWithValue("d2", item.Cells["pname_col"].Value);
                        cm.Parameters.AddWithValue("d3", item.Cells["quan_col"].Value);
                        cm.Parameters.AddWithValue("d4", item.Cells["price_col"].Value);
                        cm.ExecuteNonQuery();
                    }
                    con.Close();

                    con.Open();
                    foreach (DataGridViewRow items in dataGridView2.Rows)
                    {
                        cm = new MySqlCommand("update products set Stocks=Stocks-@a1 where product_id=@a2", con);
                        cm.Parameters.AddWithValue("a1", items.Cells["quan_col"].Value);
                        cm.Parameters.AddWithValue("a2", items.Cells["pid_col"].Value);
                        cm.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("Transaction has been successfully saved.", "Transaction Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToRefresh();

                }
                else 
                {
                    amountbox.Text = Convert.ToString(totalamount);
                    con.Open();
                    cm = new MySqlCommand("update customer set points=points-@c1 where customer_id=@c2", con);
                    cm.Parameters.AddWithValue("c1", cloyalty);
                    cm.Parameters.AddWithValue("c2", custid.Text);
                    cm.ExecuteNonQuery();
                    con.Close();
       
                    MessageBox.Show("Please add cash", "Redeeming Loyalty Points", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usedpoints.Text = cloyalbox.Text;
                    cashbox.Focus();
                    return;
                }

            }



        }

        private void fnamebox_Enter(object sender, EventArgs e)
        {
            fnamebox.Enabled = false;
            fnamebox.Enabled = true;
        }

        private void lnamebox_Enter(object sender, EventArgs e)
        {
            lnamebox.Enabled = false;
            lnamebox.Enabled = true;
        }

        private void cloyalbox_Enter(object sender, EventArgs e)
        {
            cloyalbox.Enabled = false;
            cloyalbox.Enabled = true;
        }

        private void usedpoints_Enter(object sender, EventArgs e)
        {
            usedpoints.Enabled = false;
            usedpoints.Enabled = true;
        }

        private void loyaltybox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
