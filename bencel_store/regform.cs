using System;
using System.IO;
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
    public partial class regform : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;

        emplolistfrm em;
        public regform(emplolistfrm em2)
        {
            InitializeComponent();
            em = em2;
        }

        private void regform_Load(object sender, EventArgs e)
        {
            
        }

        private void fnamebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            //{
                //return;
            //}
            //else
            //{
                //MessageBox.Show("Letters Only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //e.Handled = true;
            //}
            
        }

        private void fnamebox_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;
            if (fnamebox.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = fnamebox.Text;
                fnamebox.Text = oldText;

                //fnamebox.BackColor = System.Drawing.Color.White;
                //fnamebox.ForeColor = System.Drawing.Color.Black;
               
            }
            else
            {
                fnamebox.Text = oldText;
                //fnamebox.BackColor = System.Drawing.Color.Red;
                //fnamebox.ForeColor = System.Drawing.Color.White;
                MessageBox.Show("Letters Only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            fnamebox.SelectionStart = fnamebox.Text.Length;
        }

        private void mnamebox_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;
            if (mnamebox.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = mnamebox.Text;
                mnamebox.Text = oldText;

                //mnamebox.BackColor = System.Drawing.Color.White;
                //mnamebox.ForeColor = System.Drawing.Color.Black;

            }
            else
            {
                mnamebox.Text = oldText;
                //fnamebox.BackColor = System.Drawing.Color.Red;
                //fnamebox.ForeColor = System.Drawing.Color.White;
                MessageBox.Show("Letters Only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            mnamebox.SelectionStart = mnamebox.Text.Length;
        }

        private void lnamebox_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;
            if (lnamebox.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = lnamebox.Text;
                lnamebox.Text = oldText;

                //lnamebox.BackColor = System.Drawing.Color.White;
                //lnamebox.ForeColor = System.Drawing.Color.Black;

            }
            else
            {
                lnamebox.Text = oldText;
                //fnamebox.BackColor = System.Drawing.Color.Red;
                //fnamebox.ForeColor = System.Drawing.Color.White;
                MessageBox.Show("Letters Only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            lnamebox.SelectionStart = lnamebox.Text.Length;
        }

        private void agebox_TextChanged(object sender, EventArgs e)
        {
            int age = Convert.ToInt32(agebox.Text); 
            if(age>50)
            {
                MessageBox.Show("Please Input Appropriate Birthdate!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //bdatepicker.Value=DateTime.Now;
                return;
            }
            else if(age<18)
            {
                MessageBox.Show("Please Input Appropriate Birthdate!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //bdatepicker.Value = DateTime.Now;
                return;
            }
        }

        private void agebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void bdatepicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = bdatepicker.Value;
            int currentage = DateTime.Today.Year - bdatepicker.Value.Year;
            agebox.Text = currentage.ToString();

        }

        private void confirmbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int age = Convert.ToInt32(agebox.Text);
                int count = contactbox.TextLength;
                String bdate = bdatepicker.Value.ToString("yyyy-MM-dd", null);
                if (usernamebox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Username fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usernamebox.Focus();
                    return;
                }
                else if (passbox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Password field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    passbox.Focus();
                    return;
                }
                else if (confirmbox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Confirm Password field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    confirmbox.Focus();
                    return;
                }
                else if (fnamebox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill First Name field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fnamebox.Focus();
                    return;
                }
                else if (lnamebox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Last Name field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lnamebox.Focus();
                    return;
                }
                else if (agebox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Age field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    agebox.Focus();
                    return;
                }
                else if (addressbox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Address field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    addressbox.Focus();
                    return;
                }
                else if (gendercombo.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Gender field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gendercombo.Focus();
                    return;
                }
                else if (passbox.Text != confirmbox.Text)
                {
                    MessageBox.Show("Password and Confirm password field should match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if(count<11)
                {
                    MessageBox.Show("Contact number must be 11 digit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                else if (age > 50)
                {
                    MessageBox.Show("Please Input Appropriate Birthdate!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bdatepicker.Focus();
                    return;
                }
                else if (age < 18)
                {
                    MessageBox.Show("Please Input Appropriate Birthdate!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bdatepicker.Focus();
                    return;
                }
                else if (mnamebox.Text == string.Empty)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to leave the Middle name blank?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show("Please put 'none'/'None' to the middle name if the user doesn't have a middle name", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                    else if (dialogResult == DialogResult.No)
                    {

                        mnamebox.Focus();
                        return;
                    }
                    
                }
                
                else
                {
                   
                    con.Open();
                    cm = new MySqlCommand("insert into user(Type, username, password, First_name, Middle_name, Last_name, Birthdate, Age, Address, Contact, Gender) values('Employee','" + usernamebox.Text + "','" + confirmbox.Text + "','" + fnamebox.Text + "','" + mnamebox.Text + "','" + lnamebox.Text + "','" + bdate + "','" + agebox.Text + "','" + addressbox.Text + "', '" + contactbox.Text + "', '" + gendercombo.Text + "')", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully saved.", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    em.UserRecords();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void ToClear()
        {
            usernamebox.Text = string.Empty;
            passbox.Text = string.Empty;
            fnamebox.Text=string.Empty;
            mnamebox.Text = string.Empty;
            lnamebox.Text = string.Empty;
            addressbox.Text = string.Empty;
            confirmbox.Text = string.Empty;
            contactbox.Text = string.Empty;
            bdatepicker.Value = DateTime.Now;
            gendercombo.Text = string.Empty;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            ToClear();
        }

        private void agebox_Enter(object sender, EventArgs e)
        {
            agebox.Enabled = false;
            agebox.Enabled = true;
        }

        private void contactbox_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void contactbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void updatebtn_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
