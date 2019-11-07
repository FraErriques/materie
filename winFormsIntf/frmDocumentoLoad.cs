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


        public frmDocumentoLoad()
        {// check login status
            bool isLoggedIn =
                winFormsIntf.CheckLogin.isLoggedIn(
                    (Entity_materie.BusinessEntities.Permesso.Patente)
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] );
            if (!isLoggedIn)
            {
                winFormsIntf.frmError ErrorForm = new frmError(new System.Exception("user is not Logged In"
                    ,new System.Exception("Go to Login Form and access, in order to proceed.") ) );
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
            //// init graphics
            InitializeComponent();
            //
            //CacherDbView cacherDbView = new CacherDbView(         TODO enable out of web context
            //    this.Session
            //    , queryTail
            //    , ViewNameDecorator.ViewNameDecorator_SERVICE(this.Session.SessionID)
            //    , new CacherDbView.SpecificViewBuilder(
            //        Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_documento_SERVICE.usp_ViewCacher_specific_CREATE_documento
            //      )
            //    , int_txtRowsInPage
            //    //
            //    , this.Request
            //    , this.grdDatiPaginati
            //    , this.pnlPageNumber
            //);
            //if (null != cacherDbView)
            //{
            //    this.Session["CacherDbView"] = cacherDbView;
            //    cacherDbView.Pager_EntryPoint(
            //        this.Session
            //        , this.Request
            //        , this.grdDatiPaginati
            //        , this.pnlPageNumber
            //    );
            //}

            //System.Data.DataTable dtProva = Entity_materie.Proxies.usp_docMulti_abstract_LOAD_SERVICE.usp_docMulti_abstract_LOAD(525);
            //this.grdDocumento.DataSource = dtProva;
            // ? bind() ? is implicit.
        }// Ctor()




        private void grdDocumento_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }// grdDocumento_CellMouseDoubleClick


        private void frmDocumentoLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.uscTimbro.removeSpecifiedWin(this);
        }

        private void grdDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO verificare che non sia stata clickata una cella diversa dallo ID-materia.
            // TODO mettere ID-Materia in txtMateriaID_DoubleKey
            object theSender = sender;
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 1)
            {
                object selectedItem = this.grdDocumento.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewRow selRow = this.grdDocumento.Rows[e.RowIndex];
                DataGridViewCell selCell = selRow.Cells[e.ColumnIndex];
                string tmpSelectedDocId = selCell.Value.ToString();
                int selectedDocId = int.Parse(tmpSelectedDocId);
                this.lblStatus.Text = "selected Doc with ID="+selectedDocId.ToString();
                this.lblStatus.BackColor = System.Drawing.Color.Green;
                //
                string extractionPath;
                Downloader.DownloadButton_Click(selectedDocId, out extractionPath);
                this.openFileDialog1.InitialDirectory = extractionPath;
                this.lblExtractedDoc.Text = "Doc is : " + extractionPath;
                this.openFileDialog1.ShowDialog();
            }// else not a valid click
            else
            {
                this.lblStatus.Text = "Only ID-Documento is double-clickable for selection.";
                this.lblStatus.BackColor = System.Drawing.Color.Red;
            }
        }





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
            int indexOfAllSectors = 0;
            try
            {
                // TODO indexOfAllSectors = ((int)(this.Session["indexOfAllSectors"])).ToString();
                indexOfAllSectors = 0;
            }
            catch// all
            {// indexOfAllSectors will remain null.
            }
            //
            if (
                null == this.ddlMaterie.SelectedItem
                || "0" == this.ddlMaterie.SelectedText //  .SelectedItem.Value// no sector selected.
                || null == this.ddlMaterie.SelectedItem // .Value// managed ex.
                || indexOfAllSectors == this.ddlMaterie.SelectedIndex //  Item.Value// all sectors selected.
                )
            {
                // invalid "sector" characterization -> where condition omitted.
            }
            else
            {
                queryTail += " and " + this.ddlMaterie.SelectedItem.ToString() + " = mat.id ";
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
            //System.Web.UI.WebControls.TextBox txtRowsInPage = null;
            int int_txtRowsInPage = default(int);
            try
            {
                //txtRowsInPage =
                //    (System.Web.UI.WebControls.TextBox)(this.PageLengthManager1.FindControl("txtRowsInPage"));
                //int_txtRowsInPage = int.Parse(txtRowsInPage.Text);
                int_txtRowsInPage = int.MaxValue;// no paging, but a scrollBar on the gridView.
            }
            catch
            {// on error sends zero rows per page, to Pager.
            }
            //
            CacherDbView cacherDbView = new CacherDbView(
                null // this.Session
                , queryTail
                , ViewNameDecorator.ViewNameDecorator_SERVICE("TODO_this.Session.SessionID")
                , new CacherDbView.SpecificViewBuilder(
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_documento_SERVICE.usp_ViewCacher_specific_CREATE_documento
                  )
                , int_txtRowsInPage
                //
                //, this.Request
                //, this.grdDatiPaginati
                //, this.pnlPageNumber
            );
            if (null != cacherDbView)
            {
                //this.Session["CacherDbView"] = cacherDbView;
                //cacherDbView.Pager_EntryPoint(
                //    this.Session
                //    , this.Request
                //    , this.grdDatiPaginati
                //    , this.pnlPageNumber
                //);
                this.grdDocumento.DataSource = cacherDbView.GetChunk(null, 1);
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




    }//class
}//nmsp
