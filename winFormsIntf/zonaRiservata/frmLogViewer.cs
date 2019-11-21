using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{
    public partial class frmLogViewer : Form
    {
        public frmLogViewer()
        {// check login status
            if (!winFormsIntf.CheckLogin.isLoggedIn())
            {
                winFormsIntf.frmError ErrorForm = new frmError(
                    new System.Exception("User is not Logged In : go to Login Form and access, in order to proceed."));
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
            //// init graphics
            InitializeComponent();
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmLogViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmLogViewer_FormClosed


    }// class
}// nmsp
