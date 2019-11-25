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
        {// check login status
            if (!winFormsIntf.App_Code.CheckLogin.isLoggedIn())
            {
                winFormsIntf.frmError ErrorForm = new frmError(
                    new System.Exception("User is not Logged In : go to Login Form and access, in order to proceed."));
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
            InitializeComponent();
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmChangePwd_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmChangePwd_FormClosed


        private void btnCommit_Click(object sender, EventArgs e)
        {
            Entity_materie.BusinessEntities.Permesso.Patente curPatente = App_Code.CheckLogin.getPatente();
            bool result =
                Process.utente.utente_changePwd.CambioPassword(
                    curPatente.username,
                    // web side it's : ((Entity_materie.BusinessEntities.Permesso.Patente)(this.Session["lasciapassare"])).username,
                    this.txtOldPwd.Text,
                    this.txtNewPwd.Text,
                    this.txtConfirmNewPwd.Text
                );
            // write result.
            if (result)
            {
                this.lblStato.Text = "La password e' stata modificata.";
                this.lblStato.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.lblStato.Text = "Non e' stato possibile modificare la password.";
                this.lblStato.BackColor = System.Drawing.Color.Red;
            }
        }// end btnChangePwd_Click


    }// class
}// nmsp
