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

    public partial class AddSupplier : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");
        MySqlCommand cm;
        //MySqlDataReader dr;
        Form6 f1;
        public AddSupplier(Form6 frm6)
        {
            InitializeComponent();
            f1 = frm6;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            userbox2.Text = global.username;
            userbox2.Visible = false;
            supplierid.Visible = false;
        }
        public void Clear()
        {
            supplierid.Clear();
            snamebox.Clear();
            snumberbox.Clear();
            saddressbox.Clear();
            emailbox.Clear();
            savebtnn.Enabled = true;
        }

            private void savebtnn_Click(object sender, EventArgs e)
            {
                try
                {
                    if ((snamebox.Text == string.Empty) || (snumberbox.Text == string.Empty) || (saddressbox.Text == string.Empty))
                    {
                        MessageBox.Show("Warning: Required Empty fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    con.Open();
                    cm = new MySqlCommand("insert into supplier_info (id,supplier_name, supplier_num, supplier_email, supplier_address, updated_by) values('" + supplierid.Text + "','" + snamebox.Text + "','" + snumberbox.Text + "', '" + emailbox.Text + "','" + saddressbox.Text + "','" + userbox2.Text + "')", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully saved.", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f1.LoadRecords();

                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Warning:" + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            private void button2_Click(object sender, EventArgs e)
            {
                this.Dispose();
            }

            private void updatebtnn_Click(object sender, EventArgs e)
            {
                try
                {

                    if ((snamebox.Text == string.Empty) || (snumberbox.Text == string.Empty) || (saddressbox.Text == string.Empty))
                    {
                        MessageBox.Show("Warning: Required Empty fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    con.Open();
                    cm = new MySqlCommand("update supplier_info set supplier_name= '" + snamebox.Text + "',supplier_num = '" + snumberbox.Text + "',supplier_email = '" + emailbox.Text + "',supplier_address = '" + saddressbox.Text + "',updated_by = '" + userbox2.Text + "'where id like '" + supplierid.Text + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully Updated.", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f1.LoadRecords();
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Warning: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        private void userbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void snumberbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void snumberbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
                MessageBox.Show("Input Numbers Only!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void emailbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

