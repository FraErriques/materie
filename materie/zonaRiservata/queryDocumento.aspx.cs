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


public partial class zonaRiservata_queryDocumento : System.Web.UI.Page
{
    private int indexOfAllSectors; // it's one after the last id in the table.


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!VerificaLasciapassare.CanLogOn(
                this.Session,
                this.Request.UserHostAddress
                )
            )
        {
            this.Session["indexOfAllSectors"] = null;// be sure to clean.
            this.Response.Redirect("../errore.aspx");
        }// else il lasciapassare e' valido -> get in.
        //
        // PostBack or not, refresh in Session, the present addres of the DynamicPortion method, which has
        // to be called from PagerDbView. Such address changes at every round-trip( tested).
        CacherDbView.DynamicPortionPtr dynamicPortionPtr = new CacherDbView.DynamicPortionPtr(
            this.prepareLavagnaDynamicPortion);
        this.Session["DynamicPortionPtr"] = dynamicPortionPtr;
        //
        /*
         * NB. page state check.-----------------------------------------------------------------
         * 
         */
        PageStateChecker.PageStateChecker_SERVICE(
            "zonaRiservata_queryDocumento"
            , this.Request
            , this.IsPostBack
            , this.Session
        );
        //----------------------------------------------- END  page state check.-----------------
        if (
            !this.IsPostBack//----------------------------------------------------false
            && !(bool)(this.Session["IsReEntrant"])//-----------------------------false
            )
        {// first absolute entrance
            //
            ComboManager.populate_Combo_ddlMateria_for_LOAD(//---primo popolamento.
                this.ddlMaterie,
                0 // "null" or <0, for no preselection. Instead to preselect choose the ordinal; eg. 2=="Appalti", 0 for "choose your Sector", which performs no query.
                , out indexOfAllSectors
            );
            this.Session["indexOfAllSectors"] = indexOfAllSectors;// NB.---cache across postbacks.-----
            this.Session["comboSectors_selectedValue"] = 0;// NB.---cache across postbacks.-----
            //
            this.loadData(0);// means no query.
        }
        else if (
            !this.IsPostBack//----------------------------------------------------false
            && (bool)(this.Session["IsReEntrant"])//------------------------------true
            )
        {// coming from html-numbers of pager
            // needed combo-refresh, but re-select combo-Value from Session  --------
            //
            int int_comboSectors_selectedValue = (int)(this.Session["comboSectors_selectedValue"]);// NB.---cache across postbacks.-----
            ComboManager.populate_Combo_ddlMateria_for_LOAD(//---primo popolamento.
                this.ddlMaterie,
                int_comboSectors_selectedValue // "null" or <0, for no preselection. Instead to preselect choose the ordinal; eg. 2=="Appalti", 0 for "choose your Sector", which performs no query.
                , out indexOfAllSectors
            );
            this.Session["indexOfAllSectors"] = indexOfAllSectors;// NB.---cache across postbacks.-----
            //
            // pager will load the new-chunk, based on a get-param.
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
                loadData(int_comboSectors_selectedValue); // TODO debug
                // don't throw new System.Exception(" queryDocumento::Page_Load . this.Session[CacherDbView] is null. ");
            }
        }
        else if (
            this.IsPostBack//------------------------------------------------------true
            && !(bool)(this.Session["IsReEntrant"])//------------------------------false
            )
        {
            // don't: throw new System.Exception(" impossible case: if IsReEntrant at least one entry occurred. ");
        }
        else if (
            this.IsPostBack//------------------------------------------------------true
            && (bool)(this.Session["IsReEntrant"])//-------------------------------true
            )
        {// coming from combo-index-changed.
            // no combo-refresh.
            // drop the current view and create the new one, by delegate ddlSettoriRefreshQuery.
        }// no "else" possible: case mapping is complete.
    }// end Page_Load

    
    //    if (!VerificaLasciapassare.CanLogOn(
    //            this.Session,
    //            this.Request.UserHostAddress
    //            )
    //        )
    //    {
    //        this.Response.Redirect("../errore.aspx");
    //    }// else il lasciapassare e' valido -> get in.
    //    //
    //    /*
    //     * NB. page state check.-----------------------------------------------------------------
    //     * 
    //     */
    //    PageStateChecker.PageStateChecker_SERVICE(
    //        "zonaRiservata_queryDocumento" // TODO add to "Timbro"
    //        , this.Request
    //        , this.IsPostBack
    //        , this.Session
    //    );
    //    //----------------------------------------------- END  page state check.-----------------
    //    //
    //    int sectorCardinality = 0;
    //    if (!this.IsPostBack)
    //    {
    //        // this.loadData();  which?
    //        ComboManager.populate_Combo_ddlSettore_for_LOAD(
    //            this.ddlSettore,
    //            null,// no pre-selection.
    //            out sectorCardinality
    //        );
    //    }// else don't.
    //    else
    //    {
    //        int tmp = sectorCardinality;
    //    }
    //}// end Page_Load.





    ///// <summary>
    ///// NB.----- query on the db_index, NOT on the combo index!------
    /////  mai usare:  this.ddlSettori.SelectedIndex
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void ddlSettoriRefreshQuery(object sender, EventArgs e)
    //{
    //    int int_sector = default(int);
    //    try//---if ddlSettori.SelectedItem==null will throw.
    //    {
    //        int_sector = int.Parse(this.ddlSettori.SelectedItem.Value);
    //        this.Session["comboSectors_selectedValue"] = int_sector;// NB.---cache across postbacks.-----
    //    }
    //    catch (System.Exception ex)
    //    {
    //        string dbg = ex.Message;
    //        int_sector = -1;// invalid.
    //    }
    //    finally
    //    {
    //        this.loadData(int_sector);
    //    }
    //}// end ddlSettoriRefreshQuery





    /// <summary>
    /// NB.---deve essere il Pager a chiamarlo, quando fa DataBind()--this.prepareLavagnaDynamicPortion()
    /// </summary>
    /// <param name="choosenSector"></param>
    private void loadData(int choosenSector)
    {
        string queryTail;
        object obj_indexOfAllSectors = null;
        obj_indexOfAllSectors = this.Session["indexOfAllSectors"];
        if (
            null != obj_indexOfAllSectors
            )
        {
            try
            {
                this.indexOfAllSectors = (int)(obj_indexOfAllSectors);// NB.---cache across postbacks.-----
            }
            catch (System.Exception ex)
            {
                string dbg = ex.Message;
                throw new System.Exception(
                    "queryDocumento::loadData ex = "
                    + ex.Message
                    + " ___ stack = " + ex.StackTrace);
            }
        }
        else
        {
            LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                "queryDocumento::  Debug: Session[_indexOfAllSectors_] is null -> refreshing combo. "
                , 0
            );
            //
            ComboManager.populate_Combo_ddlMateria_for_LOAD(//---primo popolamento.
                this.ddlMaterie,
                choosenSector // "null" or <0, for no preselection. Instead to preselect choose the ordinal; eg. 2=="Appalti", 0 for "choose your Sector", which performs no query.
                , out indexOfAllSectors
            );
            this.Session["indexOfAllSectors"] = indexOfAllSectors;// NB.---cache across postbacks.-----
            this.Session["comboSectors_selectedValue"] = choosenSector;// NB.---cache across postbacks.-----
        }
        //
        if (0 == choosenSector)
        {
            this.grdDatiPaginati.DataSource = null;//  --no query for this selection ---
            this.grdDatiPaginati.DataBind();
            this.prepareLavagnaDynamicPortion();//-------NB.-------------------
            return;// on page: --no query for this selection ---
        }
        else if (
            0 < choosenSector // from 1
            && this.indexOfAllSectors > choosenSector // to the last existing Sector
            )
        {
            queryTail = " and id_settore = " + choosenSector.ToString();
        }
        else if (// "tutti i settori aziendali", i.e. select without "where-tail" -----
            this.indexOfAllSectors == choosenSector)
        {
            queryTail = "";// Proxy will manage it.
        }
        else//  indexes<-1: should never pass here.
        {
            throw new System.Exception(" queryDocumento::combo::indexes <0: should never pass here.");
        }
        //
        System.Web.UI.WebControls.TextBox txtRowsInPage = null;
        int int_txtRowsInPage = default(int);
        try
        {
            txtRowsInPage =
                (System.Web.UI.WebControls.TextBox)(this.PageLengthManager1.FindControl("txtRowsInPage"));
            int_txtRowsInPage = int.Parse(txtRowsInPage.Text);
        }
        catch
        {// on error sends zero rows per page, to Pager.
        }
        //
        CacherDbView cacherDbView = new CacherDbView(
            this.Session
            , queryTail
            , ViewNameDecorator.ViewNameDecorator_SERVICE(this.Session.SessionID)
            , new CacherDbView.SpecificViewBuilder(
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
            throw new System.Exception("Presentation::queryDocumento::loadData() failed CacherDbView Ctor. ");
        }
    }// end loadData()


    #region prepareQueryFilter


    /// <summary>
    // * 2011.04.19
    // * NB. a query like the following does not work, se sono stati inseriti MOLTEPLICI spazi:
    // * select * from candidato where nominativo like '%Di Franza%'
    // * it needs to be patched like this, in order to work:
    // * select * from candidato where nominativo like '%Di%Franza%'
    // * 
    // */
    /// </summary>
    /// <param name="filterTxtFromInterface"></param>
    /// <returns></returns>
    private string SqlTrim(string filterTxtFromInterface)
    {
        string res = filterTxtFromInterface.Trim();//both START and END of string
        res = res.Replace(' ', '%');// blank; since a wrong number of blanks confuse the SqlFullTextSearch.
        res = res.Replace('\'', '%');// single apex is reserved in SQL
        res = res.Replace('"', '%');// double apex is not reserved in SQL, but is confusing for the search in abstracts
        // TODO : check for more.
        return res;
    }// end SqlTrim


    /// <summary>
    /// NB. la query-tail che si costruisce in questa funzione va collegata obbligatoriamente in
    /// "and" con la query-tail presente nella stored, in quanto essa utilizza tale tail per 
    /// evitare un prodotto cartesiano fra candidati e categorie.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void queryDocumentoByFilter(object sender, EventArgs e)
    {
        // NB. primo "and implicito. perchè la stored ha già altri "and" nel testo sql. Quindi clausole ulteriori devono essere precedute
        // da un "and"
        string queryTail = "";
        string indexOfAllSectors = null;
        try
        {
            indexOfAllSectors = ((int)(this.Session["indexOfAllSectors"])).ToString();
        }
        catch// all
        {// indexOfAllSectors will remain null.
        }
        //
        if (
            null == this.ddlMaterie.SelectedItem
            || "0" == this.ddlMaterie.SelectedItem.Value// no sector selected.
            || null == this.ddlMaterie.SelectedItem.Value// managed ex.
            || indexOfAllSectors == this.ddlMaterie.SelectedItem.Value// all sectors selected.
            )
        {
            // invalid "sector" characterization -> where condition omitted.
        }
        else
        {
            queryTail += " and " + this.ddlMaterie.SelectedItem.Value + " = mat.id ";
        }
        //
        /// NB. la query-tail che si costruisce in questa funzione va collegata obbligatoriamente in
        /// "and" con la query-tail presente nella stored, in quanto essa utilizza tale tail per 
        /// evitare un prodotto cartesiano fra candidati e categorie.
        //---check now for nome-Autore
        if (this.txtNominativoAutore.Text.Length > 0)
        {
            string tmp = this.SqlTrim(this.txtNominativoAutore.Text);
            if (0 < tmp.Length)
            {
                queryTail += " and aut.nominativo like '%" + tmp + "%' ";
            }
        }// end nome-Autore
        //---check now for abstract-Autore
        if (this.txtNoteAutore.Text.Length > 0)
        {
            string tmp = this.SqlTrim(this.txtNoteAutore.Text);
            if (0 < tmp.Length)
            {
                queryTail += " and aut.note like '%" + tmp + "%' ";
            }
        }// end nome-Autore
        //---check now for abstract-Documento
        if (this.txtDocumentoAbstract.Text.Length > 0)
        {
            string tmp = this.SqlTrim(this.txtDocumentoAbstract.Text);
            if (0 < tmp.Length)
            {
                queryTail += " and dm.abstract like '%" + tmp + "%' ";
            }
        }// end nome-Autore
        //
        //----here ends the query-tail building code and starts the query execution.
        //
        System.Web.UI.WebControls.TextBox txtRowsInPage = null;
        int int_txtRowsInPage = default(int);
        try
        {
            txtRowsInPage =
                (System.Web.UI.WebControls.TextBox)(this.PageLengthManager1.FindControl("txtRowsInPage"));
            int_txtRowsInPage = int.Parse(txtRowsInPage.Text);
        }
        catch
        {// on error sends zero rows per page, to Pager.
        }
        //
        CacherDbView cacherDbView = new CacherDbView(
            this.Session
            , queryTail
            , ViewNameDecorator.ViewNameDecorator_SERVICE(this.Session.SessionID)
            , new CacherDbView.SpecificViewBuilder(
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
            throw new System.Exception("Presentation::queryDocumento::loadData() failed CacherDbView Ctor. ");
        }
    }// end btnDoPostback()





    #endregion



    #region dataOnGridView


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
        if (
            1 == loggedUsrLevel
            || 2 == loggedUsrLevel
            )
        {
            this.grdDatiPaginati.Columns[5].Visible = true;// disable column "add-Doc", for ALL rows.
            this.grdDatiPaginati.Columns[7].Visible = true;// disable column "update-Abstract", for ALL rows.
        }
        else
        {
            this.grdDatiPaginati.Columns[5].Visible = false;// disable column "add-Doc", for ALL rows.
            this.grdDatiPaginati.Columns[7].Visible = false;// disable column "update-Abstract", for ALL rows.
        }
    }// end prepareLavagnaDynamicPortion()


    protected void grdDatiPaginati_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_Job_ToEdit = default(int);
        string Job_Edit_Nature = default(string);
        try
        {
            id_Job_ToEdit = int.Parse((string)e.CommandArgument);
            Job_Edit_Nature = (string)e.CommandName;
        }
        catch (System.Exception ex)
        {
            string dbg = ex.Message;
            return;// on page: TODO
        }
        //
        switch (Job_Edit_Nature)
        {
            default:
            case "GeneralEdit":
                {// caso di download Documento: avviene in pagina e permane la tabella Documento.
                    try
                    {
                        this.downloadButton_Click(id_Job_ToEdit);
                    }
                    catch (System.Exception ex)
                    {// let it default to -1
                        string dbg = ex.Message;
                        string stack_dbg = ex.StackTrace;
                        LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                            " exception while downloading from web : " + ex.Message
                            + "  " + ex.StackTrace
                            ,5 // keep it high
                        );
                    }
                    break;
                }
            // NB. evaluate the following Session-pars.
            //this.Session["ref_abstract_id"] = ...;
            //this.Session["AbstractNature"] = ...;// {"autore", "documento"}
            case "AddDocuments":
                {// NB. compulsory double-key required:
                    // this.Session["chiaveDoppiaAutore"]);
                    // this.Session["chiaveDoppiaMateria"]);
                    // load the double-key of this document
                    System.Data.DataTable dtDoubleKey = 
                        Entity_materie.Proxies.usp_docMulti_getDobleKey_at_DocId_SERVICE.usp_docMulti_getDobleKey_at_DocId(id_Job_ToEdit);
                    int idMateriaPrescelta = ((int)(dtDoubleKey.Rows[0]["IdMateria"]));
                    int idAutorePrescelto = ((int)(dtDoubleKey.Rows[0]["IdAutore"]));
                    this.Session["chiaveDoppiaAutore"] = idAutorePrescelto;
                    this.Session["chiaveDoppiaMateria"] = idMateriaPrescelta;
                    this.Session["ref_documento_id"] = id_Job_ToEdit;
                    this.Session["indexOfAllSectors"] = null;// be sure to clean.
                    this.Response.Redirect("docMultiInsert.aspx");
                    break;
                }
            case "UpdateAbstract":
                {
                    this.Session["ref_abstract_id"] = id_Job_ToEdit;
                    this.Session["AbstractNature"] = "documento";// {"autore", "documento"}
                    this.Session["indexOfAllSectors"] = null;// be sure to clean.
                    this.Response.Redirect("UpdateAbstract.aspx");
                    break;
                }
        }// end switch.
        // ready, with tokens in Session.
    }




    protected void verifyDoubleKey(int DocId)
    {
        // TODO : query db x verifica esistenza chiave doppia
        //if(correct) -> goto docMultiInsert.aspx
        //else -> selfPostBack con errore in Session, XhtmlMobileDocType pubblicazione in Page_Load()
        int idMateriaPrescelta = 0;
        int idAutorePrescelto = 0;
        System.Data.DataSet ds;
        bool resultMateria = false;// init
        bool resultAutore = false;// init
        //
        try
        {// load the double-key of this document
            System.Data.DataTable dtDoubleKey = Entity_materie.Proxies.usp_docMulti_getDobleKey_at_DocId_SERVICE.usp_docMulti_getDobleKey_at_DocId(DocId);
            idMateriaPrescelta = ((int)(dtDoubleKey.Rows[0]["IdMateria"]));
            idAutorePrescelto = ((int)(dtDoubleKey.Rows[0]["IdAutore"]));
            //
            ds = Entity_materie.Proxies.usp_chiaveDoppia_LOAD_SERVICE.usp_chiaveDoppia_LOAD();//--load all existing single keys, to do combinatorics
            if (null == ds || 2 != ds.Tables.Count)
            {
                throw new System.Exception(" Error: chiaveDoppia errata per Materia-Autore.");
            }// else continue.
            int hmMaterie = ds.Tables[0].Rows.Count;// Tables[0]==Materia
            int hmAutori = ds.Tables[1].Rows.Count; // Tables[1]==Autore
            //
            for (int c = 0; c < hmMaterie; c++)
            {
                int curMateria = ((int)(ds.Tables[0].Rows[c]["id"])); // Tables[0]==Materia
                if (idMateriaPrescelta == curMateria)
                {
                    resultMateria = true;
                    break;
                }// else continue searching for Materia
            }// end for Materia
            //
            for (int c = 0; c < hmAutori; c++)
            {
                int curAutore = ((int)(ds.Tables[1].Rows[c]["id"]));// Tables[1]==Autore
                if (idAutorePrescelto == curAutore)
                {
                    resultAutore = true;
                    break;
                }// else continue searching for Autore
            }// end for Autore
        }// end try
        catch (System.Exception ex)
        {
            string msg = ex.Message;
            this.lblErroreChiave.Text += " Exception while processing chiaveDoppia per Materia-Autore.";
            this.lblErroreChiave.BackColor = System.Drawing.Color.Red;
            return; //on page
        }
        if (resultAutore && resultMateria)// both
        {
            this.Session["chiaveDoppiaMateria"] = idMateriaPrescelta;
            this.Session["chiaveDoppiaAutore"] = idAutorePrescelto;
            this.lblErroreChiave.Text += "";
            this.lblErroreChiave.BackColor = System.Drawing.Color.Transparent;
            this.Session["DynamicPortionPtr"] = null;// be sure to clean.
            this.Response.Redirect("docMultiInsert.aspx");
        }
        else
        {
            this.lblErroreChiave.Text += " Error: chiaveDoppia errata per Materia-Autore.";
            this.lblErroreChiave.BackColor = System.Drawing.Color.Red;
            return; //on page
        }
    }// end method verifyDoubleKey()


    /// <summary>
    /// download selected doc, for edit or save.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void downloadButton_Click(int id_doc_multi)
    {// query for blob at id, by means of Entity_materie::Doc_multi.
        
        webOnlyPortionDownloader_SERVICE.webOnlyPortionDownloader(
            id_doc_multi,
            this.Context
        );

        //Downloader.DownloadButton_Click(
        //    id_doc_multi,
        //    this.Context
        //);
    }//


    #endregion dataOnGridView

}// end class.

#region cantina

        //<table  width="80%">
        //<tr >
        //<br />
        //   <asp:Label ID="lblSettori" runat="server">indicazione facoltativa del <b><u>settore</u></b> di appartenenza del documento</asp:Label>
        //</tr>
        //<br />
        //<tr>
        //   <asp:DropDownList ID="ddlSettori" runat="server" Width="80%"></asp:DropDownList>
        //</tr>
        //<br />
        //<br />
        //<br />
        //<tr>
        //   <asp:Label ID="lblConnectorOne" runat="server">il connettore logico e' obbligatoriamente <b><u>and</u></b> per queste clausole</asp:Label>
        //</tr>        
        //<tr>
        //   <asp:RadioButtonList ID="rbtAndOr_settore_nominativo" runat="server" Enabled="false">
        //        <asp:ListItem id="rdeAnd_settore_nominativo" Enabled="true" Selected="True" Text="And" Value="And"></asp:ListItem>
        //        <asp:ListItem id="rdeOr_settore_nominativo" Enabled="true" Selected="False" Text="Or" Value="Or"></asp:ListItem>
        //   </asp:RadioButtonList>
        //</tr>
        //<tr>
        //   <asp:Label ID="lblNominativo" runat="server">porzioni, facoltative, di testo da riconoscere nel <b><u>nominativo</u></b> del candidato</asp:Label>
        //</tr>
        //<br />
        //<tr>
        //   <asp:TextBox ID="txtNominativo" runat="server"></asp:TextBox>
        //</tr>
        //<br />
        //<br />
        //<br />
        //<tr>
        //   <asp:Label ID="lblConnectorTwo" runat="server">il connettore logico e' obbligatoriamente <b><u>and</u></b> per queste clausole</asp:Label>
        //</tr>
        //<tr>
        //   <asp:RadioButtonList ID="rbtAndOr_nominativo_abstract" runat="server" Enabled="false">
        //        <asp:ListItem id="rdeAnd_nominativo_abstract" Enabled="true" Selected="True" Text="And" Value="And"></asp:ListItem>
        //        <asp:ListItem id="rdeOr_nominativo_abstract" Enabled="true" Selected="False" Text="Or" Value="Or"></asp:ListItem>
        //   </asp:RadioButtonList>
        //</tr>
        //<tr>
        //   <asp:Label ID="lblAbstract" runat="server">porzioni, facoltative, di testo da riconoscere nella <b><u>descrizione</u></b> del candidato</asp:Label>
        //</tr>
        //<br />
        //<tr>
        //   <asp:TextBox ID="txtAbstract" runat="server"></asp:TextBox>
        //</tr>
        //<br />
        //<br />
        //<br />        
        //<tr>
        //   <asp:Button ID="btnDoPostback" runat="server" Text="invio richiesta" OnClick="btnDoPostback_Click"></asp:Button>
        //</tr>        
        //</table>           



//if( queryTail.Length>5)// something added to the initial "and"->add another logical connector
//{
//    if(this.rdeAnd_settore_nominativo.Selected)
//    {
//        queryTail += " and ";
//    }
//    else if(this.rdeOr_settore_nominativo.Selected)
//    {
//        queryTail += " or ";
//    }
//    else
//    {
//        throw new System.Exception("Debug needed on page queryCaqndidato ! ");
//    }
//}
//else// nothing added to the initial "and" -> DON'T add another logical connector.
//{
//}
///* 2011.04.19
// * NB. a query like the following does not work, se sono stati inseriti MOLTEPLICI spazi:
// * select * from candidato where nominativo like '%Di Franza%'
// * it needs to be patched like this, in order to work:
// * select * from candidato where nominativo like '%Di%Franza%'
// * 
// */
//string txtNominativoFiltering = this.txtNominativo.Text.Trim();
//txtNominativoFiltering = txtNominativoFiltering.Replace(' ', '%');// NB. see note above.
//txtNominativoFiltering = txtNominativoFiltering.Replace('\'', '%');// NB. single apex is a reserved char in SQL.
//queryTail += " c.nominativo like '%" + txtNominativoFiltering + "%'";
////
//// it's necessary to add another logical connector.
//if(this.rdeAnd_nominativo_abstract.Selected)
//{
//    queryTail += " and ";
//}
//else if(this.rdeOr_nominativo_abstract.Selected)
//{
//    queryTail += " or ";
//}
//else
//{
//    throw new System.Exception("Debug needed on page queryCaqndidato ! ");
//}
//queryTail += " c.note like '%" + this.txtAbstract.Text.Trim() + "%'";

#endregion
