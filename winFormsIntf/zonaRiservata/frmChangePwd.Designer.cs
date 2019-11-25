namespace winFormsIntf
{
    partial class frmChangePwd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this.grbChangePwd = new System.Windows.Forms.GroupBox();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtConfirmNewPwd = new System.Windows.Forms.TextBox();
            this.lblOldPwd = new System.Windows.Forms.Label();
            this.lblNewPwd = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.grbChangePwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbChangePwd
            // 
            this.grbChangePwd.Controls.Add(this.btnCommit);
            this.grbChangePwd.Controls.Add(this.lblStato);
            this.grbChangePwd.Controls.Add(this.lblConfirm);
            this.grbChangePwd.Controls.Add(this.lblNewPwd);
            this.grbChangePwd.Controls.Add(this.lblOldPwd);
            this.grbChangePwd.Controls.Add(this.txtConfirmNewPwd);
            this.grbChangePwd.Controls.Add(this.txtNewPwd);
            this.grbChangePwd.Controls.Add(this.txtOldPwd);
            this.grbChangePwd.Location = new System.Drawing.Point(512, 69);
            this.grbChangePwd.Name = "grbChangePwd";
            this.grbChangePwd.Size = new System.Drawing.Size(432, 182);
            this.grbChangePwd.TabIndex = 1;
            this.grbChangePwd.TabStop = false;
            this.grbChangePwd.Text = "Chenge Password";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(194, 32);
            this.txtOldPwd.Multiline = true;
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(222, 20);
            this.txtOldPwd.TabIndex = 0;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(194, 67);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '#';
            this.txtNewPwd.Size = new System.Drawing.Size(222, 20);
            this.txtNewPwd.TabIndex = 1;
            // 
            // txtConfirmNewPwd
            // 
            this.txtConfirmNewPwd.Location = new System.Drawing.Point(194, 102);
            this.txtConfirmNewPwd.Name = "txtConfirmNewPwd";
            this.txtConfirmNewPwd.PasswordChar = '#';
            this.txtConfirmNewPwd.Size = new System.Drawing.Size(222, 20);
            this.txtConfirmNewPwd.TabIndex = 2;
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.AutoSize = true;
            this.lblOldPwd.Location = new System.Drawing.Point(38, 39);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(69, 13);
            this.lblOldPwd.TabIndex = 3;
            this.lblOldPwd.Text = "old password";
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.AutoSize = true;
            this.lblNewPwd.Location = new System.Drawing.Point(38, 74);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(75, 13);
            this.lblNewPwd.TabIndex = 4;
            this.lblNewPwd.Text = "new password";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(38, 109);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(112, 13);
            this.lblConfirm.TabIndex = 5;
            this.lblConfirm.Text = "confirm new password";
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(38, 158);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(30, 13);
            this.lblStato.TabIndex = 6;
            this.lblStato.Text = "stato";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(260, 148);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(156, 23);
            this.btnCommit.TabIndex = 7;
            this.btnCommit.Text = "Change Password";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(28, 19);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(916, 52);
            this.uscTimbro.TabIndex = 0;
            // 
            // frmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 263);
            this.Controls.Add(this.grbChangePwd);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmChangePwd";
            this.Text = "frmChangePwd";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChangePwd_FormClosed);
            this.grbChangePwd.ResumeLayout(false);
            this.grbChangePwd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.GroupBox grbChangePwd;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.Label lblNewPwd;
        private System.Windows.Forms.Label lblOldPwd;
        private System.Windows.Forms.TextBox txtConfirmNewPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtOldPwd;
    }
}
