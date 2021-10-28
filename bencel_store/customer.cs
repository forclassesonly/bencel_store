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
    public partial class customer : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        //MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        public customer()
        {
            InitializeComponent();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        public void loaddata()
        {
            try
            {
                con.Open();
                cm = new MySqlCommand("select * from customer", con);
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
    }
}
