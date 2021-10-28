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
    public partial class unitfrm : Form
    {
      
        AddProduct u1;
        public unitfrm(AddProduct u2)
        {
            InitializeComponent();
            u1 = u2;
        }

        private void unitfrm_Load(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            
           if(u1.comboBox1.Items.Contains(unitbox.Text))
            {
                MessageBox.Show("Already Exists");
            }
            else
            {
                u1.comboBox1.Items.Insert(0, unitbox.Text);
                this.Dispose();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
