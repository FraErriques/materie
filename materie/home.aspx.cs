using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



public partial class home : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        string Lang = null;
        if (Request.UserLanguages != null)
        {
            if (0 < Request.UserLanguages.Length)
            {
                Lang = Request.UserLanguages[0];
                if (Lang != null)
                {
                    // TODO
                }
                else
                {
                    // TODO
                }
                /* ---------------------------- tips & tricks ----------------------------------
                 * 
                 * System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Lang) ;
                 * if (CurrencySymbol != null && CurrencySymbol != "")
                 * {
                 *      CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = CurrencySymbol;
                 * }// else skip
                 * 
                 */
            }// else skip
        }// else skip
        string currentCurrencySymbol = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol;
        //
        //--check just onEntry, since also un-logged can enter here.-----
        //
        /*
         * NB. page state check.-----------------------------------------------------------------
         * 
         */
        PageStateChecker.PageStateChecker_SERVICE(
            "home"
            , this.Request
            , this.IsPostBack
            , this.Session
        );
        //
        //string url = HttpContext.Current.Request.Url.AbsoluteUri;
        //// i.e. complete url_like http://localhost:1302/TESTERS/Default6.aspx
        //string path = HttpContext.Current.Request.Url.AbsolutePath;
        //// /TESTERS/Default6.aspx
        string host = HttpContext.Current.Request.Url.Host; // web server hostname
        string connectionStringContent = DbLayer.ConnectionManager.notifyConnectionStringContent(
        "ProxyGeneratorConnections/strings"
        , "materie");
        string[] dbConnectionToken = connectionStringContent.Split(new char[] { '=', ';' });
        this.lblWebHost.Text = "Web Server hostname = " + host;
        this.lblWebHost.BackColor = System.Drawing.Color.LimeGreen;
        this.lblDbHost.Text = "DB Server hostname  = " + dbConnectionToken[3];
        this.lblDbHost.BackColor = System.Drawing.Color.Beige;


        //----------------------------------------------- END  page state check.-----------------
        LogSinkFs.Wrappers.LogWrappers.SectionOpen("cv_db::home,Page_Load", 0);
        LogSinkDb.Wrappers.LogWrappers.SectionOpen("cv_db::home,Page_Load", 0);
        //
        LogSinkFs.Wrappers.LogWrappers.SectionContent(this.Request.UserHostName, 0);
        LogSinkDb.Wrappers.LogWrappers.SectionContent(this.Request.UserHostName, 0);
        //
        LogSinkFs.Wrappers.LogWrappers.SectionClose();
        LogSinkDb.Wrappers.LogWrappers.SectionClose();
        //
        if (VerificaLasciapassare.CanLogOn(this.Session, this.Request.UserHostAddress))
        {
            try
            {
                Control loginForm = this.LoginSquareClient1.FindControl("divLoginSquareContent");
                loginForm.Visible = false;// hide login.
            }
            catch (System.Exception ex)
            {
                string dbg = ex.Message + "___" + ex.StackTrace;
            }
        }// else show login.
    }// end Page_Load()


}//
