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
            this.uscTimbro = new winFormsIntf.Timbro();
            this.grdLoggingDb = new System.Windows.Forms.DataGridView();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblHowto = new System.Windows.Forms.Label();
            this.interfacePager1 = new winFormsIntf.InterfacePager();
            this.btnLogQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoggingDb)).BeginInit();
            this.SuspendLayout();
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(19, 14);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(905, 66);
            this.uscTimbro.TabIndex = 0;
            // 
            // grdLoggingDb
            // 
            this.grdLoggingDb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoggingDb.Location = new System.Drawing.Point(19, 107);
            this.grdLoggingDb.Name = "grdLoggingDb";
            this.grdLoggingDb.Size = new System.Drawing.Size(905, 494);
            this.grdLoggingDb.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(19, 648);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 2;
            // 
            // lblHowto
            // 
            this.lblHowto.AutoSize = true;
            this.lblHowto.Location = new System.Drawing.Point(16, 620);
            this.lblHowto.Name = "lblHowto";
            this.lblHowto.Size = new System.Drawing.Size(239, 13);
            this.lblHowto.TabIndex = 3;
            this.lblHowto.Text = "Log will be shown from the picked date until now.";
            // 
            // interfacePager1
            // 
            this.interfacePager1.Location = new System.Drawing.Point(333, 620);
            this.interfacePager1.Name = "interfacePager1";
            this.interfacePager1.Size = new System.Drawing.Size(591, 107);
            this.interfacePager1.TabIndex = 4;
            // 
            // btnLogQuery
            // 
            this.btnLogQuery.Location = new System.Drawing.Point(19, 688);
            this.btnLogQuery.Name = "btnLogQuery";
            this.btnLogQuery.Size = new System.Drawing.Size(75, 23);
            this.btnLogQuery.TabIndex = 5;
            this.btnLogQuery.Text = "Log Query";
            this.btnLogQuery.UseVisualStyleBackColor = true;
            this.btnLogQuery.Click += new System.EventHandler(this.btnLogQuery_Click);
            // 
            // frmLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 756);
            this.Controls.Add(this.btnLogQuery);
            this.Controls.Add(this.interfacePager1);
            this.Controls.Add(this.lblHowto);
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
        private System.Windows.Forms.DataGridView grdLoggingDb;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblHowto;
        private InterfacePager interfacePager1;
        private System.Windows.Forms.Button btnLogQuery;
    }
}
