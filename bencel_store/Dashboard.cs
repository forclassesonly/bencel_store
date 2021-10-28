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
    public partial class Dashboard : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        public Dashboard()
        {
            InitializeComponent();
            CountTransaction();
            CountProduct();
            CountRevenue();
            LoadPieChart();
            LoadColumnChart();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            emplolistfrm emp = new emplolistfrm();
            emp.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            userbox.Text = global.username;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void transactionbox_TextChanged(object sender, EventArgs e)
        {

            
           
        }
        
        public void CountTransaction()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select count(transaction_id) as totaltran from transaction", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["totaltran"] == null)
                    {
                        transactionbox.Text = "0";
                    }
                    else
                    {
                        transactionbox.Text = dr["totaltran"].ToString();
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

        public void CountProduct()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select count(product_id) as totalprod from products", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["totalprod"] == null)
                    {
                        productbox.Text = "0";
                    }
                    else
                    {
                        productbox.Text = dr["totalprod"].ToString();
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

        public void CountRevenue()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select sum(Total_Amount) as totalrev from transaction", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["totalrev"] == null)
                    {
                        revenuebox.Text = "0";
                    }
                    else
                    {
                        revenuebox.Text = dr["totalrev"].ToString();
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

        private void revenuebox_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoadPieChart()
        {
            try
            {
                chart2.Series[0].Points.Clear();
                con.Open();
                cm = new MySqlCommand("SELECT Product_name, SUM(quantity_sold) as quantity_sold FROM transdetails GROUP BY Product_name ORDER BY SUM(quantity_sold) DESC LIMIT 5", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                  chart2.Series["s1"].Points.AddXY(dr["Product_name"], dr["quantity_sold"]);
      
                }
               
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadColumnChart()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand(" SELECT MONTH(Time_Date) as SalesMonth, SUM(Total_Amount) AS TotalSales FROM transaction GROUP BY MONTH(Time_Date) ORDER BY MONTH(Time_Date)", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    chart1.Series["Monthly Sales"].Points.AddXY(dr["SalesMonth"], dr["TotalSales"]);
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void productbox_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void chart2_Click_1(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            report_salesfrm frm4 = new report_salesfrm();
            frm4.Show();
            this.Hide();
        }

        private void inventrpbtn_Click(object sender, EventArgs e)
        {
            report_inventoryfrm frm5 = new report_inventoryfrm();
            frm5.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Blue, 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inventorylogfrmcs frm6 = new inventorylogfrmcs();
            frm6.Show();
            this.Hide();
        }
    }
}
