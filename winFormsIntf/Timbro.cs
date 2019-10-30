using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
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
        }// Ctor


        private void Timbro_Load(object sender, EventArgs e)
        {
            this.laterThanCtor();
        }// Timbro_Load



        public void laterThanCtor()
        {
            Entity_materie.BusinessEntities.Permesso.Patente patente = null;
            // the following check is necessary to avoid crashing when the "Timbro" is Loaded on a not yet mature Parent( eg. in the Timbro's Ctor).
            if (null!=this.Parent )
            {
                try
                {
                    patente =
                        (Entity_materie.BusinessEntities.Permesso.Patente)
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"];
                    if (null == patente)
                    {
                        return; // NB. do not throw here. It will return on page with an enabled menu.
                    }
                }
                catch (System.Exception ex)
                {
                    frmError unloggedUserError = new frmError(new System.Exception("current useer is NOT logged in : ALLARM ! "
                        + ex.Message));
                }
            }// if (null!=this.Parent )
            // else LoginForm cannot have a user already logged in.
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
            }// null != patente
            else// means that the Timbro.cs is ready to set up the menu
            {
                this.mnuTimbro.Enabled = true;
                this.mnuTimbro.Visible = true;
            }
            //
            // Note:...else if (this.Parent.GetType() == typeof(winFormsIntf.frmDocumentoLoad))
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
        {
            this.emptyWinList();// kill all windows.
            // the following means Program.firstBlood.Dispose() i.e. kill the frmLogin, which was the first one.
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Dispose();
        }// closeAppToolStripMenuItem_Click



        private void goToErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //windowWarehouse[] activeInstances = new windowWarehouse[9];// TODO ?
            //activeInstances[0] = new windowWarehouse(Common.Template_Singleton.TSingleton<winFormsIntf.frmAutoreLoad>.instance());
            //activeInstances[1] = new windowWarehouse(Common.Template_Singleton.TSingleton<winFormsIntf.frmDocumentoLoad>.instance());

            //    //public enum CurrentWindowType
            //    //{
            //    //    // invalid
            //    //    Invalid = 0
            //    //    ///	effective opening modes
            //    //    ,frmAutoreLoad          = 1
            //    //    ,frmDocumentoLoad       = 2
            //    //    ,frmMateriaInsert       = 3
            //    //    ,frmAutoreInsert        = 4
            //    //    ,frmDocumentoInsert     = 5
            //    //    ,frmError               = 6
            //    //    ,frmLogin               = 7
            //    //    ,frmLogViewer           = 8
            //    //    ,frmPrimes              = 9
            //    //    ,frmChangePwd           = 10
            //    //    ,frmUpdateAbstract      = 11
            //    //}// enum
            //...
            winFormsIntf.frmError ErrorForm = new frmError(new System.Exception("Debbugging Session: " + // )); //  + TODO
                    " \r\n frmAutoreLoad       =" + Program.activeInstances[0].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmDocumentoLoad    =" + Program.activeInstances[1].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmMateriaInsert    =" + Program.activeInstances[2].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmAutoreInsert     =" + Program.activeInstances[3].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmDocumentoInsert  =" + Program.activeInstances[4].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmError            =" + Program.activeInstances[5].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmLogin            =" + Program.activeInstances[6].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmLogViewer        =" + Program.activeInstances[7].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmPrimes           =" + Program.activeInstances[8].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmChangePwd        =" + Program.activeInstances[9].checkCurrentTypeActualConsistency().ToString() +
                    " \r\n frmUpdateAbstract   =" + Program.activeInstances[10].checkCurrentTypeActualConsistency().ToString()
                ));
            //
            ErrorForm.ShowDialog();// block on Error Form
        }



        #endregion adminMenus


        #region kernelModules

        public void emptyWinList()
        {
            for (int c = Program.formList.Count; c > 0; c--)
            {
                if (null != Program.formList[c - 1])
                {
                    ((System.Windows.Forms.Form)(Program.formList[c - 1])).Dispose();
                    Program.formList[c - 1] = null;//gc
                    Program.formList.RemoveAt(c - 1);// remove the empty slot
                }// skip null entries; pass to a fixed-size_Array end reset the index.
            }
        }// emptyWinList()


        public void removeSpecifiedWin(System.Windows.Forms.Form parFrm)
        {
            for (int c = Program.formList.Count; c > 0; c--)
            {
                if (null != Program.formList[c - 1])
                {
                    if (parFrm == (System.Windows.Forms.Form)(Program.formList[c - 1]))
                    {
                        ((System.Windows.Forms.Form)(Program.formList[c - 1])).Dispose();
                        Program.formList[c - 1] = null;//gc
                        Program.formList.RemoveAt(c - 1);// remove the empty slot
                    }
                }// skip null entries; pass to a fixed-size_Array end reset the index.
            }
        }// removeSpecifiedWin()


        #endregion kernelModules




        #region menuFormCreation

        private void autoreLoadToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if( Program.activeInstances[0].canOpenAnotherOne())
            {
                Program.formList.Add(new frmAutoreLoad());
                if( Program.activeInstances[0].openingHowto() == windowWarehouse.openingMode.Modal)
                {
                    ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).ShowDialog();// show the last born.
                }
                else if (Program.activeInstances[0].openingHowto() == windowWarehouse.openingMode.NotModal)
                {
                    ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).Show();// show the last born.
                }
                else
                {
                    throw new System.Exception(" Invalid opening mode.");
                }
            }// if can open another win
            else
            {
                MessageBox.Show(this, " No more instances of type AutoreLoad available. Close something of this type.", "Win Cardinality");
            }// else can open no more win
        }// autoreLoadToolStripMenuItem_Click


        private void documentoLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.activeInstances[1].canOpenAnotherOne())
            {
                Program.formList.Add(new frmDocumentoLoad() );
                if (Program.activeInstances[1].openingHowto() == windowWarehouse.openingMode.Modal)
                {
                    ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).ShowDialog();// show the last born.
                }
                else if (Program.activeInstances[1].openingHowto() == windowWarehouse.openingMode.NotModal)
                {
                    ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).Show();// show the last born.
                }
                else
                {
                    throw new System.Exception(" Invalid opening mode.");
                }
            }// if can open another win
            else
            {
                MessageBox.Show(this, " No more instances of type DocumentoLoad available. Close something of this type.", "Win Cardinality");
            }// else can open no more win
        }// documentoLToolStripMenuItem_Click


        private void mappaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void insertMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void insertAutoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// LogViewer : an interface for the LoggingDatabase used from Singleton_LogSinkDb_
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.activeInstances[7].canOpenAnotherOne())
            {
                Program.formList.Add(new frmLogViewer() );
                if (Program.activeInstances[7].openingHowto() == windowWarehouse.openingMode.Modal)
                {
                    ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).ShowDialog();// show the last born.
                }
                else if (Program.activeInstances[7].openingHowto() == windowWarehouse.openingMode.NotModal)
                {
                    ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).Show();// show the last born.
                }
                else
                {
                    throw new System.Exception(" Invalid opening mode.");
                }
            }// if can open another win
            else
            {
                MessageBox.Show(this, " No more instances of type DocumentoLoad available. Close something of this type.", "Win Cardinality");
            }// else can open no more win
        }// logToolStripMenuItem_Click



        private void primesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePwdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.emptyWinList();// kill all windows.
            //
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] = null;// no more loggedIn
            // check login status
            bool isLoggedIn =
                winFormsIntf.CheckLogin.isLoggedIn(
                    (Entity_materie.BusinessEntities.Permesso.Patente)
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"]);
            if (!isLoggedIn)
            {
                winFormsIntf.frmError ErrorForm = new frmError(new System.Exception("user is not Logged In"
                    , new System.Exception("Go to Login Form and access, in order to proceed.")));
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
        }// Logout

        #endregion menuFormCreation


    }// class
}// nmsp
