namespace winFormsIntf
{
    partial class Pager
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
            this.lblGoToPage = new System.Windows.Forms.Label();
            this.lblRowXchunk = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnGoToPage = new System.Windows.Forms.Button();
            this.btnChangeChunk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFirstPage
            // 
            this.lblFirstPage.AutoSize = true;
            this.lblFirstPage.Location = new System.Drawing.Point(5, 9);
            this.lblFirstPage.Name = "lblFirstPage";
            this.lblFirstPage.Size = new System.Drawing.Size(54, 13);
            this.lblFirstPage.TabIndex = 0;
            this.lblFirstPage.Text = "First Page";
            this.lblFirstPage.Click += new System.EventHandler(this.lblFirstPage_Click);
            // 
            // lblLastPage
            // 
            this.lblLastPage.AutoSize = true;
            this.lblLastPage.Location = new System.Drawing.Point(400, 9);
            this.lblLastPage.Name = "lblLastPage";
            this.lblLastPage.Size = new System.Drawing.Size(67, 13);
            this.lblLastPage.TabIndex = 1;
            this.lblLastPage.Text = "Last Page==";
            this.lblLastPage.Click += new System.EventHandler(this.lblLastPage_Click);
            // 
            // lblPageBefore
            // 
            this.lblPageBefore.AutoSize = true;
            this.lblPageBefore.Location = new System.Drawing.Point(74, 9);
            this.lblPageBefore.Name = "lblPageBefore";
            this.lblPageBefore.Size = new System.Drawing.Size(78, 13);
            this.lblPageBefore.TabIndex = 2;
            this.lblPageBefore.Text = "<<Page Before";
            this.lblPageBefore.Click += new System.EventHandler(this.lblBefore_Click);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(172, 9);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(81, 13);
            this.lblCurrentPage.TabIndex = 3;
            this.lblCurrentPage.Text = "Current Page==";
            this.lblCurrentPage.Click += new System.EventHandler(this.lblCurrentPage_Click);
            // 
            // lblPageAfter
            // 
            this.lblPageAfter.AutoSize = true;
            this.lblPageAfter.Location = new System.Drawing.Point(302, 9);
            this.lblPageAfter.Name = "lblPageAfter";
            this.lblPageAfter.Size = new System.Drawing.Size(69, 13);
            this.lblPageAfter.TabIndex = 4;
            this.lblPageAfter.Text = ">>Page After";
            this.lblPageAfter.Click += new System.EventHandler(this.lblPageAfter_Click);
            // 
            // lblGoToPage
            // 
            this.lblGoToPage.AutoSize = true;
            this.lblGoToPage.Location = new System.Drawing.Point(29, 44);
            this.lblGoToPage.Name = "lblGoToPage";
            this.lblGoToPage.Size = new System.Drawing.Size(65, 13);
            this.lblGoToPage.TabIndex = 7;
            this.lblGoToPage.Text = "Go To Page";
            this.lblGoToPage.Click += new System.EventHandler(this.lblGoToPage_Click);
            // 
            // lblRowXchunk
            // 
            this.lblRowXchunk.AutoSize = true;
            this.lblRowXchunk.Location = new System.Drawing.Point(29, 70);
            this.lblRowXchunk.Name = "lblRowXchunk";
            this.lblRowXchunk.Size = new System.Drawing.Size(72, 13);
            this.lblRowXchunk.TabIndex = 6;
            this.lblRowXchunk.Text = "Row X chunk";
            this.lblRowXchunk.Click += new System.EventHandler(this.lblRowXchunk_Click);
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(29, 97);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(30, 13);
            this.lblStato.TabIndex = 5;
            this.lblStato.Text = "stato";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(109, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 20);
            this.textBox2.TabIndex = 9;
            // 
            // btnGoToPage
            // 
            this.btnGoToPage.Location = new System.Drawing.Point(195, 36);
            this.btnGoToPage.Name = "btnGoToPage";
            this.btnGoToPage.Size = new System.Drawing.Size(75, 20);
            this.btnGoToPage.TabIndex = 10;
            this.btnGoToPage.Text = "Go To Page";
            this.btnGoToPage.UseVisualStyleBackColor = true;
            this.btnGoToPage.Click += new System.EventHandler(this.btnGoToPage_Click);
            // 
            // btnChangeChunk
            // 
            this.btnChangeChunk.Location = new System.Drawing.Point(195, 62);
            this.btnChangeChunk.Name = "btnChangeChunk";
            this.btnChangeChunk.Size = new System.Drawing.Size(75, 20);
            this.btnChangeChunk.TabIndex = 11;
            this.btnChangeChunk.Text = "Change Chunk";
            this.btnChangeChunk.UseVisualStyleBackColor = true;
            this.btnChangeChunk.Click += new System.EventHandler(this.btnChangeChunk_Click);
            // 
            // Pager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChangeChunk);
            this.Controls.Add(this.btnGoToPage);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblGoToPage);
            this.Controls.Add(this.lblRowXchunk);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.lblPageAfter);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.lblPageBefore);
            this.Controls.Add(this.lblLastPage);
            this.Controls.Add(this.lblFirstPage);
            this.Name = "Pager";
            this.Size = new System.Drawing.Size(505, 127);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstPage;
        private System.Windows.Forms.Label lblLastPage;
        private System.Windows.Forms.Label lblPageBefore;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblPageAfter;
        private System.Windows.Forms.Label lblGoToPage;
        private System.Windows.Forms.Label lblRowXchunk;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnGoToPage;
        private System.Windows.Forms.Button btnChangeChunk;
    }
}
