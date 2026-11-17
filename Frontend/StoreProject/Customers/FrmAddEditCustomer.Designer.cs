namespace StoreProject.Customers
{
    partial class FrmAddEditCustomer
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
            this.CustomerInfo = new System.Windows.Forms.TabPage();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TBPasswordConfirm = new System.Windows.Forms.TextBox();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.TBCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LabCustomerId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PBClose = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.addOrEditPerson1 = new StoreProject.Customers.AddOrEditPerson();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.PersonInfo.SuspendLayout();
            this.CustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PersonInfo);
            this.tabControl1.Controls.Add(this.CustomerInfo);
            this.tabControl1.Location = new System.Drawing.Point(12, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 227);
            this.tabControl1.TabIndex = 0;
            // 
            // PersonInfo
            // 
            this.PersonInfo.Controls.Add(this.addOrEditPerson1);
            this.PersonInfo.Location = new System.Drawing.Point(4, 22);
            this.PersonInfo.Name = "PersonInfo";
            this.PersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.PersonInfo.Size = new System.Drawing.Size(655, 201);
            this.PersonInfo.TabIndex = 0;
            this.PersonInfo.Text = "Person Info";
            this.PersonInfo.UseVisualStyleBackColor = true;
            // 
            // CustomerInfo
            // 
            this.CustomerInfo.Controls.Add(this.button1);
            this.CustomerInfo.Controls.Add(this.BtnSave);
            this.CustomerInfo.Controls.Add(this.TBPasswordConfirm);
            this.CustomerInfo.Controls.Add(this.TBPassword);
            this.CustomerInfo.Controls.Add(this.TBCustomerName);
            this.CustomerInfo.Controls.Add(this.label2);
            this.CustomerInfo.Controls.Add(this.label4);
            this.CustomerInfo.Controls.Add(this.label3);
            this.CustomerInfo.Controls.Add(this.LabCustomerId);
            this.CustomerInfo.Controls.Add(this.label1);
            this.CustomerInfo.Location = new System.Drawing.Point(4, 22);
            this.CustomerInfo.Name = "CustomerInfo";
            this.CustomerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.CustomerInfo.Size = new System.Drawing.Size(655, 201);
            this.CustomerInfo.TabIndex = 1;
            this.CustomerInfo.Text = "Customer Info";
            this.CustomerInfo.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(545, 102);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(104, 50);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TBPasswordConfirm
            // 
            this.TBPasswordConfirm.Location = new System.Drawing.Point(263, 153);
            this.TBPasswordConfirm.Name = "TBPasswordConfirm";
            this.TBPasswordConfirm.PasswordChar = '*';
            this.TBPasswordConfirm.Size = new System.Drawing.Size(118, 20);
            this.TBPasswordConfirm.TabIndex = 2;
            this.TBPasswordConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.TBPasswordConfirm_Validating);
            // 
            // TBPassword
            // 
            this.TBPassword.Location = new System.Drawing.Point(263, 119);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '*';
            this.TBPassword.Size = new System.Drawing.Size(118, 20);
            this.TBPassword.TabIndex = 1;
            this.TBPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // TBCustomerName
            // 
            this.TBCustomerName.Location = new System.Drawing.Point(263, 81);
            this.TBCustomerName.Name = "TBCustomerName";
            this.TBCustomerName.Size = new System.Drawing.Size(118, 20);
            this.TBCustomerName.TabIndex = 0;
            this.TBCustomerName.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password Confirm :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(106, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer Name :";
            // 
            // LabCustomerId
            // 
            this.LabCustomerId.AutoSize = true;
            this.LabCustomerId.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabCustomerId.Location = new System.Drawing.Point(270, 31);
            this.LabCustomerId.Name = "LabCustomerId";
            this.LabCustomerId.Size = new System.Drawing.Size(80, 25);
            this.LabCustomerId.TabIndex = 1;
            this.LabCustomerId.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Id :";
            // 
            // PBClose
            // 
            this.PBClose.Image = global::StoreProject.Properties.Resources.Close_64;
            this.PBClose.Location = new System.Drawing.Point(571, 12);
            this.PBClose.Name = "PBClose";
            this.PBClose.Size = new System.Drawing.Size(100, 50);
            this.PBClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBClose.TabIndex = 1;
            this.PBClose.TabStop = false;
            this.PBClose.Click += new System.EventHandler(this.PBClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // addOrEditPerson1
            // 
            this.addOrEditPerson1.Location = new System.Drawing.Point(6, 6);
            this.addOrEditPerson1.Name = "addOrEditPerson1";
            this.addOrEditPerson1.Size = new System.Drawing.Size(624, 142);
            this.addOrEditPerson1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(545, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAddEditCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 310);
            this.Controls.Add(this.PBClose);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddEditCustomer";
            this.Text = "FrmAddEditCustomer";
            this.Load += new System.EventHandler(this.FrmAddEditCustomer_Load);
            this.tabControl1.ResumeLayout(false);
            this.PersonInfo.ResumeLayout(false);
            this.CustomerInfo.ResumeLayout(false);
            this.CustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PersonInfo;
        private AddOrEditPerson addOrEditPerson1;
        private System.Windows.Forms.TabPage CustomerInfo;
        private System.Windows.Forms.TextBox TBPasswordConfirm;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.TextBox TBCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LabCustomerId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.PictureBox PBClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
    }
}