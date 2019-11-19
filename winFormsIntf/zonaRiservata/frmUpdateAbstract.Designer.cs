namespace winFormsIntf
{
    partial class frmUpdateAbstract
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
            this.uscTimbro.Location = new System.Drawing.Point(17, 27);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(903, 32);
            this.uscTimbro.TabIndex = 0;
            // 
            // frmUpdateAbstract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 352);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmUpdateAbstract";
            this.Text = "frmUpdateAbstract";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateAbstract_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
    }
}