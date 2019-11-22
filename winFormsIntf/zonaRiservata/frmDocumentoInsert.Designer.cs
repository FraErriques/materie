namespace winFormsIntf
{
    partial class frmDocumentoInsert
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
            this.txtDocumentoAbstract = new System.Windows.Forms.TextBox();
            this.btnSearchFileSystem = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lvwDocSelection = new System.Windows.Forms.ListView();
            this.colDocPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDoubleKey = new System.Windows.Forms.Label();
            this.lblEsito = new System.Windows.Forms.Label();
            this.grbDocInsert = new System.Windows.Forms.GroupBox();
            this.btnFromFsToDb = new System.Windows.Forms.Button();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.grbDocInsert.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDocumentoAbstract
            // 
            this.txtDocumentoAbstract.Location = new System.Drawing.Point(6, 21);
            this.txtDocumentoAbstract.Multiline = true;
            this.txtDocumentoAbstract.Name = "txtDocumentoAbstract";
            this.txtDocumentoAbstract.Size = new System.Drawing.Size(356, 297);
            this.txtDocumentoAbstract.TabIndex = 1;
            // 
            // btnSearchFileSystem
            // 
            this.btnSearchFileSystem.Location = new System.Drawing.Point(393, 21);
            this.btnSearchFileSystem.Name = "btnSearchFileSystem";
            this.btnSearchFileSystem.Size = new System.Drawing.Size(267, 23);
            this.btnSearchFileSystem.TabIndex = 2;
            this.btnSearchFileSystem.Text = "Search FileSystem for documents to upload";
            this.btnSearchFileSystem.UseVisualStyleBackColor = true;
            this.btnSearchFileSystem.Click += new System.EventHandler(this.btnSearchFileSystem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // lvwDocSelection
            // 
            this.lvwDocSelection.CheckBoxes = true;
            this.lvwDocSelection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDocPath});
            this.lvwDocSelection.Location = new System.Drawing.Point(393, 50);
            this.lvwDocSelection.Name = "lvwDocSelection";
            this.lvwDocSelection.Size = new System.Drawing.Size(366, 268);
            this.lvwDocSelection.TabIndex = 3;
            this.lvwDocSelection.UseCompatibleStateImageBehavior = false;
            this.lvwDocSelection.View = System.Windows.Forms.View.Details;
            // 
            // colDocPath
            // 
            this.colDocPath.Text = "full path of Document";
            this.colDocPath.Width = 960;
            // 
            // lblDoubleKey
            // 
            this.lblDoubleKey.AutoSize = true;
            this.lblDoubleKey.Location = new System.Drawing.Point(300, 87);
            this.lblDoubleKey.Name = "lblDoubleKey";
            this.lblDoubleKey.Size = new System.Drawing.Size(110, 13);
            this.lblDoubleKey.TabIndex = 4;
            this.lblDoubleKey.Text = "DoubleKey translation";
            // 
            // lblEsito
            // 
            this.lblEsito.AutoSize = true;
            this.lblEsito.Location = new System.Drawing.Point(15, 516);
            this.lblEsito.Name = "lblEsito";
            this.lblEsito.Size = new System.Drawing.Size(29, 13);
            this.lblEsito.TabIndex = 5;
            this.lblEsito.Text = "esito";
            // 
            // grbDocInsert
            // 
            this.grbDocInsert.Controls.Add(this.btnFromFsToDb);
            this.grbDocInsert.Controls.Add(this.txtDocumentoAbstract);
            this.grbDocInsert.Controls.Add(this.lvwDocSelection);
            this.grbDocInsert.Controls.Add(this.btnSearchFileSystem);
            this.grbDocInsert.Location = new System.Drawing.Point(12, 115);
            this.grbDocInsert.Name = "grbDocInsert";
            this.grbDocInsert.Size = new System.Drawing.Size(808, 380);
            this.grbDocInsert.TabIndex = 6;
            this.grbDocInsert.TabStop = false;
            this.grbDocInsert.Text = "Documento Insert";
            // 
            // btnFromFsToDb
            // 
            this.btnFromFsToDb.Location = new System.Drawing.Point(578, 335);
            this.btnFromFsToDb.Name = "btnFromFsToDb";
            this.btnFromFsToDb.Size = new System.Drawing.Size(181, 23);
            this.btnFromFsToDb.TabIndex = 4;
            this.btnFromFsToDb.Text = "Upload from FileSystem to Db";
            this.btnFromFsToDb.UseVisualStyleBackColor = true;
            this.btnFromFsToDb.Click += new System.EventHandler(this.btnFromFsToDb_Click);
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(891, 52);
            this.uscTimbro.TabIndex = 0;
            // 
            // frmDocumentoInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(932, 547);
            this.Controls.Add(this.grbDocInsert);
            this.Controls.Add(this.lblEsito);
            this.Controls.Add(this.lblDoubleKey);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmDocumentoInsert";
            this.Text = "frmDocumentoInsert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDocumentoInsert_FormClosed);
            this.grbDocInsert.ResumeLayout(false);
            this.grbDocInsert.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.TextBox txtDocumentoAbstract;
        private System.Windows.Forms.Button btnSearchFileSystem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView lvwDocSelection;
        private System.Windows.Forms.ColumnHeader colDocPath;
        private System.Windows.Forms.Label lblDoubleKey;
        private System.Windows.Forms.Label lblEsito;
        private System.Windows.Forms.GroupBox grbDocInsert;
        private System.Windows.Forms.Button btnFromFsToDb;
    }
}