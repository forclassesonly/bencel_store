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
    public partial class report_salesfrm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        public report_salesfrm()
        {
            InitializeComponent();
        }

        private void report_salesfrm_Load(object sender, EventArgs e)
        {
            textBox1.Text = global.username;
        }
        public void ToFilterSaleReport()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select * from transaction where Time_Date between @d1 and @d2  ", con);
                da = new MySqlDataAdapter();
                dt = new DataTable();
                da.SelectCommand = cm;
                cm.Parameters.AddWithValue("d1", dateTimePicker1.Value);
                cm.Parameters.AddWithValue("d2", dateTimePicker2.Value);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["Total_Amount"].Value);
                }
                dailybox.Text = sum.ToString();
            }
            catch
            {

            }
        }
        public void loadtransaction()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select * from transaction", con);
                da = new MySqlDataAdapter();
                dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch
            {

            }
        }
       

        private void generatebtn_Click(object sender, EventArgs e)
        {
            
            ToFilterSaleReport();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard frm5 = new Dashboard();
            frm5.Show();
            this.Hide();
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

        private void inventrpbtn_Click(object sender, EventArgs e)
        {
            report_inventoryfrm frm5 = new report_inventoryfrm();
            frm5.Show();
            this.Hide();
        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            report_salesfrm frm6 = new report_salesfrm();
            frm6.Show();
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
        Bitmap bmp;
        private void button4_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void dailybtn_Click_1(object sender, EventArgs e)
        {

        }

        private void dailybox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            DateTime fromdate = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime todate1 = Convert.ToDateTime(dateTimePicker2.Text);
            if (fromdate >= todate1)
            {
                MessageBox.Show("Warning: From Date Must be Less Than To Date!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
                
            }
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            inventorylogfrmcs frm6 = new inventorylogfrmcs();
            frm6.Show();
            this.Hide();
        }
    }
}
