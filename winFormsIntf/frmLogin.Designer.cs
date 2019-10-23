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
            this.uscTimbro = new winFormsIntf.Timbro();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(288, 126);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.Enter += new System.EventHandler(this.txtUser_MouseEnter);
            this.txtUser.MouseEnter += new System.EventHandler(this.txtUser_MouseEnter);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(288, 152);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 20);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.Enter += new System.EventHandler(this.txtPwd_MouseEnter);
            this.txtPwd.MouseEnter += new System.EventHandler(this.txtPwd_MouseEnter);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(313, 197);
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
            this.lblStatus.Location = new System.Drawing.Point(32, 237);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(187, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 2);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(778, 32);
            this.uscTimbro.TabIndex = 3;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 273);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.uscTimbro);
            this.MaximumSize = new System.Drawing.Size(876, 300);
            this.MinimumSize = new System.Drawing.Size(876, 300);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Timbro uscTimbro;
        public System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.Label lblStatus;
    }
}
