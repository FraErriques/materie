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
        private int actual_currentPage;
        public int actual_rowXchunk;
        public int actual_lastPage;
        //
        private int required_currentPage;// for validation
        private int required_rowXchunk;// for validation
        private int required_lastPage;
        //
        private int rowInf;// for the query of the required chunk.
        private int rowSup;
        //---the following data are permanent and for that they have only one version.
        private string viewName;
        private int rowCardinalityTotalView;
        //
        private string currentPageText = "Current Page==";
        private string lastPageText = "Last Page==";
        //
        private Entity_materie.BusinessEntities.PagingCalculator pagingCalculator;
        private Entity_materie.BusinessEntities.Cacher cacherInstance;
        private System.Windows.Forms.DataGridView gridInCurrentForm;// it's an instance that belongs to the containerForm, while this is a component.

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
            this.actual_lastPage = par_lastPage;
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
            this.changeFromDirectButtons_Click(+1);
        }// lblFirstPage_Click

        private void lblLastPage_Click( object sender, EventArgs e )
        {
            this.changeFromDirectButtons_Click(this.actual_lastPage );
        }// lblLastPage_Click

        private void lblBefore_Click( object sender, EventArgs e )
        {
            this.changeFromDirectButtons_Click(
                this.actual_currentPage - 1  // sx one.
            );
        }// lblBefore_Click

        //private void lblCurrentPage_Click( object sender, EventArgs e )
        //{}// never an active label: no action is required to move to the current page.

        private void lblPageAfter_Click( object sender, EventArgs e )
        {
            this.changeFromDirectButtons_Click(
                this.actual_currentPage + 1  // dx one.
            );
        }// lblPageAfter_Click


        /// <summary>
        /// change from directButton: i.e. {first,prev,next,last}.
        /// such request preserves the chunk size and guarantees feasibility of the change, since no nonsense request is 
        /// possible from a direct button.
        /// </summary>
        private void changeFromDirectButtons_Click(
            int requested_pageFromDirectButtons
          )
        {
            bool isPageChangeFeasibleUntilNow = false;
            // validation in process.
            System.Data.DataTable updatedDataSource;
            isPageChangeFeasibleUntilNow =
                Process_materie.paginazione.TryChangePage_SERVICE.TryChangePage(
                      ref this.actual_currentPage
                    , ref this.actual_rowXchunk
                    , ref this.actual_lastPage 
                    //
                    , this.pagingCalculator
                    , this.cacherInstance
                    //
                    , ref requested_pageFromDirectButtons
                    , ref this.required_rowXchunk
                    //
                    , ref this.rowInf
                    , ref this.rowSup
                    , ref this.required_lastPage
                    //
                    , out updatedDataSource
                );
            this.intefaceAfterPageChange(
                isPageChangeFeasibleUntilNow
                , updatedDataSource);
            this.checkState();
            // ready.
        }// changeFromDirectButtons_Click
 


        /// <summary>
        /// change both params: it's no good to separate them.
        /// </summary>
        private void btnChangeBoth_Click(object sender, EventArgs e)
        {
            bool isPageChangeFeasibleUntilNow = false;
            //
            try
            {
                this.required_currentPage = int.Parse(this.txtGoToPage.Text);
                isPageChangeFeasibleUntilNow = true;
            }
            catch (System.Exception ex)
            {
                isPageChangeFeasibleUntilNow = false;
                lblStato.Text = ex.Message;
                lblStato.BackColor = System.Drawing.Color.Orange;
            }
            try//--parse the second one even if the first fails, since we need a complete response for the user.
            {
                this.required_rowXchunk = int.Parse(this.txtChunkSize.Text);
                isPageChangeFeasibleUntilNow &= true;// keep in account the preceding result.
            }
            catch (System.Exception ex)
            {
                isPageChangeFeasibleUntilNow &= false;// keep in account the preceding result.
                lblStato.Text += ex.Message;// second message TODO pass to a txtBox multiline.
                lblStato.BackColor = System.Drawing.Color.Orange;
            }
            finally// this finally block serves both try-catch pairs.
            {// other validation in process.
                System.Data.DataTable updatedDataSource = null;
                if (isPageChangeFeasibleUntilNow)
                {
                    isPageChangeFeasibleUntilNow &=
                        Process_materie.paginazione.TryChangePage_SERVICE.TryChangePage(
                              ref this.actual_currentPage
                            , ref this.actual_rowXchunk
                            , ref this.actual_lastPage
                        //
                            , this.pagingCalculator
                            , this.cacherInstance
                        //
                            , ref this.required_currentPage
                            , ref this.required_rowXchunk
                        //
                            , ref this.rowInf
                            , ref this.rowSup
                            , ref this.required_lastPage
                        //
                            , out updatedDataSource
                        );
                }// else don't even go to Process::
                this.intefaceAfterPageChange(
                    isPageChangeFeasibleUntilNow
                    ,updatedDataSource );
            }
            this.checkState();
            //ready.
        }// btnChangeBoth_Click



        private void intefaceAfterPageChange( 
            bool hasPageBeenChanged
            ,System.Data.DataTable updatedDataSource
         )
        {
            if (hasPageBeenChanged)
            {
                this.lblLastPage.Text = this.actual_lastPage.ToString();
                this.txtGoToPage.BackColor = System.Drawing.Color.White;
                this.txtChunkSize.BackColor = System.Drawing.Color.White;
                this.lblStato.Text = "Cambio effettuato.";
                this.lblStato.BackColor = System.Drawing.Color.LightGreen;
                this.txtGoToPage.Text = "";
                this.txtChunkSize.Text = this.actual_rowXchunk.ToString();
                this.lblCurrentPage.Text = this.actual_currentPage.ToString();
                this.required_currentPage = this.actual_currentPage;
                this.required_rowXchunk = this.actual_rowXchunk;
                //---NB. crucial
                this.gridInCurrentForm.DataSource = updatedDataSource;
            }
            else//// TODO : decide
            {                
                this.txtGoToPage.BackColor = System.Drawing.Color.Orange;
                this.txtChunkSize.BackColor = System.Drawing.Color.Orange;
                this.lblStato.Text = "Cambio non possibile.";
                this.lblStato.BackColor = System.Drawing.Color.Red;
                //---NB. crucial
                // DO NOT update, in case of failure! this.gridInCurrentForm.DataSource = updatedDataSource;
            }
            this.checkState();// refresh interface.
        }// intefaceAfterPageChange








        private void defaultState()
        {
            this.txtChunkSize.Text = "5";// default
            this.actual_rowXchunk = int.Parse( this.txtChunkSize.Text);// default
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
            this.actual_currentPage = +1;
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.actual_currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = true;
            this.lblPageAfter.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.actual_lastPage.ToString();
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
            this.actual_currentPage = this.actual_lastPage;
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.actual_currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = false;
            this.lblPageAfter.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.actual_lastPage.ToString();
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
            this.actual_currentPage = this.required_currentPage;// NB.----
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.actual_currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = true;
            this.lblPageAfter.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.actual_lastPage.ToString();
            this.lblLastPage.BackColor = System.Drawing.Color.Transparent;
            this.lblLastPage.Enabled = true;
        }// onIntermediatePage


        private void checkState()
        {
            if (this.actual_currentPage == 1)
            {
                this.onFirstPage();
            }
            else if (this.actual_currentPage == this.actual_lastPage )
            {
                this.onLastPage();
            }
            else// intermediate page
            {
                this.onIntermediatePage();
            }
        }// checkState


    }// class
}//nmsp




# region cantina

        //private void pageUpdater()
        //{
        //    // mediante istanza del PagingCalculator:
        //    this.pagingCalculator.updateRequest(
        //        this.currentPage
        //        , this.rowXchunk
        //    );
        //    this.pagingCalculator.getRowInfSup(
        //        out this.rowInf
        //        , out this.rowSup
        //        , out this.lastPage
        //     );
        //    //
        //}


        //private bool parseTxtBoxes()
        //{
        //    bool isPageChangeFeasibleUntilNow = false;
        //    //
        //    try
        //    {
        //        this.requiredPage = int.Parse(this.txtGoToPage.Text);
        //        isPageChangeFeasibleUntilNow = true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        isPageChangeFeasibleUntilNow = false;
        //        lblStato.Text = ex.Message;
        //        lblStato.BackColor = System.Drawing.Color.Orange;
        //    }
        //    try//--parse the second one even if the first fails, since we need a complete response for the user.
        //    {
        //        this.required_rowXchunk = int.Parse(this.txtChunkSize.Text);
        //        isPageChangeFeasibleUntilNow &= true;// keep in account the preceding result.
        //    }
        //    catch (System.Exception ex)
        //    {
        //        isPageChangeFeasibleUntilNow &= false;// keep in account the preceding result.
        //        lblStato.Text += ex.Message;// second message TODO pass to a txtBox multiline.
        //        lblStato.BackColor = System.Drawing.Color.Orange;
        //    }
        //    finally// this finally block serves both try-catch pairs.
        //    {// validation in process.
        //        System.Data.DataTable updatedDataSource;
        //        Process_materie.paginazione.TryChangePage_SERVICE.TryChangePage(
        //            ref this.currentPage
        //            , ref this.lastPage
        //            , ref this.rowXchunk
        //            , this.pagingCalculator
        //            , this.cacherInstance
        //            , this.requiredPage
        //            , this.required_rowXchunk
        //            , out this.rowInf
        //            , out this.rowSup
        //            , out this.lastPage
        //            , out updatedDataSource
        //        );
        //        this.intefaceAfterPageChange( isPageChangeFeasibleUntilNow);
        //    }
        //    //
        //    return isPageChangeFeasibleUntilNow;
        //}// parseTxtBoxes

//        private bool tryChangePage(
//            int required_page
//          )
//        {
//            bool res = false;
//            try
//            {
////int required_page = int.Parse(this.txtGoToPage.Text);
//                int required_rowXchunk = int.Parse(this.txtChunkSize.Text);
//                System.Data.DataTable dt;
//                bool hasPageBeenChanged =
//                    Process_materie.paginazione.TryChangePage_SERVICE.TryChangePage(
//                        this.currentPage
//                        , this.lastPage
//                        , required_rowXchunk
//                        , required_page
//                        , this.pagingCalculator
//                        , this.cacherInstance
//                        , out this.rowInf
//                        , out this.rowSup
//                        , out this.lastPage
//                        , out dt
//                    );
//                this.lblStato.Text = "";
//                this.lblStato.BackColor = System.Drawing.Color.Transparent;
//                this.gridInCurrentForm.DataSource = dt;// NB.  DataBind
//                if (hasPageBeenChanged)// TODO : decide
//                {
//                    this.lblLastPage.Text = this.lastPage.ToString();
//                    this.currentPage = required_page;
//                    this.txtGoToPage.Text = this.currentPage.ToString();
//                    this.txtChunkSize.Text = this.rowXchunk.ToString();
//                }
//                else// TODO ????
//                {
//                    this.lblLastPage.Text = this.lastPage.ToString();
//                    //this.currentPage = required_page;
//                    this.txtGoToPage.Text = this.currentPage.ToString();
//                    this.txtChunkSize.Text = this.rowXchunk.ToString();
//                }
//                this.checkState();// update interface.
//            }// try
//            catch (System.Exception ex)
//            {
//                this.lblStato.Text = ex.Message;
//                this.lblStato.BackColor = System.Drawing.Color.Orange;
//            }
//            finally
//            {
//            }
//            // ready.
//            return res;
//        }// tryChangePage()

# endregion cantina
