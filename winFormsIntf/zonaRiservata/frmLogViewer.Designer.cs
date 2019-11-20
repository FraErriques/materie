namespace winFormsIntf
{
    partial class frmLogViewer
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
            this.grdLoggingDb = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoggingDb)).BeginInit();
            this.SuspendLayout();
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(19, 14);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(905, 66);
            this.uscTimbro.TabIndex = 0;
            // 
            // grdLoggingDb
            // 
            this.grdLoggingDb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoggingDb.Location = new System.Drawing.Point(19, 107);
            this.grdLoggingDb.Name = "grdLoggingDb";
            this.grdLoggingDb.Size = new System.Drawing.Size(905, 494);
            this.grdLoggingDb.TabIndex = 1;
            // 
            // frmLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 624);
            this.Controls.Add(this.grdLoggingDb);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmLogViewer";
            this.Text = "frmLogViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogViewer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdLoggingDb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.DataGridView grdLoggingDb;
    }
}
