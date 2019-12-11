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
            //---manage the Cacher here.
            Entity_materie.BusinessEntities.ViewDynamics.accessPoint("Autore");// view theme.
            string designedViewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;// get the View name
            CacherDbView cacherDbView = new CacherDbView(
                queryTail
                ,Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator( designedViewName)
                ,new CacherDbView.SpecificViewBuilder(// delegate to the right View Proxy.
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
                )
            );
            if (null != cacherDbView)
            {
                this.grdAutoriNominativoNote.DataSource = cacherDbView.GetChunk(
                    1 // NB : does not paginate; so you will get all the View in a single chunk.
                );
            }
            else
            {
                throw new System.Exception("Presentation::autoreLoad::goProxyQueryAutoriByNominativoNote() failed CacherDbView Ctor. ");
            }
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
        /// this method populates the grdView by means of a Proxy which loads all Authors who published at least one
        /// paper on the subject( i.e. Materia) selected in the Combo. From the grid the user will be able to select the Materia-id
        /// for writing it down in the DoubleKey. Each row in the grd selects the same Materia, since all rows contain papers on that subject.
        /// It is exactly the same as selecting the Materia from the combo( with the upper button). The auxiliary grid on the right is intended as 
        /// a help to the user, to remember who wrote on the specified subject matter( i.e. Materia).
        /// The whereTail to pass to the View_creator is:   "and dm.ref_materia_id=int_sector  and mate.id=int_sector"
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
                if (int_sector > 0)
                {
                    where_tail = "and dm.ref_materia_id="
                        + int_sector.ToString()
                        + " and mate.id="
                        + int_sector.ToString();
                }
                else
                {
                    where_tail = "";
                }
                //string viewName = 
                //------start example use of Cacher-PagingCalculator-Pager--------------------------
                int rowCardinalityTotalView;
                string viewName;// out par
                //
                //Entity_materie.BusinessEntities.Cacher cacherInstance;
                int par_lastPage;
                System.Data.DataTable chunkDataSource;
                Entity_materie.BusinessEntities.PagingManager pagingManager;// out par
                //
                Process_materie.paginazione.costruzionePager.primaCostruzionePager(
                    "AutoriByArticoliPubblicati" // view theme
                    , where_tail
                    , 5 // default
                    , out rowCardinalityTotalView
                    , out viewName
                    , new Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder(
                        Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autoreOnMateria_SERVICE.usp_ViewCacher_specific_CREATE_autoreOnMateria
                      )
                    , out par_lastPage
                    , out chunkDataSource
                    , out pagingManager
                );

                //
                this.uscInterfacePager_AutoreOnMateria.Init(
                    this.grdAutoriMateria//  backdoor, to give the PagerInterface-control the capability of updating the grid.
                    , pagingManager
                );// callBack in Interface::Pager
                this.grdAutoriMateria.DataSource = chunkDataSource;// fill dataGrid
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



        enum tblAutoriColumns
        {//NB. enums cannot be declared into methods.
            Invalid = -1
            ,RowNumber = 0
            ,idAutore = 1
            ,nominativo = 2
            ,note = 3
        }// NB. modify, in case of record layout modification.
        //
        private void grdAutoriNominativoNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try// inside here there's an int.Parse that throws.
            {
                DataGridViewRow selRowDirect = this.grdAutoriNominativoNote.Rows[e.RowIndex];
                DataGridViewCell selCellDirect = selRowDirect.Cells[(int)(winFormsIntf.frmAutoreLoad.tblAutoriColumns.idAutore)];//compulsory.
                string tmpSelectedAutoreIdDirect = selCellDirect.Value.ToString();
                int selectedAutoreIdDirect = int.Parse(tmpSelectedAutoreIdDirect);// throws
                //
                this.txtChiaveAutore.Text = selectedAutoreIdDirect.ToString();// report the selected DoubleKey portion.
                this.lblStatus.Text = "";// everything went ok.
                this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            }// try
            catch( System.Exception ex)
            {
                this.lblStatus.Text = "trouble: " + ex.Message;
                this.lblStatus.BackColor = System.Drawing.Color.Red;
            }
        }// grdAutoriNominativoNote_CellDoubleClick


        enum tblAutoriOnMateriaColumns
        {//NB. enums cannot be declared into methods.
            Invalid = -1
            // NB. no RowNumber in this query: it's not a View.
            ,idAutore = 0
            ,nomeAutore = 1
            ,idMateria = 2
            ,nomeMateria = 3
        }// NB. modify, in case of record layout modification.
        //
        private void grdAutoriMateria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try// inside here there's an int.Parse that throws.
            {
                DataGridViewRow selRowDirect = this.grdAutoriMateria.Rows[e.RowIndex];
                DataGridViewCell selCellDirect = selRowDirect.Cells[(int)(winFormsIntf.frmAutoreLoad.tblAutoriOnMateriaColumns.idMateria)];//compulsory.
                string tmpSelectedMateriaIdDirect = selCellDirect.Value.ToString();
                int selectedMateriaIdDirect = int.Parse(tmpSelectedMateriaIdDirect);// throws
                //
                this.txtChiaveMateria.Text = selectedMateriaIdDirect.ToString();// report the selected DoubleKey portion.
                this.lblStatus.Text = "";// everything went ok.
                this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            }// try
            catch (System.Exception ex)
            {
                this.lblStatus.Text = "trouble: " + ex.Message;
                this.lblStatus.BackColor = System.Drawing.Color.Red;
            }
        }// grdAutoriMateria_CellDoubleClick


    }// class
}// nmsp
