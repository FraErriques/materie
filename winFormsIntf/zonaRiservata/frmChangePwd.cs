using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace winFormsIntf
{


    public partial class frmChangePwd : Form
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmChangePwd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.uscTimbro.removeSpecifiedWin(this);
        }// frmChangePwd_FormClosed


    }// class
}// nmsp
