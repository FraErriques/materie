using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;


namespace winFormsIntf
{

    public partial class frmDocumentoLoad : Form
    {
        private winFormsIntf.App_Code.ComboMaterieManager comboMaterieManager;


        public frmDocumentoLoad()
        {// check login status
            if (!winFormsIntf.CheckLogin.isLoggedIn())
            {
                winFormsIntf.frmError ErrorForm = new frmError(
                    new System.Exception("User is not Logged In : go to Login Form and access, in order to proceed."));
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
            //// init graphics
            InitializeComponent();
            //
            //
            this.comboMaterieManager = new App_Code.ComboMaterieManager();
            this.comboMaterieManager.populate_Combo_ddlMateria_for_LOAD(
                this.ddlMaterie
                , 0
              );
        }// Ctor()




        private void grdDocumento_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // TODO what's the difference between _CellMouseDoubleClick and _CellDoubleClick ??
            // Answers: CellDoubleClick and CellClick are events that fire from the left mouse button, as well as "clicks" that 
            // come from tabbing to an item and hitting the spacebar, etc. ... 
            // CellMouseDoubleClick fires only when the LEFT button is double clicked.
        }// grdDocumento_CellMouseDoubleClick


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmDocumentoLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmDocumentoLoad_FormClosed


        enum tblDocumentoColumns
        {//NB. enums cannot be declared into methods.
            Invalid = -1
            , RowNumber = 0
            , id_Documento = 1
            , nome_Materia = 2
            , nome_Autore = 3
            //  etc , ... 
        }// NB. modify, in case of record layout modification.
        //
        private void grdDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try// inside here there's an int.Parse that throws. And the Downloader.DownloadButton_Click throws too.
            {
                DataGridViewRow selRowDirect = this.grdDocumento.Rows[e.RowIndex];
                DataGridViewCell selCellDirect =
                    selRowDirect.Cells[(int)(winFormsIntf.frmDocumentoLoad.tblDocumentoColumns.id_Documento)];//compulsory.
                string tmpSelected_Doc_IdDirect = selCellDirect.Value.ToString();
                int selected_Doc_IdDirect = int.Parse(tmpSelected_Doc_IdDirect);// throws
                //
                string extractionPath;
                Downloader.DownloadButton_Click( selected_Doc_IdDirect, out extractionPath);
                this.openFileDialog1.InitialDirectory = extractionPath;
                this.lblExtractedDoc.Text = "Doc is : " + extractionPath;
                this.lblExtractedDoc.BackColor = System.Drawing.Color.LimeGreen;
                this.openFileDialog1.ShowDialog();
            }// try
            catch (System.Exception ex)
            {
                this.lblStatus.Text = "trouble: " + ex.Message;
                this.lblStatus.BackColor = System.Drawing.Color.Red;
            }
        }// grdDocumento_CellDoubleClick()





        /// <summary>
        /// NB. la query-tail che si costruisce in questa funzione va collegata obbligatoriamente in
        /// "and" con la query-tail presente nella stored, in quanto essa utilizza tale tail per 
        /// evitare un prodotto cartesiano fra candidati e categorie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void queryDocumentoByFilter(object sender, EventArgs e)
        protected void btnQueryDoc_Click(object sender, EventArgs e)
        {
            // NB. primo "and implicito. perchè la stored ha già altri "and" nel testo sql. Quindi clausole ulteriori devono essere precedute
            // da un "and"
            string queryTail = "";
            int indexOfMateria = 0;
            try
            {
                indexOfMateria = this.comboMaterieManager.ddlMaterie_SelectedIndexChanged(this.ddlMaterie);
            }
            catch// all
            {// indexOfAllSectors will remain null.
            }
            //
            if (
                    indexOfMateria <= 0 // all sectors selected.
                )
            {
                // invalid "sector" characterization -> where condition omitted.
            }
            else
            {
                queryTail += " and " + indexOfMateria.ToString() + " = mat.id ";
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
            //---manage the Cacher here.
            Entity_materie.BusinessEntities.ViewDynamics.accessPoint("Documento");// view theme.
            string designedViewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;// get the View name
            CacherDbView cacherDbView = new CacherDbView(
                queryTail
                ,Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(designedViewName)
                ,new CacherDbView.SpecificViewBuilder(// create the delegate which points to the appropriate Proxy().
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_documento_SERVICE.usp_ViewCacher_specific_CREATE_documento
                )
            );
            if (null != cacherDbView)
            {
                this.grdDocumento.DataSource = cacherDbView.GetChunk(
                    1 // NB : does not paginate; so you will get all the View in a single chunk.
                );
            }
            else
            {
                throw new System.Exception("Presentation::queryDocumento::loadData() failed CacherDbView Ctor. ");
            }
        }// end btnDoPostback()


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


        private void ddlMaterie_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboMaterieManager.ddlMaterie_SelectedIndexChanged(this.ddlMaterie);
        }// ddlMaterie_SelectedIndexChanged


    }//class
}//nmsp
