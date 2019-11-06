namespace winFormsIntf
{
    partial class frmAutoreInsert
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.timbro1 = new winFormsIntf.Timbro();
            this.docFullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(31, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(26, 133);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(126, 20);
            this.domainUpDown1.TabIndex = 2;
            this.domainUpDown1.Text = "domainUpDown1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(246, 65);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(120, 368);
            this.listBox1.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.docFullPath});
            this.listView1.Location = new System.Drawing.Point(466, 65);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(299, 368);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // timbro1
            // 
            this.timbro1.Location = new System.Drawing.Point(12, 12);
            this.timbro1.Name = "timbro1";
            this.timbro1.Size = new System.Drawing.Size(857, 32);
            this.timbro1.TabIndex = 0;
            // 
            // docFullPath
            // 
            this.docFullPath.Text = "Doc full path";
            this.docFullPath.Width = 957;
            // 
            // frmAutoreInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 493);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.timbro1);
            this.Name = "frmAutoreInsert";
            this.Text = "frmAutoreInsert";
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro timbro1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader docFullPath;
    }
}