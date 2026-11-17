namespace StoreProject
{
    partial class TimeControl
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
            this.RBAM = new System.Windows.Forms.RadioButton();
            this.RBPM = new System.Windows.Forms.RadioButton();
            this.TBHour = new System.Windows.Forms.TextBox();
            this.TBMinute = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RBAM
            // 
            this.RBAM.AutoSize = true;
            this.RBAM.Checked = true;
            this.RBAM.Location = new System.Drawing.Point(91, 2);
            this.RBAM.Name = "RBAM";
            this.RBAM.Size = new System.Drawing.Size(44, 17);
            this.RBAM.TabIndex = 1;
            this.RBAM.TabStop = true;
            this.RBAM.Text = "A.m";
            this.RBAM.UseVisualStyleBackColor = true;
            // 
            // RBPM
            // 
            this.RBPM.AutoSize = true;
            this.RBPM.Location = new System.Drawing.Point(141, 3);
            this.RBPM.Name = "RBPM";
            this.RBPM.Size = new System.Drawing.Size(43, 17);
            this.RBPM.TabIndex = 2;
            this.RBPM.Text = "P.m";
            this.RBPM.UseVisualStyleBackColor = true;
            // 
            // TBHour
            // 
            this.TBHour.Location = new System.Drawing.Point(4, 2);
            this.TBHour.Name = "TBHour";
            this.TBHour.Size = new System.Drawing.Size(28, 20);
            this.TBHour.TabIndex = 3;
            this.TBHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBHour_KeyPress);
            // 
            // TBMinute
            // 
            this.TBMinute.Location = new System.Drawing.Point(57, 2);
            this.TBMinute.Name = "TBMinute";
            this.TBMinute.Size = new System.Drawing.Size(28, 20);
            this.TBMinute.TabIndex = 4;
            this.TBMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBMinute_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = ":";
            // 
            // TimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBMinute);
            this.Controls.Add(this.TBHour);
            this.Controls.Add(this.RBPM);
            this.Controls.Add(this.RBAM);
            this.Name = "TimeControl";
            this.Size = new System.Drawing.Size(187, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton RBAM;
        private System.Windows.Forms.RadioButton RBPM;
        private System.Windows.Forms.TextBox TBHour;
        private System.Windows.Forms.TextBox TBMinute;
        private System.Windows.Forms.Label label1;
    }
}
