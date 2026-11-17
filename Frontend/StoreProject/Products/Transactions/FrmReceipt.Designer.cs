namespace StoreProject.Products
{
    partial class FrmReceipt
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
            this.BtnPay = new System.Windows.Forms.Button();
            this.BtnCanecl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LabTotalAmount = new System.Windows.Forms.Label();
            this.TBPaidAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBDetailPaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(516, 396);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // BtnPay
            // 
            this.BtnPay.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPay.ForeColor = System.Drawing.Color.Coral;
            this.BtnPay.Location = new System.Drawing.Point(411, 394);
            this.BtnPay.Name = "BtnPay";
            this.BtnPay.Size = new System.Drawing.Size(93, 39);
            this.BtnPay.TabIndex = 1;
            this.BtnPay.Text = "Pay";
            this.BtnPay.UseVisualStyleBackColor = false;
            this.BtnPay.Click += new System.EventHandler(this.BtnPay_Click);
            // 
            // BtnCanecl
            // 
            this.BtnCanecl.BackColor = System.Drawing.Color.Red;
            this.BtnCanecl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCanecl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCanecl.Location = new System.Drawing.Point(411, 433);
            this.BtnCanecl.Name = "BtnCanecl";
            this.BtnCanecl.Size = new System.Drawing.Size(93, 39);
            this.BtnCanecl.TabIndex = 2;
            this.BtnCanecl.Text = "Cancel";
            this.BtnCanecl.UseVisualStyleBackColor = false;
            this.BtnCanecl.Click += new System.EventHandler(this.BtnCanecl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "TotalAmount: ";
            // 
            // LabTotalAmount
            // 
            this.LabTotalAmount.AutoSize = true;
            this.LabTotalAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTotalAmount.Location = new System.Drawing.Point(232, 410);
            this.LabTotalAmount.Name = "LabTotalAmount";
            this.LabTotalAmount.Size = new System.Drawing.Size(60, 23);
            this.LabTotalAmount.TabIndex = 4;
            this.LabTotalAmount.Text = "[????]";
            // 
            // TBPaidAmount
            // 
            this.TBPaidAmount.Location = new System.Drawing.Point(222, 452);
            this.TBPaidAmount.Name = "TBPaidAmount";
            this.TBPaidAmount.Size = new System.Drawing.Size(115, 20);
            this.TBPaidAmount.TabIndex = 5;
            this.TBPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBPaidAmount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Paid Amount : ";
            // 
            // TBDetailPaid
            // 
            this.TBDetailPaid.Location = new System.Drawing.Point(222, 478);
            this.TBDetailPaid.Multiline = true;
            this.TBDetailPaid.Name = "TBDetailPaid";
            this.TBDetailPaid.Size = new System.Drawing.Size(282, 77);
            this.TBDetailPaid.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Detail Paid : ";
            // 
            // FrmReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 567);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBDetailPaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBPaidAmount);
            this.Controls.Add(this.LabTotalAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCanecl);
            this.Controls.Add(this.BtnPay);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Location = new System.Drawing.Point(0, 80);
            this.Name = "FrmReceipt";
            this.Text = "FrmReceipt";
            this.Load += new System.EventHandler(this.FrmReceipt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnPay;
        private System.Windows.Forms.Button BtnCanecl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabTotalAmount;
        private System.Windows.Forms.TextBox TBPaidAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBDetailPaid;
        private System.Windows.Forms.Label label3;
    }
}