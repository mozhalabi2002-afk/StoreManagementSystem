namespace StoreProject.Vendors
{
    partial class FrmAddEditVendor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PersonInfo = new System.Windows.Forms.TabPage();
            this.addOrEditPerson1 = new StoreProject.Customers.AddOrEditPerson();
            this.VendorInfo = new System.Windows.Forms.TabPage();
            this.ShiftFinshed = new StoreProject.TimeControl();
            this.ShiftStarted = new StoreProject.TimeControl();
            this.TBPasssword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.NUDSalary = new System.Windows.Forms.NumericUpDown();
            this.TBVendorName = new System.Windows.Forms.TextBox();
            this.LabVendorId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.timeControl1 = new StoreProject.TimeControl();
            this.ShiftStated = new StoreProject.TimeControl();
            this.timeControl2 = new StoreProject.TimeControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.PersonInfo.SuspendLayout();
            this.VendorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PersonInfo);
            this.tabControl1.Controls.Add(this.VendorInfo);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 262);
            this.tabControl1.TabIndex = 0;
            // 
            // PersonInfo
            // 
            this.PersonInfo.Controls.Add(this.addOrEditPerson1);
            this.PersonInfo.Location = new System.Drawing.Point(4, 22);
            this.PersonInfo.Name = "PersonInfo";
            this.PersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.PersonInfo.Size = new System.Drawing.Size(800, 236);
            this.PersonInfo.TabIndex = 0;
            this.PersonInfo.Text = "PersonInfo";
            this.PersonInfo.UseVisualStyleBackColor = true;
            // 
            // addOrEditPerson1
            // 
            this.addOrEditPerson1.Location = new System.Drawing.Point(6, 6);
            this.addOrEditPerson1.Name = "addOrEditPerson1";
            this.addOrEditPerson1.Size = new System.Drawing.Size(624, 142);
            this.addOrEditPerson1.TabIndex = 0;
            this.addOrEditPerson1.Load += new System.EventHandler(this.addOrEditPerson1_Load);
            // 
            // VendorInfo
            // 
            this.VendorInfo.Controls.Add(this.ShiftFinshed);
            this.VendorInfo.Controls.Add(this.ShiftStarted);
            this.VendorInfo.Controls.Add(this.TBPasssword);
            this.VendorInfo.Controls.Add(this.label7);
            this.VendorInfo.Controls.Add(this.BtnSave);
            this.VendorInfo.Controls.Add(this.NUDSalary);
            this.VendorInfo.Controls.Add(this.TBVendorName);
            this.VendorInfo.Controls.Add(this.LabVendorId);
            this.VendorInfo.Controls.Add(this.label6);
            this.VendorInfo.Controls.Add(this.label5);
            this.VendorInfo.Controls.Add(this.label4);
            this.VendorInfo.Controls.Add(this.label3);
            this.VendorInfo.Controls.Add(this.label2);
            this.VendorInfo.Controls.Add(this.label1);
            this.VendorInfo.Location = new System.Drawing.Point(4, 22);
            this.VendorInfo.Name = "VendorInfo";
            this.VendorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.VendorInfo.Size = new System.Drawing.Size(800, 236);
            this.VendorInfo.TabIndex = 1;
            this.VendorInfo.Text = "VendorInfo";
            this.VendorInfo.UseVisualStyleBackColor = true;
            // 
            // ShiftFinshed
            // 
            this.ShiftFinshed.Location = new System.Drawing.Point(262, 148);
            this.ShiftFinshed.Name = "ShiftFinshed";
            this.ShiftFinshed.Size = new System.Drawing.Size(187, 25);
            this.ShiftFinshed.TabIndex = 4;
            // 
            // ShiftStarted
            // 
            this.ShiftStarted.Location = new System.Drawing.Point(262, 105);
            this.ShiftStarted.Name = "ShiftStarted";
            this.ShiftStarted.Size = new System.Drawing.Size(187, 25);
            this.ShiftStarted.TabIndex = 2;
            // 
            // TBPasssword
            // 
            this.TBPasssword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPasssword.Location = new System.Drawing.Point(604, 60);
            this.TBPasssword.Name = "TBPasssword";
            this.TBPasssword.PasswordChar = '*';
            this.TBPasssword.Size = new System.Drawing.Size(185, 30);
            this.TBPasssword.TabIndex = 1;
            this.TBPasssword.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(460, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 29);
            this.label7.TabIndex = 14;
            this.label7.Text = "Password :";
            // 
            // BtnSave
            // 
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(668, 172);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(98, 48);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // NUDSalary
            // 
            this.NUDSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NUDSalary.Cursor = System.Windows.Forms.Cursors.Default;
            this.NUDSalary.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDSalary.Increment = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            this.NUDSalary.Location = new System.Drawing.Point(691, 105);
            this.NUDSalary.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NUDSalary.Name = "NUDSalary";
            this.NUDSalary.Size = new System.Drawing.Size(91, 30);
            this.NUDSalary.TabIndex = 3;
            this.NUDSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBVendorName
            // 
            this.TBVendorName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBVendorName.Location = new System.Drawing.Point(262, 63);
            this.TBVendorName.Name = "TBVendorName";
            this.TBVendorName.Size = new System.Drawing.Size(185, 30);
            this.TBVendorName.TabIndex = 0;
            this.TBVendorName.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // LabVendorId
            // 
            this.LabVendorId.AutoSize = true;
            this.LabVendorId.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabVendorId.Location = new System.Drawing.Point(262, 21);
            this.LabVendorId.Name = "LabVendorId";
            this.LabVendorId.Size = new System.Drawing.Size(91, 29);
            this.LabVendorId.TabIndex = 6;
            this.LabVendorId.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(89, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Permission  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(460, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Salary Per Hour  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Shift Time Finshed :  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Shift Time Started  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vendor Name  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor Id :";
            // 
            // BtnClose
            // 
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(675, 266);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(98, 48);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // timeControl1
            // 
            this.timeControl1.Location = new System.Drawing.Point(262, 105);
            this.timeControl1.Name = "timeControl1";
            this.timeControl1.Size = new System.Drawing.Size(187, 25);
            this.timeControl1.TabIndex = 16;
            // 
            // ShiftStated
            // 
            this.ShiftStated.Location = new System.Drawing.Point(262, 105);
            this.ShiftStated.Name = "ShiftStated";
            this.ShiftStated.Size = new System.Drawing.Size(187, 25);
            this.ShiftStated.TabIndex = 16;
            // 
            // timeControl2
            // 
            this.timeControl2.Location = new System.Drawing.Point(260, 144);
            this.timeControl2.Name = "timeControl2";
            this.timeControl2.Size = new System.Drawing.Size(187, 25);
            this.timeControl2.TabIndex = 17;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmAddEditVendor
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(850, 321);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddEditVendor";
            this.Text = "FrmAddEditVendor";
            this.Load += new System.EventHandler(this.FrmAddEditVendor_Load);
            this.tabControl1.ResumeLayout(false);
            this.PersonInfo.ResumeLayout(false);
            this.VendorInfo.ResumeLayout(false);
            this.VendorInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PersonInfo;
        private Customers.AddOrEditPerson addOrEditPerson1;
        private System.Windows.Forms.TabPage VendorInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUDSalary;
        private System.Windows.Forms.TextBox TBVendorName;
        private System.Windows.Forms.Label LabVendorId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TextBox TBPasssword;
        private System.Windows.Forms.Label label7;
        private TimeControl ShiftFinshed;
        private TimeControl ShiftStarted;
        private TimeControl timeControl1;
        private TimeControl ShiftStated;
        private TimeControl timeControl2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}