﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class zonaRiservata_UpdateAbstract : System.Web.UI.Page
{
    int id_Abstract_ToEdit = default(int);
    string AbstractNature = default(string);


    protected void Page_Load( object sender, EventArgs e)
    {
        //
        if (!VerificaLasciapassare.CanLogOn(
                this.Session,
                this.Request.UserHostAddress
                )
            )
        {// un-logged user. Close both logs and goto error.
            this.Response.Redirect("../errore.aspx");
        }// else il lasciapassare e' valido
        //
        /*
         * NB. page state check.-----------------------------------------------------------------
         * 
         */
        PageStateChecker.PageStateChecker_SERVICE(
            "zonaRiservata_UpdateAbstract"
            , this.Request
            , this.IsPostBack
            , this.Session
        );
        //----------------------------------------------- END  page state check.-----------------
        if (!this.IsPostBack)
        {
            this.evaluateStateParams();// it's called also from btnUpdateAbstract_Click() for this it's a function.
            this.loadData();// load abstract for update.
        }
        else
        {
            // it's a commit -> don't load.  TODO
        }
    }// end Page_Load().


    private void evaluateStateParams()
    {
        // NB. evaluate the following Session-pars.
        //this.Session["ref_abstract_id"] = ...;
        //this.Session["AbstractNature"] = ...;// {"autore", "documento"}
        try
        {
            this.id_Abstract_ToEdit = (int)(this.Session["ref_abstract_id"]);
        }
        catch (System.Exception ex)
        {
            string dbg = ex.Message;
            throw new System.Exception("ref_abstract_id cannot be missing, in this page.");
        }
        //
        try
        {
            this.AbstractNature = (string)(this.Session["AbstractNature"]);
        }
        catch (System.Exception ex)
        {
            string dbg = ex.Message;
            throw new System.Exception("AbstractNature cannot be missing, in this page.");
        }
    }//


    private void loadData(
      )
    {
        System.Data.DataTable dtAbstract = null;
        //
        switch ( this.AbstractNature)
        {
            case "autore":
                {
                    dtAbstract =
                        Entity_materie.Proxies.usp_autore_note_LOAD_SERVICE.usp_autore_note_LOAD(
                            this.id_Abstract_ToEdit );
                    break;
                }
            case "documento":
                {
                    dtAbstract =
                        Entity_materie.Proxies.usp_docMulti_abstract_LOAD_SERVICE.usp_docMulti_abstract_LOAD(
                            this.id_Abstract_ToEdit );
                    break;
                }
            default:
                {
                    throw new System.Exception(" invalid AbstractNature ");
                    //break;  unreachable
                }
        }// end switch
        //
        try
        {
            if (
                null != dtAbstract
                && 0 < dtAbstract.Rows.Count
                )
            {
                this.txtUpdateAbstract.Text = (string)(dtAbstract.Rows[0].ItemArray[0]);
            }
            else
            {
                throw new System.Exception(" Error while retrieving the required abstract.");
            }
        }
        catch( System.Exception ex)
        {
            string dbg = ex.Message
                + ". StackTrace = " + ex.StackTrace;
            LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                dbg, 0);
            this.txtUpdateAbstract.Text = dbg;
        }
    }// loadData


    protected void btnUpdateAbstract_Click(object sender, EventArgs e)
    {
        this.evaluateStateParams();
        // update IN TRANSACTION.
        switch ( this.AbstractNature)
        {
            case "autore":
                {
                    System.Data.SqlClient.SqlTransaction trx =
                        Common.Connection.TransactionManager.trxOpener(
                            "ProxyGeneratorConnections/strings",// compulsory xpath
                            "materie");
                    int update_res =
                        Entity_materie.Proxies.usp_autore_note_UPDATE_SERVICE.usp_autore_note_UPDATE(
                            this.id_Abstract_ToEdit,
                            this.txtUpdateAbstract.Text,
                            trx
                        );
                    Common.Connection.TransactionManager.trxCloser(trx, true);
                    break;
                }
            case "documento":
                {
                    System.Data.SqlClient.SqlTransaction trx =
                        Common.Connection.TransactionManager.trxOpener(
                            "ProxyGeneratorConnections/strings",// compulsory xpath
                            "materie");
                    int update_res =
                        Entity_materie.Proxies.usp_docMulti_abstract_UPDATE_SERVICE.usp_docMulti_abstract_UPDATE(
                            this.id_Abstract_ToEdit,
                            this.txtUpdateAbstract.Text,
                            trx
                        );
                    Common.Connection.TransactionManager.trxCloser(trx, true);
                    break;
                }
            default:
                {
                    throw new System.Exception(" invalid AbstractNature ");
                    //break;  unreachable
                }
        }// end switch
    }//


}// end class
