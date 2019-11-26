namespace winFormsIntf
{
    partial class frmPrototype
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrototype));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.docFullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uscTimbro = new winFormsIntf.Timbro();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblChunkUno = new System.Windows.Forms.Label();
            this.lblChunkDue = new System.Windows.Forms.Label();
            this.idAutore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominativoAutore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imbDoSomething = new System.Windows.Forms.DataGridViewImageColumn();
            this.Read = new System.Windows.Forms.DataGridViewImageColumn();
            this.UpdateAbstract = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(326, 548);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(114, 549);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(126, 20);
            this.domainUpDown1.TabIndex = 2;
            this.domainUpDown1.Text = "domainUpDown1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(515, 539);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(120, 30);
            this.listBox1.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.docFullPath,
            this.colDue});
            this.listView1.Location = new System.Drawing.Point(658, 532);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(299, 37);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // docFullPath
            // 
            this.docFullPath.Text = "Doc full path";
            this.docFullPath.Width = 957;
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(911, 60);
            this.uscTimbro.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAutore,
            this.nominativoAutore,
            this.imbDoSomething,
            this.Read,
            this.UpdateAbstract});
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(883, 393);
            this.dataGridView1.TabIndex = 5;
            // 
            // lblChunkUno
            // 
            this.lblChunkUno.AutoSize = true;
            this.lblChunkUno.Location = new System.Drawing.Point(268, 477);
            this.lblChunkUno.Name = "lblChunkUno";
            this.lblChunkUno.Size = new System.Drawing.Size(68, 13);
            this.lblChunkUno.TabIndex = 6;
            this.lblChunkUno.Text = "lblChunkUno";
            this.lblChunkUno.Click += new System.EventHandler(this.lblChunkUno_Click);
            // 
            // lblChunkDue
            // 
            this.lblChunkDue.AutoSize = true;
            this.lblChunkDue.Location = new System.Drawing.Point(512, 477);
            this.lblChunkDue.Name = "lblChunkDue";
            this.lblChunkDue.Size = new System.Drawing.Size(68, 13);
            this.lblChunkDue.TabIndex = 7;
            this.lblChunkDue.Text = "lblChunkDue";
            this.lblChunkDue.Click += new System.EventHandler(this.lblChunkDue_Click);
            // 
            // idAutore
            // 
            this.idAutore.DataPropertyName = "id";
            this.idAutore.HeaderText = "ID Materia";
            this.idAutore.Name = "idAutore";
            this.idAutore.ReadOnly = true;
            this.idAutore.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nominativoAutore
            // 
            this.nominativoAutore.DataPropertyName = "nomeMateria";
            this.nominativoAutore.HeaderText = "Materia";
            this.nominativoAutore.Name = "nominativoAutore";
            this.nominativoAutore.ReadOnly = true;
            // 
            // imbDoSomething
            // 
            this.imbDoSomething.HeaderText = "Write";
            this.imbDoSomething.Image = ((System.Drawing.Image)(resources.GetObject("imbDoSomething.Image")));
            this.imbDoSomething.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imbDoSomething.Name = "imbDoSomething";
            this.imbDoSomething.ReadOnly = true;
            this.imbDoSomething.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Read
            // 
            this.Read.HeaderText = "Read";
            this.Read.Image = ((System.Drawing.Image)(resources.GetObject("Read.Image")));
            this.Read.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Read.Name = "Read";
            this.Read.ReadOnly = true;
            // 
            // UpdateAbstract
            // 
            this.UpdateAbstract.HeaderText = "UpdateAbstract";
            this.UpdateAbstract.Image = ((System.Drawing.Image)(resources.GetObject("UpdateAbstract.Image")));
            this.UpdateAbstract.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.UpdateAbstract.Name = "UpdateAbstract";
            this.UpdateAbstract.ReadOnly = true;
            // 
            // frmPrototype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 581);
            this.Controls.Add(this.lblChunkDue);
            this.Controls.Add(this.lblChunkUno);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmPrototype";
            this.Text = "frmPrototype";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrototype_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader docFullPath;
        private System.Windows.Forms.ColumnHeader colDue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblChunkUno;
        private System.Windows.Forms.Label lblChunkDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutore;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominativoAutore;
        private System.Windows.Forms.DataGridViewImageColumn imbDoSomething;
        private System.Windows.Forms.DataGridViewImageColumn Read;
        private System.Windows.Forms.DataGridViewImageColumn UpdateAbstract;
    }
}