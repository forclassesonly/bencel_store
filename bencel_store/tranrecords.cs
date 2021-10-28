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
    public partial class tranrecords : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        public tranrecords()
        {
            InitializeComponent();
            

        }

        private void tranrecords_Load(object sender, EventArgs e)
        {
            
            ToLoadtrans();
        }
        public void ToLoadtrans()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select * from transaction order by Time_Date DESC", con);
                da = new MySqlDataAdapter();
                dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                


                con.Open();
                cm = new MySqlCommand("delete from transaction where not exists (select * from transdetails where transaction_id = transaction.Transaction_id)", con);
                cm.ExecuteNonQuery();
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
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                da = new MySqlDataAdapter("select Transaction_id, Time_Date, Total_Amount, Cash_Given, S_change, User from transaction where Transaction_id like'" + searchbox.Text + "%'", con);
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

        private void filterbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = dateTimePicker1.Value;

                string strDate = dateToday.ToString("yyyy-MM-dd");

                sql = "SELECT * FROM `transaction` WHERE Date(`Time_Date`) = '" + strDate + "'";
                retrieveData(sql, dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            ToLoadtrans();
            dateTimePicker1.Value = DateTime.Now;
            searchbox.Text = "";
        }

        
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string value = dataGridView1.Rows[e.RowIndex].Cells["Transaction_id"].FormattedValue.ToString();
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
             trdetails trfrm = new trdetails(this);
             trfrm.ShowDialog();
            

                

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
