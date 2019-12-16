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
            this.lsbMaterie = new System.Windows.Forms.ListBox();
            this.btnCommit = new System.Windows.Forms.Button();
            this.lblStato = new System.Windows.Forms.Label();
            this.txtMateriaNew = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grbMateriaInsert = new System.Windows.Forms.GroupBox();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.grbMateriaInsert.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbMaterie
            // 
            this.lsbMaterie.Enabled = false;
            this.lsbMaterie.FormattingEnabled = true;
            this.lsbMaterie.Location = new System.Drawing.Point(22, 19);
            this.lsbMaterie.Name = "lsbMaterie";
            this.lsbMaterie.ScrollAlwaysVisible = true;
            this.lsbMaterie.Size = new System.Drawing.Size(442, 316);
            this.lsbMaterie.TabIndex = 1;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(389, 341);
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
            this.lblStato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStato.Location = new System.Drawing.Point(19, 385);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(37, 16);
            this.lblStato.TabIndex = 3;
            this.lblStato.Text = "stato";
            // 
            // txtMateriaNew
            // 
            this.txtMateriaNew.Location = new System.Drawing.Point(22, 341);
            this.txtMateriaNew.Name = "txtMateriaNew";
            this.txtMateriaNew.Size = new System.Drawing.Size(328, 20);
            this.txtMateriaNew.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(598, 105);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh Materia list";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grbMateriaInsert
            // 
            this.grbMateriaInsert.Controls.Add(this.lsbMaterie);
            this.grbMateriaInsert.Controls.Add(this.txtMateriaNew);
            this.grbMateriaInsert.Controls.Add(this.lblStato);
            this.grbMateriaInsert.Controls.Add(this.btnCommit);
            this.grbMateriaInsert.Location = new System.Drawing.Point(30, 86);
            this.grbMateriaInsert.Name = "grbMateriaInsert";
            this.grbMateriaInsert.Size = new System.Drawing.Size(508, 420);
            this.grbMateriaInsert.TabIndex = 6;
            this.grbMateriaInsert.TabStop = false;
            this.grbMateriaInsert.Text = "Elenco delle Materie ad oggi censite";
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(30, 29);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(903, 51);
            this.uscTimbro.TabIndex = 0;
            // 
            // frmMateriaInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(989, 518);
            this.Controls.Add(this.grbMateriaInsert);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmMateriaInsert";
            this.Text = "frmMateriaInsert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMateriaInsert_FormClosed);
            this.grbMateriaInsert.ResumeLayout(false);
            this.grbMateriaInsert.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.ListBox lsbMaterie;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.TextBox txtMateriaNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grbMateriaInsert;
    }
}