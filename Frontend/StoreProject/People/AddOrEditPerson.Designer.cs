namespace StoreProject.Customers
{
    partial class AddOrEditPerson
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TBFirstName = new System.Windows.Forms.TextBox();
            this.TBSecondName = new System.Windows.Forms.TextBox();
            this.TBLastName = new System.Windows.Forms.TextBox();
            this.TBPhoneNumber = new System.Windows.Forms.TextBox();
            this.TBNO = new System.Windows.Forms.TextBox();
            this.BtnNext = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Phone Number :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(345, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "N.O : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(269, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Second Name : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Last Name : ";
            // 
            // TBFirstName
            // 
            this.TBFirstName.Location = new System.Drawing.Point(134, 15);
            this.TBFirstName.Name = "TBFirstName";
            this.TBFirstName.Size = new System.Drawing.Size(129, 20);
            this.TBFirstName.TabIndex = 0;
            this.TBFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // TBSecondName
            // 
            this.TBSecondName.Location = new System.Drawing.Point(425, 13);
            this.TBSecondName.Name = "TBSecondName";
            this.TBSecondName.Size = new System.Drawing.Size(129, 20);
            this.TBSecondName.TabIndex = 1;
            this.TBSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // TBLastName
            // 
            this.TBLastName.Location = new System.Drawing.Point(135, 52);
            this.TBLastName.Name = "TBLastName";
            this.TBLastName.Size = new System.Drawing.Size(129, 20);
            this.TBLastName.TabIndex = 2;
            this.TBLastName.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // TBPhoneNumber
            // 
            this.TBPhoneNumber.Location = new System.Drawing.Point(152, 95);
            this.TBPhoneNumber.Name = "TBPhoneNumber";
            this.TBPhoneNumber.Size = new System.Drawing.Size(129, 20);
            this.TBPhoneNumber.TabIndex = 4;
            this.TBPhoneNumber.Validating += new System.ComponentModel.CancelEventHandler(this.PhoneNumber_Validating);
            // 
            // TBNO
            // 
            this.TBNO.Location = new System.Drawing.Point(425, 52);
            this.TBNO.Name = "TBNO";
            this.TBNO.Size = new System.Drawing.Size(129, 20);
            this.TBNO.TabIndex = 3;
            this.TBNO.Validating += new System.ComponentModel.CancelEventHandler(this.TBNO_Validating);
            // 
            // BtnNext
            // 
            this.BtnNext.BackColor = System.Drawing.Color.White;
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNext.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNext.Location = new System.Drawing.Point(484, 96);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(92, 32);
            this.BtnNext.TabIndex = 5;
            this.BtnNext.Text = "Next";
            this.BtnNext.UseVisualStyleBackColor = false;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TBNO);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TBLastName);
            this.panel1.Controls.Add(this.TBFirstName);
            this.panel1.Controls.Add(this.TBSecondName);
            this.panel1.Location = new System.Drawing.Point(17, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 86);
            this.panel1.TabIndex = 11;
            this.panel1.TabStop = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddOrEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.TBPhoneNumber);
            this.Controls.Add(this.label3);
            this.Name = "AddOrEditPerson";
            this.Size = new System.Drawing.Size(624, 142);
            this.Enter += new System.EventHandler(this.AddOrEditPerson_Enter);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBFirstName;
        private System.Windows.Forms.TextBox TBSecondName;
        private System.Windows.Forms.TextBox TBLastName;
        private System.Windows.Forms.TextBox TBPhoneNumber;
        private System.Windows.Forms.TextBox TBNO;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
