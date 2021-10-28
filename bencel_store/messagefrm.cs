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
using System.Collections.Specialized;
using System.Net;

namespace bencel_store
{
    public partial class messagefrm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");
        MySqlCommand cm;

        Form6 mf;
        public messagefrm(Form6 mf2)
        {
           InitializeComponent();
            mf = mf2;
        }

        private void messagefrm_Load(object sender, EventArgs e)
        {
            Getdata();
        }
        public void Getdata()
        {
            int selectedrowindex = mf.dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = mf.dataGridView1.Rows[selectedrowindex];
            string supname = Convert.ToString(selectedRow.Cells[2].Value);
            string supnum = Convert.ToString(selectedRow.Cells[3].Value);

            snamebox.Text = supname;
            semailbox.Text = supnum;

        }

        private void snamebox_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void snamebox_Enter(object sender, EventArgs e)
        {
            snamebox.Enabled = false;
            snamebox.Enabled = true;
        }

        private void semailbox_Enter(object sender, EventArgs e)
        {
            semailbox.Enabled = false;
            semailbox.Enabled = true;
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("1", semailbox.Text);
            nameValueCollection.Add("2", messagebox.Text);
            nameValueCollection.Add("3", "TR-BENCE606051_7Y86W");
            nameValueCollection.Add("passwd", "[unq64y)!!");
            byte[] send = webClient.UploadValues("https://www.itexmo.com/php_api/api.php", "POST", nameValueCollection);
            System.Text.UTF8Encoding.UTF8.GetString(send);

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ToClear();
        }
        public void ToClear()
        {
            
            messagebox.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
