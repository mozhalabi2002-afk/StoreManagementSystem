namespace StoreProject.Products
{
    partial class ShowProductsForCustomers
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CBCategoryName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PBBasket = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnPay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PBBasket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 141);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1139, 309);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // CBCategoryName
            // 
            this.CBCategoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCategoryName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCategoryName.FormattingEnabled = true;
            this.CBCategoryName.Items.AddRange(new object[] {
            "All"});
            this.CBCategoryName.Location = new System.Drawing.Point(100, 105);
            this.CBCategoryName.Name = "CBCategoryName";
            this.CBCategoryName.Size = new System.Drawing.Size(144, 27);
            this.CBCategoryName.TabIndex = 7;
            this.CBCategoryName.SelectedIndexChanged += new System.EventHandler(this.CBCategoryName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-107, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Category Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(399, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "Shows Products";
            // 
            // PBBasket
            // 
            this.PBBasket.BackColor = System.Drawing.Color.White;
            this.PBBasket.Image = global::StoreProject.Properties.Resources.download__1_;
            this.PBBasket.Location = new System.Drawing.Point(1017, 77);
            this.PBBasket.Name = "PBBasket";
            this.PBBasket.Size = new System.Drawing.Size(110, 55);
            this.PBBasket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBBasket.TabIndex = 10;
            this.PBBasket.TabStop = false;
            this.PBBasket.Click += new System.EventHandler(this.PBBasket_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StoreProject.Properties.Resources.Close_64;
            this.pictureBox1.Location = new System.Drawing.Point(947, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BtnPay
            // 
            this.BtnPay.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPay.Location = new System.Drawing.Point(888, 77);
            this.BtnPay.Name = "BtnPay";
            this.BtnPay.Size = new System.Drawing.Size(110, 55);
            this.BtnPay.TabIndex = 11;
            this.BtnPay.Text = "Pay";
            this.BtnPay.UseVisualStyleBackColor = true;
            this.BtnPay.Click += new System.EventHandler(this.BtnPay_Click);
            // 
            // ShowProductsForCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 450);
            this.Controls.Add(this.BtnPay);
            this.Controls.Add(this.PBBasket);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.CBCategoryName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowProductsForCustomers";
            this.Text = "ShowProductsForCustomers";
            this.Load += new System.EventHandler(this.ShowProductsForCustomers_Load);
            this.Leave += new System.EventHandler(this.ShowProductsForCustomers_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.PBBasket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox CBCategoryName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PBBasket;
        private System.Windows.Forms.Button BtnPay;
    }
}