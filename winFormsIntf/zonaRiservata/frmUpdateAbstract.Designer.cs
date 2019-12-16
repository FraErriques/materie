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
            this.txtContentToBeUpdated = new System.Windows.Forms.TextBox();
            this.lblStato = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.grbUpdateAbstract = new System.Windows.Forms.GroupBox();
            this.grbUpdateAbstract.SuspendLayout();
            this.SuspendLayout();
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(17, 27);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(903, 48);
            this.uscTimbro.TabIndex = 0;
            // 
            // txtContentToBeUpdated
            // 
            this.txtContentToBeUpdated.Location = new System.Drawing.Point(6, 19);
            this.txtContentToBeUpdated.Multiline = true;
            this.txtContentToBeUpdated.Name = "txtContentToBeUpdated";
            this.txtContentToBeUpdated.Size = new System.Drawing.Size(888, 415);
            this.txtContentToBeUpdated.TabIndex = 1;
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(6, 475);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(30, 13);
            this.lblStato.TabIndex = 2;
            this.lblStato.Text = "stato";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(734, 465);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(160, 23);
            this.btnCommit.TabIndex = 3;
            this.btnCommit.Text = "Commit content update";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // grbUpdateAbstract
            // 
            this.grbUpdateAbstract.Controls.Add(this.txtContentToBeUpdated);
            this.grbUpdateAbstract.Controls.Add(this.btnCommit);
            this.grbUpdateAbstract.Controls.Add(this.lblStato);
            this.grbUpdateAbstract.Location = new System.Drawing.Point(17, 81);
            this.grbUpdateAbstract.Name = "grbUpdateAbstract";
            this.grbUpdateAbstract.Size = new System.Drawing.Size(903, 503);
            this.grbUpdateAbstract.TabIndex = 4;
            this.grbUpdateAbstract.TabStop = false;
            this.grbUpdateAbstract.Text = "Content to be Updated";
            // 
            // frmUpdateAbstract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 596);
            this.Controls.Add(this.grbUpdateAbstract);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmUpdateAbstract";
            this.Text = "frmUpdateAbstract";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateAbstract_FormClosed);
            this.grbUpdateAbstract.ResumeLayout(false);
            this.grbUpdateAbstract.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.TextBox txtContentToBeUpdated;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.GroupBox grbUpdateAbstract;
    }
}