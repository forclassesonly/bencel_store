using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using MySql.Data.MySqlClient;




namespace bencel_store
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True"); // making connection
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT username, password, Type FROM user WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'", con);
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successfully.", "Login Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    global.username = dt.Rows[0]["username"].ToString();
                    global.pass = dt.Rows[0]["password"].ToString();
                    global.type = dt.Rows[0]["Type"].ToString();
                    String user_type = global.type;
                    this.Hide();
                    if (user_type == "Admin")
                    {
                        Dashboard dash = new Dashboard();
                        dash.Show();
                    }
                    else
                    {
                        Form2 objform2Main = new Form2();
                        objform2Main.Show();
                    }




                }
                else if ((textBox1.Text == string.Empty) || (textBox2.Text == string.Empty))
                {
                    MessageBox.Show("Warning: All fields are required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                button1.PerformClick();

            }
        }
    }
}
