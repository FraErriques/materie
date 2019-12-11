namespace winFormsIntf.prototype
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrototype));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Read = new System.Windows.Forms.DataGridViewImageColumn();
            this.imbDoSomething = new System.Windows.Forms.DataGridViewImageColumn();
            this.UpdateAbstract = new System.Windows.Forms.DataGridViewImageColumn();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.interfacePager1 = new winFormsIntf.InterfacePager();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nominativo,
            this.note,
            this.RowNumber,
            this.Read,
            this.imbDoSomething,
            this.UpdateAbstract});
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(883, 349);
            this.dataGridView1.TabIndex = 5;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id Autore";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 70;
            // 
            // nominativo
            // 
            this.nominativo.DataPropertyName = "nominativo";
            this.nominativo.HeaderText = "nominativo Autore";
            this.nominativo.Name = "nominativo";
            this.nominativo.ReadOnly = true;
            this.nominativo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nominativo.Width = 70;
            // 
            // note
            // 
            this.note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.note.DataPropertyName = "note";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.note.DefaultCellStyle = dataGridViewCellStyle3;
            this.note.HeaderText = "note Autore";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.note.Width = 61;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.RowNumber.HeaderText = "RowNumber in View";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowNumber.Width = 70;
            // 
            // Read
            // 
            this.Read.HeaderText = "Read";
            this.Read.Image = ((System.Drawing.Image)(resources.GetObject("Read.Image")));
            this.Read.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Read.Name = "Read";
            this.Read.ReadOnly = true;
            this.Read.Width = 40;
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
            // UpdateAbstract
            // 
            this.UpdateAbstract.HeaderText = "UpdateAbstract";
            this.UpdateAbstract.Image = ((System.Drawing.Image)(resources.GetObject("UpdateAbstract.Image")));
            this.UpdateAbstract.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.UpdateAbstract.Name = "UpdateAbstract";
            this.UpdateAbstract.ReadOnly = true;
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(911, 60);
            this.uscTimbro.TabIndex = 0;
            // 
            // interfacePager1
            // 
            this.interfacePager1.Location = new System.Drawing.Point(158, 419);
            this.interfacePager1.Name = "interfacePager1";
            this.interfacePager1.Size = new System.Drawing.Size(472, 107);
            this.interfacePager1.TabIndex = 6;
            // 
            // frmPrototype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 581);
            this.Controls.Add(this.interfacePager1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmPrototype";
            this.Text = "frmPrototype";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrototype_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewImageColumn Read;
        private System.Windows.Forms.DataGridViewImageColumn imbDoSomething;
        private System.Windows.Forms.DataGridViewImageColumn UpdateAbstract;
        private InterfacePager interfacePager1;
    }
}