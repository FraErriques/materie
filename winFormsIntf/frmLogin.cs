using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{
    

    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
            // TODO disable menu
            this.uscTimbro.Enabled = false;// let the menus unusable until Login.
            this.lblStatus.Text = "";// reset
        }// Ctor()

        

 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLoginResetTimbroUsrLabel();// TODO
            //
            LogSinkFs.Wrappers.LogWrappers.SectionOpen("LoginSquareClient", 5);
            LogSinkDb.Wrappers.LogWrappers.SectionOpen("LoginSquareClient", 5);
            //---filter username----NB. no filtering on pwd----------
            string filtered_username = Process.utente.utente_login.filterUsername(this.txtUser.Text);
            //
            int loginResult =
                Process.utente.utente_login.canLogOn(
                    filtered_username,
                    this.txtPwd.Text //--NB. no filtering on pwd---------- 
                );
            // cache data to be used it in permission-management, iff 0==loginresult.
            Entity_materie.BusinessEntities.Permesso.Patente patente = null;
            if (
                0 == loginResult
                // && null != patente
              )
            {//--ok
                Entity_materie.BusinessEntities.Permesso perm = new Entity_materie.BusinessEntities.Permesso(filtered_username);
                patente = perm.GetPatente();
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] = patente;// now she's logged in.
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"] = null;
                //
                try
                {
                    LogSinkFs.Wrappers.LogWrappers.SectionContent(
                        "Login valido per l'utente " + 
                        ((Entity_materie.BusinessEntities.Permesso.Patente)
                            (Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.
                            instance()["lasciapassare"])).username
                        ,5);
                    LogSinkDb.Wrappers.LogWrappers.SectionContent(
                        "Login valido per l'utente " +
                        ((Entity_materie.BusinessEntities.Permesso.Patente)
                            (Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.
                            instance()["lasciapassare"])).username
                        ,5);
                }
                catch (System.Exception ex)
                {
                    LogSinkFs.Wrappers.LogWrappers.SectionContent(
                        ex.Message
                        ,5);
                    LogSinkDb.Wrappers.LogWrappers.SectionContent(
                        ex.Message
                        ,5);
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] = null;// login failed
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"] =
                        Process.utente.utente_login.loginMessages[loginResult];
                    this.lblStatus.Text = "Errore : Login negata.";// "this" is acting on firstBlood; from inside instance can avoid the Singleton syntax.
                    this.lblStatus.BackColor = System.Drawing.Color.Red;
                    this.uscTimbro.setLbl(" Errore : Login negata.");
                    // NB disable menu
                    this.uscTimbro.Enabled = false;
                }
                //
                LogSinkFs.Wrappers.LogWrappers.SectionClose();
                LogSinkDb.Wrappers.LogWrappers.SectionClose();
                // accessed by Login.
                this.lblStatus.Text = "Login corretta.";// "this" is acting on firstBlood; from inside instance can avoid the Singleton syntax.
                this.lblStatus.BackColor = System.Drawing.Color.LightGreen;
                this.uscTimbro.setLbl(" Login corretta per l'utente " + patente.username + " which is " + patente.livelloAccesso);
                // NB enable menu, to let the recognized guy operate.
                this.uscTimbro.Enabled = true;
                this.uscTimbro.Visible = true;
                this.uscTimbro.laterThanCtor();// evaluate permission and regulate the menus.
                this.pnlLoginControls.Enabled = false;// disable after login, to forbid changing user without an explicit Logout().
            }
            else// if 0<loginResult -> get error msg.
            {//--out
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] = null;// login failed
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"]=
                    Process.utente.utente_login.loginMessages[loginResult];
                //
                LogSinkFs.Wrappers.LogWrappers.SectionContent(
                    "Login fallito per l'utente " + this.txtUser.Text + " tradotto in " + filtered_username
                    ,5);
                LogSinkDb.Wrappers.LogWrappers.SectionContent(
                    "Login fallito per l'utente " + this.txtUser.Text + " tradotto in " + filtered_username
                    ,5);
                //
                LogSinkFs.Wrappers.LogWrappers.SectionClose();
                LogSinkDb.Wrappers.LogWrappers.SectionClose();
                this.lblStatus.Text = "Errore : Login negata.";// "this" is acting on firstBlood; from inside instance can avoid the Singleton syntax.
                this.lblStatus.BackColor = System.Drawing.Color.Red;
                this.uscTimbro.setLbl(" Errore : Login negata.");
                // NB disable menu
                this.uscTimbro.Enabled = false;
            }
        }// end btnLogin_Click()




        private void txtUser_MouseEnter(object sender, EventArgs e)
        {
            this.txtUser.Text = "";
        }

        private void txtPwd_MouseEnter(object sender, EventArgs e)
        {
            this.txtPwd.Text = "";
        }

        // when the user navigates via-menu to an applicative window, let the login one no more visible.
        private void frmLogin_Leave(object sender, EventArgs e)
        {
            // TODO disable menu
            this.uscTimbro.Enabled = false;
            this.lblStatus.Text = "";// reset
            // via firstBlood
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Visible = false;
        }// frmLogin_Leave


        // NB.
        private void frmLogin_Load(object sender, EventArgs e)
        {// DON'T check login status onLOAD
            //if (!winFormsIntf.CheckLogin.isLoggedIn())
            //{
            //    winFormsIntf.frmError ErrorForm = new frmError(
            //        new System.Exception("User is not Logged In : go to Login Form and access, in order to proceed."));
            //    ErrorForm.ShowDialog();// block on Error Form
            //}// else is LoggedIn -> CanContinue
            ////
        }


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmLogin_FormClosed


        private void frmLoginResetTimbroUsrLabel()
        {// reset Timbro::usrLabel onEnter.
            this.uscTimbro.setLbl("");
        }


    }// class
}// nmsp
