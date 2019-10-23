using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class zonaRiservata_zprotoDocRead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!VerificaLasciapassare.CanLogOn(
                this.Session,
                this.Request.UserHostAddress
                )
            )
        {
            this.Session["DynamicPortionPtr"] = null;// be sure to clean.
            this.Response.Redirect("../errore.aspx");
        }// else il lasciapassare e' valido -> get in.
        //
        //
        //
        // PostBack or not, refresh in Session, the present addres of the DynamicPortion method, which has
        // to be called from PagerDbView. Such address changes at every round-trip( tested).
        CacherDbView.DynamicPortionPtr dynamicPortionPtr = new CacherDbView.DynamicPortionPtr(
            this.prepareLavagnaDynamicPortion);
        this.Session["DynamicPortionPtr"] = dynamicPortionPtr;
        //
        object obj_CacherDbView = this.Session["CacherDbView"];
        if (null != obj_CacherDbView)
        {
            ((CacherDbView)obj_CacherDbView).Pager_EntryPoint(
                this.Session
                , this.Request
                , this.grdDatiPaginati
                , this.pnlPageNumber
            );
        }
        else
        {
            this.loadData();// creates the View, via the Cacher
        }
    }// Page_Load


    private void loadData()
    {
        string where_tail = "";
        int int_txtRowsInPage = default( int);
        try
        {
            System.Web.UI.WebControls.TextBox txtRowsInPage =
                (System.Web.UI.WebControls.TextBox)(this.PageLengthManager1.FindControl("txtRowsInPage"));
            int_txtRowsInPage = int.Parse( txtRowsInPage.Text);
        }
        catch( System.Exception ex)
        {
            this.lblStatus.Text = ex.InnerException.ToString();
        }
        //
        CacherDbView cacherDbView = new CacherDbView(
            this.Session
            , where_tail
            , ViewNameDecorator.ViewNameDecorator_SERVICE(this.Session.SessionID)
            ,new CacherDbView.SpecificViewBuilder(
                Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_documento_SERVICE.usp_ViewCacher_specific_CREATE_documento
             )
            , int_txtRowsInPage
            //
            , this.Request
            , this.grdDatiPaginati
            , this.pnlPageNumber
        );
        if (null != cacherDbView)
        {
            this.Session["CacherDbView"] = cacherDbView;
            cacherDbView.Pager_EntryPoint(
                this.Session
                , this.Request
                , this.grdDatiPaginati
                , this.pnlPageNumber
            );
        }
        else
        {
            throw new System.Exception("Presentation::zprotoDocRead::loadData() failed CacherDbView Ctor. ");
        }        
    }// loadData

    private void prepareLavagnaDynamicPortion()
    {
        int loggedUsrLevel = RoleChecker.TryRoleChecker(
            this.Session,
            this.Request.UserHostAddress
        );
        /*
         *  0  unlogged
         *  1  admin
         *  2  writer
         *  3  reader
         * 
         */
        //if (
        //    1 == loggedUsrLevel
        //    || 2 == loggedUsrLevel
        //    )
        //{
        //    this.grdDatiPaginati.Columns[3].Visible = true;
        //}
        //else
        //{
        //    this.grdDatiPaginati.Columns[3].Visible = false;// disable column "add-Doc", for ALL rows.
        //    this.btnSubmitDoubleKey.Enabled = false;// disable every writing feature, for read-only users.
        //}
    }// end prepareLavagnaDynamicPortion()


}// class
