namespace winFormsIntf
{
    partial class frmMappa
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
            this.components = new System.ComponentModel.Container();
            this.uscTimbro = new winFormsIntf.Timbro();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView_AvailableSchemas = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(17, 27);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(903, 48);
            this.uscTimbro.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeView_AvailableSchemas
            // 
            this.treeView_AvailableSchemas.Location = new System.Drawing.Point(49, 81);
            this.treeView_AvailableSchemas.Name = "treeView_AvailableSchemas";
            this.treeView_AvailableSchemas.Size = new System.Drawing.Size(121, 97);
            this.treeView_AvailableSchemas.TabIndex = 1;
            // 
            // frmMappa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 352);
            this.Controls.Add(this.treeView_AvailableSchemas);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmMappa";
            this.Text = "frmMappa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMappa_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView_AvailableSchemas;
    }
}