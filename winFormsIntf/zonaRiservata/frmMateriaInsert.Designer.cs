﻿namespace winFormsIntf
{
    partial class frmMateriaInsert
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
            this.timbro1 = new winFormsIntf.Timbro();
            this.SuspendLayout();
            // 
            // timbro1
            // 
            this.timbro1.Location = new System.Drawing.Point(30, 29);
            this.timbro1.Name = "timbro1";
            this.timbro1.Size = new System.Drawing.Size(903, 32);
            this.timbro1.TabIndex = 0;
            // 
            // frmMateriaInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 518);
            this.Controls.Add(this.timbro1);
            this.Name = "frmMateriaInsert";
            this.Text = "frmMateriaInsert";
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro timbro1;
    }
}