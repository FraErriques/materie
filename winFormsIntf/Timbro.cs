using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;



namespace winFormsIntf
{

    /// <summary>
    /// The main App-Guidance class: it's a user control, i.e. the homologous of a .ascx in Aspx. Each of the winForms share this control.
    /// </summary>
    public partial class Timbro : UserControl
    {

        # region Ctor&Interface

        public Timbro()
        {
            // Systemm::initGraph
            InitializeComponent();
            // laterThanCtor(); not yet ready, the this.Parent field.
            // NB. if (typeof( winFormsIntf.Timbro) == this.GetType() )// NB. typeof() is an operator on types while GetType is a method on instances.
            //{} as in the previous example, their return value is compatible since in both cases it's of type "System.Type".
            this.lblLoggedUser.BackColor = System.Drawing.Color.GreenYellow;
        }// Ctor


        private void Timbro_Load(object sender, EventArgs e)
        {
            this.laterThanCtor();
        }// Timbro_Load


        public void setLbl(string theMessage)
        {
            this.lblLoggedUser.Text = theMessage;
        }


        public void laterThanCtor()
        {
            Entity_materie.BusinessEntities.Permesso.Patente patente = null;
            // the following check is necessary to avoid crashing when the "Timbro" is Loaded on a not yet mature Parent( eg. in the Timbro's Ctor).
            if (null != this.Parent)
            {
                patente = winFormsIntf.App_Code.CheckLogin.getPatente();
                //
                if (null != patente)
                {// classification taken literally, from the db.
                    ///     1	Administrator
                    ///     2	writer
                    ///     3	reader
                    switch (patente.livelloAccesso)
                    {
                        case "Administrator":
                            {
                                this.writeMenusEnabled(true);
                                this.adminMenusEnabled(true);
                                break;
                            }
                        case "writer":
                            {
                                this.writeMenusEnabled(true);
                                this.adminMenusEnabled(false);
                                break;
                            }
                        case "reader":
                            {
                                this.writeMenusEnabled(false);
                                this.adminMenusEnabled(false);
                                break;
                            }
                    }// switch
                    this.setLbl(" Login corretta per l'utente " + patente.username + " which is " + patente.livelloAccesso);
                    // NB enable menu, to let the recognized guy operate.
                    this.mnuTimbro.Enabled = true;
                    this.mnuTimbro.Visible = true;
                }// null != patente
                else// patente still==null.
                {
                    this.setLbl(" Utente non collegato.");
                    // NB enable menu, to let the recognized guy operate.
                    this.mnuTimbro.Enabled = false;
                    this.mnuTimbro.Visible = true;
                }
            }// if (null!=this.Parent )
            else
            {// else LoginForm cannot have a user already logged in.
                return;// on page. It's too early to perform the permission check.
            }
        }// laterThanCtor



        private void writeMenusEnabled(bool hasToBeEnabled)
        {
            // TODO insertDocumento: disable the btnValidateDoubleKey in AutoreLoad
            this.insertMateriaToolStripMenuItem.Enabled = hasToBeEnabled;
            this.insertAutoreToolStripMenuItem.Enabled = hasToBeEnabled;
        }// writeMenusEnabled

        private void adminMenusEnabled(bool hasToBeEnabled)
        {
            this.logToolStripMenuItem.Enabled = hasToBeEnabled;
            this.primesToolStripMenuItem.Enabled = hasToBeEnabled;
            //this.logoutToolStripMenuItem.Enabled = hasToBeEnabled; -- fr everybody
            //this.closeAppToolStripMenuItem.Enabled = hasToBeEnabled;
            //--both Visibility & Enabling for the following
            this.goToErrorToolStripMenuItem.Visible = hasToBeEnabled;
            this.goToErrorToolStripMenuItem.Enabled = hasToBeEnabled;
        }// adminMenusEnabled


        # endregion Ctor&Interface


        #region adminMenus




        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {// it's an action; not a Form.
            winFormsIntf.windowWarehouse.emptyWinList();// kill all windows.
            // the following means Program.firstBlood.Dispose() i.e. kill the frmLogin, which was the first one.
            // if frmLogin was in the "ArrayList activeInstancesFormList" a Logout would close the App.
            // the chance to LogOff and re-Login is guaranteed by keeping the frmLogin instance in a Singleton,
            // outside the "ArrayList activeInstancesFormList".
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Dispose();
        }// closeAppToolStripMenuItem_Click


        /// <summary>
        /// the present usage of frmErrore is to check the cardinality of existing form instances of the various kinds.
        /// </summary>
        private void goToErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toBePublished = "Form cardinality per Type : \r\n----------------\r\n" +
                " \r\n frmAutoreLoad       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmAutoreLoad.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmDocumentoLoad       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmDocumentoLoad.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmMateriaInsert       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmMateriaInsert.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmAutoreInsert       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmAutoreInsert.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmDocumentoInsert       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmDocumentoInsert.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmError NB. different ##(-1)instances in list =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmError.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmLogin-Singleton-references =" +
                    Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.getReferenceCardinality().ToString() +
                " \r\n frmLogViewer       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmLogViewer.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmPrimes       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmPrimes.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmChangePwd       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmChangePwd.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmUpdateAbstract       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmUpdateAbstract.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmPrototype       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmPrototype.ToString()])).
                    checkCurrentTypeActualConsistency().ToString() +
                " \r\n frmMappa       =" + ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[winFormsIntf.windowWarehouse.CurrentWindowType.frmMappa.ToString()])).
                    checkCurrentTypeActualConsistency().ToString();
            //
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"] = toBePublished;
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmError);
        }// goToErrorToolStripMenuItem_Click


        /// <summary>
        /// LogViewer : an interface for the LoggingDatabase used from Singleton_LogSinkDb_
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmLogViewer);
        }// logToolStripMenuItem_Click


        private void primesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmPrimes);
        }


        private void prototypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmPrototype);
        }// prototypeToolStripMenuItem_Click


        #endregion adminMenus

        
        #region menuFormCreation

        private void autoreLoadToolStripMenuItem_Click( object sender, EventArgs e )
        {
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmAutoreLoad);
        }// autoreLoadToolStripMenuItem_Click

        private void documentoLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmDocumentoLoad);
        }// documentoLToolStripMenuItem_Click

        private void mappaToolStripMenuItem_Click(object sender, EventArgs e)
        {// figure informative sui flussi dell'applicazione.
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmMappa);
        }

        private void insertMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmMateriaInsert);
        }

        private void insertAutoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm( windowWarehouse.CurrentWindowType.frmAutoreInsert);
        }// insertAutoreToolStripMenuItem_Click


        private void changePwdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmChangePwd);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {// NB. "Logout" is not a Form. It's an action. !
            winFormsIntf.windowWarehouse.emptyWinList();// kill all windows.
            //
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] = null;// no more loggedIn
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().uscTimbro.setLbl("");// on the Login frm.
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().pnlLoginControls.Enabled = true;// let the guy re-login.
            // check login status
            if( ! winFormsIntf.App_Code.CheckLogin.isLoggedIn() )
            {
                winFormsIntf.frmError ErrorForm = new frmError();
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
        }// Logout


        #endregion menuFormCreation


    }// class
}// nmsp
