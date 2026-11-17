namespace StoreProject.Products
{
    partial class FrmTransactionManagment
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
            this.label1 = new System.Windows.Forms.Label();
            this.DGVTransactions = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TBFilter = new System.Windows.Forms.TextBox();
            this.CBFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LabRecord = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(285, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 33);
            this.label1.TabIndex = 12;
            this.label1.Text = "Transations Operation";
            // 
            // DGVTransactions
            // 
            this.DGVTransactions.BackgroundColor = System.Drawing.Color.White;
            this.DGVTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTransactions.GridColor = System.Drawing.Color.White;
            this.DGVTransactions.Location = new System.Drawing.Point(26, 142);
            this.DGVTransactions.Name = "DGVTransactions";
            this.DGVTransactions.Size = new System.Drawing.Size(840, 258);
            this.DGVTransactions.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StoreProject.Properties.Resources.Close_64;
            this.pictureBox1.Location = new System.Drawing.Point(763, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(702, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 50);
            this.button1.TabIndex = 19;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TBFilter
            // 
            this.TBFilter.Location = new System.Drawing.Point(303, 102);
            this.TBFilter.Name = "TBFilter";
            this.TBFilter.Size = new System.Drawing.Size(156, 20);
            this.TBFilter.TabIndex = 17;
            this.TBFilter.TextChanged += new System.EventHandler(this.TBFilter_TextChanged);
            this.TBFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBFilter_KeyPress);
            // 
            // CBFilter
            // 
            this.CBFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFilter.FormattingEnabled = true;
            this.CBFilter.Items.AddRange(new object[] {
            "None",
            "Transaction Id",
            "Order Id",
            "First Name",
            "Last Name",
            "N.o",
            "Phone Number",
            "Total Amount",
            "Remaing Amount"});
            this.CBFilter.Location = new System.Drawing.Point(128, 102);
            this.CBFilter.Name = "CBFilter";
            this.CBFilter.Size = new System.Drawing.Size(136, 21);
            this.CBFilter.TabIndex = 16;
            this.CBFilter.SelectedIndexChanged += new System.EventHandler(this.CBFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Filter : ";
            // 
            // LabRecord
            // 
            this.LabRecord.AutoSize = true;
            this.LabRecord.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabRecord.Location = new System.Drawing.Point(181, 422);
            this.LabRecord.Name = "LabRecord";
            this.LabRecord.Size = new System.Drawing.Size(28, 29);
            this.LabRecord.TabIndex = 14;
            this.LabRecord.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "#Record : ";
            // 
            // FrmTransactionManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVTransactions);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TBFilter);
            this.Controls.Add(this.CBFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabRecord);
            this.Controls.Add(this.label2);
            this.Name = "FrmTransactionManagment";
            this.Text = "FrmTransactionManagment";
            this.Load += new System.EventHandler(this.FrmTransactionManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVTransactions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBFilter;
        private System.Windows.Forms.ComboBox CBFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LabRecord;
        private System.Windows.Forms.Label label2;
    }
}