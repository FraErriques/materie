using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace winFormsIntf.prototype
{

    public partial class Pager : UserControl
    {
        //--data is all boxed in Entity::BusinessEntities::PagingManager.
        public Entity_materie.BusinessEntities.PagingManager pagingManager;
        //---the following data are permanent and for that they have only one version.
        public string viewName;
        public int rowCardinalityTotalView;
        //
        public string currentPageText = "Current Page==";
        public string lastPageText = "Last Page==";
        public System.Windows.Forms.DataGridView gridInCurrentForm;// it's an instance that belongs to the containerForm, while this is a component.


        /// <summary>
        /// Ctor()
        /// </summary>
        public Pager()
        {
            InitializeComponent();
            // No more You can do here.
            // Only after, it will be buildable, by means of the callback "Init".
            // object o = this.Parent; not yet; needs a call postCtor.
        }// Ctor()


        /// <summary>
        /// this is the callBack wich Process has to invoke, to set the LastPage, after having
        /// called Entity::Cacher & Entity::PagingCalculator.
        /// </summary>
        /// <param name="par_lastPage"></param>
        public void Init(
            System.Windows.Forms.DataGridView theGrid // a backDoor to the frmContainer::Grid; necessary for successive DataBind().
            ,Entity_materie.BusinessEntities.PagingManager pagingManager // the InterfacePager will need it.
          )
        {
            if (null == pagingManager)
            {
                throw new System.Exception("ALARM ! PaginManager not initialized.");
            }// else can continue
            else
            {
                this.pagingManager = pagingManager;// get it and keep it.
            }
            this.lblViewName.Text = "View Name:  " + pagingManager.cacherInstance.get_viewName();
            this.pagingManager.viewName = pagingManager.cacherInstance.get_viewName();
            this.lblRowsInView.Text = "Rows in View = " + pagingManager.cacherInstance.get_rowCardinalityTotalView().ToString();//label has a prefix. Don't overwrite it.
            this.gridInCurrentForm = theGrid;
            this.pagingManager.pagingCalculator.required_currentPage = this.pagingManager.pagingCalculator.actual_currentPage;// init
            this.pagingManager.pagingCalculator.required_rowXchunk = this.pagingManager.pagingCalculator.actual_rowXchunk;
            this.pagingManager.pagingCalculator.required_lastPage = this.pagingManager.pagingCalculator.actual_lastPage;
            // ready.
            this.defaultState();// not yet ready in Ctor().
        }// Init()


        private void lblFirstPage_Click( object sender, EventArgs e )
        {
            this.pagingManager.pagingCalculator.required_currentPage = +1;
            this.changeFromDirectButtons_Click();
        }// lblFirstPage_Click

        private void lblLastPage_Click( object sender, EventArgs e )
        {
            this.pagingManager.pagingCalculator.required_currentPage = this.pagingManager.pagingCalculator.actual_lastPage;
            this.changeFromDirectButtons_Click();
        }// lblLastPage_Click

        private void lblBefore_Click( object sender, EventArgs e )
        {
            this.pagingManager.pagingCalculator.required_currentPage = this.pagingManager.pagingCalculator.actual_currentPage - 1;  // sx one.
            this.changeFromDirectButtons_Click();
        }// lblBefore_Click

        //private void lblCurrentPage_Click( object sender, EventArgs e )
        //{}// never an active label: no action is required to move to the current page.

        private void lblPageAfter_Click( object sender, EventArgs e )
        {
            this.pagingManager.pagingCalculator.required_currentPage = this.pagingManager.pagingCalculator.actual_currentPage + 1;  // dx one.
            this.changeFromDirectButtons_Click();
        }// lblPageAfter_Click


        /// <summary>
        /// change from directButton: i.e. {first,prev,next,last}.
        /// such request preserves the chunk size and guarantees feasibility of the change, since no nonsense request is 
        /// possible from a direct button.
        /// </summary>
        private void changeFromDirectButtons_Click(
            // int requested_pageFromDirectButtons NO MORe: updated this.pagingManager.pagingCalculator.required_currentPage
          )
        {
            bool isPageChangeFeasibleUntilNow = false;
            // validation in process.
            System.Data.DataTable updatedDataSource;
            isPageChangeFeasibleUntilNow =
                Process_materie.paginazione.TryChangePage_SERVICE.TryChangePage(
                    ref this.pagingManager
                    , out updatedDataSource
                );
            //
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
                this.pagingManager.pagingCalculator.required_currentPage = int.Parse(this.txtGoToPage.Text);
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
                this.pagingManager.pagingCalculator.required_rowXchunk = int.Parse(this.txtChunkSize.Text);
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
                            ref this.pagingManager
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
                this.lblLastPage.Text = this.pagingManager.pagingCalculator.actual_lastPage.ToString();
                this.txtGoToPage.BackColor = System.Drawing.Color.White;
                this.txtChunkSize.BackColor = System.Drawing.Color.White;
                this.lblStato.Text = "Cambio effettuato.";
                this.lblStato.BackColor = System.Drawing.Color.LightGreen;
                this.txtGoToPage.Text = "";
                this.txtChunkSize.Text = this.pagingManager.pagingCalculator.actual_rowXchunk.ToString();
                this.lblCurrentPage.Text = this.pagingManager.pagingCalculator.actual_currentPage.ToString();
                this.pagingManager.pagingCalculator.required_currentPage = this.pagingManager.pagingCalculator.actual_currentPage;
                this.pagingManager.pagingCalculator.required_rowXchunk = this.pagingManager.pagingCalculator.actual_rowXchunk;
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
            this.pagingManager.pagingCalculator.actual_rowXchunk = int.Parse(this.txtChunkSize.Text);// default
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
            this.pagingManager.pagingCalculator.actual_currentPage = +1;// NB.---- +1
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.pagingManager.pagingCalculator.actual_currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = true;
            this.lblPageAfter.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.pagingManager.pagingCalculator.actual_lastPage.ToString();
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
            this.pagingManager.pagingCalculator.actual_currentPage = this.pagingManager.pagingCalculator.actual_lastPage;// NB.----last
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.pagingManager.pagingCalculator.actual_currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = false;
            this.lblPageAfter.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.pagingManager.pagingCalculator.actual_lastPage.ToString();
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
            this.pagingManager.pagingCalculator.actual_currentPage = this.pagingManager.pagingCalculator.required_currentPage;// NB.---- current
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.pagingManager.pagingCalculator.actual_currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            //
            this.lblPageAfter.Enabled = true;
            this.lblPageAfter.BackColor = System.Drawing.Color.GreenYellow;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.pagingManager.pagingCalculator.actual_lastPage.ToString();
            this.lblLastPage.BackColor = System.Drawing.Color.Transparent;
            this.lblLastPage.Enabled = true;
        }// onIntermediatePage


        private void checkState()
        {
            if (this.pagingManager.pagingCalculator.actual_currentPage == 1)
            {
                this.onFirstPage();
            }
            else if (this.pagingManager.pagingCalculator.actual_currentPage == this.pagingManager.pagingCalculator.actual_lastPage)
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
