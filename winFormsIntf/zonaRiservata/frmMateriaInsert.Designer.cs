namespace winFormsIntf
{
    partial class frmMateriaInsert
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
            this.lsbMaterie = new System.Windows.Forms.ListBox();
            this.btnCommit = new System.Windows.Forms.Button();
            this.lblStato = new System.Windows.Forms.Label();
            this.txtMateriaNew = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(30, 29);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(903, 51);
            this.uscTimbro.TabIndex = 0;
            // 
            // lsbMaterie
            // 
            this.lsbMaterie.Enabled = false;
            this.lsbMaterie.FormattingEnabled = true;
            this.lsbMaterie.Location = new System.Drawing.Point(30, 86);
            this.lsbMaterie.Name = "lsbMaterie";
            this.lsbMaterie.Size = new System.Drawing.Size(442, 316);
            this.lsbMaterie.TabIndex = 1;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(397, 440);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 2;
            this.btnCommit.Text = "Commit Insert Materia";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(27, 450);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(30, 13);
            this.lblStato.TabIndex = 3;
            this.lblStato.Text = "stato";
            // 
            // txtMateriaNew
            // 
            this.txtMateriaNew.Location = new System.Drawing.Point(30, 417);
            this.txtMateriaNew.Name = "txtMateriaNew";
            this.txtMateriaNew.Size = new System.Drawing.Size(328, 20);
            this.txtMateriaNew.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(499, 86);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh Materia list";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmMateriaInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 518);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtMateriaNew);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.lsbMaterie);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmMateriaInsert";
            this.Text = "frmMateriaInsert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMateriaInsert_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.ListBox lsbMaterie;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.TextBox txtMateriaNew;
        private System.Windows.Forms.Button btnRefresh;
    }
}