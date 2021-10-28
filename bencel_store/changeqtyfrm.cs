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
    public partial class changeqtyfrm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;
        posfrm p6;
        public changeqtyfrm(posfrm po6)
        {
            InitializeComponent();
            p6 = po6;
        }

        private void changeqtyfrm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int selectedrowindex = p6.dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = p6.dataGridView2.Rows[selectedrowindex];
                string p_id = Convert.ToString(selectedRow.Cells["pid_col"].Value);
                con.Close();
                con.Open();
                cm = new MySqlCommand("select Stocks from products where product_id = '" + p_id + "'", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    int qr = Convert.ToInt32(dr["Stocks"]);
                    if (numquan.Value > qr)
                    {
                        MessageBox.Show("Insufficient stock! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    else if (numquan.Value == 0)
                    {
                        MessageBox.Show("Warning: Please add quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        selectedRow.Cells["quan_col"].Value = numquan.Value;
                        p6.LoadTotal();
                        this.Dispose();
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
    }
}
