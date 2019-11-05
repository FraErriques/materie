namespace winFormsIntf
{
    partial class frmLogin
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
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlLoginControls = new System.Windows.Forms.Panel();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.pnlLoginControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(66, 21);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.Enter += new System.EventHandler(this.txtUser_MouseEnter);
            this.txtUser.MouseEnter += new System.EventHandler(this.txtUser_MouseEnter);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(66, 57);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 20);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.Enter += new System.EventHandler(this.txtPwd_MouseEnter);
            this.txtPwd.MouseEnter += new System.EventHandler(this.txtPwd_MouseEnter);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(91, 100);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(63, 138);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(31, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "aaaa";
            // 
            // pnlLoginControls
            // 
            this.pnlLoginControls.Controls.Add(this.txtUser);
            this.pnlLoginControls.Controls.Add(this.lblStatus);
            this.pnlLoginControls.Controls.Add(this.txtPwd);
            this.pnlLoginControls.Controls.Add(this.btnLogin);
            this.pnlLoginControls.Location = new System.Drawing.Point(608, 40);
            this.pnlLoginControls.Name = "pnlLoginControls";
            this.pnlLoginControls.Size = new System.Drawing.Size(233, 166);
            this.pnlLoginControls.TabIndex = 5;
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 2);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(829, 32);
            this.uscTimbro.TabIndex = 3;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 230);
            this.Controls.Add(this.pnlLoginControls);
            this.Controls.Add(this.uscTimbro);
            this.MaximumSize = new System.Drawing.Size(950, 300);
            this.MinimumSize = new System.Drawing.Size(876, 200);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.pnlLoginControls.ResumeLayout(false);
            this.pnlLoginControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Timbro uscTimbro;
        public System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Panel pnlLoginControls;
    }
}
