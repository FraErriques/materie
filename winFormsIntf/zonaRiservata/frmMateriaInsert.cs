using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace winFormsIntf
{


    public partial class frmMateriaInsert : Form
    {
        private winFormsIntf.App_Code.ListBoxMaterieManager listBoxMaterieManager;


        public frmMateriaInsert()
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
            //
            this.listBoxMaterieManager = new App_Code.ListBoxMaterieManager();
            this.listBoxMaterieManager.populate_Listbox_ddlMateria_for_LOAD(
                this.lsbMaterie             );
            this.grbMateriaInsert.Enabled = true;
        }// Ctor()





        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmMateriaInsert_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmMateriaInsert_FormClosed


        private void btnCommit_Click(object sender, EventArgs e)
        {// Proxy with Transaction. Insert.
            System.Data.SqlClient.SqlTransaction trx = null;// init to invalid.
            int proxyInsertionResult = -1;// init to invalid.
            bool mustCommit = false;// init to invalid.
            if (this.canGoDb())
            {
                trx = Common.Connection.TransactionManager.trxOpener(
                            "ProxyGeneratorConnections/strings",// SectionGroup compulsory xpath
                            "materie" // KeyName
                    );
                proxyInsertionResult = Entity_materie.Proxies.usp_materia_LOOKUP_INSERT_SERVICE.usp_materia_LOOKUP_INSERT(
                    this.txtMateriaNew.Text
                    , trx
                 );
                mustCommit = (proxyInsertionResult == 0);
                Common.Connection.TransactionManager.trxCloser(
                    trx
                    , mustCommit
                );
                if (mustCommit)
                {
                    this.btnRefresh_Click(this, null);// get the new picture.
                    this.lblStato.Text = "Inserimento Materia avvenuto con successo.";
                    this.lblStato.BackColor = System.Drawing.Color.GreenYellow;
                    this.grbMateriaInsert.Enabled = false;// a second Commit is not allowed.
                }
                else
                {
                    this.lblStato.Text = "Inserimento Materia fallito.";
                    this.lblStato.BackColor = System.Drawing.Color.OrangeRed;
                    this.grbMateriaInsert.Enabled = true;
                }
            }
            else
            {
                this.lblStato.Text = "Il campo Nominativo della Materia non puo' essere vuoto.";
                this.lblStato.BackColor = System.Drawing.Color.Red;
                this.grbMateriaInsert.Enabled = true;
            }
        }// btnCommit_Click


        private bool canGoDb()
        {
            bool res = false;
            if(     null != this.txtMateriaNew
                 && null != this.txtMateriaNew.Text
                 && "" != this.txtMateriaNew.Text.Trim()
              )
            {
                res = true;
            }// else stay false.
            //ready
            return res;
        }// canGoDb


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.listBoxMaterieManager = null;// gc
            this.listBoxMaterieManager = new App_Code.ListBoxMaterieManager();// Ctor() goes to Proxy.
            this.listBoxMaterieManager.populate_Listbox_ddlMateria_for_LOAD(
                this.lsbMaterie);
        }


    }// class

}// nmsp
