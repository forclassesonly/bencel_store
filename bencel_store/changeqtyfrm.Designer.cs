﻿
namespace bencel_store
{
    partial class changeqtyfrm
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
            this.button1 = new System.Windows.Forms.Button();
            this.numquan = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numquan)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Change Qty";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numquan
            // 
            this.numquan.Location = new System.Drawing.Point(50, 73);
            this.numquan.Name = "numquan";
            this.numquan.Size = new System.Drawing.Size(185, 22);
            this.numquan.TabIndex = 2;
            // 
            // changeqtyfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 235);
            this.Controls.Add(this.numquan);
            this.Controls.Add(this.button1);
            this.Name = "changeqtyfrm";
            this.Text = "changeqtyfrm";
            this.Load += new System.EventHandler(this.changeqtyfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numquan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numquan;
    }
}