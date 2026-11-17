namespace StoreProject.Products
{
    partial class ShowProductForCustomer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productInfo1 = new StoreProject.Products.ProductInfo();
            this.BtnAddToBasket = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NUDQuantity = new System.Windows.Forms.NumericUpDown();
            this.Quantity = new System.Windows.Forms.Panel();
            this.Weight = new System.Windows.Forms.Panel();
            this.TBWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuantity)).BeginInit();
            this.Quantity.SuspendLayout();
            this.Weight.SuspendLayout();
            this.SuspendLayout();
            // 
            // productInfo1
            // 
            this.productInfo1.Location = new System.Drawing.Point(3, 3);
            this.productInfo1.Name = "productInfo1";
            this.productInfo1.Size = new System.Drawing.Size(459, 313);
            this.productInfo1.TabIndex = 0;
            this.productInfo1.Load += new System.EventHandler(this.productInfo1_Load);
            // 
            // BtnAddToBasket
            // 
            this.BtnAddToBasket.BackColor = System.Drawing.Color.Aqua;
            this.BtnAddToBasket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddToBasket.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddToBasket.Location = new System.Drawing.Point(297, 261);
            this.BtnAddToBasket.Name = "BtnAddToBasket";
            this.BtnAddToBasket.Size = new System.Drawing.Size(144, 51);
            this.BtnAddToBasket.TabIndex = 1;
            this.BtnAddToBasket.Text = "Add To Basket";
            this.BtnAddToBasket.UseVisualStyleBackColor = false;
            this.BtnAddToBasket.Click += new System.EventHandler(this.BtnAddToBasket_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quantity :";
            // 
            // NUDQuantity
            // 
            this.NUDQuantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDQuantity.Location = new System.Drawing.Point(103, 3);
            this.NUDQuantity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NUDQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDQuantity.Name = "NUDQuantity";
            this.NUDQuantity.Size = new System.Drawing.Size(120, 27);
            this.NUDQuantity.TabIndex = 3;
            this.NUDQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUDQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Quantity
            // 
            this.Quantity.Controls.Add(this.NUDQuantity);
            this.Quantity.Controls.Add(this.label1);
            this.Quantity.Location = new System.Drawing.Point(243, 62);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(221, 33);
            this.Quantity.TabIndex = 4;
            // 
            // Weight
            // 
            this.Weight.Controls.Add(this.TBWeight);
            this.Weight.Controls.Add(this.label2);
            this.Weight.Location = new System.Drawing.Point(243, 110);
            this.Weight.Name = "Weight";
            this.Weight.Size = new System.Drawing.Size(221, 33);
            this.Weight.TabIndex = 5;
            // 
            // TBWeight
            // 
            this.TBWeight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBWeight.Location = new System.Drawing.Point(101, 3);
            this.TBWeight.Name = "TBWeight";
            this.TBWeight.Size = new System.Drawing.Size(117, 30);
            this.TBWeight.TabIndex = 3;
            this.TBWeight.Text = "1";
            this.TBWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBWeight_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Weight :";
            // 
            // ShowProductForCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Weight);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.BtnAddToBasket);
            this.Controls.Add(this.productInfo1);
            this.Name = "ShowProductForCustomer";
            this.Size = new System.Drawing.Size(467, 321);
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuantity)).EndInit();
            this.Quantity.ResumeLayout(false);
            this.Quantity.PerformLayout();
            this.Weight.ResumeLayout(false);
            this.Weight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ProductInfo productInfo1;
        private System.Windows.Forms.Button BtnAddToBasket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUDQuantity;
        private System.Windows.Forms.Panel Quantity;
        private System.Windows.Forms.Panel Weight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBWeight;
    }
}
