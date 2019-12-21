using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;


namespace winFormsIntf
{
    public partial class frmAutoreLoad : Form
    {
        private winFormsIntf.App_Code.ComboMaterieManager comboMaterieManager;


        public frmAutoreLoad()
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
            this.comboMaterieManager = new App_Code.ComboMaterieManager();
            this.comboMaterieManager.populate_Combo_ddlMateria_for_LOAD(
                this.ddlMaterie
                , 0
              );
            // NB. only writers can navigate to frmDocumentoInsert.
            this.prepareLavagna_dynamicPortion();// decide whether to enable grpDoubleKey.
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAutoreLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }






        /// <summary>
        /// // query sugli autori by Nominativo & Note.
        /// </summary>
        private void goProxyQueryAutoriByNominativoNote( object sender, EventArgs e)
        {
            string queryTail;
            // Esempio di come deve diventare la queryTail: predisporre due textBox multiline 
            // per raccogliere "note" e "nominativo" like% ed "and".
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
            //
            //------start example use of Cacher-PagingCalculator-Pager--------------------------
            int rowCardinalityTotalView;// out par
            string viewName;// out par
            int par_lastPage;// out par
            System.Data.DataTable chunkDataSource;// out par
            Entity_materie.BusinessEntities.PagingManager pagingManager;// out par
            //
            int defaultChunkSizeForThisGrid = 4;
            Process_materie.paginazione.costruzionePager.primaCostruzionePager(
                "AutOnNomeNote" // view theme
                , queryTail // whereTail
                , defaultChunkSizeForThisGrid // default
                , out rowCardinalityTotalView
                , out viewName
                , new Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder(
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
                  )
                , out par_lastPage
                , out chunkDataSource
                , out pagingManager
            );
            this.uscInterfacePager_AutoriNominativoNote.Init(
                this.grdAutoriNominativoNote//  backdoor, to give the PagerInterface-control the capability of updating the grid.
                , defaultChunkSizeForThisGrid // defaultChunkSizeForThisGrid
                , pagingManager
            );// callBack in Interface::Pager
            this.grdAutoriNominativoNote.DataSource = chunkDataSource;// fill dataGrid
            //

            ////-ex--manage the Cacher here.
            //Entity_materie.BusinessEntities.ViewDynamics.accessPoint("Autore");// view theme.
            //string designedViewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;// get the View name
            //CacherDbView cacherDbView = new CacherDbView(
            //    queryTail
            //    ,Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator( designedViewName)
            //    ,new CacherDbView.SpecificViewBuilder(// delegate to the right View Proxy.
            //        Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
            //    )
            //);
            //if (null != cacherDbView)
            //{
            //    this.grdAutoriNominativoNote.DataSource = cacherDbView.GetChunk(
            //        1 // NB : does not paginate; so you will get all the View in a single chunk.
            //    );
            //}
            //else
            //{
            //    throw new System.Exception("Presentation::autoreLoad::goProxyQueryAutoriByNominativoNote() failed CacherDbView Ctor. ");
            //}
        }// end goProxyQueryAutoriByNominativoNote()



        /// <summary>
        /// this method performs a check on the database, to verify the existence of the DoubleKey: on a negative result the user 
        /// reads an error message in the page and has a chance to correct the DoubleKey. On a positive result a new frm is opened in Modal way.
        /// It's an insertDocumento frm, which assumes the DoubleKey that has just been approved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitDoubleKey_Click(object sender, EventArgs e)
        {
            // NB : query db x verifica esistenza chiave doppia
            //if(correct) -> goto docMultiInsert.aspx
            //else -> selfPostBack con errore in Session, XhtmlMobileDocType pubblicazione in Page_Load()
            int idMateriaPrescelta = 0;
            int idAutorePrescelto = 0;
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
                this.lblStatus.Text = " Exception while processing chiaveDoppia per Materia-Autore." + ex.Message;
                this.lblStatus.BackColor = System.Drawing.Color.Red;
                return; //on page
            }
            if (resultAutore && resultMateria)// both
            {
                // NB. quanto segue this.Session["chiaveDoppiaMateria"] = idMateriaPrescelta;
                // NB. this.Session["chiaveDoppiaAutore"] = idAutorePrescelto;
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["chiaveDoppiaMateria"] = idMateriaPrescelta;
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["chiaveDoppiaAutore"] = idAutorePrescelto;
                this.lblStatus.Text = "DoubleKey validated.";
                this.lblStatus.BackColor = System.Drawing.Color.Green;
                //this.Session["DynamicPortionPtr"] = null;// be sure to clean.
                //this.Response.Redirect("docMultiInsert.aspx");
                this.goToDocumentoInsert();
            }
            else
            {
                this.lblStatus.Text = " Error: chiaveDoppia errata per Materia-Autore.";
                this.lblStatus.BackColor = System.Drawing.Color.Red;
                return; //on page NB. do not do ResponseRedirect if you have to remain inPage.
                //Doing "return" stays on the client and preserves the control content(i.e. textBox, etc.).
            }
        }// end method verifyDoubleKey()


        /// <summary>
        /// this is the only accessPoint to the form DocumentoInsert. No menu-voice is present for it, since the
        /// user has to build and validate a DoubleKey to access there.
        /// </summary>
        private void goToDocumentoInsert()
        {// NB. access to frmDocumentoInsert is only from frmAutoreLoad
            bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmDocumentoInsert);
        }// goToDocumentoInsert()


        /// <summary>
        /// this method selects the Materia-id of the Materia choosen in the combo and writes it down in the txtBox
        /// of the DoubleKey
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublishMateriaFromCombo_Click(object sender, EventArgs e)
        {
            this.txtChiaveMateria.Text = this.comboMaterieManager.ddlMaterie_SelectedIndexChanged(this.ddlMaterie).ToString();
        }// btnPublishMateriaFromCombo_Click




        /// <summary>
        /// NB. the View-caching technique is implemented in two phases here. The viewName_one contains the AutoreOnMateria
        /// selected distinct, since each Autore can publish multiple papers on the same subject but we want only a row, like
        /// Eulero on Analysis. The "distinct" mechanism is not compatible with the RowNumber addition since the RowNumber
        /// renders every row unique. So I implemented this into two phases: a first view selectedDistinct and a second one which
        /// adds the RowNumber, which is necessaty for caching&paging.
        /// An immportant note: subqueries support the use of a primary query, whose resultset is usable in the "where" clause.
        /// If one instead needs to use such resultset in the "from" clause, a view is necessary to store such resultset. So we did.
        /// 
        /// This method populates the grdView by means of a Proxy which loads all Authors who published at least one
        /// paper on the subject( i.e. Materia) selected in the Combo. From the grid the user will be able to select the Materia-id
        /// for writing it down in the DoubleKey. 
        /// Each row in the grd selects the same Materia, since all rows contain papers on that subject.
        /// It is exactly the same as selecting the Materia from the combo( with the upper button).
        /// The auxiliary grid on the right is intended as 
        /// a help to the user, to remember who wrote on the specified subject matter( i.e. Materia).
        /// 
        /// The whereTail to pass to the View_creator_one is:   "and dm.ref_materia_id=int_sector  and mate.id=int_sector"
        /// The View_creator_two takes the viewName both of the viewOne and of the viewTwo. There's no "whereTail" here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoriByArticoliPubblicati_Click(object sender, EventArgs e)
        {
            int int_sector = default(int);
            try//---if ddlMaterie.SelectedItem==null will throw.
            {
                int_sector = ((winFormsIntf.App_Code.GenericCoupleKeyValue)(this.ddlMaterie.SelectedItem)).getId();
            }
            catch (System.Exception ex)
            {
                string dbg = ex.Message;
                int_sector = -1;// invalid.
            }
            finally
            {   // NB. int_sector = -1;// int_sector<0 means search Authors who wrote on whatever Subject.
                // on index==0 query su tutte le materie. The id starts from 1. 0 is "seleziona materia".
                string where_tail;
                if (int_sector > 0)// elif (int_sector <= 0) we are requiring:"alla Authors who wrote
                {// at least one paper on whatever subject." 
                    where_tail = "and dm.ref_materia_id="
                        + int_sector.ToString()
                        + " and mate.id="
                        + int_sector.ToString();
                }
                else
                {//NB. do not pass null to the Proxy.
                    where_tail = "";
                }
                //
                Entity_materie.BusinessEntities.ViewDynamics.accessPoint("autOnMat_uno");
                string viewName_uno = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;
                int resCreationView_one =
                Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autOnMat_uno_SERVICE.usp_ViewCacher_specific_CREATE_autOnMat_uno(
                    where_tail
                    , Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator( viewName_uno)
                );
                //---view_due will be build adding RowNumber to view_uno record.
                int rowCardinalityTotalView;
                int par_lastPage;
                string viewName_due;// out par
                System.Data.DataTable chunkDataSource;
                Entity_materie.BusinessEntities.PagingManager pagingManager;// out par
                //
                int defaultChunkSizeForThisGrid = 3;
//where_tail = viewName_uno;// NB.!! a necessary trick, to use a standard call!!
                Process_materie.paginazione.costruzionePager.primaCostruzionePager_inDoubleSplit(
                    Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(viewName_uno)
                    // , Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(viewName_due) down
                    , defaultChunkSizeForThisGrid // default
                    , out rowCardinalityTotalView
                    , out viewName_due
                    , new Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder(
                        Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autOnMat_due_SERVICE.
                        usp_ViewCacher_specific_CREATE_autOnMat_due
                      )
                    , out par_lastPage
                    , out chunkDataSource
                    , out pagingManager
                    //------
                    ,true  // is in DoubleSplit
                );
                //
                this.uscInterfacePager_AutoreOnMateria.Init(
                    this.grdAutoriMateria//  backdoor, to give the PagerInterface-control the capability of updating the grid.
                    , defaultChunkSizeForThisGrid // defaultChunkSizeForThisGrid
                    , pagingManager
                );// callBack in Interface::Pager
                
                this.grdAutoriMateria.DataSource = chunkDataSource;// fill dataGrid with View_due !
            }
        }// btnAutoriByArticoliPubblicati_Click()




        /// <summary>
        /// this method has to enable-disable some controls, due to the logged user profile.
        /// Writers can have selection icons enabled in the grids and the validation button for the DoubleKey; in a word they are allowed to
        /// navigate to the insertDocumento form. The readers can only use AutoreLoad form as a consultation page, about Authors and Subjects.
        /// </summary>
        private void prepareLavagna_dynamicPortion()
        {
            Entity_materie.BusinessEntities.Permesso.Patente patente = winFormsIntf.App_Code.CheckLogin.getPatente();
            if (null != patente)
            {
                if (patente.livelloAccesso == "reader")
                {
                    this.grpDoubleKey.Enabled = false;
                }
                else// can write, and then insert into db.
                {
                    this.grpDoubleKey.Enabled = true;
                }
            }
            else
            {// patente is null
                throw new System.Exception(" Alarm ! User should be logged in, at this phase. ");
            }
        }// prepareLavagna_dynamicPortion




        private void ddlMaterie_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboMaterieManager.ddlMaterie_SelectedIndexChanged(this.ddlMaterie);
        }// ddlMaterie_SelectedIndexChanged




        public enum TblAutoriColumns
        {//NB. enums cannot be declared into methods.
            Invalid = -1 // invalid entry
            ,            idAutore = 4    //----
            ,            nominativo = 5  //----
            ,            note = 6        //----
            ,            action_writeSingleKeyAutore = 0 //--System starts ordinals, on first ActionColumn
            ,            action_updateNoteAut = 1 //
            ,            action_updateAutNome = 2 //
            , RowNumber = 3 // until last column.
        }// NB. modify, in case of record layout modification.
        //
        private void grdAutoriNominativoNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TblAutoriColumns selectedColumnGridAutoreOnNote = TblAutoriColumns.Invalid;// init to invalid.
            int rigaSelezionata = e.RowIndex;// coordinate della selezione da parte dell'utente.
            int colonnaSelezionata = e.ColumnIndex;
            selectedColumnGridAutoreOnNote = (TblAutoriColumns)colonnaSelezionata;
            //
            if (colonnaSelezionata == (int)(winFormsIntf.frmAutoreLoad.TblAutoriColumns.action_writeSingleKeyAutore ) )
            {
                string msg = "selezione dell'azione write: select singleKey_Autore.";
                this.lblStatus.Text = msg;
                this.lblStatus.BackColor = System.Drawing.Color.LightGreen;
            }
            else if (colonnaSelezionata == (int)(winFormsIntf.frmAutoreLoad.TblAutoriColumns.action_updateNoteAut ) )
            {
                string msg = "selezione dell'azione update: update abstract-Autore.";
                this.lblStatus.Text = msg;
                this.lblStatus.BackColor = System.Drawing.Color.LightGreen;
            }
            else if (colonnaSelezionata == (int)(winFormsIntf.frmAutoreLoad.TblAutoriColumns.action_updateAutNome ) )
            {
                string msg = "selezione dell'azione update: update nome-Autore.";
                this.lblStatus.Text = msg;
                this.lblStatus.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                string msg = "selezione di una colonna che non ha azione associata";
                this.lblStatus.Text = msg;
                this.lblStatus.BackColor = System.Drawing.Color.LightSalmon;
                //--NB. each non-action column is an invalid choice.
                selectedColumnGridAutoreOnNote = TblAutoriColumns.Invalid;
            }
            //
            //
            int idAutore_CellValue_int = -1;// init to invalid.
            if (selectedColumnGridAutoreOnNote == TblAutoriColumns.Invalid)
            {
                return;// on page, sin a non-action column has been chose.
            }
            else// an action button has been chosen
            {
                try
                {
                    object idAutore_CellValue_obj = this.grdAutoriNominativoNote["id", e.RowIndex].Value;
                    idAutore_CellValue_int = (int)(this.grdAutoriNominativoNote["id", e.RowIndex].Value);
                }
                catch (System.Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            // notify on lblStatus
            this.lblStatus.Text += "_" + colonnaSelezionata.ToString();
            // idAutore_CellValue_int idAutoreSelected
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["idAutoreSelected"] = idAutore_CellValue_int;//Session
            if (selectedColumnGridAutoreOnNote == TblAutoriColumns.action_updateAutNome)
            {
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["update_action"] =
                    UpdateContentActions.AutoreNome;//Session
                //
                // this is the only accessPoint to the form frmUpdateAbstract. No menu-voice is present for it, since the
                // user has to choose from GridViews, to access there.
                bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmUpdateAbstract );
            }
            else if (selectedColumnGridAutoreOnNote == TblAutoriColumns.action_updateNoteAut)
            {
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["update_action"] =
                    UpdateContentActions.AutoreAbstract;//Session
                //
                // this is the only accessPoint to the form frmUpdateAbstract. No menu-voice is present for it, since the
                // user has to choose from GridViews, to access there.
                bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmUpdateAbstract);
            }
            else if (selectedColumnGridAutoreOnNote == TblAutoriColumns.action_writeSingleKeyAutore)
            {
                // no Session : just transcript the SingleKey_Autore
                this.txtChiaveAutore.Text = idAutore_CellValue_int.ToString();// and return on page, to complete the DoubleKey.
            }
            else
            {
                throw new System.Exception(" Invalid action : Debug frmAutoreLoad::grdAutoriNominativoNote_CellClick");
            }
        }// grdAutoriNominativoNote_CellClick



        //---------------------------------------################------------------------//
        public enum UpdateContentActions
        {//NB. enums cannot be declared into methods.
            Invalid = -1, // invalid entry
            AutoreNome = 0,
            AutoreAbstract = 1,
            MateriaNome = 2,
            DocumentoAbstract = 3
        }// NB. modify, in case of acrion-imageButton modification.

        
        public enum TblAutoriOnMateriaColumns
        {//NB. enums cannot be declared into methods.
            Invalid = -1, // invalid entry            
            idAutore = 3,
            nomeAutore = 4,
            idMateria = 5,
            nomeMateria = 6,
            action_writeDoubleKeyAutoreMateria = 0, //-- ? System starts ordinals, on first ActionColumn
            action_updateNomeMateria = 1, //
            RowNumber = 2 // until last column.
        }// NB. modify, in case of record layout modification.
        //
        private void grdAutoriMateria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TblAutoriOnMateriaColumns selectedColumnGridAutoreOnMateria = TblAutoriOnMateriaColumns.Invalid;// init to invalid.
            int rigaSelezionata = e.RowIndex;// coordinate della selezione da parte dell'utente.
            int colonnaSelezionata = e.ColumnIndex;
            selectedColumnGridAutoreOnMateria = (TblAutoriOnMateriaColumns)colonnaSelezionata;
            //
            if (colonnaSelezionata == (int)(winFormsIntf.frmAutoreLoad.TblAutoriOnMateriaColumns.action_writeDoubleKeyAutoreMateria))
            {
                string msg = "selezione dell'azione write: select doubleKey_AutoreMateria.";
                this.lblStatusAonMat.Text = msg;
                this.lblStatusAonMat.BackColor = System.Drawing.Color.LightGreen;
            }
            else if (colonnaSelezionata == (int)(winFormsIntf.frmAutoreLoad.TblAutoriOnMateriaColumns.action_updateNomeMateria ))
            {
                string msg = "selezione dell'azione update: update nome-Materia.";
                this.lblStatusAonMat.Text = msg;
                this.lblStatusAonMat.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                string msg = "selezione di una colonna che non ha azione associata";
                this.lblStatusAonMat.Text = msg;
                this.lblStatusAonMat.BackColor = System.Drawing.Color.LightSalmon;
                //--NB. each non-action column is an invalid choice.
                selectedColumnGridAutoreOnMateria = TblAutoriOnMateriaColumns.Invalid;
            }
            //
            //
            int idAutore_CellValue_int = -1;// init to invalid.
            int idMateria_CellValue_int = -1;// init to invalid.
            if (selectedColumnGridAutoreOnMateria == TblAutoriOnMateriaColumns.Invalid)
            {
                return;// on page, sin a non-action column has been chose.
            }
            else// an action button has been chosen
            {
                try
                {
                    object idAutore_CellValue_obj = this.grdAutoriMateria["idAutore", e.RowIndex].Value;
                    idAutore_CellValue_int = (int)(this.grdAutoriMateria["idAutore", e.RowIndex].Value);
                    //
                    object idMateria_CellValue_obj = this.grdAutoriMateria["idMateria", e.RowIndex].Value;
                    idMateria_CellValue_int = (int)(this.grdAutoriMateria["idMateria", e.RowIndex].Value);
                }
                catch (System.Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            // notify on lblStatus
            this.lblStatusAonMat.Text += "_" + colonnaSelezionata.ToString();
            // idAutore_CellValue_int idAutoreSelected
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["idAutoreSelected"] = idAutore_CellValue_int;// Session
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["idMateriaSelected"] = idMateria_CellValue_int;// Session
            if (selectedColumnGridAutoreOnMateria == TblAutoriOnMateriaColumns.action_updateNomeMateria)
            {
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["update_action"] =
                    UpdateContentActions.MateriaNome;//Session
                //
                // this is the only accessPoint to the form frmUpdateAbstract. No menu-voice is present for it, since the
                // user has to choose from GridViews, to access there.
                bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmUpdateAbstract);
            }
            else if (selectedColumnGridAutoreOnMateria == TblAutoriOnMateriaColumns.action_writeDoubleKeyAutoreMateria)
            {
                // no Session : just transcript the SingleKey_Autore
                this.txtChiaveAutore.Text = idAutore_CellValue_int.ToString();// and return on page, to complete the DoubleKey.
            }
            else
            {
                throw new System.Exception(" Invalid action : Debug frmAutoreLoad::grdAutoriMateria_CellClick");
            }
        }// grdAutoriMateria_CellClick



    }// class
}// nmsp




# region cantina


// TODO : rivedere
//enum tblAutoriOnMateriaColumns
//{//NB. enums cannot be declared into methods.
//    Invalid = -1
//    // NB. no RowNumber in this query: it's not a View.
//    ,idAutore = 0
//    ,nomeAutore = 1
//    ,idMateria = 2
//    ,nomeMateria = 3
//}// NB. modify, in case of record layout modification.
////
//private void grdAutoriMateria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//{
//    try// inside here there's an int.Parse that throws.
//    {
//        DataGridViewRow selRowDirect = this.grdAutoriMateria.Rows[e.RowIndex];
//        DataGridViewCell selCellDirect = selRowDirect.Cells[(int)(winFormsIntf.frmAutoreLoad.tblAutoriOnMateriaColumns.idMateria)];//compulsory.
//        string tmpSelectedMateriaIdDirect = selCellDirect.Value.ToString();
//        int selectedMateriaIdDirect = int.Parse(tmpSelectedMateriaIdDirect);// throws
//        //
//        this.txtChiaveMateria.Text = selectedMateriaIdDirect.ToString();// report the selected DoubleKey portion.
//        this.lblStatus.Text = "";// everything went ok.
//        this.lblStatus.BackColor = System.Drawing.Color.Transparent;
//    }// try
//    catch (System.Exception ex)
//    {
//        this.lblStatus.Text = "trouble: " + ex.Message;
//        this.lblStatus.BackColor = System.Drawing.Color.Red;
//    }
//}// grdAutoriMateria_CellDoubleClick



# endregion cantina
