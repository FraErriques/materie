using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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
            "_Default"
            , this.Request
            , this.IsPostBack
            , this.Session
        );
        //----------------------------------------------- END  page state check.-----------------
        LogSinkFs.Wrappers.LogWrappers.SectionOpen("materie::_Default,Page_Load", 0);
        LogSinkDb.Wrappers.LogWrappers.SectionOpen("materie::_Default,Page_Load", 0);
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
