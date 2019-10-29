using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            System.Data.DataTable dtProva = Entity_materie.Proxies.usp_autore_LOAD_SERVICE.usp_autore_LOAD("");
            this.grdDocumento.DataSource = dtProva;
            // ? bind() ? is implicit.
        }// Ctor()




        private void grdDocumento_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          Int32 selectedCellCount =
                grdDocumento.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (grdDocumento.AreAllCellsSelected(true))
                {
                    MessageBox.Show("All cells are selected", "Selected Cells");
                }
                else
                {
                    System.Text.StringBuilder sb =
                        new System.Text.StringBuilder();

                    for (int i = 0;
                        i < selectedCellCount; i++)
                    {
                        sb.Append("Row: ");
                        sb.Append(grdDocumento.SelectedCells[i].RowIndex
                            .ToString());
                        sb.Append(", Column: ");
                        sb.Append(grdDocumento.SelectedCells[i].ColumnIndex
                            .ToString());
                        sb.Append(Environment.NewLine);
                    }

                    sb.Append("Total: " + selectedCellCount.ToString());
                    MessageBox.Show(sb.ToString(), "Selected Cells");
                }
            }
        }// grdDocumento_CellMouseDoubleClick


        private void frmDocumentoLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.uscTimbro.removeSpecifiedWin(this);
        }



    }//class
}//nmsp
