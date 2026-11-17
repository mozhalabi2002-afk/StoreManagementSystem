namespace StoreProject.Vendors
{
    partial class FrmVendorsManagement
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
            this.DGVVendors = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewVendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateVendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteVendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CBFilter = new System.Windows.Forms.ComboBox();
            this.TBFilter = new System.Windows.Forms.TextBox();
            this.BtnAddNew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVendors)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVVendors
            // 
            this.DGVVendors.BackgroundColor = System.Drawing.Color.White;
            this.DGVVendors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVVendors.ContextMenuStrip = this.contextMenuStrip1;
            this.DGVVendors.GridColor = System.Drawing.Color.White;
            this.DGVVendors.Location = new System.Drawing.Point(12, 138);
            this.DGVVendors.Name = "DGVVendors";
            this.DGVVendors.Size = new System.Drawing.Size(840, 258);
            this.DGVVendors.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewVendorToolStripMenuItem,
            this.toolStripMenuItem2,
            this.updateVendorToolStripMenuItem,
            this.toolStripMenuItem3,
            this.deleteVendorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 114);
            // 
            // addNewVendorToolStripMenuItem
            // 
            this.addNewVendorToolStripMenuItem.Name = "addNewVendorToolStripMenuItem";
            this.addNewVendorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.addNewVendorToolStripMenuItem.Text = "Add New vendor";
            this.addNewVendorToolStripMenuItem.Click += new System.EventHandler(this.addNewVendorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItem2.Text = "----------------------------";
            // 
            // updateVendorToolStripMenuItem
            // 
            this.updateVendorToolStripMenuItem.Name = "updateVendorToolStripMenuItem";
            this.updateVendorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.updateVendorToolStripMenuItem.Text = "Update vendor";
            this.updateVendorToolStripMenuItem.Click += new System.EventHandler(this.updateVendorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItem3.Text = "----------------------------";
            // 
            // deleteVendorToolStripMenuItem
            // 
            this.deleteVendorToolStripMenuItem.Name = "deleteVendorToolStripMenuItem";
            this.deleteVendorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.deleteVendorToolStripMenuItem.Text = "Delete Vendor";
            this.deleteVendorToolStripMenuItem.Click += new System.EventHandler(this.deleteVendorToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(271, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Management Vendors ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "#Record : ";
            // 
            // LabRecord
            // 
            this.LabRecord.AutoSize = true;
            this.LabRecord.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabRecord.Location = new System.Drawing.Point(167, 418);
            this.LabRecord.Name = "LabRecord";
            this.LabRecord.Size = new System.Drawing.Size(28, 29);
            this.LabRecord.TabIndex = 3;
            this.LabRecord.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filter : ";
            // 
            // CBFilter
            // 
            this.CBFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFilter.FormattingEnabled = true;
            this.CBFilter.Items.AddRange(new object[] {
            "None",
            "Vendor Id",
            "Vendor Name",
            "First Name",
            "Second Name",
            "Last Name",
            "Shift Time Started",
            "Shift Time Finshed",
            "N.o",
            "Phone Number"});
            this.CBFilter.Location = new System.Drawing.Point(114, 98);
            this.CBFilter.Name = "CBFilter";
            this.CBFilter.Size = new System.Drawing.Size(136, 21);
            this.CBFilter.TabIndex = 6;
            this.CBFilter.SelectedIndexChanged += new System.EventHandler(this.CBFilter_SelectedIndexChanged);
            // 
            // TBFilter
            // 
            this.TBFilter.Location = new System.Drawing.Point(289, 98);
            this.TBFilter.Name = "TBFilter";
            this.TBFilter.Size = new System.Drawing.Size(156, 20);
            this.TBFilter.TabIndex = 7;
            this.TBFilter.TextChanged += new System.EventHandler(this.TBFilter_TextChanged);
            this.TBFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBFilter_KeyPress);
            // 
            // BtnAddNew
            // 
            this.BtnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddNew.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddNew.Location = new System.Drawing.Point(688, 78);
            this.BtnAddNew.Name = "BtnAddNew";
            this.BtnAddNew.Size = new System.Drawing.Size(142, 50);
            this.BtnAddNew.TabIndex = 8;
            this.BtnAddNew.Text = "Add New";
            this.BtnAddNew.UseVisualStyleBackColor = true;
            this.BtnAddNew.Click += new System.EventHandler(this.BtnAddNew_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(688, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 50);
            this.button1.TabIndex = 9;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StoreProject.Properties.Resources.Close_64;
            this.pictureBox1.Location = new System.Drawing.Point(749, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmVendorsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnAddNew);
            this.Controls.Add(this.TBFilter);
            this.Controls.Add(this.CBFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVVendors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVendorsManagement";
            this.Text = "FrmVendorsManagement";
            this.Load += new System.EventHandler(this.FrmVendorsManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVVendors)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVVendors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabRecord;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewVendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem updateVendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteVendorToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBFilter;
        private System.Windows.Forms.TextBox TBFilter;
        private System.Windows.Forms.Button BtnAddNew;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}