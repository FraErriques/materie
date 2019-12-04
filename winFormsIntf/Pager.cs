using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{

    public partial class Pager : UserControl
    {
        private int currentPage;
        public int lastPage;
        public int rowXchunk;
        private int requiredPage;// for validation
        private int required_rowXchunk;// for validation
        private int rowInf;
        private int rowSup;
        private int rowCardinalityTotalView;
        private string viewName;
        private string currentPageText = "Current Page==";
        private string lastPageText = "Last Page==";
        private Entity_materie.BusinessEntities.PagingCalculator pagingCalculator;
        private Entity_materie.BusinessEntities.Cacher cacherInstance;
        private System.Windows.Forms.DataGridView gridInCurrentForm;

        public Pager()
        {
            InitializeComponent();
            //
            // here goes the call to Process::paginazione::costruzione
            //      - instantiate a Entity::Cacher and give out the reference
            //          the Cacher will create the View end get its rowCardinality
            //      - instantiate a Entity::PagingCalculator and give out the reference
            //          the PagingCalculator will receive the ViewRowCardinality and the currentChunkSize and decide
            //          how many pages exist, with current parameters. The variable LastPage will be an out param.
            //      - 
            this.defaultState();
            this.pagingCalculator = null;// only after, it will be buildable, by means of the callback "Init".
            // object o = this.Parent; not yet; needs a call postCtor.
        }// Ctor()


        /// <summary>
        /// this is the callBack wich Process has to invoke, to set the LastPage, after having
        /// called Entity::Cacher & Entity::PagingCalculator.
        /// </summary>
        /// <param name="par_lastPage"></param>
        public void Init( 
            int par_lastPage
            ,int rowCardinalityTotalView
            ,string viewName
            ,Entity_materie.BusinessEntities.PagingCalculator thePagingCalc
            ,Entity_materie.BusinessEntities.Cacher cacherInstance
            ,System.Windows.Forms.DataGridView theGrid
          )
        {
            this.lastPage = par_lastPage;
            this.lblViewName.Text += viewName;//NB. label has a prefix. Don't overwrite it.
            this.viewName = viewName;
            this.lblRowsInView.Text += rowCardinalityTotalView.ToString();//NB. label has a prefix. Don't overwrite it.
            this.rowCardinalityTotalView = rowCardinalityTotalView;
            this.cacherInstance = cacherInstance;
            this.pagingCalculator = thePagingCalc;
            this.gridInCurrentForm = theGrid;
            // ready.
            this.defaultState();
        }// Init()


        private void lblFirstPage_Click( object sender, EventArgs e )
        {
            this.tryChangePage(+1);
            this.onFirstPage();
            this.checkState();// update interface.
        }

        private void lblLastPage_Click( object sender, EventArgs e )
        {
            this.tryChangePage( this.lastPage);
            this.onLastPage();
            this.checkState();// update interface.
        }

        private void lblBefore_Click( object sender, EventArgs e )
        {
            this.tryChangePage(
                --this.currentPage // sx one.
            );
            this.checkState();
        }

        //private void lblCurrentPage_Click( object sender, EventArgs e )
        //{}// never an active label: no action is required to move to the current page.

        private void lblPageAfter_Click( object sender, EventArgs e )
        {
            this.tryChangePage(
                ++this.currentPage // dx one.
            );
            this.checkState();
        }

        //private void lblGoToPage_Click( object sender, EventArgs e )
        //{}

        //private void lblRowXchunk_Click( object sender, EventArgs e )
        //{}



        private void pageUpdater()
        {
            // mediante istanza del PagingCalculator:
            this.pagingCalculator.updateRequest(
                this.currentPage
                , this.rowXchunk
            );
            this.pagingCalculator.getRowInfSup(
                out this.rowInf
                , out this.rowSup
                , out this.lastPage
             );
            //
        }


        private bool parseTxtBoxes()
        {
            bool res = false;
            //int presentPage = this.currentPage;// swap
            //int presentChunkSize = this.rowXchunk;// swap
            //
            try
            {
                this.requiredPage = int.Parse(this.txtGoToPage.Text);
                res = true;
            }
            catch (System.Exception ex)
            {
                res = false;
                lblStato.Text = ex.Message;
                lblStato.BackColor = System.Drawing.Color.Orange;
            }
            try
            {
                this.required_rowXchunk = int.Parse(this.txtChunkSize.Text);
                res &= true;// keep in account the preceding result.
            }
            catch (System.Exception ex)
            {
                res &= false;// keep in account the preceding result.
                lblStato.Text += ex.Message;// second message TODO pass to a txtBox multiline.
                lblStato.BackColor = System.Drawing.Color.Orange;
            }
            finally// this finally block serves both try-catch pairs.
            {// validation in process before
                //this.txtGoToPage.Text = this.currentPage.ToString();
                //this.txtChunkSize.Text = this.rowXchunk.ToString();
            }
            //
            return res;
        }// parseTxtBoxes

        /// <summary>
        /// change both params: it's no good to separate them.
        /// </summary>
        private void btnChangeBoth_Click(object sender, EventArgs e)
        {
            bool parsing_res = this.parseTxtBoxes();
            bool hasPageBeenChanged = false;
            //
            System.Data.DataTable dt;
            if (parsing_res)
            {
                hasPageBeenChanged =
                    Process_materie.paginazione.TryChangePage_SERVICE.TryChangePage(
                        this.currentPage
                        , this.lastPage
                        , required_rowXchunk
                        , requiredPage
                        , this.pagingCalculator
                        , this.cacherInstance
                        , out this.rowInf
                        , out this.rowSup
                        , out this.lastPage
                        , out dt
                    );
                this.lblStato.Text = "";
                this.lblStato.BackColor = System.Drawing.Color.Transparent;
                this.gridInCurrentForm.DataSource = dt;// NB.  DataBind
            }
            else
            {
                hasPageBeenChanged = false;
            }
            if (hasPageBeenChanged)// TODO : decide
            {
                this.lblLastPage.Text = this.lastPage.ToString();// updated
                this.currentPage = requiredPage;// updated
                this.txtGoToPage.Text = this.currentPage.ToString();
                this.rowXchunk = required_rowXchunk;// updated
                this.txtChunkSize.Text = this.rowXchunk.ToString();
            }
            else// TODO ????
            {
                this.lblLastPage.Text = this.lastPage.ToString();
                //this.currentPage = required_page;
                this.txtGoToPage.Text = this.currentPage.ToString();
                this.txtChunkSize.Text = this.rowXchunk.ToString();
            }
            this.checkState();// update interface.
        }// btnChangeBoth_Click


        private bool tryChangePage(
            int required_page
          )
        {
            bool res = false;
            try
            {
//int required_page = int.Parse(this.txtGoToPage.Text);
                int required_rowXchunk = int.Parse(this.txtChunkSize.Text);
                System.Data.DataTable dt;
                bool hasPageBeenChanged =
                    Process_materie.paginazione.TryChangePage_SERVICE.TryChangePage(
                        this.currentPage
                        , this.lastPage
                        , required_rowXchunk
                        , required_page
                        , this.pagingCalculator
                        , this.cacherInstance
                        , out this.rowInf
                        , out this.rowSup
                        , out this.lastPage
                        , out dt
                    );
                this.lblStato.Text = "";
                this.lblStato.BackColor = System.Drawing.Color.Transparent;
                this.gridInCurrentForm.DataSource = dt;// NB.  DataBind
                if (hasPageBeenChanged)// TODO : decide
                {
                    this.lblLastPage.Text = this.lastPage.ToString();
                    this.currentPage = required_page;
                    this.txtGoToPage.Text = this.currentPage.ToString();
                    this.txtChunkSize.Text = this.rowXchunk.ToString();
                }
                else// TODO ????
                {
                    this.lblLastPage.Text = this.lastPage.ToString();
                    //this.currentPage = required_page;
                    this.txtGoToPage.Text = this.currentPage.ToString();
                    this.txtChunkSize.Text = this.rowXchunk.ToString();
                }
                this.checkState();// update interface.
            }// try
            catch (System.Exception ex)
            {
                this.lblStato.Text = ex.Message;
                this.lblStato.BackColor = System.Drawing.Color.Orange;
            }
            finally
            {
            }
            // ready.
            return res;
        }// tryChangePage()



        private void defaultState()
        {
            try
            {
                this.rowXchunk = int.Parse(this.txtChunkSize.Text);// default value is present onConstruction
            }
            catch
            {
                this.txtChunkSize.Text = "5";// default
                this.rowXchunk = int.Parse(this.txtChunkSize.Text);
            }
            this.onFirstPage();
        }

        private void onFirstPage()
        {
            this.lblFirstPage.Enabled = false;
            this.lblFirstPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageBefore.Enabled = false;
            this.lblPageBefore.BackColor = System.Drawing.Color.Transparent;
            //
            this.currentPage = +1;
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = true;
            this.lblPageAfter.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.lastPage.ToString();
            this.lblLastPage.BackColor = System.Drawing.Color.GreenYellow;
            this.lblLastPage.Enabled = true;
        }// onFirstPage


        private void onLastPage()
        {
            this.lblFirstPage.Enabled = true;
            this.lblFirstPage.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.lblPageBefore.Enabled = true;
            this.lblPageBefore.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.currentPage = this.lastPage;
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = false;
            this.lblPageAfter.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.lastPage.ToString();
            this.lblLastPage.BackColor = System.Drawing.Color.Transparent;
            this.lblLastPage.Enabled = false;
        }//onLastPage


        private void onIntermediatePage()
        {
            this.lblFirstPage.Enabled = true;
            this.lblFirstPage.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.lblPageBefore.Enabled = true;
            this.lblPageBefore.BackColor = System.Drawing.Color.GreenYellow;
            //
            // this.currentPage = this.currentPage; sure
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = true;
            this.lblPageAfter.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.lastPage.ToString();
            this.lblLastPage.BackColor = System.Drawing.Color.GreenYellow;
            this.lblLastPage.Enabled = true;
        }// onIntermediatePage


        private void checkState()
        {
            if (this.currentPage == 1)
            {
                this.defaultState();
            }
            else if (this.currentPage == this.lastPage)
            {
                this.onLastPage();
            }
            else// intermediate page
            {
                this.onIntermediatePage();
            }
            //// update the actual data in the grid. NO MORE it's done by Process
            //this.gridInCurrentForm.DataSource =
            //    this.cacherInstance.getChunk(
            //        this.rowInf
            //        , this.rowSup
            //    );
        }// checkState


    }// class
}//nmsp
