namespace StoreProject.Products
{
    partial class FrmAddEditProduct
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
            this.LabAddress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TBProductName = new System.Windows.Forms.TextBox();
            this.TBPrice = new System.Windows.Forms.TextBox();
            this.TBWeight = new System.Windows.Forms.TextBox();
            this.TBSize = new System.Windows.Forms.TextBox();
            this.PbProductImage = new System.Windows.Forms.PictureBox();
            this.PbBarCode = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CBCategoryName = new System.Windows.Forms.ComboBox();
            this.NUDQuantity = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.CBSaleType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // LabAddress
            // 
            this.LabAddress.AutoSize = true;
            this.LabAddress.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabAddress.ForeColor = System.Drawing.Color.Yellow;
            this.LabAddress.Location = new System.Drawing.Point(249, 9);
            this.LabAddress.Name = "LabAddress";
            this.LabAddress.Size = new System.Drawing.Size(342, 45);
            this.LabAddress.TabIndex = 0;
            this.LabAddress.Text = "Add New Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quantity :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(264, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Price : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(254, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Weight :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(270, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Size : ";
            // 
            // TBProductName
            // 
            this.TBProductName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBProductName.Location = new System.Drawing.Point(339, 70);
            this.TBProductName.Name = "TBProductName";
            this.TBProductName.Size = new System.Drawing.Size(131, 23);
            this.TBProductName.TabIndex = 7;
            this.TBProductName.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // TBPrice
            // 
            this.TBPrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPrice.Location = new System.Drawing.Point(339, 314);
            this.TBPrice.Name = "TBPrice";
            this.TBPrice.Size = new System.Drawing.Size(131, 23);
            this.TBPrice.TabIndex = 8;
            this.TBPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            this.TBPrice.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // TBWeight
            // 
            this.TBWeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBWeight.Location = new System.Drawing.Point(339, 349);
            this.TBWeight.Name = "TBWeight";
            this.TBWeight.Size = new System.Drawing.Size(131, 23);
            this.TBWeight.TabIndex = 9;
            this.TBWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // TBSize
            // 
            this.TBSize.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBSize.Location = new System.Drawing.Point(339, 391);
            this.TBSize.Name = "TBSize";
            this.TBSize.Size = new System.Drawing.Size(131, 23);
            this.TBSize.TabIndex = 10;
            this.TBSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // PbProductImage
            // 
            this.PbProductImage.Location = new System.Drawing.Point(339, 113);
            this.PbProductImage.Name = "PbProductImage";
            this.PbProductImage.Size = new System.Drawing.Size(131, 79);
            this.PbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbProductImage.TabIndex = 11;
            this.PbProductImage.TabStop = false;
            this.PbProductImage.Validating += new System.ComponentModel.CancelEventHandler(this.PbProductImage_Validating);
            // 
            // PbBarCode
            // 
            this.PbBarCode.Location = new System.Drawing.Point(643, 187);
            this.PbBarCode.Name = "PbBarCode";
            this.PbBarCode.Size = new System.Drawing.Size(135, 84);
            this.PbBarCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbBarCode.TabIndex = 12;
            this.PbBarCode.TabStop = false;
            this.PbBarCode.Click += new System.EventHandler(this.PbBarCode_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(210, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Product Image :";
            // 
            // CBCategoryName
            // 
            this.CBCategoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCategoryName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCategoryName.FormattingEnabled = true;
            this.CBCategoryName.Location = new System.Drawing.Point(339, 217);
            this.CBCategoryName.Name = "CBCategoryName";
            this.CBCategoryName.Size = new System.Drawing.Size(131, 24);
            this.CBCategoryName.TabIndex = 14;
            // 
            // NUDQuantity
            // 
            this.NUDQuantity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDQuantity.Location = new System.Drawing.Point(339, 282);
            this.NUDQuantity.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NUDQuantity.Name = "NUDQuantity";
            this.NUDQuantity.Size = new System.Drawing.Size(131, 23);
            this.NUDQuantity.TabIndex = 15;
            this.NUDQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(549, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "BarCode :";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(499, 143);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(108, 23);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Set Image";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(655, 275);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(108, 23);
            this.linkLabel2.TabIndex = 18;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Set Image";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSave.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.Yellow;
            this.BtnSave.Location = new System.Drawing.Point(257, 431);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(257, 59);
            this.BtnSave.TabIndex = 19;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StoreProject.Properties.Resources.Close_64;
            this.pictureBox1.Location = new System.Drawing.Point(699, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CBSaleType
            // 
            this.CBSaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSaleType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBSaleType.FormattingEnabled = true;
            this.CBSaleType.Items.AddRange(new object[] {
            "Quantity",
            "Weight"});
            this.CBSaleType.Location = new System.Drawing.Point(339, 247);
            this.CBSaleType.Name = "CBSaleType";
            this.CBSaleType.Size = new System.Drawing.Size(131, 24);
            this.CBSaleType.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(249, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Sale By : ";
            // 
            // FrmAddEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(17, 2);
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(802, 521);
            this.Controls.Add(this.CBSaleType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.NUDQuantity);
            this.Controls.Add(this.CBCategoryName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PbBarCode);
            this.Controls.Add(this.PbProductImage);
            this.Controls.Add(this.TBSize);
            this.Controls.Add(this.TBWeight);
            this.Controls.Add(this.TBPrice);
            this.Controls.Add(this.TBProductName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LabAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddEditProduct";
            this.Text = "FrmAddEditProduct";
            this.Load += new System.EventHandler(this.FrmAddEditProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBProductName;
        private System.Windows.Forms.TextBox TBPrice;
        private System.Windows.Forms.TextBox TBWeight;
        private System.Windows.Forms.TextBox TBSize;
        private System.Windows.Forms.PictureBox PbProductImage;
        private System.Windows.Forms.PictureBox PbBarCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBCategoryName;
        private System.Windows.Forms.NumericUpDown NUDQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox CBSaleType;
        private System.Windows.Forms.Label label9;
    }
}