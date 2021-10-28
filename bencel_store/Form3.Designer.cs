
namespace bencel_store
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.userbox = new System.Windows.Forms.TextBox();
            this.total_itemsbox = new System.Windows.Forms.TextBox();
            this.total_amountbox = new System.Windows.Forms.TextBox();
            this.bencelDataSet = new bencel_store.bencelDataSet();
            this.bencelDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bencelDataSet1 = new bencel_store.bencelDataSet();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.To_computebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.prodid_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_namecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cashbox = new System.Windows.Forms.TextBox();
            this.changebox = new System.Windows.Forms.TextBox();
            this.numquan = new System.Windows.Forms.NumericUpDown();
            this.change_quanbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bencelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bencelDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bencelDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numquan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // userbox
            // 
            this.userbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.userbox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.userbox.Location = new System.Drawing.Point(405, 34);
            this.userbox.Margin = new System.Windows.Forms.Padding(4);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(208, 28);
            this.userbox.TabIndex = 1;
            this.userbox.TextChanged += new System.EventHandler(this.userbox_TextChanged);
            this.userbox.Enter += new System.EventHandler(this.userbox_Enter);
            // 
            // total_itemsbox
            // 
            this.total_itemsbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.total_itemsbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_itemsbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.total_itemsbox.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_itemsbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.total_itemsbox.Location = new System.Drawing.Point(316, 87);
            this.total_itemsbox.Margin = new System.Windows.Forms.Padding(4);
            this.total_itemsbox.Name = "total_itemsbox";
            this.total_itemsbox.Size = new System.Drawing.Size(159, 38);
            this.total_itemsbox.TabIndex = 5;
            this.total_itemsbox.TextChanged += new System.EventHandler(this.total_itemsbox_TextChanged);
            this.total_itemsbox.Enter += new System.EventHandler(this.total_itemsbox_Enter);
            // 
            // total_amountbox
            // 
            this.total_amountbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.total_amountbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_amountbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.total_amountbox.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_amountbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.total_amountbox.Location = new System.Drawing.Point(316, 31);
            this.total_amountbox.Margin = new System.Windows.Forms.Padding(4);
            this.total_amountbox.Name = "total_amountbox";
            this.total_amountbox.Size = new System.Drawing.Size(172, 38);
            this.total_amountbox.TabIndex = 6;
            this.total_amountbox.TextChanged += new System.EventHandler(this.total_amountbox_TextChanged);
            this.total_amountbox.Enter += new System.EventHandler(this.total_amountbox_Enter);
            // 
            // bencelDataSet
            // 
            this.bencelDataSet.DataSetName = "bencelDataSet";
            this.bencelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bencelDataSetBindingSource
            // 
            this.bencelDataSetBindingSource.DataSource = this.bencelDataSet;
            this.bencelDataSetBindingSource.Position = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.label1.Location = new System.Drawing.Point(68, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "TOTAL ITEMS:";
            // 
            // bencelDataSet1
            // 
            this.bencelDataSet1.DataSetName = "bencelDataSet";
            this.bencelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.label5.Location = new System.Drawing.Point(317, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "User:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.panel1.Location = new System.Drawing.Point(60, 65);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1325, 12);
            this.panel1.TabIndex = 24;
            // 
            // To_computebtn
            // 
            this.To_computebtn.BackColor = System.Drawing.Color.DarkRed;
            this.To_computebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.To_computebtn.FlatAppearance.BorderSize = 0;
            this.To_computebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.To_computebtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.To_computebtn.ForeColor = System.Drawing.Color.White;
            this.To_computebtn.Location = new System.Drawing.Point(896, 681);
            this.To_computebtn.Margin = new System.Windows.Forms.Padding(4);
            this.To_computebtn.Name = "To_computebtn";
            this.To_computebtn.Size = new System.Drawing.Size(391, 57);
            this.To_computebtn.TabIndex = 17;
            this.To_computebtn.Text = "Pay with cash";
            this.To_computebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.To_computebtn.UseVisualStyleBackColor = false;
            this.To_computebtn.Click += new System.EventHandler(this.To_computebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.FlatAppearance.BorderSize = 2;
            this.clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearbtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.clearbtn.Location = new System.Drawing.Point(388, 34);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(133, 53);
            this.clearbtn.TabIndex = 8;
            this.clearbtn.Text = "Clear";
            this.clearbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.FlatAppearance.BorderSize = 2;
            this.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletebtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.deletebtn.Location = new System.Drawing.Point(231, 34);
            this.deletebtn.Margin = new System.Windows.Forms.Padding(4);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(133, 53);
            this.deletebtn.TabIndex = 7;
            this.deletebtn.Text = "Delete";
            this.deletebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodid_column,
            this.prod_namecolumn,
            this.price_column,
            this.quantity_column});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(60, 85);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(683, 559);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Rows_added);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Rows_removed);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // prodid_column
            // 
            this.prodid_column.HeaderText = "Product ID";
            this.prodid_column.MinimumWidth = 6;
            this.prodid_column.Name = "prodid_column";
            this.prodid_column.ReadOnly = true;
            // 
            // prod_namecolumn
            // 
            this.prod_namecolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.prod_namecolumn.HeaderText = "Product Name";
            this.prod_namecolumn.MinimumWidth = 6;
            this.prod_namecolumn.Name = "prod_namecolumn";
            this.prod_namecolumn.ReadOnly = true;
            this.prod_namecolumn.Width = 137;
            // 
            // price_column
            // 
            this.price_column.HeaderText = "Price";
            this.price_column.MinimumWidth = 6;
            this.price_column.Name = "price_column";
            this.price_column.ReadOnly = true;
            // 
            // quantity_column
            // 
            this.quantity_column.HeaderText = "Quantity";
            this.quantity_column.MinimumWidth = 6;
            this.quantity_column.Name = "quantity_column";
            this.quantity_column.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.label3.Location = new System.Drawing.Point(16, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 38);
            this.label3.TabIndex = 28;
            this.label3.Text = "Point of Sale";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.label8.Location = new System.Drawing.Point(33, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(263, 38);
            this.label8.TabIndex = 29;
            this.label8.Text = "TOTAL AMOUNT:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.label9.Location = new System.Drawing.Point(123, 110);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 48);
            this.label9.TabIndex = 30;
            this.label9.Text = "CHANGE:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.label10.Location = new System.Drawing.Point(32, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(276, 48);
            this.label10.TabIndex = 31;
            this.label10.Text = "ENTER CASH:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.button1.Location = new System.Drawing.Point(72, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 53);
            this.button1.TabIndex = 33;
            this.button1.Text = "Product List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cashbox
            // 
            this.cashbox.BackColor = System.Drawing.Color.Black;
            this.cashbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cashbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.cashbox.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashbox.ForeColor = System.Drawing.Color.White;
            this.cashbox.Location = new System.Drawing.Point(359, 36);
            this.cashbox.Margin = new System.Windows.Forms.Padding(4);
            this.cashbox.Name = "cashbox";
            this.cashbox.Size = new System.Drawing.Size(203, 48);
            this.cashbox.TabIndex = 35;
            this.cashbox.TextChanged += new System.EventHandler(this.cashbox_TextChanged);
            this.cashbox.Enter += new System.EventHandler(this.cashbox_Enter);
            this.cashbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cashbox_KeyPress);
            // 
            // changebox
            // 
            this.changebox.BackColor = System.Drawing.Color.Black;
            this.changebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.changebox.Cursor = System.Windows.Forms.Cursors.Default;
            this.changebox.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changebox.ForeColor = System.Drawing.Color.White;
            this.changebox.Location = new System.Drawing.Point(359, 110);
            this.changebox.Margin = new System.Windows.Forms.Padding(4);
            this.changebox.Name = "changebox";
            this.changebox.Size = new System.Drawing.Size(203, 48);
            this.changebox.TabIndex = 36;
            this.changebox.Enter += new System.EventHandler(this.changebox_Enter);
            // 
            // numquan
            // 
            this.numquan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numquan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numquan.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numquan.Location = new System.Drawing.Point(308, 140);
            this.numquan.Margin = new System.Windows.Forms.Padding(4);
            this.numquan.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numquan.Name = "numquan";
            this.numquan.Size = new System.Drawing.Size(160, 29);
            this.numquan.TabIndex = 37;
            this.numquan.ValueChanged += new System.EventHandler(this.numquan_ValueChanged);
            this.numquan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numquan_KeyPress);
            // 
            // change_quanbtn
            // 
            this.change_quanbtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.change_quanbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.change_quanbtn.FlatAppearance.BorderSize = 2;
            this.change_quanbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.change_quanbtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_quanbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(195)))));
            this.change_quanbtn.Location = new System.Drawing.Point(116, 124);
            this.change_quanbtn.Margin = new System.Windows.Forms.Padding(4);
            this.change_quanbtn.Name = "change_quanbtn";
            this.change_quanbtn.Size = new System.Drawing.Size(153, 57);
            this.change_quanbtn.TabIndex = 38;
            this.change_quanbtn.Text = "Change Quantity";
            this.change_quanbtn.UseVisualStyleBackColor = false;
            this.change_quanbtn.Click += new System.EventHandler(this.change_quanbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numquan);
            this.groupBox1.Controls.Add(this.change_quanbtn);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.deletebtn);
            this.groupBox1.Controls.Add(this.clearbtn);
            this.groupBox1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(796, 85);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(588, 209);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.total_itemsbox);
            this.groupBox2.Controls.Add(this.total_amountbox);
            this.groupBox2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(799, 302);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(585, 155);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Sale";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.changebox);
            this.groupBox3.Controls.Add(this.cashbox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(799, 464);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(587, 198);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.panel2.Location = new System.Drawing.Point(23, 46);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 2);
            this.panel2.TabIndex = 42;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkRed;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(471, 681);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(391, 57);
            this.button2.TabIndex = 43;
            this.button2.Text = "Cashless Pay";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkRed;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(48, 681);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(391, 57);
            this.button3.TabIndex = 44;
            this.button3.Text = "Pay with Loyalty Points";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1500, 790);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.To_computebtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bencelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bencelDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bencelDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numquan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox userbox;
        private System.Windows.Forms.TextBox total_itemsbox;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.BindingSource bencelDataSetBindingSource;
        private bencelDataSet bencelDataSet;
        private System.Windows.Forms.Label label1;
        private bencelDataSet bencelDataSet1;
        private System.Windows.Forms.Button To_computebtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox cashbox;
        private System.Windows.Forms.TextBox changebox;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodid_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_namecolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_column;
        private System.Windows.Forms.NumericUpDown numquan;
        private System.Windows.Forms.Button change_quanbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox total_amountbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}