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
        private DataTable dtMateria;
        private int indexOfAll_Materie;
        private int idOfSelectedItem;// in the comboMaterie
        private int idOfSelected_Materia;
        private int idOfSelected_Autore;


        public frmAutoreLoad()
        {// check login status
            bool isLoggedIn =
                winFormsIntf.CheckLogin.isLoggedIn(
                    (Entity_materie.BusinessEntities.Permesso.Patente)
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"]);
            if (!isLoggedIn)
            {
                winFormsIntf.frmError ErrorForm = new frmError(new System.Exception("user is not Logged In"
                    , new System.Exception("Go to Login Form and access, in order to proceed.")));
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
            //// init graphics
            InitializeComponent();
            //
            this.populate_Combo_ddlMateria_for_LOAD( 0, out this.indexOfAll_Materie);// pre-select the voice "selez.."
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAutoreLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.uscTimbro.removeSpecifiedWin(this);
        }


        /// <summary>
        /// this metohd calls the Proxy in Entity_materie, which loads Authors, filtered by Name and Abstract. The resultset is an Authors' list
        /// from which the user can select an Author-id to compose the DoubleKey.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoriNominativoNote_Click(object sender, EventArgs e)
        {
            int int_sector = default(int);
            try//---if ddlMaterie.SelectedItem==null will throw.
            {
                int_sector = int.Parse(this.ddlMaterie.SelectedIndex.ToString() ); //  Item. .Value);
                // this.Session["comboSectors_selectedValue"] = int_sector;// NB.---cache across postbacks.-----
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["comboSectors_selectedValue"] = int_sector;// NB.---cache across postbacks.-----
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
        }




        /// <summary>
        /// // query sugli autori by Nominativo & Note.
        /// </summary>
        private void goProxyQueryAutoriByNominativoNote()
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
            //System.Web.UI.WebControls.TextBox txtRowsInPage = null;
            
            //try
            //{
            //    txtRowsInPage =
            //        (System.Web.UI.WebControls.TextBox)(this.PageLengthManager1.FindControl("txtRowsInPage"));
            //    int_txtRowsInPage = int.Parse(txtRowsInPage.Text);
            //}
            //catch
            //{// on error sends zero rows per page, to Pager.
            //}
            int int_txtRowsInPage = 500;// default to a high cardinality, since we don't page on localhost.
            CacherDbView cacherDbView = new CacherDbView(
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance() //  this.Session
                , queryTail
                , "ViewNameDecorator_TODO" //ViewNameDecorator.ViewNameDecorator_SERVICE(this.Session.SessionID)
                , new CacherDbView.SpecificViewBuilder(
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
                  )
                , int_txtRowsInPage
                //
                //, this.Request
                //, this.grdDatiPaginati
                // this.pnlPageNumber
            );
            if (null != cacherDbView)
            {
                
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["CacherDbView"] = cacherDbView;
                // this.Session["CacherDbView"] = cacherDbView;
                //cacherDbView.Pager_EntryPoint(
                //    this.Session
                //    , this.Request
                //    , this.grdDatiPaginati
                //    , this.pnlPageNumber
                //);
                //------ check 
                this.grdAutoriNominativoNote.DataSource = cacherDbView.GetChunk(
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()
                    , 1 // TODO verify : but seems that does not paginete; so you will get all the View in a single chunk.
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
        {
            if (Program.activeInstances[4].canOpenAnotherOne())// NB change here #
            {
                Program.formList.Add(new frmDocumentoInsert() );// NB change here #
                if (Program.activeInstances[4].openingHowto() == windowWarehouse.openingMode.Modal)// NB change here #
                {
                    ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).ShowDialog();// show the last born.
                }
                else if (Program.activeInstances[4].openingHowto() == windowWarehouse.openingMode.NotModal)// NB change here #
                {
                    ((System.Windows.Forms.Form)(Program.formList[Program.formList.Count - 1])).Show();// show the last born.
                }
                else
                {
                    throw new System.Exception(" Invalid opening mode.");
                }
            }// if can open another win
            else
            {
                MessageBox.Show(this, " No more instances of type frmDocumentoInsert available. Close something of this type.", "Win Cardinality");
            }// else can open no more win
        }// goToDocumentoInsert()


        /// <summary>
        /// this method selects the Materia-id of the Materia choosen in the combo and writes it down in the txtBox
        /// of the DoubleKey
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublishMateriaFromCombo_Click(object sender, EventArgs e)
        {
            this.txtChiaveMateria.Text = this.idOfSelectedItem.ToString();
        }// btnPublishMateriaFromCombo_Click


        /// <summary>
        /// this method populates the grdView by means of a Proxy which loads all Authors who published at least one
        /// paper on the subject( i.e. Materia) selected in the Combo. From the grid the user will be able to select the Materia-id
        /// for writing it down in the DoubleKey. Each row in the grd selects the same Materia, since all rows contain papers on that subject.
        /// It is exactly the same as selecting the Materia from the combo( with the upper button). The auxiliary grid on the right is intended as 
        /// a help to the user, to remember who wrote on the specified subject matter( i.e. Materia).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoriByArticoliPubblicati_Click(object sender, EventArgs e)
        {
            int int_sector = default(int);
            try//---if ddlMaterie.SelectedItem==null will throw.
            {
                int_sector = this.ddlMaterie.SelectedIndex;  //int.Parse( // .SelectedItem . Value);
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["comboSectors_selectedValue"] = int_sector;
                //this.Session["comboSectors_selectedValue"] = int_sector;// NB.---cache across postbacks.-----
                this.indexOfAll_Materie = 
                    (int)(Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["comboSectors_selectedValue"]);
            }
            catch (System.Exception ex)
            {
                string dbg = ex.Message;
                int_sector = -1;// invalid.
            }
            finally
            {// TODO : prevedere caso query su tutte le materie (i.e. su tutti gli Autori censiti ).
                if (int_sector >= this.indexOfAll_Materie)
                {
                    int_sector = -1;// int_sector<0 means search Authors who wrote on whatever Subject.
                }// else keep the single_Materia index.
                System.Data.DataTable dt = Entity_materie.Proxies.usp_autore_LOAD_whoWroteOnMateria_SERVICE.usp_autore_LOAD_whoWroteOnMateria(int_sector);
                this.grdAutoriMateria.DataSource = dt;
                // this.GridView1.DataBind(); implicit in this context
            }
        }


        /// <summary>
        /// this method has to enable-disable some controls, due to the logged user profile.
        /// Writers can have selection icons enabled in the grids and the validation button for the DoubleKey; in a word they are allowed to
        /// navigate to the insertDocumento form. The readers can only use AutoreLoad form as a consultation page, about Authors and Subjects.
        /// </summary>
        private void prepareLavagna_dynamicPortion()
        {
        }




        public void populate_Combo_ddlMateria_for_LOAD(
            //System.Web.UI.WebControls.DropDownList ddlSettore,
            object selectedElement,
            out int indexOfAllSectors // it's one after the last id in the table.
          )
        {
            indexOfAllSectors = default(int);// compulsory init, for out pars; the func_body will let it actual.
            //--------------popolamento-----------------
            dtMateria = Entity_materie.Proxies.usp_materia_LOOKUP_LOAD_SERVICE.usp_materia_LOOKUP_LOAD();
            this.ddlMaterie.Items.Clear();
            this.ddlMaterie.Items.Add("selezione della Materia"
             //,//--no query for this combo voice ---
             //   new System.Windows.Forms.ListControl( // .Web.UI.WebControls.ListItem(
             //       "selezione della Materia",//--no query for this combo voice ---
             //       "0" // index in combo-box
             //   )// end new_list_item
            );// end items_add
            int c = 0;// zero is the first row in the datatable.
            int max_identity = 0;
            if (null != dtMateria)
            {
                for (; c < dtMateria.Rows.Count; c++)
                {
                    this.ddlMaterie.Items.Add(
                            (string)(dtMateria.Rows[c]["nomeMateria"])
                    );
                    //this.ddlMaterie.Items.Add(
                    //    new System.Web.UI.WebControls.ListItem(
                    //        (string)(dtMateria.Rows[c]["nomeMateria"]),
                    //        ((int)(dtMateria.Rows[c]["id"])).ToString() // the identity in the table, to be used for the query.
                    //    )
                    //);
                    int tmp_identity = (int)(dtMateria.Rows[c]["id"]);
                    if (tmp_identity > max_identity)
                    {
                        max_identity = tmp_identity;
                    }// else skip.
                }// end for.
                this.ddlMaterie.Items.Add(
                        "Tutte le Materie"//--select without "where-tail" -----
                );
                indexOfAllSectors = max_identity + 1;//--------NB.------report combo_cardinality to the caller.-------
            }// else skip.
            //-------------- END popolamento Stati Lavorazione----------------------------------
            int int_selectedElement = default(int);
            if (
                System.DBNull.Value != selectedElement
                && null != selectedElement
                )
            {
                int_selectedElement = (int)selectedElement;
                if (0 >= int_selectedElement)
                {
                    this.ddlMaterie.SelectedIndex = 0;// i.e. "selezionare Materia.."
                    return;// no preselection.
                }// else continue pre-selecting.
                int r = 0;
                for (; r < dtMateria.Rows.Count; r++)
                {
                    if (// selectedElement contains an [id], i.e. an encoded FK.
                        int_selectedElement == (int)(dtMateria.Rows[r]["id"])
                        )
                    {
                        break;// selectedElement's row is "r".
                    }// else continue.
                }
                if (r < dtMateria.Rows.Count)//--caso query su tutte le materie
                {
                    int theIndex =
                        this.ddlMaterie.Items.IndexOf(
                                (string)(dtMateria.Rows[r]["nomeMateria"])
                        );
                    this.ddlMaterie.SelectedIndex = theIndex;
                }
                else
                {
                    int theIndex =
                        this.ddlMaterie.Items.IndexOf(
                            "Tutte le Materie"  //--select without "where-tail" -----
                    );
                    this.ddlMaterie.SelectedIndex = theIndex;
                }
            }// else no pre-selection.
        }//populate_Combo_ddlMateria_for_LOAD


        private void ddlMaterie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIndex = this.ddlMaterie.SelectedIndex;// good
            object selItem = this.ddlMaterie.SelectedItem;// good
            //string selTxt = this.ddlMaterie.SelectedText;// bad
            //object selVal = this.ddlMaterie.SelectedValue;// bad
            //
            idOfSelectedItem = default(int);
            try
            {
                for (int c = 0; c < dtMateria.Rows.Count; c++)
                {
                    if ((string)selItem == (string)(dtMateria.Rows[c]["nomeMateria"]))
                    {
                        idOfSelectedItem = (int)(dtMateria.Rows[c]["id"]);
                        break;// id are univocal. No more search after a match.
                    }// if matches
                }// for each row of dataTable
            }// try
            catch (System.Exception ex)
            {
                string msg = "something wrong " + ex.Message;
            }// catch
        }// ddlMaterie_SelectedIndexChanged



        private void grdAutoriNominativoNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO verificare che non sia stata clickata una cella diversa dallo ID-Autore.
            object theSender = sender;
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                object selectedItem = this.grdAutoriNominativoNote.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewRow selRow = this.grdAutoriNominativoNote.Rows[e.RowIndex];
                DataGridViewCell selCell = selRow.Cells[e.ColumnIndex];
                string tmpSelectedAutoreId = selCell.Value.ToString();
                int selectedAutoreId = int.Parse(tmpSelectedAutoreId);
                this.txtChiaveAutore.Text = selectedAutoreId.ToString();
                this.idOfSelected_Autore = selectedAutoreId;// save to put in session for page frmDocumentoInsert
                this.lblStatus.Text = "";
                this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            }// else not a valid click
            else
            {
                this.lblStatus.Text = "Only ID-Autore is double-clickable for selection.";
                this.lblStatus.BackColor = System.Drawing.Color.Red;
            }
        }// grdAutoriNominativoNote_CellDoubleClick

        private void grdAutoriMateria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO verificare che non sia stata clickata una cella diversa dallo ID-materia.
            // TODO mettere ID-Materia in txtMateriaID_DoubleKey
            object theSender = sender;
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                object selectedItem = this.grdAutoriMateria.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewRow selRow = this.grdAutoriMateria.Rows[e.RowIndex];
                DataGridViewCell selCell = selRow.Cells[e.ColumnIndex];
                string tmpSelectedMateriaId = selCell.Value.ToString();
                int selectedMateriaId = int.Parse(tmpSelectedMateriaId);
                this.txtChiaveMateria.Text = selectedMateriaId.ToString();
                this.idOfSelected_Materia = selectedMateriaId;// save to put in session for page frmDocumentoInsert
                this.lblStatus.Text = "";
                this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            }// else not a valid click
            else
            {
                this.lblStatus.Text = "Only ID-Materia is double-clickable for selection.";
                this.lblStatus.BackColor = System.Drawing.Color.Red;
            }
        }// grdAutoriMateria_CellDoubleClick


    }// class
}// nmsp
