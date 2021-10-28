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
    public partial class emplolistfrm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");
        MySqlCommand cm;
        MySqlDataReader dr;
        string _userid, _fname, _mname, _lname, _bdate, _age, _address, _contact, _gender, _username, _password, _type;

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            inventorylogfrmcs frm6 = new inventorylogfrmcs();
            frm6.Show();
            this.Hide();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select id, First_name, Middle_name, Last_name, Birthdate, Age, Address, Contact, Gender, username, password, Type from user where First_name like'" + txtsearch.Text + "%'", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        public emplolistfrm()
        {
            InitializeComponent();
            UserRecords();

        }
        private void emplolistfrm_Load(object sender, EventArgs e)
        {
            textBox1.Text = global.username;
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            regform regfrm = new regform(this);
            regfrm.createbtn.Enabled = true;
            regfrm.updatebtn.Enabled = false;
            regfrm.ShowDialog();
        }
        public void UserRecords()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select id, First_name, Middle_name, Last_name, Birthdate, Age, Address, Contact, Gender, username, password, Type from user", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;
                _userid = dataGridView1[1, i].Value.ToString();
                _fname = dataGridView1[2, i].Value.ToString();
                _mname = dataGridView1[3, i].Value.ToString();
                _lname = dataGridView1[4, i].Value.ToString();
                _bdate = dataGridView1[5, i].Value.ToString();
                _age = dataGridView1[6, i].Value.ToString();
                _address = dataGridView1[7, i].Value.ToString();
                _contact = dataGridView1[8, i].Value.ToString();
                _gender = dataGridView1[9, i].Value.ToString();
                _username = dataGridView1[10, i].Value.ToString();
                _password = dataGridView1[11, i].Value.ToString();
                _type = dataGridView1[12, i].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname == "coledit")
                {
                    regform fr = new regform(this);
                    fr.createbtn.Enabled = false;
                    fr.updatebtn.Enabled = true;
                    fr.fnamebox.Text = _fname;
                    fr.mnamebox.Text = _mname;
                    fr.lnamebox.Text = _lname;
                    fr.bdatepicker.Value = DateTime.Parse(_bdate);
                    fr.agebox.Text = _age;
                    fr.addressbox.Text = _address;
                    fr.contactbox.Text = _contact;
                    fr.gendercombo.Text = _gender;
                    fr.passbox.Text = _password;
                    fr.confirmbox.Text = _password;
                    fr.usernamebox.Text = _username;
                    fr.ShowDialog();
                }

                else if (colname == "coldelete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cm = new MySqlCommand("delete from user where id like'" + _userid + "'", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("User has been successfully deleted.", "Deleted User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
