namespace winFormsIntf
{
    partial class frmDocumentoLoad
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
            this.grdDocumento = new System.Windows.Forms.DataGridView();
            this.uscTimbro = new winFormsIntf.Timbro();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDocumento
            // 
            this.grdDocumento.AllowUserToAddRows = false;
            this.grdDocumento.AllowUserToDeleteRows = false;
            this.grdDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumento.Location = new System.Drawing.Point(31, 88);
            this.grdDocumento.Name = "grdDocumento";
            this.grdDocumento.ReadOnly = true;
            this.grdDocumento.Size = new System.Drawing.Size(1018, 343);
            this.grdDocumento.TabIndex = 0;
            this.grdDocumento.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdDocumento_CellMouseDoubleClick);
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(31, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(827, 32);
            this.uscTimbro.TabIndex = 1;
            // 
            // frmDocumentoLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 443);
            this.Controls.Add(this.uscTimbro);
            this.Controls.Add(this.grdDocumento);
            this.Name = "frmDocumentoLoad";
            this.Text = "frmDocumentoLoad";
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDocumento;
        private Timbro uscTimbro;
    }
}