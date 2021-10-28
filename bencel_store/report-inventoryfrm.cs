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
    public partial class report_inventoryfrm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        public report_inventoryfrm()
        {
            InitializeComponent();
        }

        private void report_inventoryfrm_Load(object sender, EventArgs e)
        {
            ToloadInvenReport();
            textBox3.Text = global.username;
        }

        public void ToloadInvenReport()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select product_id, Product_name, Price * Stocks as Inventory_Value from products", con);
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
        public void LoadSalesValue()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select Product_name, quantity_sold, sum(quantity_sold * Price) as Sales_Value from transdetails group by Product_name", con);
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


        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            emplolistfrm emp = new emplolistfrm();
            emp.Show();
            this.Hide();
        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            report_salesfrm frm4 = new report_salesfrm();
            frm4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
                Form1 frm1 = new Form1();
                frm1.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }
        Bitmap bmp;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if(selected== "Inventory Value")
            {
                ToloadInvenReport();
            }
            else if(selected== "Sales Value")
            {
                LoadSalesValue();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Product_name LIKE '{0}%'", textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inventorylogfrmcs frm6 = new inventorylogfrmcs();
            frm6.Show();
            this.Hide();
        }
    }
}
