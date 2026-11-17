namespace StoreProject.Products
{
    partial class Item
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
            this.Lab = new System.Windows.Forms.Label();
            this.LabProductName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LabPrice = new System.Windows.Forms.Label();
            this.LabType = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.Label();
            this.TotalAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lab
            // 
            this.Lab.AutoSize = true;
            this.Lab.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab.Location = new System.Drawing.Point(12, 12);
            this.Lab.Name = "Lab";
            this.Lab.Size = new System.Drawing.Size(135, 19);
            this.Lab.TabIndex = 0;
            this.Lab.Text = "Product Name :";
            // 
            // LabProductName
            // 
            this.LabProductName.AutoSize = true;
            this.LabProductName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabProductName.Location = new System.Drawing.Point(153, 12);
            this.LabProductName.Name = "LabProductName";
            this.LabProductName.Size = new System.Drawing.Size(59, 19);
            this.LabProductName.TabIndex = 1;
            this.LabProductName.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price : ";
            // 
            // LabPrice
            // 
            this.LabPrice.AutoSize = true;
            this.LabPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabPrice.Location = new System.Drawing.Point(153, 40);
            this.LabPrice.Name = "LabPrice";
            this.LabPrice.Size = new System.Drawing.Size(59, 19);
            this.LabPrice.TabIndex = 3;
            this.LabPrice.Text = "[????]";
            // 
            // LabType
            // 
            this.LabType.AutoSize = true;
            this.LabType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabType.Location = new System.Drawing.Point(312, 12);
            this.LabType.Name = "LabType";
            this.LabType.Size = new System.Drawing.Size(60, 19);
            this.LabType.TabIndex = 4;
            this.LabType.Text = "Type :";
            // 
            // Type
            // 
            this.Type.AutoSize = true;
            this.Type.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Type.Location = new System.Drawing.Point(378, 12);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(59, 19);
            this.Type.TabIndex = 5;
            this.Type.Text = "[????]";
            // 
            // TotalAmount
            // 
            this.TotalAmount.AutoSize = true;
            this.TotalAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmount.Location = new System.Drawing.Point(378, 40);
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Size = new System.Drawing.Size(59, 19);
            this.TotalAmount.TabIndex = 7;
            this.TotalAmount.Text = "[????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(240, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Total Amount :";
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.TotalAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.LabType);
            this.Controls.Add(this.LabPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabProductName);
            this.Controls.Add(this.Lab);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(550, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lab;
        private System.Windows.Forms.Label LabProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LabPrice;
        private System.Windows.Forms.Label LabType;
        private System.Windows.Forms.Label Type;
        private System.Windows.Forms.Label TotalAmount;
        private System.Windows.Forms.Label label8;
    }
}
