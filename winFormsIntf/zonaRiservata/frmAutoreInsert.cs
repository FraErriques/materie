using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace winFormsIntf
{


    public partial class frmAutoreInsert : Form
    {
        public frmAutoreInsert()
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
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmAutoreInsert_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }


        private void btnCommit_Click(object sender, EventArgs e)
        {// Proxy with Transaction. Insert.
            System.Data.SqlClient.SqlTransaction trx = null;// init to invalid.
            int proxyInsertionResult = -1;// init to invalid.
            bool mustCommit = false;// init to invalid.
            if (this.canGoToDb())
            {
                trx =
                    Common.Connection.TransactionManager.trxOpener(
                            "ProxyGeneratorConnections/strings",// SectionGroup compulsory xpath
                            "materie" // KeyName
                    );
                proxyInsertionResult =
                    Entity_materie.Proxies.usp_autore_INSERT_SERVICE.usp_autore_INSERT(
                        this.txtNominativoAutore.Text
                        , this.txtAbstractAutore.Text
                        , trx // Sql transaction for insert
                     );
                mustCommit = (proxyInsertionResult == 0);
                Common.Connection.TransactionManager.trxCloser(
                    trx
                    , mustCommit
                );
                if (mustCommit)
                {
                    this.lblStato.Text = "Inserimento Autore avvenuto con successo.";
                    this.lblStato.BackColor = System.Drawing.Color.GreenYellow;
                }
                else
                {
                    this.lblStato.Text = "Inserimento Autore fallito.";
                    this.lblStato.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                this.lblStato.Text = "Il campo Nominativo ed il campo Note sono entrambi obbligatori.";
                this.lblStato.BackColor = System.Drawing.Color.Red;
            }
        }// btnCommit_Click


        private bool canGoToDb()
        {
            bool res = false;
            //
            if (null != this.txtNominativoAutore
                && null != this.txtNominativoAutore.Text
                && "" != this.txtNominativoAutore.Text.Trim()
                )
            {
                res = true;
            }// else stay false.
            if (null != this.txtAbstractAutore
                && null != this.txtAbstractAutore.Text
                && "" != this.txtAbstractAutore.Text.Trim()
                )
            {
                res &= true;// &= since it'a second validation in "AND" with the first one.
            }// if
            // ready.
            return res;
        }// canGoToDb()


    }// class

}// nmsp
