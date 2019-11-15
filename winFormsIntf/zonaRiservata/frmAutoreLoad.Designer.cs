namespace winFormsIntf
{
    partial class frmAutoreLoad
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
            this.btnAutoriNominativoNote = new System.Windows.Forms.Button();
            this.lblNoteAutore = new System.Windows.Forms.Label();
            this.lblNominativoAutore = new System.Windows.Forms.Label();
            this.txtNoteAutore = new System.Windows.Forms.TextBox();
            this.txtNominativoAutore = new System.Windows.Forms.TextBox();
            this.grdAutoriNominativoNote = new System.Windows.Forms.DataGridView();
            this.txtChiaveMateria = new System.Windows.Forms.TextBox();
            this.txtChiaveAutore = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSubmitDoubleKey = new System.Windows.Forms.Button();
            this.ddlMaterie = new System.Windows.Forms.ComboBox();
            this.btnPublishMateriaFromCombo = new System.Windows.Forms.Button();
            this.btnAutoriByArticoliPubblicati = new System.Windows.Forms.Button();
            this.grdAutoriMateria = new System.Windows.Forms.DataGridView();
            this.lblChiaveMateria = new System.Windows.Forms.Label();
            this.lblChiaveAutore = new System.Windows.Forms.Label();
            this.grpDoubleKey = new System.Windows.Forms.GroupBox();
            this.uscTimbro = new winFormsIntf.Timbro();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoriNominativoNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoriMateria)).BeginInit();
            this.grpDoubleKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAutoriNominativoNote
            // 
            this.btnAutoriNominativoNote.Location = new System.Drawing.Point(29, 550);
            this.btnAutoriNominativoNote.Name = "btnAutoriNominativoNote";
            this.btnAutoriNominativoNote.Size = new System.Drawing.Size(217, 23);
            this.btnAutoriNominativoNote.TabIndex = 10;
            this.btnAutoriNominativoNote.Text = "Query: Autori by Nominativo e Note";
            this.btnAutoriNominativoNote.UseVisualStyleBackColor = true;
            this.btnAutoriNominativoNote.Click += new System.EventHandler(this.goProxyQueryAutoriByNominativoNote);
            // 
            // lblNoteAutore
            // 
            this.lblNoteAutore.AutoSize = true;
            this.lblNoteAutore.Location = new System.Drawing.Point(26, 279);
            this.lblNoteAutore.Name = "lblNoteAutore";
            this.lblNoteAutore.Size = new System.Drawing.Size(247, 13);
            this.lblNoteAutore.TabIndex = 9;
            this.lblNoteAutore.Text = "Note sull\' Autore: elementi da utilizzare nella ricerca";
            // 
            // lblNominativoAutore
            // 
            this.lblNominativoAutore.AutoSize = true;
            this.lblNominativoAutore.Location = new System.Drawing.Point(26, 50);
            this.lblNominativoAutore.Name = "lblNominativoAutore";
            this.lblNominativoAutore.Size = new System.Drawing.Size(257, 13);
            this.lblNominativoAutore.TabIndex = 8;
            this.lblNominativoAutore.Text = "Nominativo Autore: elementi da utilizzare nella ricerca";
            // 
            // txtNoteAutore
            // 
            this.txtNoteAutore.Location = new System.Drawing.Point(29, 295);
            this.txtNoteAutore.Multiline = true;
            this.txtNoteAutore.Name = "txtNoteAutore";
            this.txtNoteAutore.Size = new System.Drawing.Size(365, 231);
            this.txtNoteAutore.TabIndex = 7;
            // 
            // txtNominativoAutore
            // 
            this.txtNominativoAutore.Location = new System.Drawing.Point(29, 78);
            this.txtNominativoAutore.Multiline = true;
            this.txtNominativoAutore.Name = "txtNominativoAutore";
            this.txtNominativoAutore.Size = new System.Drawing.Size(365, 188);
            this.txtNominativoAutore.TabIndex = 6;
            // 
            // grdAutoriNominativoNote
            // 
            this.grdAutoriNominativoNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAutoriNominativoNote.Location = new System.Drawing.Point(29, 590);
            this.grdAutoriNominativoNote.Name = "grdAutoriNominativoNote";
            this.grdAutoriNominativoNote.ReadOnly = true;
            this.grdAutoriNominativoNote.Size = new System.Drawing.Size(909, 163);
            this.grdAutoriNominativoNote.TabIndex = 11;
            this.grdAutoriNominativoNote.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAutoriNominativoNote_CellDoubleClick);
            // 
            // txtChiaveMateria
            // 
            this.txtChiaveMateria.Location = new System.Drawing.Point(19, 33);
            this.txtChiaveMateria.Name = "txtChiaveMateria";
            this.txtChiaveMateria.Size = new System.Drawing.Size(100, 20);
            this.txtChiaveMateria.TabIndex = 12;
            // 
            // txtChiaveAutore
            // 
            this.txtChiaveAutore.Location = new System.Drawing.Point(19, 59);
            this.txtChiaveAutore.Name = "txtChiaveAutore";
            this.txtChiaveAutore.Size = new System.Drawing.Size(100, 20);
            this.txtChiaveAutore.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(16, 95);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(193, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "not yet a specific status : just pre-query.";
            // 
            // btnSubmitDoubleKey
            // 
            this.btnSubmitDoubleKey.Location = new System.Drawing.Point(19, 124);
            this.btnSubmitDoubleKey.Name = "btnSubmitDoubleKey";
            this.btnSubmitDoubleKey.Size = new System.Drawing.Size(200, 23);
            this.btnSubmitDoubleKey.TabIndex = 15;
            this.btnSubmitDoubleKey.Text = "Verifica Chiave Doppia e Inserimento";
            this.btnSubmitDoubleKey.UseVisualStyleBackColor = true;
            this.btnSubmitDoubleKey.Click += new System.EventHandler(this.btnSubmitDoubleKey_Click);
            // 
            // ddlMaterie
            // 
            this.ddlMaterie.FormattingEnabled = true;
            this.ddlMaterie.Location = new System.Drawing.Point(430, 78);
            this.ddlMaterie.Name = "ddlMaterie";
            this.ddlMaterie.Size = new System.Drawing.Size(318, 21);
            this.ddlMaterie.TabIndex = 16;
            this.ddlMaterie.SelectedIndexChanged += new System.EventHandler(this.ddlMaterie_SelectedIndexChanged);
            // 
            // btnPublishMateriaFromCombo
            // 
            this.btnPublishMateriaFromCombo.Location = new System.Drawing.Point(765, 76);
            this.btnPublishMateriaFromCombo.Name = "btnPublishMateriaFromCombo";
            this.btnPublishMateriaFromCombo.Size = new System.Drawing.Size(173, 23);
            this.btnPublishMateriaFromCombo.TabIndex = 17;
            this.btnPublishMateriaFromCombo.Text = "Seleziona Materia da Combo";
            this.btnPublishMateriaFromCombo.UseVisualStyleBackColor = true;
            this.btnPublishMateriaFromCombo.Click += new System.EventHandler(this.btnPublishMateriaFromCombo_Click);
            // 
            // btnAutoriByArticoliPubblicati
            // 
            this.btnAutoriByArticoliPubblicati.Location = new System.Drawing.Point(430, 105);
            this.btnAutoriByArticoliPubblicati.Name = "btnAutoriByArticoliPubblicati";
            this.btnAutoriByArticoliPubblicati.Size = new System.Drawing.Size(349, 23);
            this.btnAutoriByArticoliPubblicati.TabIndex = 18;
            this.btnAutoriByArticoliPubblicati.Text = "Query: Autori che hanno articoli sulla Materia selezionata";
            this.btnAutoriByArticoliPubblicati.UseVisualStyleBackColor = true;
            this.btnAutoriByArticoliPubblicati.Click += new System.EventHandler(this.btnAutoriByArticoliPubblicati_Click);
            // 
            // grdAutoriMateria
            // 
            this.grdAutoriMateria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAutoriMateria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdAutoriMateria.Location = new System.Drawing.Point(430, 143);
            this.grdAutoriMateria.Name = "grdAutoriMateria";
            this.grdAutoriMateria.ReadOnly = true;
            this.grdAutoriMateria.Size = new System.Drawing.Size(508, 194);
            this.grdAutoriMateria.TabIndex = 19;
            this.grdAutoriMateria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAutoriMateria_CellDoubleClick);
            // 
            // lblChiaveMateria
            // 
            this.lblChiaveMateria.AutoSize = true;
            this.lblChiaveMateria.Location = new System.Drawing.Point(147, 40);
            this.lblChiaveMateria.Name = "lblChiaveMateria";
            this.lblChiaveMateria.Size = new System.Drawing.Size(158, 13);
            this.lblChiaveMateria.TabIndex = 20;
            this.lblChiaveMateria.Text = " ID Materia per la chiave doppia";
            // 
            // lblChiaveAutore
            // 
            this.lblChiaveAutore.AutoSize = true;
            this.lblChiaveAutore.Location = new System.Drawing.Point(147, 66);
            this.lblChiaveAutore.Name = "lblChiaveAutore";
            this.lblChiaveAutore.Size = new System.Drawing.Size(157, 13);
            this.lblChiaveAutore.TabIndex = 21;
            this.lblChiaveAutore.Text = " ID Autore per la chiave doppia ";
            // 
            // grpDoubleKey
            // 
            this.grpDoubleKey.Controls.Add(this.txtChiaveAutore);
            this.grpDoubleKey.Controls.Add(this.lblChiaveAutore);
            this.grpDoubleKey.Controls.Add(this.txtChiaveMateria);
            this.grpDoubleKey.Controls.Add(this.lblChiaveMateria);
            this.grpDoubleKey.Controls.Add(this.lblStatus);
            this.grpDoubleKey.Controls.Add(this.btnSubmitDoubleKey);
            this.grpDoubleKey.Location = new System.Drawing.Point(29, 762);
            this.grpDoubleKey.Name = "grpDoubleKey";
            this.grpDoubleKey.Size = new System.Drawing.Size(357, 166);
            this.grpDoubleKey.TabIndex = 22;
            this.grpDoubleKey.TabStop = false;
            this.grpDoubleKey.Text = "DoubleKey building and verification";
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(926, 32);
            this.uscTimbro.TabIndex = 0;
            // 
            // frmAutoreLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1004, 940);
            this.Controls.Add(this.grpDoubleKey);
            this.Controls.Add(this.grdAutoriMateria);
            this.Controls.Add(this.btnAutoriByArticoliPubblicati);
            this.Controls.Add(this.btnPublishMateriaFromCombo);
            this.Controls.Add(this.ddlMaterie);
            this.Controls.Add(this.grdAutoriNominativoNote);
            this.Controls.Add(this.btnAutoriNominativoNote);
            this.Controls.Add(this.lblNoteAutore);
            this.Controls.Add(this.lblNominativoAutore);
            this.Controls.Add(this.txtNoteAutore);
            this.Controls.Add(this.txtNominativoAutore);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmAutoreLoad";
            this.Text = "frmAutoreLoad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAutoreLoad_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoriNominativoNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoriMateria)).EndInit();
            this.grpDoubleKey.ResumeLayout(false);
            this.grpDoubleKey.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.Button btnAutoriNominativoNote;
        private System.Windows.Forms.Label lblNoteAutore;
        private System.Windows.Forms.Label lblNominativoAutore;
        private System.Windows.Forms.TextBox txtNoteAutore;
        private System.Windows.Forms.TextBox txtNominativoAutore;
        private System.Windows.Forms.DataGridView grdAutoriNominativoNote;
        private System.Windows.Forms.TextBox txtChiaveMateria;
        private System.Windows.Forms.TextBox txtChiaveAutore;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSubmitDoubleKey;
        private System.Windows.Forms.ComboBox ddlMaterie;
        private System.Windows.Forms.Button btnPublishMateriaFromCombo;
        private System.Windows.Forms.Button btnAutoriByArticoliPubblicati;
        private System.Windows.Forms.DataGridView grdAutoriMateria;
        private System.Windows.Forms.Label lblChiaveMateria;
        private System.Windows.Forms.Label lblChiaveAutore;
        private System.Windows.Forms.GroupBox grpDoubleKey;

    }
}