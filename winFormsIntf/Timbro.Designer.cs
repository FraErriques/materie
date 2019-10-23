namespace winFormsIntf
{
    partial class Timbro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuTimbro = new System.Windows.Forms.MenuStrip();
            this.autoreLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentoLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mappaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertMateriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertAutoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePwdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimbro.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuTimbro
            // 
            this.mnuTimbro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoreLoadToolStripMenuItem,
            this.documentoLToolStripMenuItem,
            this.mappaToolStripMenuItem,
            this.insertMateriaToolStripMenuItem,
            this.insertAutoreToolStripMenuItem,
            this.logToolStripMenuItem,
            this.primesToolStripMenuItem,
            this.changePwdToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.closeAppToolStripMenuItem,
            this.goToErrorToolStripMenuItem});
            this.mnuTimbro.Location = new System.Drawing.Point(0, 0);
            this.mnuTimbro.Name = "mnuTimbro";
            this.mnuTimbro.Size = new System.Drawing.Size(857, 24);
            this.mnuTimbro.TabIndex = 1;
            this.mnuTimbro.Text = "Timbro";
            // 
            // autoreLoadToolStripMenuItem
            // 
            this.autoreLoadToolStripMenuItem.Name = "autoreLoadToolStripMenuItem";
            this.autoreLoadToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.autoreLoadToolStripMenuItem.Text = "AutoreLoad";
            this.autoreLoadToolStripMenuItem.Click += new System.EventHandler(this.autoreLoadToolStripMenuItem_Click);
            // 
            // documentoLToolStripMenuItem
            // 
            this.documentoLToolStripMenuItem.Name = "documentoLToolStripMenuItem";
            this.documentoLToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.documentoLToolStripMenuItem.Text = "DocumentoLoad";
            this.documentoLToolStripMenuItem.Click += new System.EventHandler(this.documentoLToolStripMenuItem_Click);
            // 
            // mappaToolStripMenuItem
            // 
            this.mappaToolStripMenuItem.Name = "mappaToolStripMenuItem";
            this.mappaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.mappaToolStripMenuItem.Text = "Mappa";
            // 
            // insertMateriaToolStripMenuItem
            // 
            this.insertMateriaToolStripMenuItem.Name = "insertMateriaToolStripMenuItem";
            this.insertMateriaToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.insertMateriaToolStripMenuItem.Text = "InsertMateria";
            // 
            // insertAutoreToolStripMenuItem
            // 
            this.insertAutoreToolStripMenuItem.Name = "insertAutoreToolStripMenuItem";
            this.insertAutoreToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.insertAutoreToolStripMenuItem.Text = "InsertAutore";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // primesToolStripMenuItem
            // 
            this.primesToolStripMenuItem.Name = "primesToolStripMenuItem";
            this.primesToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.primesToolStripMenuItem.Text = "Primes";
            // 
            // changePwdToolStripMenuItem
            // 
            this.changePwdToolStripMenuItem.Name = "changePwdToolStripMenuItem";
            this.changePwdToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.changePwdToolStripMenuItem.Text = "ChangePwd";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // closeAppToolStripMenuItem
            // 
            this.closeAppToolStripMenuItem.Name = "closeAppToolStripMenuItem";
            this.closeAppToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.closeAppToolStripMenuItem.Text = "CloseApp";
            this.closeAppToolStripMenuItem.Click += new System.EventHandler(this.closeAppToolStripMenuItem_Click);
            // 
            // goToErrorToolStripMenuItem
            // 
            this.goToErrorToolStripMenuItem.Name = "goToErrorToolStripMenuItem";
            this.goToErrorToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.goToErrorToolStripMenuItem.Text = "GoToError";
            this.goToErrorToolStripMenuItem.Click += new System.EventHandler(this.goToErrorToolStripMenuItem_Click);
            // 
            // Timbro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mnuTimbro);
            this.Name = "Timbro";
            this.Size = new System.Drawing.Size(857, 32);
            this.Load += new System.EventHandler(this.Timbro_Load);
            this.mnuTimbro.ResumeLayout(false);
            this.mnuTimbro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuTimbro;
        private System.Windows.Forms.ToolStripMenuItem autoreLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentoLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mappaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertMateriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertAutoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePwdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToErrorToolStripMenuItem;
    }
}
