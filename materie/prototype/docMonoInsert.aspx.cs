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


public partial class zonaRiservata_docMonoInsert : System.Web.UI.Page
{
    //// from interface: <!-- <asp:DropDownList ID="ddlAutore" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAutoreRefreshQuery"></asp:DropDownList>  -->
    //private int indexOfAllSectors; // it's one after the last id in the table.


    private int int_ref_candidato_id = default(int);
    private int int_ref_materia_id = default(int);
    public struct UploadElement
    {
        public string client_path;
        public string web_server_path;
    };



    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!VerificaLasciapassare.CanLogOn(
        //        this.Session,
        //        this.Request.UserHostAddress
        //        )
        //    )
        //{
        //    this.Response.Redirect("../errore.aspx");
        //}// else il lasciapassare e' valido -> get in.
        //
        //-------------------------------------------------------------------NB. no more dependence on "candidato".
        //object ref_candidato_id = this.Session["ref_candidato_id"];
        //if (null == ref_candidato_id)
        //{
        //    throw new System.Exception("ref_candidato_id cannot be missing, in this page.");
        //}// else continue.
        //try
        //{
        //    this.int_ref_candidato_id = (int)ref_candidato_id;
        //}
        //catch (System.Exception ex)
        //{
        //    string dbg = ex.Message;
        //    this.int_ref_candidato_id = -1;// Proxy will manage.
        //}
        //
        /*
         * NB. page state check.-----------------------------------------------------------------
         * 
         */
        try
        {
            //this.int_ref_candidato_id = (int)(this.Session["chiaveDoppiaAutore"]);
            //this.int_ref_materia_id = (int)(this.Session["chiaveDoppiaMateria"]);
            this.int_ref_candidato_id = 1;// DoubleKey for Debug purposes
            this.int_ref_materia_id = 1;// DoubleKey for Debug purposes
            this.lblEsito.BackColor = System.Drawing.Color.Transparent;
            this.lblEsito.Text = "";
        }
        catch (System.Exception ex)
        {
            string msg = ex.Message;
            this.lblEsito.BackColor = System.Drawing.Color.Red;
            this.lblEsito.Text = "Assenza della chiave doppia in Sessione. Allarme.";
        }
        //
        PageStateChecker.PageStateChecker_SERVICE(
            "zonaRiservata_docMonoInsert"
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
            //ComboManager.populate_Combo_ddlMateria_for_LOAD(//---primo popolamento.
            //    this.ddlMaterie,
            //    0 // "null" or <0, for no preselection.
            //    , out indexOfAllSectors
            //);
            //this.Session["indexOfAllSectors"] = indexOfAllSectors;// NB.---cache across postbacks.-----
            //this.Session["comboSectors_selectedValue"] = 0;// NB.---cache across postbacks.-----
            ////
            //this.loadData(0);// means no query.
        }
        else if (
            !this.IsPostBack//----------------------------------------------------false
            && (bool)(this.Session["IsReEntrant"])//------------------------------true
            )
        {// coming from html-numbers of pager
            // needed combo-refresh, but re-select combo-Value from Session  --------
            //
            //int int_comboSectors_selectedValue = (int)(this.Session["comboSectors_selectedValue"]);// NB.---cache across postbacks.-----
            //ComboManager.populate_Combo_ddlMateria_for_LOAD(//---primo popolamento.
            //    this.ddlMaterie,
            //    int_comboSectors_selectedValue // "null" or <0, for no preselection.
            //    , out indexOfAllSectors
            //);
            //this.Session["indexOfAllSectors"] = indexOfAllSectors;// NB.---cache across postbacks.-----
            ////
            //// pager will load the new-chunk, based on a get-param.
            //object obj_CacherDbView = this.Session["CacherDbView"];
            //if (null != obj_CacherDbView)
            //{
            //    //((CacherDbView)obj_CacherDbView).Pager_EntryPoint(
            //    //    this.Session
            //    //    , this.Request
            //    //    , this.grdDatiPaginati
            //    //    , this.pnlPageNumber
            //    //);
            //}
            //else
            //{
            //    loadData(int_comboSectors_selectedValue); // TODO debug
            //    // don't throw new System.Exception(" autoreLoad::Page_Load . this.Session[CacherDbView] is null. ");
            //}
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





    ///// <summary>
    ///// NB.----- query on the db_index, NOT on the combo index!------
    /////  mai usare:  this.ddlMaterie.SelectedIndex
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void ddlMaterieRefreshQuery(object sender, EventArgs e)
    //{
    //    int int_sector = default(int);
    //    try//---if ddlMaterie.SelectedItem==null will throw.
    //    {
    //        int_sector = int.Parse(this.ddlMaterie.SelectedItem.Value);
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
    //}// end ddlMaterieRefreshQuery




    ///// <summary>
    ///// NB.---deve essere il Pager a chiamarlo, quando fa DataBind()--this.prepareLavagnaDynamicPortion()
    ///// </summary>
    ///// <param name="choosenSector"></param>
    //private void loadData(int choosenSector)
    //{//......adapt
    //}// end loadData()





    #region multi_upload
    //------------------------------------------------------------------------------------------------

    protected void btnAllega_Click(object sender, EventArgs e)
    {
        string dbg = this.uploadFile.Value;
        if (null == this.Session["arlUploadPaths"])//----------TODO  dbg
        {
            this.Session["arlUploadPaths"] = new ArrayList();
        }// else already built.
        //
        if (// add to chkList only valid items
            null != dbg
            && "" != dbg
            )
        {
            this.chkMultiDoc.Items.Add(new ListItem(dbg));
            int presentCardinality = this.chkMultiDoc.Items.Count;
            this.chkMultiDoc.Items[presentCardinality - 1].Selected = true;
            // NB. the upload must be performed, before emptying the upload-html-control.
            this.allegaSingoloFile();// on current selection; i.e. a scalar item. throws on empty selection.
        }// else skip an invalid selection.
        // ready
    }//


    /// <summary>
    /// btnSubmit is used to communicate the final decision of the user:
    ///     after he reviews the check-list of the web_srv uploaded files, he finally
    ///     confirms what to send to the db_srv( i.e. the checked ones only).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDocsFromWebToDb_Click(object sender, EventArgs e)
    {
        string _abstract;
        int ref_candidato_id;
        int ref_materia_id;
        string sourceName;
        bool result = true;// bool mask.
        //
        bool validForWriting = default(bool);// a not-valid-forWriting item does not affect the whole insertion.
        int acc = 0;
        foreach (ListItem Item in this.chkMultiDoc.Items)
        {
            if (Item.Selected)
            {
                validForWriting = this.validationForWrite(
                    out _abstract,
                    out ref_candidato_id,
                    out ref_materia_id,
                    ref acc // the accumulator is used, as index, to acces an array in Session and incremented by the calee.
                    , out sourceName
                );
                if (true == validForWriting)
                {
                    Entity_materie.BusinessEntities.docMono dm = new Entity_materie.BusinessEntities.docMono(
                        ref_candidato_id
                        , ref_materia_id
                        );
                    int entityDbInsertionResult =
                        dm.FILE_from_FS_insertto_DB(
                            ref_candidato_id,
                            ref_materia_id,
                            _abstract,
                            sourceName
                        );
                    result &= (0 < entityDbInsertionResult);// each insertion must return the lastGeneratedId, which>0.
                }// else NOTvalidForWriting -> skip item.
                result &= validForWriting;// update the result, to last insertion outcome.
            }// else skip an item that has been un-checked, after uploading from client to web_srv.
        }// end foreach item that has been uploaded from client to web_srv.
        //
        //
        // ready
        if (!result)
        {
            LoggingToolsContainerNamespace.LoggingToolsContainer.DecideAndLog(
                null,// original exception type
                "Non e' stato possibile inserire il lavoro.",
                0);
            //this.pnlInteractiveControls.Enabled = true;// let the user correct errors on page.
            this.divUpload.Enabled = true;// let the user correct errors on page.
            this.lblEsito.Text = "Non e' stato possibile inserire il lavoro.";
            this.lblEsito.BackColor = System.Drawing.Color.Red;
            return;// on page
        }
        else
        {
            LoggingToolsContainerNamespace.LoggingToolsContainer.DecideAndLog(
                null,// original exception type
                "Il lavoro e' stato inserito correttamente.",
                0);
            //----navigate to "scadenziario", where the inserted phase is visible.
            this.lblEsito.Text = "";
            this.lblEsito.BackColor = System.Drawing.Color.Transparent;
            this.Session["errore"] = null;// gc
            this.Session["arlUploadPaths"] = null;// gc
            this.Session["ref_candidato_id"] = null;// gc --- NB.
            this.Response.Redirect("candidatoLoad.aspx");
        }
    }//---end submit()




    /// <summary>
    /// upload a single token( file) from an attachment-list( check-list).
    /// </summary>
    /// <param name="theFileToBeUploaded"></param>
    protected void allegaSingoloFile()
    {
        UploadElement uploadElement = new UploadElement();// TODO store
        // Get the filename_only from client_fullpath.
        string fileName_only = System.IO.Path.GetFileName(this.uploadFile.PostedFile.FileName);
        uploadElement.client_path = this.uploadFile.PostedFile.FileName;
        //
        ConfigurationLayer.ConfigurationService cs = new
            ConfigurationLayer.ConfigurationService("FileTransferTempPath/fullpath");
        string serverPath = cs.GetStringValue("path");
        //-Gestione dismessa perchè scrive in directory di sistema-- NB. it's different for every user, included ASPNETusr ---------
        //-Gestione dismessa perchè scrive in directory di sistema-string serverPath = Environment.GetEnvironmentVariable("tmp", EnvironmentVariableTarget.User);
        //-Gestione dismessa perchè va corretta a mano per ogni macchina string serverPath = @"C:\root\LogSinkFs\cv";// TODO adapt to the server file sysetm.
        // add ending part.
        serverPath += "\\upload";
        //
        // Ensure the folder exists
        if (!System.IO.Directory.Exists(serverPath))
        {
            System.IO.Directory.CreateDirectory(serverPath);
        }// else already present on the web server file system.
        // Save the file to the folder, on the web-server.
        string fullPath_onWebServer = System.IO.Path.Combine(serverPath, fileName_only);
        uploadElement.web_server_path = fullPath_onWebServer;// TODO dbg.
        if (null == this.Session["arlUploadPaths"])
        {
            throw new System.Exception("TODO call btnAllega() first!");
        }// else ok.
        ((System.Collections.ArrayList)(this.Session["arlUploadPaths"])).Add(uploadElement);
        // ready
        this.uploadFile.PostedFile.SaveAs(fullPath_onWebServer);//--NB.---crucial system call: from client do web-srv.
    }// end uploadButton_Click()




    //------------------------------------------------------------------------------------------------
    #endregion multi_upload




    private bool validationForWrite(
        //----parametri validazione---------
            out string _abstract,
            out int ref_candidato_id,
            out int ref_materia_id,
            ref int acc,// NB. "ref" and not "out" since it needs to be updated, not assigned from scratch.
            out string sourceName
        )
    {
        bool result = true;// used as bitmask with & operator.
        //
        _abstract = this.txtAbstract.Text;
        if (
            null != _abstract
            && "" != _abstract
            )
        {
            result &= true;
        }
        else
        {
            result &= false;
        }
        //
        ref_candidato_id = this.int_ref_candidato_id;
        if (
            0 < ref_candidato_id)
        {
            result &= true;
        }
        else
        {
            result &= false;
        }
        //
        ref_materia_id = this.int_ref_materia_id;
        if (
            0 < ref_materia_id)
        {
            result &= true;
        }
        else
        {
            result &= false;
        }
        /*
         * NB. the acc index is incremented, AFTER array-access, and returned to the caller, 
         * which manages the loop.
         */
        sourceName = ((UploadElement)((System.Collections.ArrayList)(this.Session["arlUploadPaths"]))[acc++]).web_server_path; //sourceName
        if (
            null != sourceName
            && "" != sourceName
            )
        {
            result &= true;
        }
        else
        {
            result &= false;
        }
        //
        // ready
        return result;
    }// end validationForWrite.


}//
