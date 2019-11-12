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
            this.lblNominativoAutore = new System.Windows.Forms.Label();
            this.lblNoteAutore = new System.Windows.Forms.Label();
            this.lblDocumentoAbstract = new System.Windows.Forms.Label();
            this.lblMaterie = new System.Windows.Forms.Label();
            this.lblPageLogic = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.txtNominativoAutore.Size = new System.Drawing.Size(309, 73);
            this.txtNominativoAutore.TabIndex = 3;
            // 
            // txtNoteAutore
            // 
            this.txtNoteAutore.Location = new System.Drawing.Point(31, 164);
            this.txtNoteAutore.Multiline = true;
            this.txtNoteAutore.Name = "txtNoteAutore";
            this.txtNoteAutore.Size = new System.Drawing.Size(309, 77);
            this.txtNoteAutore.TabIndex = 4;
            // 
            // txtDocumentoAbstract
            // 
            this.txtDocumentoAbstract.Location = new System.Drawing.Point(389, 67);
            this.txtDocumentoAbstract.Multiline = true;
            this.txtDocumentoAbstract.Name = "txtDocumentoAbstract";
            this.txtDocumentoAbstract.Size = new System.Drawing.Size(190, 73);
            this.txtDocumentoAbstract.TabIndex = 5;
            // 
            // ddlMaterie
            // 
            this.ddlMaterie.FormattingEnabled = true;
            this.ddlMaterie.Location = new System.Drawing.Point(389, 164);
            this.ddlMaterie.Name = "ddlMaterie";
            this.ddlMaterie.Size = new System.Drawing.Size(190, 21);
            this.ddlMaterie.TabIndex = 6;
            // 
            // btnQueryDoc
            // 
            this.btnQueryDoc.Location = new System.Drawing.Point(389, 202);
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
            this.lblExtractedDoc.Location = new System.Drawing.Point(395, 238);
            this.lblExtractedDoc.Name = "lblExtractedDoc";
            this.lblExtractedDoc.Size = new System.Drawing.Size(136, 13);
            this.lblExtractedDoc.TabIndex = 8;
            this.lblExtractedDoc.Text = "extraction full path on client";
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(31, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(827, 32);
            this.uscTimbro.TabIndex = 1;
            // 
            // lblNominativoAutore
            // 
            this.lblNominativoAutore.AutoSize = true;
            this.lblNominativoAutore.Location = new System.Drawing.Point(46, 48);
            this.lblNominativoAutore.Name = "lblNominativoAutore";
            this.lblNominativoAutore.Size = new System.Drawing.Size(216, 13);
            this.lblNominativoAutore.TabIndex = 9;
            this.lblNominativoAutore.Text = "elementi di ricerca sul Nominativo dell\'Autore";
            // 
            // lblNoteAutore
            // 
            this.lblNoteAutore.AutoSize = true;
            this.lblNoteAutore.Location = new System.Drawing.Point(46, 148);
            this.lblNoteAutore.Name = "lblNoteAutore";
            this.lblNoteAutore.Size = new System.Drawing.Size(194, 13);
            this.lblNoteAutore.TabIndex = 10;
            this.lblNoteAutore.Text = "elementi di ricerca sulle Note dell\'Autore";
            // 
            // lblDocumentoAbstract
            // 
            this.lblDocumentoAbstract.AutoSize = true;
            this.lblDocumentoAbstract.Location = new System.Drawing.Point(386, 48);
            this.lblDocumentoAbstract.Name = "lblDocumentoAbstract";
            this.lblDocumentoAbstract.Size = new System.Drawing.Size(229, 13);
            this.lblDocumentoAbstract.TabIndex = 11;
            this.lblDocumentoAbstract.Text = "elementi di ricerca sull\'Abstract del Documento ";
            // 
            // lblMaterie
            // 
            this.lblMaterie.AutoSize = true;
            this.lblMaterie.Location = new System.Drawing.Point(386, 148);
            this.lblMaterie.Name = "lblMaterie";
            this.lblMaterie.Size = new System.Drawing.Size(228, 13);
            this.lblMaterie.TabIndex = 12;
            this.lblMaterie.Text = "selezione della Materia trattata nel Documento ";
            // 
            // lblPageLogic
            // 
            this.lblPageLogic.AutoSize = true;
            this.lblPageLogic.Location = new System.Drawing.Point(654, 127);
            this.lblPageLogic.Name = "lblPageLogic";
            this.lblPageLogic.Size = new System.Drawing.Size(0, 13);
            this.lblPageLogic.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(642, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 95);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "Tutti i filtri di ricerca sono opzionali e combinati fra loro in \"AND\". Altriment" +
    "i si verificano prodotti cartesiani, dato il tipo di query.";
            // 
            // frmDocumentoLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 666);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblPageLogic);
            this.Controls.Add(this.lblMaterie);
            this.Controls.Add(this.lblDocumentoAbstract);
            this.Controls.Add(this.lblNoteAutore);
            this.Controls.Add(this.lblNominativoAutore);
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
        private System.Windows.Forms.Label lblNominativoAutore;
        private System.Windows.Forms.Label lblNoteAutore;
        private System.Windows.Forms.Label lblDocumentoAbstract;
        private System.Windows.Forms.Label lblMaterie;
        private System.Windows.Forms.Label lblPageLogic;
        private System.Windows.Forms.TextBox textBox1;
    }
}