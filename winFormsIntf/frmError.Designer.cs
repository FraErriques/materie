namespace winFormsIntf
{
    partial class frmError
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
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnGoLogin = new System.Windows.Forms.Button();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(12, 148);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(438, 169);
            this.txtStatus.TabIndex = 0;
            // 
            // btnGoLogin
            // 
            this.btnGoLogin.Location = new System.Drawing.Point(12, 107);
            this.btnGoLogin.Name = "btnGoLogin";
            this.btnGoLogin.Size = new System.Drawing.Size(217, 23);
            this.btnGoLogin.TabIndex = 1;
            this.btnGoLogin.Text = "Pagina Login";
            this.btnGoLogin.UseVisualStyleBackColor = true;
            this.btnGoLogin.Click += new System.EventHandler(this.btnGoLogin_Click);
            // 
            // timbro1
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 12);
            this.uscTimbro.Name = "timbro1";
            this.uscTimbro.Size = new System.Drawing.Size(857, 32);
            this.uscTimbro.TabIndex = 2;
            // 
            // frmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 329);
            this.Controls.Add(this.uscTimbro);
            this.Controls.Add(this.btnGoLogin);
            this.Controls.Add(this.txtStatus);
            this.Name = "frmError";
            this.Text = "frmError";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnGoLogin;
        private Timbro uscTimbro;
    }
}