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
    public partial class Form5 : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        string _productid, _pname, _quantity, _price, _itemcost, _unit, _expiration, _minstock, _maxstock, _updated_by, _exp;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select * from products where Product_name like'" + txtSearch.Text + "%'", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                }
                dataGridView1.ClearSelection();
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addstockfrm stockfrm = new addstockfrm(this);
            stockfrm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if(selected == "All Products")
            {
                LoadRecords();
            }
            
            else if (selected == "Low In stock")
            {
                lowStock();
            }
            else if(selected == "Minimum level")
            {
                OnMinStock();
            }
            else if(selected == "Maximum level")
            {
                OnMaxStock();
            }

        }

        private void typebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            expirationfrm exfrm = new expirationfrm();
            exfrm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                AddProduct addfrm = new AddProduct(this);
                addfrm.savebtn.Enabled = true;
                addfrm.updatebtn.Enabled = false;
                addfrm.ShowDialog();
            }
            catch
            {

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            _productid = dataGridView1[1, i].Value.ToString();
            _pname = dataGridView1[2, i].Value.ToString();
            _quantity = dataGridView1[3, i].Value.ToString();
            _price = dataGridView1[4, i].Value.ToString();
            _itemcost = dataGridView1[5, i].Value.ToString();
            _unit = dataGridView1[6, i].Value.ToString();
            _expiration = dataGridView1[7, i].Value.ToString();
            _minstock = dataGridView1[8, i].Value.ToString();
            _maxstock = dataGridView1[9, i].Value.ToString();
            _updated_by = dataGridView1[10, i].Value.ToString();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname == "colEdit")
                {
                    AddProduct frm = new AddProduct(this);
                    frm.savebtn.Enabled = false;
                    //  frm.anothercat.Visible = false;
                    //   frm.anothercat.Enabled = false;
                    frm.updatebtn.Enabled = true;
                    frm.quantibox.Enabled = false;
                    frm.proid.Enabled = false;
                    frm.proid.Text = _productid;
                    frm.pnamebox.Text = _pname;
                    frm.quantibox.Text = _quantity;
                    frm.pricebox2.Text = _price;
                    frm.itemcostbox.Text = _itemcost;
                    frm.comboBox1.Text = _unit;
                    frm.expirydate.Value = DateTime.Parse(_expiration);
                    //  frm.categorycmbo.Text = _category;
                    frm.minstkbox.Text = _minstock;
                    frm.maxstkbox.Text = _maxstock;
                    frm.ShowDialog();
                }


                else if (colname == "colDelete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cm = new MySqlCommand("delete from products where product_id like'" + _productid + "'", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Product has been successfully deleted.", "Deleted Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecords();
                    }
                }
            }
            catch
            {

            }
        }

        public Form5()
        {
            InitializeComponent();
            LoadRecords();
        }

        public void LoadRecords()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select * from products order by Product_name ASC", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                }
                //dataGridView1.ClearSelection();
                //colorstock();
                dr.Close();
                con.Close();
            }
            catch
            {

            }
        }
        
       
        public void lowStock()
        {
            try
            {
                  int i = 0;
                  dataGridView1.Rows.Clear();
                  con.Open();
                  cm = new MySqlCommand("select * from products where Stocks < Min_stock", con);
                  dr = cm.ExecuteReader();
                  while (dr.Read())
                     {
                        i += 1;
                        dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                     }
                    dataGridView1.ClearSelection();
                    dr.Close();
                    con.Close();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        public void OnMinStock()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select * from products where Stocks = Min_stock", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                }
                dataGridView1.ClearSelection();
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void OnMaxStock()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select * from products where Stocks >= Max_stock", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                }
                dataGridView1.ClearSelection();
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Form5_Load(object sender, EventArgs e)
        {
            
            typebox.Text = global.type;
            typebox.Visible = false;
            if (typebox.Text=="Admin")
            {
                button3.Visible = true;
                button3.Enabled = true;
            }
            else
            {
                button3.Visible = false;
                button3.Enabled = false;
                dataGridView1.Columns["colDelete"].Visible = false;
            }
        }
    }
}
