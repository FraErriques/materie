namespace winFormsIntf
{
    partial class frmLogViewer
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
            this.grdLoggingDb = new System.Windows.Forms.DataGridView();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateStart = new System.Windows.Forms.Label();
            this.btnLogQuery = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.uscInterfacePager_logLocalhost = new winFormsIntf.InterfacePager();
            this.uscTimbro = new winFormsIntf.Timbro();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoggingDb)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLoggingDb
            // 
            this.grdLoggingDb.BackgroundColor = System.Drawing.Color.Goldenrod;
            this.grdLoggingDb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoggingDb.Location = new System.Drawing.Point(19, 107);
            this.grdLoggingDb.Name = "grdLoggingDb";
            this.grdLoggingDb.ReadOnly = true;
            this.grdLoggingDb.Size = new System.Drawing.Size(905, 494);
            this.grdLoggingDb.TabIndex = 1;
            this.grdLoggingDb.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLoggingDb_CellContentClick);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(19, 648);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 2;
            // 
            // lblDateStart
            // 
            this.lblDateStart.AutoSize = true;
            this.lblDateStart.Location = new System.Drawing.Point(16, 632);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(121, 13);
            this.lblDateStart.TabIndex = 3;
            this.lblDateStart.Text = "Start Day of Log interval";
            // 
            // btnLogQuery
            // 
            this.btnLogQuery.Location = new System.Drawing.Point(19, 721);
            this.btnLogQuery.Name = "btnLogQuery";
            this.btnLogQuery.Size = new System.Drawing.Size(75, 23);
            this.btnLogQuery.TabIndex = 5;
            this.btnLogQuery.Text = "Log Query";
            this.btnLogQuery.UseVisualStyleBackColor = true;
            this.btnLogQuery.Click += new System.EventHandler(this.btnLogQuery_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(19, 695);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 6;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.BackColor = System.Drawing.SystemColors.Control;
            this.lblDateEnd.Location = new System.Drawing.Point(16, 679);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(118, 13);
            this.lblDateEnd.TabIndex = 7;
            this.lblDateEnd.Text = "End Day of Log interval";
            // 
            // uscInterfacePager_logLocalhost
            // 
            this.uscInterfacePager_logLocalhost.Location = new System.Drawing.Point(333, 620);
            this.uscInterfacePager_logLocalhost.Name = "uscInterfacePager_logLocalhost";
            this.uscInterfacePager_logLocalhost.Size = new System.Drawing.Size(591, 107);
            this.uscInterfacePager_logLocalhost.TabIndex = 4;
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(19, 14);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(905, 66);
            this.uscTimbro.TabIndex = 0;
            // 
            // frmLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 756);
            this.Controls.Add(this.lblDateEnd);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.btnLogQuery);
            this.Controls.Add(this.uscInterfacePager_logLocalhost);
            this.Controls.Add(this.lblDateStart);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.grdLoggingDb);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmLogViewer";
            this.Text = "frmLogViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogViewer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdLoggingDb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timbro uscTimbro;
        private InterfacePager uscInterfacePager_logLocalhost;
        //
        private System.Windows.Forms.DataGridView grdLoggingDb;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateStart;
        private System.Windows.Forms.Button btnLogQuery;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblDateEnd;
    }
}
