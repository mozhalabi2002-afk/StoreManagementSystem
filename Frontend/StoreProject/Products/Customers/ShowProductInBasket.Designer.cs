namespace StoreProject.Products
{
    partial class ShowProductInBasket
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
            this.Quantity = new System.Windows.Forms.Panel();
            this.NUDQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.Weight = new System.Windows.Forms.Panel();
            this.TBWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Quantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuantity)).BeginInit();
            this.Weight.SuspendLayout();
            this.SuspendLayout();
            // 
            // productInfo1
            // 
            this.productInfo1.Location = new System.Drawing.Point(3, 3);
            this.productInfo1.Name = "productInfo1";
            this.productInfo1.Size = new System.Drawing.Size(494, 271);
            this.productInfo1.TabIndex = 0;
            // 
            // Quantity
            // 
            this.Quantity.Controls.Add(this.NUDQuantity);
            this.Quantity.Controls.Add(this.label1);
            this.Quantity.Location = new System.Drawing.Point(261, 105);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(221, 33);
            this.Quantity.TabIndex = 5;
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
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.Red;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(375, 310);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(104, 40);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // Weight
            // 
            this.Weight.Controls.Add(this.TBWeight);
            this.Weight.Controls.Add(this.label2);
            this.Weight.Location = new System.Drawing.Point(261, 144);
            this.Weight.Name = "Weight";
            this.Weight.Size = new System.Drawing.Size(221, 33);
            this.Weight.TabIndex = 6;
            // 
            // TBWeight
            // 
            this.TBWeight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBWeight.Location = new System.Drawing.Point(103, 2);
            this.TBWeight.Name = "TBWeight";
            this.TBWeight.Size = new System.Drawing.Size(115, 27);
            this.TBWeight.TabIndex = 7;
            this.TBWeight.Text = "1";
            this.TBWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBWeight_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Weight :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(375, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowProductInBasket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Weight);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.productInfo1);
            this.Name = "ShowProductInBasket";
            this.Size = new System.Drawing.Size(500, 350);
            this.Load += new System.EventHandler(this.ShowProductInBasket_Load);
            this.Quantity.ResumeLayout(false);
            this.Quantity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuantity)).EndInit();
            this.Weight.ResumeLayout(false);
            this.Weight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ProductInfo productInfo1;
        private System.Windows.Forms.Panel Quantity;
        private System.Windows.Forms.NumericUpDown NUDQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Panel Weight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBWeight;
        private System.Windows.Forms.Button button1;
    }
}
