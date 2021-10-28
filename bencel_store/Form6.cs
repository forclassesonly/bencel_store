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
    public partial class Form6 : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;database=bencel;Port=3306"); // making connection
        MySqlCommand cm;
        MySqlDataReader dr;
        string _supplierid, _sname, _snumber, _semail, _saddress, _updated_by;
        public Form6()
        {
            InitializeComponent();
            LoadRecords();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            cm = new MySqlCommand("select * from supplier_info order by supplier_name ASC", con);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            messagefrm rfm = new messagefrm(this);
            rfm.ShowDialog();
        }

        private void txtboxsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                cm = new MySqlCommand("select * from supplier_info where supplier_name like'" + txtboxsearch.Text + "%'", con);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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
            int i = dataGridView1.CurrentRow.Index;
            _supplierid = dataGridView1[1, i].Value.ToString();
            _sname = dataGridView1[2, i].Value.ToString();
            _snumber = dataGridView1[3, i].Value.ToString();
            _semail = dataGridView1[4, i].Value.ToString();
            _saddress = dataGridView1[5, i].Value.ToString();
            _updated_by = dataGridView1[6, i].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddSupplier addfrm = new AddSupplier(this);
            addfrm.savebtnn.Enabled = true;
            addfrm.ShowDialog();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "colEdit")
            {
                AddSupplier frm = new AddSupplier(this);
                frm.savebtnn.Enabled = false;
                frm.supplierid.Enabled = false;
                frm.supplierid.Text = _supplierid;
                frm.snamebox.Text = _sname;
                frm.snumberbox.Text = _snumber;
                frm.saddressbox.Text = _saddress;
                frm.emailbox.Text = _semail;
                frm.ShowDialog();
            }

            else if (colname == "colDelete")
            {
                if (MessageBox.Show("Are you sure you want to delete this supplier?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new MySqlCommand("delete from supplier_info where id like'" + _supplierid + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Supplier has been successfully deleted.", "Deleted Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            typebox.Text = global.type;
            typebox.Visible = false;
            if (typebox.Text == "Admin")
            {
                btnAdd.Visible = true;
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Visible = false;
                btnAdd.Enabled = false;
                dataGridView1.Columns["colDelete"].Visible = false;
            }

        }
    }
}
