using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bencel_store
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.panel2.Controls.Clear();
            posfrm frm11 = new posfrm()
            {
                Dock = DockStyle.Bottom,
                TopLevel = false
            };
            this.panel2.Controls.Add(frm11);
            frm11.Show();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //button4.Visible = false;
          //  button4.Enabled = false;
            userbox.Text = global.username;
            typebox.Text = global.type;
            typebox.Visible = false;
            if (typebox.Text == "Admin")
            {
                button5.Visible = true;
                button5.Enabled = true;
            }
            else
            {
                button5.Visible = false;
                button5.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.panel2.Controls.Clear();
          //  Form3 frm3 = new Form3()
          //  {
          //      Dock = DockStyle.Bottom,
          //      TopLevel = false
         //   };
         //   this.panel2.Controls.Add(frm3);
          //  frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            Form5 frm5 = new Form5()
            {
                Dock = DockStyle.Bottom,
                TopLevel = false
            };
            this.panel2.Controls.Add(frm5);
            frm5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            tranrecords frm4 = new tranrecords()
            {
                Dock = DockStyle.Bottom,
                TopLevel = false
            };
            this.panel2.Controls.Add(frm4);
            frm4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            Form6 frm6 = new Form6()
            {
                Dock = DockStyle.Bottom,
                TopLevel = false
            };
            this.panel2.Controls.Add(frm6);
            frm6.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
                Form1 frm1 = new Form1();
                frm1.Show();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

       

        private void btnbarcode_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            barcodefrm frm9 = new barcodefrm()
            {
                Dock = DockStyle.Bottom,
                TopLevel = false
            };
            this.panel2.Controls.Add(frm9);
            frm9.Show();
        }

        private void customerbtn_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            customer frm10 = new customer()
            {
                Dock = DockStyle.Bottom,
                TopLevel = false
            };
            this.panel2.Controls.Add(frm10);
            frm10.Show();
        }

        private void posfrmbtn_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            posfrm frm11 = new posfrm()
            {
                Dock = DockStyle.Bottom,
                TopLevel = false
            };
            this.panel2.Controls.Add(frm11);
            frm11.Show();
        }

        private void addprodfrm_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            addscanprod frm12 = new addscanprod()
            {
                Dock = DockStyle.Bottom,
                TopLevel = false
            };
            this.panel2.Controls.Add(frm12);
            frm12.Show();
        }
    }
}
