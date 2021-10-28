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
    public partial class expirationfrm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");
        MySqlCommand cm;
        MySqlDataReader dr;
        public expirationfrm()
        {
            InitializeComponent();
            LoadExpiryRecors();
        }

        private void expirationfrm_Load(object sender, EventArgs e)
        {

        }
        public void LoadExpiryRecors()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select Product_name, Expiration from products", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    DateTime now = DateTime.Now;
                    DateTime end = dr.GetDateTime(1);
                    if (end <= now)
                    {
                        dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), "Expired");
                    }
                    else
                    {
                        dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), (end.Date - now.Date).Days);
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

        private void closebtn2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void NearExpired()
        {
            try
            {
                DateTime now = DateTime.Now;
                DateTime near = DateTime.Now.AddDays(7);
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select Product_name, Expiration from products where Expiration between @e1 and @e2 ", con);
                cm.Parameters.AddWithValue("e1", now);
                cm.Parameters.AddWithValue("e2", near);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    DateTime end = dr.GetDateTime(1);
                    if (end > now)
                    {
                        dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), (end.Date - now.Date).Days);
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

        public void Expired()
        {
            try
            {
                DateTime now = DateTime.Now;
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select Product_name, Expiration from products where Expiration <= @e1", con);
                cm.Parameters.AddWithValue("e1", now);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    DateTime end = dr.GetDateTime(1);
                    if (end <= now)
                    {
                        dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), "Expired");
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

        private void expirecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.expirecombo.GetItemText(this.expirecombo.SelectedItem);
            if (selected == "All Products")
            {
                LoadExpiryRecors();
            }
            else if (selected == "Expired")
            {
                Expired();
            }
            else if (selected == "Near to Expire")
            {
                NearExpired();
            }
        }
    }
}
