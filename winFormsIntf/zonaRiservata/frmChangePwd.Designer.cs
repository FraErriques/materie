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
            this.uscTimbro = new winFormsIntf.Timbro();
            this.SuspendLayout();
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
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmChangePwd";
            this.Text = "frmChangePwd";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChangePwd_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
    }
}
