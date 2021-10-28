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
    public partial class AddProduct : Form

    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");
        MySqlCommand cm;
        MySqlDataReader dr;
        Form5 f1;
        public AddProduct(Form5 frm5)
        {
            InitializeComponent();
            f1 = frm5;
        }



        private void AddProduct_Load(object sender, EventArgs e)
        {
            userbox2.Text = global.username;
            typebox.Visible = false;
            expirydate.MinDate = DateTime.Now.Date;
            typebox.Text = global.type;
            if (typebox.Text == "Admin")
            {
                comboBox1.Enabled = true;
                itemcostbox.Enabled = true;
                interestbox.Enabled = true;


            }
            else
            {
                comboBox1.Enabled = false;
                itemcostbox.Enabled = false;
                interestbox.Enabled = false;
            }
            // anothercatbox.Visible = false;
            // closecat.Visible = false;
            //  closecat.Enabled = false;

        }

        public void Clear()
        {
            proid.Clear();
            pnamebox.Clear();
            quantibox.Clear();
            pricebox2.Clear();
            itemcostbox.Clear();
            interestbox.Clear();
            comboBox1.SelectedIndex = -1;
            expirydate.Value = DateTime.Now;
         //   categorycmbo.Text = string.Empty;
            minstkbox.Clear();
            maxstkbox.Clear();
            savebtn.Enabled = true;
            updatebtn.Enabled = false;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {

                String edate = expirydate.Value.ToString("yyyy-MM-dd", null);
                if (string.IsNullOrEmpty(proid.Text))
                {
                    MessageBox.Show("Warning: Product ID is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    proid.Focus();

                }
                else if (string.IsNullOrEmpty(pnamebox.Text))
                {
                    MessageBox.Show("Warning: Product Name is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pnamebox.Focus();

                }
                else if (string.IsNullOrEmpty(quantibox.Text))
                {
                    //quantibox.Text = "0";
                    MessageBox.Show("Warning: Stock field is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    quantibox.Focus();

                }
                else if (string.IsNullOrEmpty(itemcostbox.Text))
                {
                    //itemcostbox.Text = "0";
                    MessageBox.Show("Warning: Item Cost is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    itemcostbox.Focus();
                }
                else if (string.IsNullOrEmpty(pricebox2.Text))
                {
                    //pricebox2.Text = "0";
                    MessageBox.Show("Warning: Price field is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pricebox2.Focus();
                }

                else if (string.IsNullOrEmpty(maxstkbox.Text))
                {
                    //maxstkbox = "0";
                    MessageBox.Show("Warning: Maximum Stock is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maxstkbox.Focus();
                }
                else if (string.IsNullOrEmpty(minstkbox.Text))
                {
                    //minstkbox = "0";
                    MessageBox.Show("Warning: Minimum stock is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    minstkbox.Focus();
                }
                else
                {
                    int q = Convert.ToInt32(quantibox.Text);
                    int p = Convert.ToInt32(pricebox2.Text);
                    int i = Convert.ToInt32(itemcostbox.Text);
                    int maxstck = Convert.ToInt32(maxstkbox.Text);
                    int minstck = Convert.ToInt32(minstkbox.Text);
                    if (q == 0)
                    {
                        MessageBox.Show("Warning: Please Add Value on Stocks!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        quantibox.Focus();
                        return;
                    }
                    else if (i == 0)
                    {
                        MessageBox.Show("Warning: Please Add Value on Item Cost!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        itemcostbox.Focus();
                        return;
                    }
                    else if (comboBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Warning: Please Choose a Unit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBox1.Focus();
                        return;
                    }
                    else if (minstck == 0)
                    {
                        MessageBox.Show("Warning: Please Add Value on Maximum Stock!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        minstkbox.Focus();
                        return;
                    }
                    else if (maxstck == 0)
                    {
                        MessageBox.Show("Warning: Please Add Value on Maximum Stock!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        maxstkbox.Focus();
                        return;
                    }
                   
                   
                    else
                    {
                        con.Open();
                        cm = new MySqlCommand("insert into products(product_id, Product_name, Stocks, Price, Item_Cost, Unit, Expiration, Min_stock, Max_stock, updated_by) values('" + proid.Text + "','" + pnamebox.Text + "','" + quantibox.Text + "','" + pricebox2.Text + "','" + itemcostbox.Text + "','" + comboBox1.Text + "','" + edate + "','" + minstkbox.Text + "','" + maxstkbox.Text + "','" + userbox2.Text + "')", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record has been successfully saved.", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        f1.LoadRecords();
                        //f1.colorstock();
                    }

                }

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Warning:" + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

  

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                String edate = expirydate.Value.ToString("yyyy-MM-dd", null);
                quantibox.Enabled = false;
                if (string.IsNullOrEmpty(pnamebox.Text))
                {
                    MessageBox.Show("Warning: Product Name is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pnamebox.Focus();

                }
                else if (string.IsNullOrEmpty(quantibox.Text))
                {
                    //quantibox.Text = "0";
                    MessageBox.Show("Warning: Stock field is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    quantibox.Focus();

                }
                else if (string.IsNullOrEmpty(itemcostbox.Text))
                {
                    //itemcostbox.Text = "0";
                    MessageBox.Show("Warning: Item Cost is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    itemcostbox.Focus();
                }
                else if (string.IsNullOrEmpty(pricebox2.Text))
                {
                    //pricebox2.Text = "0";
                    MessageBox.Show("Warning: Price field is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pricebox2.Focus();
                }

                else if (string.IsNullOrEmpty(maxstkbox.Text))
                {
                    //maxstkbox = "0";
                    MessageBox.Show("Warning: Maximum Stock is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maxstkbox.Focus();
                }
                else if (string.IsNullOrEmpty(minstkbox.Text))
                {
                    //minstkbox = "0";
                    MessageBox.Show("Warning: Minimum stock is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    minstkbox.Focus();
                }
                else
                {
                    decimal q = Convert.ToInt32(quantibox.Text);
                    int p = Convert.ToInt32(pricebox2.Text);
                    int i = Convert.ToInt32(itemcostbox.Text);
                    int maxstck = Convert.ToInt32(maxstkbox.Text);
                    int minstck = Convert.ToInt32(minstkbox.Text);
                    if (q == 0)
                    {
                        MessageBox.Show("Warning: Please Add Value on Stocks!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        quantibox.Focus();
                        return;
                    }
                    else if (i == 0)
                    {
                        MessageBox.Show("Warning: Please Add Value on Item Cost!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        itemcostbox.Focus();
                        return;
                    }
                    else if (comboBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Warning: Please Choose a Unit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBox1.Focus();
                        return;
                    }
                    else if (minstck == 0)
                    {
                        MessageBox.Show("Warning: Please Add Value on Maximum Stock!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        minstkbox.Focus();
                        return;
                    }
                    else if (maxstck == 0)
                    {
                        MessageBox.Show("Warning: Please Add Value on Maximum Stock!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        maxstkbox.Focus();
                        return;
                    }
                  
                    else
                    {
                        con.Open();
                        cm = new MySqlCommand("update products set Product_name= '" + pnamebox.Text + "',Stocks = '" + quantibox.Text + "',Price = '" + pricebox2.Text + "',Item_Cost = '" + itemcostbox.Text + "',Unit = '" + comboBox1.Text + "', Expiration = '" + edate + "', Min_stock = '" + minstkbox.Text + "', Max_stock = '" + maxstkbox.Text + "', updated_by = '" + userbox2.Text + "' where product_id like '" + proid.Text + "'", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record has been successfully Updated.", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        f1.LoadRecords();
                       // f1.colorstock();
                        this.Dispose();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        private void itemcostbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void quantibox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pricebox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void minstkbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maxstkbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void itemcostbox_TextChanged(object sender, EventArgs e)
        {
            itemcostbox.Text = itemcostbox.Text.TrimStart('0');
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void interestbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                interestbox.Text = interestbox.Text.TrimStart('0');
                int stock = Convert.ToInt32(quantibox.Text);
                int item = Convert.ToInt32(itemcostbox.Text);
                int interest = Convert.ToInt32(interestbox.Text);
                double price = ((item / stock) + interest);

                pricebox2.Text = Math.Round(price, 0, MidpointRounding.AwayFromZero).ToString("#,##0");
                

            }
            catch
            {
                pricebox2.Text = " ";
            }
        }

        private void interestbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected == "Add Another Unit")
            {
                unitfrm ufrm = new unitfrm(this);
                ufrm.ShowDialog();
                comboBox1.SelectedIndex = -1;
            }
        }

        private void pricebox2_Enter(object sender, EventArgs e)
        {
            pricebox2.Enabled = false;
            pricebox2.Enabled = true;
        }

        private void quantibox_TextChanged(object sender, EventArgs e)
        {
            quantibox.Text = quantibox.Text.TrimStart('0');
        }

        private void minstkbox_TextChanged(object sender, EventArgs e)
        {
            minstkbox.Text = minstkbox.Text.TrimStart('0');
        }

        private void maxstkbox_TextChanged(object sender, EventArgs e)
        {
            maxstkbox.Text = maxstkbox.Text.TrimStart('0');
        }

        private void pricebox2_TextChanged(object sender, EventArgs e)
        {
            pricebox2.Text = pricebox2.Text.TrimStart('0');
        }

        private void pnamebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void proid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
