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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idAutore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominativoAutore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imbDoSomething = new System.Windows.Forms.DataGridViewImageColumn();
            this.Read = new System.Windows.Forms.DataGridViewImageColumn();
            this.UpdateAbstract = new System.Windows.Forms.DataGridViewImageColumn();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.uscPager = new winFormsIntf.Pager();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(883, 349);
            this.dataGridView1.TabIndex = 5;
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
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(911, 60);
            this.uscTimbro.TabIndex = 0;
            // 
            // uscPager
            // 
            this.uscPager.Location = new System.Drawing.Point(208, 429);
            this.uscPager.Name = "uscPager";
            this.uscPager.Size = new System.Drawing.Size(505, 127);
            this.uscPager.TabIndex = 6;
            // 
            // frmPrototype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 581);
            this.Controls.Add(this.uscPager);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutore;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominativoAutore;
        private System.Windows.Forms.DataGridViewImageColumn imbDoSomething;
        private System.Windows.Forms.DataGridViewImageColumn Read;
        private System.Windows.Forms.DataGridViewImageColumn UpdateAbstract;
        private Pager uscPager;
    }
}