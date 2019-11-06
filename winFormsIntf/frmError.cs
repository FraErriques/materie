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

        public frmError()
        {
            InitializeComponent();
            //
            this.txtStatus.Enabled = false;
            this.uscTimbro.Enabled = false;
        }// Ctor



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
            this.uscTimbro.emptyWinList();// kill all windows.
            //
            //Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Focus();
            //Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().txtUser.Focus();
            //Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().ShowDialog();// re-show the original Login; exec suspended here.
            this.Close();// the frmError
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Show();// nonModal firstBlood
        }// btnGoLogin_Click


    }//class
}// nmsp
