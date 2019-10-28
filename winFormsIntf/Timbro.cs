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


    public partial class Timbro : UserControl
    {
        
        

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


        private void autoreLoadToolStripMenuItem_Click( object sender, EventArgs e )
        {

                Program.formList.Add( new frmAutoreLoad()); // .formStack.Push(
                ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).ShowDialog();// show the last born.
                //frmAutoreLoad_inst.ShowDialog();// this MODAL action suspends the execution;
                // the following lines will be executed only on closure of frmAutoreLoad_inst (asynchronous execution).
                ////instead
                //frmAutoreLoad_inst.Show();// this closes everything synchronously.
                //// this way the execution continues.
                //this.Close();NB. don't do that. This closes the main form, on closure of a slave one.
        }// autoreLoadToolStripMenuItem_Click

        private void documentoLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formList.Add(new frmDocumentoLoad()); // .formStack.Push(
            ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).ShowDialog();// show the last born.
        }// documentoLToolStripMenuItem_Click


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



        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.emptyWinList();// kill all windows.
            // the following means Program.firstBlood.Dispose() i.e. kill the frmLogin, which was the first one.
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Dispose();
        }// closeAppToolStripMenuItem_Click



        private void goToErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windowWarehouse[] activeInstances = new windowWarehouse[9];// TODO ?
            activeInstances[0] = new windowWarehouse(Common.Template_Singleton.TSingleton<winFormsIntf.frmAutoreLoad>.instance());
            activeInstances[1] = new windowWarehouse(Common.Template_Singleton.TSingleton<winFormsIntf.frmDocumentoLoad>.instance());
            winFormsIntf.frmError ErrorForm = new frmError(new System.Exception("Debbugging Session: (AutoreLoad)=" + activeInstances[0].checkCurrentTypeActualConsistency().ToString()+
"  (DocumentoLoad)=" + activeInstances[1].checkCurrentTypeActualConsistency().ToString()  ));
            //
            ErrorForm.ShowDialog();// block on Error Form
        }


    }// class
}// nmsp
