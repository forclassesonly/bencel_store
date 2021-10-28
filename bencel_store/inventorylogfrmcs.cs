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
    public partial class inventorylogfrmcs : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        public inventorylogfrmcs()
        {
            InitializeComponent();
        }

        private void inventorylogfrmcs_Load(object sender, EventArgs e)
        {
            ToloadInvenLog();
        }
        public void ToloadInvenLog()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select * from inventory_log", con);
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
        private void retrieveData(string sql, DataGridView dtg)
        {
            try
            {
                con.Open();

                cm = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();

                cm.Connection = con;
                cm.CommandText = sql;
                da.SelectCommand = cm;
                da.Fill(dt);

                dtg.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }

        private void filterbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = dateTimePicker1.Value;

                string strDate = dateToday.ToString("yyyy-MM-dd");

                sql = "SELECT * FROM `inventory_log` WHERE Date(`Time_Date`) = '" + strDate + "'";
                retrieveData(sql, dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            ToloadInvenLog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Product_name LIKE '{0}%' OR User LIKE '{0}%'", textBox1.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard form1 = new Dashboard();
            form1.Show();
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

        private void inventrpbtn_Click(object sender, EventArgs e)
        {
            report_inventoryfrm frm5 = new report_inventoryfrm();
            frm5.Show();
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

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells["inventorylog_id"].Value);
                if (MessageBox.Show("Are you sure you want to delete this log?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new MySqlCommand("delete from inventory_log where inventorylog_id like'" + id + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Log has been successfully deleted.", "Deleted Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToloadInvenLog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
