﻿namespace winFormsIntf
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
            this.uscTimbro = new winFormsIntf.Timbro();
            this.txtNominativoAutore = new System.Windows.Forms.TextBox();
            this.txtAbstractAutore = new System.Windows.Forms.TextBox();
            this.lblNominativoAutore = new System.Windows.Forms.Label();
            this.lblNoteAutore = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.lblStato = new System.Windows.Forms.Label();
            this.grbAutoreInsert = new System.Windows.Forms.GroupBox();
            this.grbAutoreInsert.SuspendLayout();
            this.SuspendLayout();
            // 
            // uscTimbro
            // 
            this.uscTimbro.Location = new System.Drawing.Point(12, 12);
            this.uscTimbro.Name = "uscTimbro";
            this.uscTimbro.Size = new System.Drawing.Size(899, 73);
            this.uscTimbro.TabIndex = 0;
            // 
            // txtNominativoAutore
            // 
            this.txtNominativoAutore.Location = new System.Drawing.Point(15, 52);
            this.txtNominativoAutore.Multiline = true;
            this.txtNominativoAutore.Name = "txtNominativoAutore";
            this.txtNominativoAutore.Size = new System.Drawing.Size(422, 283);
            this.txtNominativoAutore.TabIndex = 1;
            // 
            // txtAbstractAutore
            // 
            this.txtAbstractAutore.Location = new System.Drawing.Point(456, 52);
            this.txtAbstractAutore.Multiline = true;
            this.txtAbstractAutore.Name = "txtAbstractAutore";
            this.txtAbstractAutore.Size = new System.Drawing.Size(443, 283);
            this.txtAbstractAutore.TabIndex = 2;
            // 
            // lblNominativoAutore
            // 
            this.lblNominativoAutore.AutoSize = true;
            this.lblNominativoAutore.BackColor = System.Drawing.Color.GreenYellow;
            this.lblNominativoAutore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNominativoAutore.Location = new System.Drawing.Point(12, 33);
            this.lblNominativoAutore.Name = "lblNominativoAutore";
            this.lblNominativoAutore.Size = new System.Drawing.Size(118, 16);
            this.lblNominativoAutore.TabIndex = 3;
            this.lblNominativoAutore.Text = "Nominativo Autore";
            // 
            // lblNoteAutore
            // 
            this.lblNoteAutore.AutoSize = true;
            this.lblNoteAutore.BackColor = System.Drawing.Color.GreenYellow;
            this.lblNoteAutore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteAutore.Location = new System.Drawing.Point(453, 33);
            this.lblNoteAutore.Name = "lblNoteAutore";
            this.lblNoteAutore.Size = new System.Drawing.Size(79, 16);
            this.lblNoteAutore.TabIndex = 4;
            this.lblNoteAutore.Text = "Note Autore";
            // 
            // btnCommit
            // 
            this.btnCommit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommit.Location = new System.Drawing.Point(709, 354);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(190, 34);
            this.btnCommit.TabIndex = 5;
            this.btnCommit.Text = "Commit Inserimento Autore";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStato.Location = new System.Drawing.Point(12, 363);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(39, 16);
            this.lblStato.TabIndex = 6;
            this.lblStato.Text = "Stato";
            // 
            // grbAutoreInsert
            // 
            this.grbAutoreInsert.Controls.Add(this.txtNominativoAutore);
            this.grbAutoreInsert.Controls.Add(this.btnCommit);
            this.grbAutoreInsert.Controls.Add(this.lblStato);
            this.grbAutoreInsert.Controls.Add(this.txtAbstractAutore);
            this.grbAutoreInsert.Controls.Add(this.lblNominativoAutore);
            this.grbAutoreInsert.Controls.Add(this.lblNoteAutore);
            this.grbAutoreInsert.Location = new System.Drawing.Point(12, 77);
            this.grbAutoreInsert.Name = "grbAutoreInsert";
            this.grbAutoreInsert.Size = new System.Drawing.Size(933, 422);
            this.grbAutoreInsert.TabIndex = 7;
            this.grbAutoreInsert.TabStop = false;
            this.grbAutoreInsert.Text = "Autore Insert";
            // 
            // frmAutoreInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(981, 541);
            this.Controls.Add(this.grbAutoreInsert);
            this.Controls.Add(this.uscTimbro);
            this.Name = "frmAutoreInsert";
            this.Text = "frmAutoreInsert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAutoreInsert_FormClosed);
            this.grbAutoreInsert.ResumeLayout(false);
            this.grbAutoreInsert.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Timbro uscTimbro;
        private System.Windows.Forms.TextBox txtNominativoAutore;
        private System.Windows.Forms.TextBox txtAbstractAutore;
        private System.Windows.Forms.Label lblNominativoAutore;
        private System.Windows.Forms.Label lblNoteAutore;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.GroupBox grbAutoreInsert;
    }
}
