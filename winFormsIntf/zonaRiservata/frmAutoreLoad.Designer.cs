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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoreLoad));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAutoriNominativoNote = new System.Windows.Forms.Button();
            this.lblNoteAutore = new System.Windows.Forms.Label();
            this.lblNominativoAutore = new System.Windows.Forms.Label();
            this.txtNoteAutore = new System.Windows.Forms.TextBox();
            this.txtNominativoAutore = new System.Windows.Forms.TextBox();
            this.grdAutoriNominativoNote = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.write = new System.Windows.Forms.DataGridViewImageColumn();
            this.updateNoteAutore = new System.Windows.Forms.DataGridViewImageColumn();
            this.updateNameAutore = new System.Windows.Forms.DataGridViewImageColumn();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblStatusAonMat = new System.Windows.Forms.Label();
            this.uscInterfacePager_AutoriNominativoNote = new winFormsIntf.InterfacePager();
            this.uscInterfacePager_AutoreOnMateria = new winFormsIntf.InterfacePager();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.idAutore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeAutore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.singleKeyMateria = new System.Windows.Forms.DataGridViewImageColumn();
            this.updateNomeMateria = new System.Windows.Forms.DataGridViewImageColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoriNominativoNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoriMateria)).BeginInit();
            this.grpDoubleKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAutoriNominativoNote
            // 
            this.btnAutoriNominativoNote.Location = new System.Drawing.Point(12, 576);
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
            this.lblNoteAutore.Location = new System.Drawing.Point(9, 305);
            this.lblNoteAutore.Name = "lblNoteAutore";
            this.lblNoteAutore.Size = new System.Drawing.Size(247, 13);
            this.lblNoteAutore.TabIndex = 9;
            this.lblNoteAutore.Text = "Note sull\' Autore: elementi da utilizzare nella ricerca";
            // 
            // lblNominativoAutore
            // 
            this.lblNominativoAutore.AutoSize = true;
            this.lblNominativoAutore.Location = new System.Drawing.Point(9, 76);
            this.lblNominativoAutore.Name = "lblNominativoAutore";
            this.lblNominativoAutore.Size = new System.Drawing.Size(257, 13);
            this.lblNominativoAutore.TabIndex = 8;
            this.lblNominativoAutore.Text = "Nominativo Autore: elementi da utilizzare nella ricerca";
            // 
            // txtNoteAutore
            // 
            this.txtNoteAutore.Location = new System.Drawing.Point(12, 321);
            this.txtNoteAutore.Multiline = true;
            this.txtNoteAutore.Name = "txtNoteAutore";
            this.txtNoteAutore.Size = new System.Drawing.Size(365, 231);
            this.txtNoteAutore.TabIndex = 7;
            // 
            // txtNominativoAutore
            // 
            this.txtNominativoAutore.Location = new System.Drawing.Point(12, 104);
            this.txtNominativoAutore.Multiline = true;
            this.txtNominativoAutore.Name = "txtNominativoAutore";
            this.txtNominativoAutore.Size = new System.Drawing.Size(365, 188);
            this.txtNominativoAutore.TabIndex = 6;
            // 
            // grdAutoriNominativoNote
            // 
            this.grdAutoriNominativoNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAutoriNominativoNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nominativo,
            this.note,
            this.write,
            this.updateNoteAutore,
            this.updateNameAutore,
            this.Row});
            this.grdAutoriNominativoNote.Location = new System.Drawing.Point(12, 616);
            this.grdAutoriNominativoNote.Name = "grdAutoriNominativoNote";
            this.grdAutoriNominativoNote.ReadOnly = true;
            this.grdAutoriNominativoNote.Size = new System.Drawing.Size(909, 163);
            this.grdAutoriNominativoNote.TabIndex = 11;
            this.grdAutoriNominativoNote.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAutoriNominativoNote_CellClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 21;
            // 
            // nominativo
            // 
            this.nominativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nominativo.DataPropertyName = "nominativo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nominativo.DefaultCellStyle = dataGridViewCellStyle2;
            this.nominativo.HeaderText = "Autore";
            this.nominativo.MinimumWidth = 40;
            this.nominativo.Name = "nominativo";
            this.nominativo.ReadOnly = true;
            this.nominativo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nominativo.Width = 44;
            // 
            // note
            // 
            this.note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.note.DataPropertyName = "note";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "some notes as example";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.note.DefaultCellStyle = dataGridViewCellStyle3;
            this.note.HeaderText = "note Autore";
            this.note.MinimumWidth = 160;
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.note.Width = 520;
            // 
            // write
            // 
            this.write.HeaderText = "singleKey idAutore";
            this.write.Image = ((System.Drawing.Image)(resources.GetObject("write.Image")));
            this.write.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.write.Name = "write";
            this.write.ReadOnly = true;
            this.write.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.write.Width = 70;
            // 
            // updateNoteAutore
            // 
            this.updateNoteAutore.HeaderText = "update noteAutore";
            this.updateNoteAutore.Image = ((System.Drawing.Image)(resources.GetObject("updateNoteAutore.Image")));
            this.updateNoteAutore.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.updateNoteAutore.Name = "updateNoteAutore";
            this.updateNoteAutore.ReadOnly = true;
            this.updateNoteAutore.Width = 70;
            // 
            // updateNameAutore
            // 
            this.updateNameAutore.HeaderText = "update Autore";
            this.updateNameAutore.Image = ((System.Drawing.Image)(resources.GetObject("updateNameAutore.Image")));
            this.updateNameAutore.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.updateNameAutore.Name = "updateNameAutore";
            this.updateNameAutore.ReadOnly = true;
            this.updateNameAutore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.updateNameAutore.Width = 70;
            // 
            // Row
            // 
            this.Row.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Row.DataPropertyName = "RowNumber";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Row.DefaultCellStyle = dataGridViewCellStyle4;
            this.Row.HeaderText = "Row";
            this.Row.MinimumWidth = 20;
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            this.Row.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Row.Width = 35;
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
            this.ddlMaterie.Location = new System.Drawing.Point(413, 104);
            this.ddlMaterie.Name = "ddlMaterie";
            this.ddlMaterie.Size = new System.Drawing.Size(318, 21);
            this.ddlMaterie.TabIndex = 16;
            this.ddlMaterie.SelectedIndexChanged += new System.EventHandler(this.ddlMaterie_SelectedIndexChanged);
            // 
            // btnPublishMateriaFromCombo
            // 
            this.btnPublishMateriaFromCombo.Location = new System.Drawing.Point(748, 102);
            this.btnPublishMateriaFromCombo.Name = "btnPublishMateriaFromCombo";
            this.btnPublishMateriaFromCombo.Size = new System.Drawing.Size(173, 23);
            this.btnPublishMateriaFromCombo.TabIndex = 17;
            this.btnPublishMateriaFromCombo.Text = "Seleziona Materia da Combo";
            this.btnPublishMateriaFromCombo.UseVisualStyleBackColor = true;
            this.btnPublishMateriaFromCombo.Click += new System.EventHandler(this.btnPublishMateriaFromCombo_Click);
            // 
            // btnAutoriByArticoliPubblicati
            // 
            this.btnAutoriByArticoliPubblicati.Location = new System.Drawing.Point(413, 131);
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
            this.grdAutoriMateria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAutore,
            this.nomeAutore,
            this.idMateria,
            this.nomeMateria,
            this.singleKeyMateria,
            this.updateNomeMateria,
            this.RowNumber});
            this.grdAutoriMateria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdAutoriMateria.Location = new System.Drawing.Point(413, 169);
            this.grdAutoriMateria.Name = "grdAutoriMateria";
            this.grdAutoriMateria.ReadOnly = true;
            this.grdAutoriMateria.Size = new System.Drawing.Size(508, 194);
            this.grdAutoriMateria.TabIndex = 19;
            this.grdAutoriMateria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAutoriMateria_CellClick);
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
            this.grpDoubleKey.Location = new System.Drawing.Point(12, 788);
            this.grpDoubleKey.Name = "grpDoubleKey";
            this.grpDoubleKey.Size = new System.Drawing.Size(357, 166);
            this.grpDoubleKey.TabIndex = 22;
            this.grpDoubleKey.TabStop = false;
            this.grpDoubleKey.Text = "DoubleKey building and verification";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "singleKey idAutore";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 70;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "update noteAutore";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 70;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "update Autore";
            this.dataGridViewImageColumn3.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn3.Image")));
            this.dataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.Width = 70;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "singleKeyMateria";
            this.dataGridViewImageColumn4.Image = global::winFormsIntf.Properties.Resources.btnAddDoc;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.HeaderText = "update Nome Materia";
            this.dataGridViewImageColumn5.Image = global::winFormsIntf.Properties.Resources.btnUpdateAbstract;
            this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            this.dataGridViewImageColumn5.ReadOnly = true;
            // 
            // lblStatusAonMat
            // 
            this.lblStatusAonMat.AutoSize = true;
            this.lblStatusAonMat.Location = new System.Drawing.Point(410, 492);
            this.lblStatusAonMat.Name = "lblStatusAonMat";
            this.lblStatusAonMat.Size = new System.Drawing.Size(67, 13);
            this.lblStatusAonMat.TabIndex = 25;
            this.lblStatusAonMat.Text = "statoAonMat";
            // 
            // uscInterfacePager_AutoriNominativoNote
            // 
            this.uscInterfacePager_AutoriNominativoNote.Location = new System.Drawing.Point(390, 799);
            this.uscInterfacePager_AutoriNominativoNote.Name = "uscInterfacePager_AutoriNominativoNote";
            this.uscInterfacePager_AutoriNominativoNote.Size = new System.Drawing.Size(591, 107);
            this.uscInterfacePager_AutoriNominativoNote.TabIndex = 24;
            // 
            // uscInterfacePager_AutoreOnMateria
            // 
            this.uscInterfacePager_AutoreOnMateria.Location = new System.Drawing.Point(413, 382);
            this.uscInterfacePager_AutoreOnMateria.Name = "uscInterfacePager_AutoreOnMateria";
            this.uscInterfacePager_AutoreOnMateria.Size = new System.Drawing.Size(542, 107);
            this.uscInterfacePager_AutoreOnMateria.TabIndex = 23;
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(926, 47);
            this.uscTimbro.TabIndex = 0;
            // 
            // idAutore
            // 
            this.idAutore.DataPropertyName = "idAutore";
            this.idAutore.HeaderText = "id Aut";
            this.idAutore.Name = "idAutore";
            this.idAutore.ReadOnly = true;
            this.idAutore.Width = 30;
            // 
            // nomeAutore
            // 
            this.nomeAutore.DataPropertyName = "nomeAutore";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nomeAutore.DefaultCellStyle = dataGridViewCellStyle5;
            this.nomeAutore.HeaderText = "nome Autore";
            this.nomeAutore.Name = "nomeAutore";
            this.nomeAutore.ReadOnly = true;
            this.nomeAutore.Width = 110;
            // 
            // idMateria
            // 
            this.idMateria.DataPropertyName = "idMateria";
            this.idMateria.HeaderText = "id Mat";
            this.idMateria.Name = "idMateria";
            this.idMateria.ReadOnly = true;
            this.idMateria.Width = 30;
            // 
            // nomeMateria
            // 
            this.nomeMateria.DataPropertyName = "nomeMateria";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nomeMateria.DefaultCellStyle = dataGridViewCellStyle6;
            this.nomeMateria.HeaderText = "nome Materia";
            this.nomeMateria.Name = "nomeMateria";
            this.nomeMateria.ReadOnly = true;
            this.nomeMateria.Width = 130;
            // 
            // singleKeyMateria
            // 
            this.singleKeyMateria.HeaderText = "sKey Mat";
            this.singleKeyMateria.Image = global::winFormsIntf.Properties.Resources.btnAddDoc;
            this.singleKeyMateria.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.singleKeyMateria.Name = "singleKeyMateria";
            this.singleKeyMateria.ReadOnly = true;
            this.singleKeyMateria.Width = 70;
            // 
            // updateNomeMateria
            // 
            this.updateNomeMateria.HeaderText = "update Nome Materia";
            this.updateNomeMateria.Image = global::winFormsIntf.Properties.Resources.btnUpdateAbstract;
            this.updateNomeMateria.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.updateNomeMateria.Name = "updateNomeMateria";
            this.updateNomeMateria.ReadOnly = true;
            this.updateNomeMateria.Width = 70;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "Row";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Width = 30;
            // 
            // frmAutoreLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1004, 968);
            this.Controls.Add(this.lblStatusAonMat);
            this.Controls.Add(this.uscInterfacePager_AutoriNominativoNote);
            this.Controls.Add(this.uscInterfacePager_AutoreOnMateria);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private InterfacePager uscInterfacePager_AutoreOnMateria;
        private InterfacePager uscInterfacePager_AutoriNominativoNote;
        //
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
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewImageColumn write;
        private System.Windows.Forms.DataGridViewImageColumn updateNoteAutore;
        private System.Windows.Forms.DataGridViewImageColumn updateNameAutore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn5;
        private System.Windows.Forms.Label lblStatusAonMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutore;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeAutore;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeMateria;
        private System.Windows.Forms.DataGridViewImageColumn singleKeyMateria;
        private System.Windows.Forms.DataGridViewImageColumn updateNomeMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        
        

    }// class
}// nmsp
