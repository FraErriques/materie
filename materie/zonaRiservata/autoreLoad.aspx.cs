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


public partial class zonaRiservata_autoreLoad : System.Web.UI.Page
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
            this.Session["DynamicPortionPtr"] = null;// be sure to clean.
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
            "zonaRiservata_autoreLoad"
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
                0 // "null" or <0, for no preselection. Instead to preselect choose the ordinal; 0 for "choose your Sector", which performs no query.
                , out indexOfAllSectors
            );
            this.Session["indexOfAllSectors"] = indexOfAllSectors;// NB.---cache across postbacks.-----
            this.Session["comboSectors_selectedValue"] = 0;// NB.---cache across postbacks.-----
            //
            this.loadMaterie(0);// means: populate comboMaterie on Page_Load (with no pre-selection).
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
                int_comboSectors_selectedValue // "null" or <0, for no preselection. Instead to preselect choose the ordinal; 0 for "choose your Sector".
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
                loadMaterie(int_comboSectors_selectedValue); //  needed combo-refresh, but re-select combo-Value from Session  --------
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
            // drop the current view and create the new one, by delegate ddlMaterieRefreshQuery.
        }// no "else" possible: case mapping is complete.
    }// end Page_Load




    /// <summary>
    /// NB.----- query on the db_index, NOT on the combo index!------
    ///  mai usare:  this.ddlMaterie.SelectedIndex
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void queryAutoriByNominativoNote(object sender, EventArgs e)
    {
        int int_sector = default(int);
        try//---if ddlMaterie.SelectedItem==null will throw.
        {
            int_sector = int.Parse(this.ddlMaterie.SelectedItem.Value);
            this.Session["comboSectors_selectedValue"] = int_sector;// NB.---cache across postbacks.-----
        }
        catch (System.Exception ex)
        {
            string dbg = ex.Message;
            int_sector = -1;// invalid.
        }
        finally
        {
            this.goProxyQueryAutoriByNominativoNote();// query sugli autori by Nominativo & Note.
        }
    }// end ddlMaterieRefreshQuery


    protected void queryAutoriWithArticoliSuMateria(object sender, EventArgs e)
    {
        int int_sector = default(int);
        try//---if ddlMaterie.SelectedItem==null will throw.
        {
            int_sector = int.Parse(this.ddlMaterie.SelectedItem.Value);
            this.Session["comboSectors_selectedValue"] = int_sector;// NB.---cache across postbacks.-----
            this.indexOfAllSectors = (int)(this.Session["indexOfAllSectors"]);
        }
        catch (System.Exception ex)
        {
            string dbg = ex.Message;
            int_sector = -1;// invalid.
        }
        finally
        {// TODO : prevedere caso query su tutte le materie (i.e. su tutti gli Autori censiti ).
            if (int_sector >= this.indexOfAllSectors)
            {
                int_sector = -1;// int_sector<0 means search Authors who wrote on whatever Subject.
            }// else keep the single_Materia index.
            System.Data.DataTable dt = Entity_materie.Proxies.usp_autore_LOAD_whoWroteOnMateria_SERVICE.usp_autore_LOAD_whoWroteOnMateria(int_sector);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
    }




    /// <summary>
    /// popolamento Combo Materie censite
    /// NB.---deve essere il Pager a chiamarlo, quando fa DataBind()--this.prepareLavagnaDynamicPortion()  TODO ?? chiarire
    /// </summary>
    /// <param name="choosenSector">id della materia censita, selezionata dalla combo Materie. Su tale id_Materia viene fatta una query che estrae 
    /// gli autori che hanno almento un articolo su tale Materia, in questo db.
    /// </param>
    private void loadMaterie(int choosenSector)
    {
        //string queryTail;
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
                    "autoreLoad::loadMaterie ex = "
                    +ex.Message
                    +" ___ stack = " +ex.StackTrace);
            }
        }
        else
        {
            LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                "autoreLoad::  Debug: Session[_indexOfAllSectors_] is null -> refreshing combo. "
                , 0
            );
            //
            ComboManager.populate_Combo_ddlMateria_for_LOAD(//---primo popolamento.
                this.ddlMaterie,
                choosenSector // "null" or <0, for no preselection. Instead to preselect choose the ordinal; 0 for "choose your Sector".
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
        //---------manage Paged grdView ---------------------
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
            , null //queryTail
            , ViewNameDecorator.ViewNameDecorator_SERVICE(this.Session.SessionID)
            , new CacherDbView.SpecificViewBuilder(
                Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
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
            throw new System.Exception("Presentation::autoreLoad::loadMaterie() failed CacherDbView Ctor. ");
        }
    }// end loadMaterie()



    /// <summary>
    /// // query sugli autori by Nominativo & Note.
    /// </summary>
    private void goProxyQueryAutoriByNominativoNote( )
    {
        string queryTail;
        // Esempio di come deve diventare la queryTail: predisporre due textBox multiline per raccogliere "note" e "nominativo" like% ed "and".
            /*  	where 
					note like '%cant%'
					and nominativo like '%Galil%'
             */
            queryTail = "";// init;// no connection between Autore and Materia // was: and id_settore = " + choosenSector.ToString();
            if (null != this.txtNominativoAutore.Text && "" != this.txtNominativoAutore.Text)
            {
                queryTail += " where nominativo like '%";
                queryTail += this.txtNominativoAutore.Text;
                queryTail += "%' ";
            }// else the field queryTail stays as queryTail = "";// init;
            if (null != this.txtNoteAutore.Text && "" != this.txtNoteAutore.Text)
            {
                if ("" == queryTail)
                {// decide where the present condition is the first or the second one.
                    queryTail += " where ";
                }
                else
                {
                    queryTail += " and ";
                }
                queryTail += " note like '%";
                queryTail += this.txtNoteAutore.Text;
                queryTail += "%' ";
            }// else the field queryTail stays as queryTail = "";// init or as set by the previous statement.
            //
            //---manage the Cacher & Pager here.
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
            CacherDbView cacherDbView = new CacherDbView(
                this.Session
                , queryTail
                , ViewNameDecorator.ViewNameDecorator_SERVICE(this.Session.SessionID)
                , new CacherDbView.SpecificViewBuilder(
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
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
                throw new System.Exception("Presentation::autoreLoad::goProxyQueryAutoriByNominativoNote() failed CacherDbView Ctor. ");
            }
    }// end goProxyQueryAutoriByNominativoNote()



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
        if(
            1 == loggedUsrLevel
            || 2 == loggedUsrLevel
            )
        {   //----grid x Autore
            this.grdDatiPaginati.Columns[3].Visible = true;// insert Documento on current Autore
            this.grdDatiPaginati.Columns[4].Visible = true;// update Abstract Autore
            //----- grid AutoreCheHaScrittoSuMateria
            this.GridView1.Columns[4].Visible = true;// select "Materia" x DoubleKey.
        }
        else
        {
            this.grdDatiPaginati.Columns[3].Visible = false;// disable column "add-Doc", for ALL rows.
            this.grdDatiPaginati.Columns[4].Visible = false;// disable column "update-Abstract-Autore", for ALL rows.
            //----- grid AutoreCheHaScrittoSuMateria
            this.GridView1.Columns[4].Visible = false;// select "Materia" x DoubleKey.
            //--- button_Check_DoubleKey
            this.btnSubmitDoubleKey.Enabled = false;// disable every writing feature, for read-only users.
        }
    }// end prepareLavagnaDynamicPortion()




    protected void doPublishMateriaFromCombo(object sender, EventArgs e)
    {
        // ?? if( all_materie SelectedDatesCollection index 
        // ?? if( choose materia SelectedDatesCollection index 
        this.Session["ref_materia_id"] = this.ddlMaterie.SelectedItem.Value;
        this.txtChiaveMateria.Text = this.ddlMaterie.SelectedItem.Value.ToString();
    }// doPublishMateriaFromCombo


    
    protected void grdAutorePerMateria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_Materia_ToEdit = default(int);
        string Job_Edit_Nature = default(string);
        try
        {
            Job_Edit_Nature = (string)e.CommandName;
            id_Materia_ToEdit = int.Parse((string)e.CommandArgument);
        }
        catch (System.Exception ex)
        {
            string dbg = ex.Message;
            return;// out of here.
        }
        //
        switch (Job_Edit_Nature)
        {
            default:
            case "AddDocuments":
                {
                    this.Session["ref_materia_id"] = id_Materia_ToEdit;
                    //this.Session["indexOfAllSectors"] = null;// be sure to clean.
                    //this.Response.Redirect("docMultiInsert.aspx");
                    this.txtChiaveMateria.Text = id_Materia_ToEdit.ToString(); // ? this.ddlMaterie.SelectedItem.Value.ToString();
                    break;
                }
        }//switch (Job_Edit_Nature)
    }// grdAutorePerMateria_RowCommand

    protected void grdDatiPaginati_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_Autore_ToEdit = default(int);
        string Job_Edit_Nature = default(string);
        try
        {
            Job_Edit_Nature = (string)e.CommandName;
            id_Autore_ToEdit = int.Parse((string)e.CommandArgument);
        }
        catch (System.Exception ex)
        {
            string dbg = ex.Message;
            return;// out of here.
        }
        //
        switch (Job_Edit_Nature)
        {
            default:
            case "GeneralEdit":
                {
                    this.Session["ref_candidato_id"] = id_Autore_ToEdit;
                    this.Session["indexOfAllSectors"] = null;// be sure to clean.
                    this.Session["DynamicPortionPtr"] = null;// be sure to clean.
                    this.Response.Redirect("cvMultiRead.aspx");
                    break;
                }
            case "AddDocuments":
                {
                    this.Session["ref_candidato_id"] = id_Autore_ToEdit;
                    this.txtChiaveAutore.Text = id_Autore_ToEdit.ToString();// just write into the txtBox of Autore.
                    break;// the double key has to be checked: stay on page.
                }
            case "UpdateAbstract":
                {
                    this.Session["ref_abstract_id"] = id_Autore_ToEdit;
                    this.Session["AbstractNature"] = "autore";// {"autore", "documento"}
                    this.Session["indexOfAllSectors"] = null;// be sure to clean.
                    this.Session["DynamicPortionPtr"] = null;// be sure to clean.
                    this.Response.Redirect("UpdateAbstract.aspx");
                    break;
                }
        }// end switch.
        // ready, with tokens in Session.
    }// end method grdDatiPaginati_RowCommand()



    protected void verifyDoubleKey(object sender, EventArgs e)
    {
        // TODO : query db x verifica esistenza chiave doppia
        //if(correct) -> goto docMultiInsert.aspx
        //else -> selfPostBack con errore in Session, XhtmlMobileDocType pubblicazione in Page_Load()
        int idMateriaPrescelta = 0;
        int idAutorePrescelto  = 0;
        System.Data.DataSet ds;
        bool resultMateria = false;// init
        bool resultAutore = false;// init
        try
        {
            idMateriaPrescelta = int.Parse(this.txtChiaveMateria.Text);
            idAutorePrescelto = int.Parse(this.txtChiaveAutore.Text);
            ds = Entity_materie.Proxies.usp_chiaveDoppia_LOAD_SERVICE.usp_chiaveDoppia_LOAD();
            if (null == ds || 2 != ds.Tables.Count)
            {
                throw new System.Exception(" Error: chiaveDoppia errata per Materia-Autore.");
            }// else continue.
            int hmMaterie = ds.Tables[0].Rows.Count;// Tables[0]==Materia
            int hmAutori = ds.Tables[1].Rows.Count; // Tables[1]==Autore
            //
            for( int c=0; c<hmMaterie; c++)
            {
                int curMateria = ((int)(ds.Tables[0].Rows[c]["id"])); // Tables[0]==Materia
                if (idMateriaPrescelta == curMateria)
                {
                    resultMateria = true;
                    break;
                }// else continue searching for Materia
            }// end for Materia
            //
            for( int c=0; c<hmAutori; c++)
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
            return; //on page NB. do not do ResponseRedirect if you have to remain inPage.
            //Doing "return" stays on the client and preserves the control content(i.e. textBox, etc.).
        }
    }// end method verifyDoubleKey()




    


}// end class


#region cantina

            //protected void Go_zprotoDocRead(object sender, EventArgs e)
            //{
            //    this.Session["DynamicPortionPtr"] = null;
            //    this.Response.Redirect("zprotoDocRead.aspx");
            //}
            //<asp:TemplateField HeaderText="Consultazione documenti dell' Autore"  HeaderStyle-Font-Bold="true"  ItemStyle-Width="3%">
            //    <ItemTemplate>
            //        <table>
            //            <tr align="center" valign="middle">
            //                <td align="center" valign="middle">
            //                    <asp:ImageButton ID="btnReadCv" runat="server" ImageUrl="~/img/btnMailRead.bmp"  Enabled="True" Visible="False" CommandName="GeneralEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:ImageButton>
            //                </td>
            //            </tr>
            //        </table>					            
            //    </ItemTemplate>
            //    <HeaderStyle Font-Bold="True"></HeaderStyle>
            //    <ItemStyle Width="3%"></ItemStyle>
            //</asp:TemplateField>

            //<asp:TemplateField HeaderText="Update Abstract"  HeaderStyle-Font-Bold="true"  ItemStyle-Width="3%">
            //    <ItemTemplate>
            //        <table>
            //            <tr align="center" valign="middle">
            //                <td align="center" valign="middle">
            //                    <asp:ImageButton ID="btnUpdateAbstract" runat="server" ImageUrl="~/img/btnUpdateAbstract.bmp"  Enabled="True" Visible="False" CommandName="UpdateAbstract" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:ImageButton>
            //                </td>
            //            </tr>
            //        </table>					            
            //    </ItemTemplate>
            //    <HeaderStyle Font-Bold="True"></HeaderStyle>
            //    <ItemStyle Width="3%"></ItemStyle>
            //</asp:TemplateField>

////ddlAutoreRefreshQuery
//protected void ddlAutoreRefreshQuery(object sender, EventArgs e)
//{
//    int int_autore = default(int);
//    try//---if ddlAutore.SelectedItem==null will throw.
//    {
//        int_autore = int.Parse(this.ddlAutore.SelectedItem.Value);
//        this.Session["comboAutore_selectedValue"] = int_autore;// NB.---cache across postbacks.-----
//    }
//    catch (System.Exception ex)
//    {
//        string dbg = ex.Message;
//        int_autore = -1;// invalid.
//    }
//    finally
//    {
//        this.loadMaterie(int_autore);
//    }
//}// end ddlAutoreRefreshQuery



//object id_condizione_obj = this.dtCandidati.Rows[c]["id_condizione"];// stato-fase, i.e. {"accesa", "spenta"}.
//object id_statoLavorazione_obj = this.dtCandidati.Rows[c]["id_statoLavorazione"];// {sospesa,..,etc.}
////
////-------------START individuazione lavori scaduti--------------------------------------------------
//object scadenzaRiga_obj =
//    this.dtCandidati.Rows[c]["orizzonteProposto"];
//DateTime scadenzaRiga = DateTime.MaxValue;// init to "far-deadline".
//if (
//    System.DBNull.Value == scadenzaRiga_obj
//    || null == scadenzaRiga_obj
//    )
//{// keep initialization to "far-deadline".
//}
//else
//{
//    scadenzaRiga = (DateTime)scadenzaRiga_obj;
//    if (scadenzaRiga < DateTime.Now)
//    {
//        ((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).BackColor =
//            System.Drawing.Color.YellowGreen;// expired deadline.
//    }// else leave its beige default.
//}
//-------------END individuazione lavori scaduti--------------------------------------------------
//

//-----caso del destinatario, che fa avanzare la applicazione-------------
//if (
//    1==1
//    //(str_parRuolo == "addressee" || str_parRuolo == "requirer")
//    //&& (str_parEditMode == "insert" || str_parEditMode == "updateFull")
//    //&& (str_parCriterio == "1" || str_parCriterio == "3")
//   )
//{// scelta colore in base ad "fase-accesa"-"fase-spenta".
//    if (2 != (int)id_condizione_obj)// if != "accesa"
//    {
//        ((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Enabled = false;// disable entire row.
//        ((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).BackColor = System.Drawing.Color.BurlyWood;
//        ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[10]).Visible = true;//  "avanzamento" icon: visible and enabled, but readonly when needed so.
//        //
//        ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[13]).Visible = true;// shift-arrows" icon
//        ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[13]).Enabled = false;// shift-arrows" icon
//    }// else leave it enabled.
//}// end scelta colore in base ad "fase-accesa"-"fase-spenta".
//else if (
//    2==5
//    // sola lettura delle pratiche "proprie" (richiedente o destinatario), anche spente.
//    //(str_parRuolo == "addressee" || str_parRuolo == "requirer")
//    //&& (str_parEditMode == "read")
//    //&& (str_parCriterio == "5")
//   )
//{// righe "fase-spenta" gia' scartate via query.
//    ((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Enabled = true;// enable entire row.
//    // in default color, without horizont-arrows, with edit-btn in read only.
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[10]).Visible = true;//  "avanzamento" icon: visible and enabled, but readonly when needed so.
//    //
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[13]).Visible = true;// shift-arrows" icon
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[13]).Enabled = false;// shift-arrows" icon
//}// end scelta colore in base ad "fase-accesa"-"fase-spenta".
//else if (
//    2==2
////"stranger" == str_parRuolo                // neither requirer nor addressee, i.e. translator
////    // && 2 == (int)id_condizione_obj         // translate dead phases too.
////            && 7 > (int)(id_statoLavorazione_obj)     // i.e. non ancora tradotta.
////            && "updateTranslate" == str_parEditMode   // from menu "Traduzioni"
//    )
//{// traduzioni
//    ((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Enabled = true;// enable entire row.
//    ((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).BackColor = System.Drawing.Color.Aquamarine;
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[10]).Visible = true;// change "avanzamento" icon into traduzioni
//    System.Web.UI.Control mycontrol_btnStatoLavorazione =
//        (this.dgrCandidati.Items[c]).FindControl("btnStatoLavorazione");
//    ((System.Web.UI.WebControls.ImageButton)mycontrol_btnStatoLavorazione).ImageUrl =
//        "~/img/traduzioni.jpg";
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[13]).Visible = true;// shift-arrows" icon
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[13]).Enabled = false;// shift-arrows" icon
//}// end traduzioni
//else if (
//    2==3
//    //"stranger" == str_parRuolo    // neither requirer nor addressee, nor translator but reader
//    //&& "read" == str_parEditMode   // from menu "mera elencazione"
//    )
//{// reader
//    ((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Enabled = true;// disable entire row.
//    ((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).BackColor = System.Drawing.Color.BurlyWood;
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[10]).Visible = true;//  "avanzamento" icon: visible and enabled, but readonly when needed so.
//    //
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[13]).Visible = true;// shift-arrows" icon
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[13]).Enabled = false;// shift-arrows" icon
//}// end reader
//
//-------------------------------------loop on each job------------------------------
//for (int c = 0; c < nLavori; c++)
//{
//if (  // esempio di variazione su colonne, operate riga per riga.
//        6 == logged_usr_id // admin for dbg
//  )
//{
//    // colonna UpdateAbstract visible.
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[6]).Visible = true;
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[6]).Enabled = true;
//}
//else
//{
//    // colonna UpdateAbstract NOT visible.
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[6]).Visible = false;
//    ((((System.Web.UI.WebControls.TableRow)(this.dgrCandidati.Items[c])).Cells)[6]).Enabled = false;
//}
//}// end for each row

#endregion cantina
