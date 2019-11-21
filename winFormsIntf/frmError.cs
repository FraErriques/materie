using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{

    public partial class frmError : Form
    {
        private string toBePublished;


        /// <summary>
        /// Ctor() NB. frmError does not require to be logged in.
        /// </summary>
        public frmError()
        {
            InitializeComponent();
            //
            try
            {
                object messageForFrmError = Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"];
                if (null != messageForFrmError)
                {
                    this.toBePublished = (string)messageForFrmError;
                }
                else
                {
                    this.toBePublished = "";
                }
            }
            catch (System.Exception ex)
            {
                this.toBePublished = "Exception in frmError::Ctor " + ex.Message;
                if (null != ex.InnerException)
                {
                    this.toBePublished += "  Inner= " + ex.InnerException.Message;
                }
            }
            finally
            {
                this.txtStatus.Text = this.toBePublished;
            }
            //
            this.txtStatus.Enabled = false;
            this.uscTimbro.Enabled = false;
        }// Ctor


        /// <summary>
        /// Ctor() NB. frmError does not require to be logged in.
        /// </summary>
        public frmError( System.Exception ex)
        {
            InitializeComponent();
            //
            if (null != ex)
            {
                this.txtStatus.Text = ex.Message;
                if (null != ex.InnerException)
                {
                    this.txtStatus.Text += "-Inner: " + ex.InnerException.Message;
                }// else skip.
                this.txtStatus.Enabled = false;
                this.uscTimbro.Enabled = false;
            }// else an empty exception has been provided.
        }// Ctor


        //public void setContentToBePublished(string ContentToBePublished)
        //{
        //    this.toBePublished = ContentToBePublished;
        //    this.txtStatus.Text += this.toBePublished;
        //    //this.Paint; ? how ??
        //}// setContentToBePublished


        private void btnGoLogin_Click( object sender, EventArgs e )
        {
            // Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Owner
            //Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.unsubscribe_all_();// unsubscribe_all_
            //Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance();// renew the frmLogin
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Visible = false;
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().uscTimbro.Enabled = false;
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().lblStatus.Text = "";// reset
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().txtPwd.Text = "";
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().txtUser.Text = "";// ? order ?
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().pnlLoginControls.Enabled = true;
            //
            winFormsIntf.windowWarehouse.emptyWinList();// kill all windows.
            //
            //Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Focus();
            //Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().txtUser.Focus();
            //Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().ShowDialog();// re-show the original Login; exec suspended here.
            this.Close();// the frmError has to close, when proposing a new Login.
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().uscTimbro.setLbl("");// on the Login frm.
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().pnlLoginControls.Enabled = true;// let the guy re-login.
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Show();// cannot do ShowDialog since the System does not accept 
            // a second call to ShowDialog, without a closure. So nonModal firstBlood.
        }// btnGoLogin_Click


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmError_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmError_FormClosed


        // NB. don't delete this memo.
        ///  emptyWinList();// kill all windows.
        //// in this form it's done in btnGoLogin_Click


    }//class
}// nmsp
