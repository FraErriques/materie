using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{
    public partial class frmUpdateAbstract : Form
    {
        public frmUpdateAbstract()
        {// check login status
            if (!winFormsIntf.App_Code.CheckLogin.isLoggedIn())
            {
                winFormsIntf.frmError ErrorForm = new frmError(
                    new System.Exception("User is not Logged In : go to Login Form and access, in order to proceed."));
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
            //// init graphics
            InitializeComponent();
            // TODO : only "writers" could get here. Check whether a reader got here, kindly let him out.
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmUpdateAbstract_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmUpdateAbstract_FormClosed


        /// <summary>
        /// keep in mind the need for locks, due to the presence of multiple clients, which are concurrent in such write-activity on the db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommit_Click(object sender, EventArgs e)
        {

        }// btnCommit_Click


    }
}
