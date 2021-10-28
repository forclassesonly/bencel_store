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
    public partial class remark2frm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;

        trdetails tr1;
        public remark2frm(trdetails tr2)
        {
            InitializeComponent();
            tr1 = tr2;
        }
        private void remark2frm_Load(object sender, EventArgs e)
        {
            userbox.Text = global.username;
            userbox.Visible = false;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex = tr1.dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tr1.dataGridView2.Rows[selectedrowindex];
                string pname = Convert.ToString(selectedRow.Cells["Product_name"].Value);
                int count2 = Convert.ToInt32(tr1.numquan.Value);
                if (remarkbox.Text == "")
                {
                    MessageBox.Show("Warning: Please type a remark!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    con.Open();
                    cm = new MySqlCommand("insert into inventory_log(Product_name, Quantity, Remarks, Activity, User) values(@a1, @a2, @a3, 'Return Product', @a4) ", con);
                    cm.Parameters.AddWithValue("a1", pname);
                    cm.Parameters.AddWithValue("a2", count2);
                    cm.Parameters.AddWithValue("a3", remarkbox.Text);
                    cm.Parameters.AddWithValue("a4", userbox.Text);
                    cm.ExecuteNonQuery();
                    con.Close();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void remarkbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
