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
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtNominativoAutore = new System.Windows.Forms.TextBox();
            this.txtNoteAutore = new System.Windows.Forms.TextBox();
            this.txtDocumentoAbstract = new System.Windows.Forms.TextBox();
            this.ddlMaterie = new System.Windows.Forms.ComboBox();
            this.btnQueryDoc = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblExtractedDoc = new System.Windows.Forms.Label();
            this.uscTimbro = new winFormsIntf.Timbro();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDocumento
            // 
            this.grdDocumento.AllowUserToAddRows = false;
            this.grdDocumento.AllowUserToDeleteRows = false;
            this.grdDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumento.Location = new System.Drawing.Point(31, 264);
            this.grdDocumento.Name = "grdDocumento";
            this.grdDocumento.ReadOnly = true;
            this.grdDocumento.Size = new System.Drawing.Size(827, 350);
            this.grdDocumento.TabIndex = 0;
            this.grdDocumento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocumento_CellDoubleClick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(28, 631);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(30, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "stato";
            // 
            // txtNominativoAutore
            // 
            this.txtNominativoAutore.Location = new System.Drawing.Point(31, 67);
            this.txtNominativoAutore.Multiline = true;
            this.txtNominativoAutore.Name = "txtNominativoAutore";
            this.txtNominativoAutore.Size = new System.Drawing.Size(134, 73);
            this.txtNominativoAutore.TabIndex = 3;
            // 
            // txtNoteAutore
            // 
            this.txtNoteAutore.Location = new System.Drawing.Point(31, 164);
            this.txtNoteAutore.Multiline = true;
            this.txtNoteAutore.Name = "txtNoteAutore";
            this.txtNoteAutore.Size = new System.Drawing.Size(134, 77);
            this.txtNoteAutore.TabIndex = 4;
            // 
            // txtDocumentoAbstract
            // 
            this.txtDocumentoAbstract.Location = new System.Drawing.Point(209, 67);
            this.txtDocumentoAbstract.Multiline = true;
            this.txtDocumentoAbstract.Name = "txtDocumentoAbstract";
            this.txtDocumentoAbstract.Size = new System.Drawing.Size(190, 73);
            this.txtDocumentoAbstract.TabIndex = 5;
            // 
            // ddlMaterie
            // 
            this.ddlMaterie.FormattingEnabled = true;
            this.ddlMaterie.Location = new System.Drawing.Point(209, 164);
            this.ddlMaterie.Name = "ddlMaterie";
            this.ddlMaterie.Size = new System.Drawing.Size(190, 21);
            this.ddlMaterie.TabIndex = 6;
            // 
            // btnQueryDoc
            // 
            this.btnQueryDoc.Location = new System.Drawing.Point(464, 67);
            this.btnQueryDoc.Name = "btnQueryDoc";
            this.btnQueryDoc.Size = new System.Drawing.Size(394, 23);
            this.btnQueryDoc.TabIndex = 7;
            this.btnQueryDoc.Text = "Query Documento mediante filtri: Autore, Materia, Abstract";
            this.btnQueryDoc.UseVisualStyleBackColor = true;
            this.btnQueryDoc.Click += new System.EventHandler(this.btnQueryDoc_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblExtractedDoc
            // 
            this.lblExtractedDoc.AutoSize = true;
            this.lblExtractedDoc.Location = new System.Drawing.Point(206, 228);
            this.lblExtractedDoc.Name = "lblExtractedDoc";
            this.lblExtractedDoc.Size = new System.Drawing.Size(35, 13);
            this.lblExtractedDoc.TabIndex = 8;
            this.lblExtractedDoc.Text = "label1";
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
            this.ClientSize = new System.Drawing.Size(897, 666);
            this.Controls.Add(this.lblExtractedDoc);
            this.Controls.Add(this.btnQueryDoc);
            this.Controls.Add(this.ddlMaterie);
            this.Controls.Add(this.txtDocumentoAbstract);
            this.Controls.Add(this.txtNoteAutore);
            this.Controls.Add(this.txtNominativoAutore);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.uscTimbro);
            this.Controls.Add(this.grdDocumento);
            this.Name = "frmDocumentoLoad";
            this.Text = "frmDocumentoLoad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDocumentoLoad_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDocumento;
        private Timbro uscTimbro;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtNominativoAutore;
        private System.Windows.Forms.TextBox txtNoteAutore;
        private System.Windows.Forms.TextBox txtDocumentoAbstract;
        private System.Windows.Forms.ComboBox ddlMaterie;
        private System.Windows.Forms.Button btnQueryDoc;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblExtractedDoc;
    }
}