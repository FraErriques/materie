namespace winFormsIntf
{
    partial class frmPrimes
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
            this.uscTimbro = new winFormsIntf.Timbro();
            this.grdPrimes = new System.Windows.Forms.DataGridView();
            this.uscInterfacePager_Prime = new winFormsIntf.InterfacePager();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrimes)).BeginInit();
            this.SuspendLayout();
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(37, 17);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(903, 52);
            this.uscTimbro.TabIndex = 0;
            // 
            // grdPrimes
            // 
            this.grdPrimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPrimes.Location = new System.Drawing.Point(37, 75);
            this.grdPrimes.Name = "grdPrimes";
            this.grdPrimes.Size = new System.Drawing.Size(915, 402);
            this.grdPrimes.TabIndex = 1;
            // 
            // uscInterfacePager_Prime
            // 
            this.uscInterfacePager_Prime.Location = new System.Drawing.Point(135, 483);
            this.uscInterfacePager_Prime.Name = "uscInterfacePager_Prime";
            this.uscInterfacePager_Prime.Size = new System.Drawing.Size(591, 107);
            this.uscInterfacePager_Prime.TabIndex = 2;
            // 
            // frmPrimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 608);
            this.Controls.Add(this.uscInterfacePager_Prime);
            this.Controls.Add(this.grdPrimes);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmPrimes";
            this.Text = "frmPrimes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrimes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrimes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
        private InterfacePager uscInterfacePager_Prime;
        private System.Windows.Forms.DataGridView grdPrimes;
        
    }// class
}// nmsp
