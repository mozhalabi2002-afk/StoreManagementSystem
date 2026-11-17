namespace StoreProject
{
    partial class FrmVendorHome
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vendorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorsManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewVendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPrductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.transationSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendorsToolStripMenuItem,
            this.customersToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.transationSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(840, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vendorsToolStripMenuItem
            // 
            this.vendorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendorsManagementToolStripMenuItem,
            this.addNewVendorToolStripMenuItem});
            this.vendorsToolStripMenuItem.Name = "vendorsToolStripMenuItem";
            this.vendorsToolStripMenuItem.Size = new System.Drawing.Size(119, 36);
            this.vendorsToolStripMenuItem.Text = "Vendors";
            // 
            // vendorsManagementToolStripMenuItem
            // 
            this.vendorsManagementToolStripMenuItem.Name = "vendorsManagementToolStripMenuItem";
            this.vendorsManagementToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.vendorsManagementToolStripMenuItem.Text = "Vendors Management";
            this.vendorsManagementToolStripMenuItem.Click += new System.EventHandler(this.vendorsManagementToolStripMenuItem_Click);
            // 
            // addNewVendorToolStripMenuItem
            // 
            this.addNewVendorToolStripMenuItem.Name = "addNewVendorToolStripMenuItem";
            this.addNewVendorToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.addNewVendorToolStripMenuItem.Text = "Add New Vendor";
            this.addNewVendorToolStripMenuItem.Click += new System.EventHandler(this.addNewVendorToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersManagementToolStripMenuItem,
            this.addNewCustomerToolStripMenuItem});
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(147, 36);
            this.customersToolStripMenuItem.Text = "Customers";
            // 
            // customersManagementToolStripMenuItem
            // 
            this.customersManagementToolStripMenuItem.Name = "customersManagementToolStripMenuItem";
            this.customersManagementToolStripMenuItem.Size = new System.Drawing.Size(367, 36);
            this.customersManagementToolStripMenuItem.Text = "Customers Management";
            this.customersManagementToolStripMenuItem.Click += new System.EventHandler(this.customersManagementToolStripMenuItem_Click);
            // 
            // addNewCustomerToolStripMenuItem
            // 
            this.addNewCustomerToolStripMenuItem.Name = "addNewCustomerToolStripMenuItem";
            this.addNewCustomerToolStripMenuItem.Size = new System.Drawing.Size(367, 36);
            this.addNewCustomerToolStripMenuItem.Text = "Add New Customer";
            this.addNewCustomerToolStripMenuItem.Click += new System.EventHandler(this.addNewCustomerToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPrductToolStripMenuItem,
            this.showProductsToolStripMenuItem});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(128, 36);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // addNewPrductToolStripMenuItem
            // 
            this.addNewPrductToolStripMenuItem.Name = "addNewPrductToolStripMenuItem";
            this.addNewPrductToolStripMenuItem.Size = new System.Drawing.Size(291, 36);
            this.addNewPrductToolStripMenuItem.Text = "Add New Product";
            this.addNewPrductToolStripMenuItem.Click += new System.EventHandler(this.addNewPrductToolStripMenuItem_Click);
            // 
            // showProductsToolStripMenuItem
            // 
            this.showProductsToolStripMenuItem.Name = "showProductsToolStripMenuItem";
            this.showProductsToolStripMenuItem.Size = new System.Drawing.Size(291, 36);
            this.showProductsToolStripMenuItem.Text = "Show  Products";
            this.showProductsToolStripMenuItem.Click += new System.EventHandler(this.showProductsToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::StoreProject.Properties.Resources.Close_64;
            this.pictureBox1.Location = new System.Drawing.Point(739, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // transationSToolStripMenuItem
            // 
            this.transationSToolStripMenuItem.Name = "transationSToolStripMenuItem";
            this.transationSToolStripMenuItem.Size = new System.Drawing.Size(157, 36);
            this.transationSToolStripMenuItem.Text = "Transations";
            this.transationSToolStripMenuItem.Click += new System.EventHandler(this.transationSToolStripMenuItem_Click);
            // 
            // FrmVendorHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(840, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmVendorHome";
            this.Text = "ut";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vendorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorsManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewVendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCustomerToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPrductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transationSToolStripMenuItem;
    }
}

