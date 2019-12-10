namespace winFormsIntf
{
    partial class InterfacePager
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
            this.lblFirstPage = new System.Windows.Forms.Label();
            this.lblLastPage = new System.Windows.Forms.Label();
            this.lblPageBefore = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lblPageAfter = new System.Windows.Forms.Label();
            this.lblRowXchunk = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.txtGoToPage = new System.Windows.Forms.TextBox();
            this.txtChunkSize = new System.Windows.Forms.TextBox();
            this.btnChangeParams = new System.Windows.Forms.Button();
            this.lblRowsInView = new System.Windows.Forms.Label();
            this.lblViewName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFirstPage
            // 
            this.lblFirstPage.AutoSize = true;
            this.lblFirstPage.Location = new System.Drawing.Point(12, 40);
            this.lblFirstPage.Name = "lblFirstPage";
            this.lblFirstPage.Size = new System.Drawing.Size(26, 13);
            this.lblFirstPage.TabIndex = 0;
            this.lblFirstPage.Text = "First";
            this.lblFirstPage.Click += new System.EventHandler(this.lblFirstPage_Click);
            // 
            // lblLastPage
            // 
            this.lblLastPage.AutoSize = true;
            this.lblLastPage.Location = new System.Drawing.Point(359, 37);
            this.lblLastPage.Name = "lblLastPage";
            this.lblLastPage.Size = new System.Drawing.Size(27, 13);
            this.lblLastPage.TabIndex = 1;
            this.lblLastPage.Text = "Last";
            this.lblLastPage.Click += new System.EventHandler(this.lblLastPage_Click);
            // 
            // lblPageBefore
            // 
            this.lblPageBefore.AutoSize = true;
            this.lblPageBefore.Location = new System.Drawing.Point(63, 40);
            this.lblPageBefore.Name = "lblPageBefore";
            this.lblPageBefore.Size = new System.Drawing.Size(19, 13);
            this.lblPageBefore.TabIndex = 2;
            this.lblPageBefore.Text = "<<";
            this.lblPageBefore.Click += new System.EventHandler(this.lblBefore_Click);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentPage.Location = new System.Drawing.Point(138, 40);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(41, 13);
            this.lblCurrentPage.TabIndex = 3;
            this.lblCurrentPage.Text = "Current";
            // 
            // lblPageAfter
            // 
            this.lblPageAfter.AutoSize = true;
            this.lblPageAfter.Location = new System.Drawing.Point(291, 40);
            this.lblPageAfter.Name = "lblPageAfter";
            this.lblPageAfter.Size = new System.Drawing.Size(19, 13);
            this.lblPageAfter.TabIndex = 4;
            this.lblPageAfter.Text = ">>";
            this.lblPageAfter.Click += new System.EventHandler(this.lblPageAfter_Click);
            // 
            // lblRowXchunk
            // 
            this.lblRowXchunk.AutoSize = true;
            this.lblRowXchunk.Location = new System.Drawing.Point(119, 69);
            this.lblRowXchunk.Name = "lblRowXchunk";
            this.lblRowXchunk.Size = new System.Drawing.Size(60, 13);
            this.lblRowXchunk.TabIndex = 6;
            this.lblRowXchunk.Text = "RowXpage";
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(12, 73);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(30, 13);
            this.lblStato.TabIndex = 5;
            this.lblStato.Text = "stato";
            // 
            // txtGoToPage
            // 
            this.txtGoToPage.Location = new System.Drawing.Point(185, 37);
            this.txtGoToPage.Name = "txtGoToPage";
            this.txtGoToPage.Size = new System.Drawing.Size(70, 20);
            this.txtGoToPage.TabIndex = 8;
            this.txtGoToPage.Text = "1";
            // 
            // txtChunkSize
            // 
            this.txtChunkSize.Location = new System.Drawing.Point(185, 63);
            this.txtChunkSize.Name = "txtChunkSize";
            this.txtChunkSize.Size = new System.Drawing.Size(70, 20);
            this.txtChunkSize.TabIndex = 9;
            this.txtChunkSize.Text = "5";
            // 
            // btnChangeParams
            // 
            this.btnChangeParams.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeParams.Location = new System.Drawing.Point(261, 60);
            this.btnChangeParams.Name = "btnChangeParams";
            this.btnChangeParams.Size = new System.Drawing.Size(89, 25);
            this.btnChangeParams.TabIndex = 11;
            this.btnChangeParams.Text = "Change both";
            this.btnChangeParams.UseVisualStyleBackColor = false;
            this.btnChangeParams.Click += new System.EventHandler(this.btnChangeBoth_Click);
            // 
            // lblRowsInView
            // 
            this.lblRowsInView.AutoSize = true;
            this.lblRowsInView.Location = new System.Drawing.Point(258, 14);
            this.lblRowsInView.Name = "lblRowsInView";
            this.lblRowsInView.Size = new System.Drawing.Size(124, 13);
            this.lblRowsInView.TabIndex = 12;
            this.lblRowsInView.Text = "Rows In the whole View:";
            // 
            // lblViewName
            // 
            this.lblViewName.AutoSize = true;
            this.lblViewName.Location = new System.Drawing.Point(12, 14);
            this.lblViewName.Name = "lblViewName";
            this.lblViewName.Size = new System.Drawing.Size(70, 13);
            this.lblViewName.TabIndex = 13;
            this.lblViewName.Text = "View Name:  ";
            // 
            // InterfacePager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblViewName);
            this.Controls.Add(this.lblRowsInView);
            this.Controls.Add(this.btnChangeParams);
            this.Controls.Add(this.txtChunkSize);
            this.Controls.Add(this.txtGoToPage);
            this.Controls.Add(this.lblRowXchunk);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.lblPageAfter);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.lblPageBefore);
            this.Controls.Add(this.lblLastPage);
            this.Controls.Add(this.lblFirstPage);
            this.Name = "InterfacePager";
            this.Size = new System.Drawing.Size(473, 107);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstPage;
        private System.Windows.Forms.Label lblLastPage;
        private System.Windows.Forms.Label lblPageBefore;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblPageAfter;
        private System.Windows.Forms.Label lblRowXchunk;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.TextBox txtGoToPage;
        private System.Windows.Forms.TextBox txtChunkSize;
        private System.Windows.Forms.Button btnChangeParams;
        private System.Windows.Forms.Label lblRowsInView;
        private System.Windows.Forms.Label lblViewName;
    }
}
