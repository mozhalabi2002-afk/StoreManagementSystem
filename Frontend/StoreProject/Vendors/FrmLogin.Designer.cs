namespace StoreProject.Vendors
{
    partial class FrmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.LabTime = new System.Windows.Forms.Label();
            this.LabDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TBUserName = new System.Windows.Forms.TextBox();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.CHBRememberMe = new System.Windows.Forms.CheckBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.LinkSignupUp = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Urdu Typesetting", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(140, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 117);
            this.label1.TabIndex = 0;
            this.label1.Text = "Halabi Store";
            // 
            // LabTime
            // 
            this.LabTime.AutoSize = true;
            this.LabTime.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTime.ForeColor = System.Drawing.Color.White;
            this.LabTime.Location = new System.Drawing.Point(50, 9);
            this.LabTime.Name = "LabTime";
            this.LabTime.Size = new System.Drawing.Size(72, 23);
            this.LabTime.TabIndex = 1;
            this.LabTime.Text = "[????]";
            // 
            // LabDate
            // 
            this.LabDate.AutoSize = true;
            this.LabDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabDate.ForeColor = System.Drawing.Color.White;
            this.LabDate.Location = new System.Drawing.Point(50, 48);
            this.LabDate.Name = "LabDate";
            this.LabDate.Size = new System.Drawing.Size(72, 23);
            this.LabDate.TabIndex = 2;
            this.LabDate.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "User Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(171, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password :";
            // 
            // TBUserName
            // 
            this.TBUserName.Location = new System.Drawing.Point(358, 177);
            this.TBUserName.Name = "TBUserName";
            this.TBUserName.Size = new System.Drawing.Size(124, 20);
            this.TBUserName.TabIndex = 5;
            // 
            // TBPassword
            // 
            this.TBPassword.Location = new System.Drawing.Point(358, 222);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.Size = new System.Drawing.Size(124, 20);
            this.TBPassword.TabIndex = 6;
            // 
            // CHBRememberMe
            // 
            this.CHBRememberMe.AutoSize = true;
            this.CHBRememberMe.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHBRememberMe.Location = new System.Drawing.Point(297, 259);
            this.CHBRememberMe.Name = "CHBRememberMe";
            this.CHBRememberMe.Size = new System.Drawing.Size(161, 29);
            this.CHBRememberMe.TabIndex = 7;
            this.CHBRememberMe.Text = "Remeber Me";
            this.CHBRememberMe.UseVisualStyleBackColor = true;
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.Gray;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.ForeColor = System.Drawing.Color.Yellow;
            this.BtnLogin.Location = new System.Drawing.Point(160, 294);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(322, 35);
            this.BtnLogin.TabIndex = 8;
            this.BtnLogin.Text = "Log in";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            this.BtnLogin.Enter += new System.EventHandler(this.BtnLogin_Enter);
            this.BtnLogin.Leave += new System.EventHandler(this.BtnLogin_Leave);
            // 
            // LinkSignupUp
            // 
            this.LinkSignupUp.AutoSize = true;
            this.LinkSignupUp.Font = new System.Drawing.Font("Tahoma", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkSignupUp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkSignupUp.LinkColor = System.Drawing.Color.White;
            this.LinkSignupUp.Location = new System.Drawing.Point(273, 339);
            this.LinkSignupUp.Name = "LinkSignupUp";
            this.LinkSignupUp.Size = new System.Drawing.Size(92, 25);
            this.LinkSignupUp.TabIndex = 9;
            this.LinkSignupUp.TabStop = true;
            this.LinkSignupUp.Text = "Sign Up";
            this.LinkSignupUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSignupUp_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StoreProject.Properties.Resources.Close_64;
            this.pictureBox1.Location = new System.Drawing.Point(530, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.BtnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(656, 373);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LinkSignupUp);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.CHBRememberMe);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.TBUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabDate);
            this.Controls.Add(this.LabTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabTime;
        private System.Windows.Forms.Label LabDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBUserName;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.CheckBox CHBRememberMe;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.LinkLabel LinkSignupUp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}