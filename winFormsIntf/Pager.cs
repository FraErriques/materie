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
            this.onFirstPage();
        }

        private void lblLastPage_Click( object sender, EventArgs e )
        {
            this.onLastPage();
        }

        private void lblBefore_Click( object sender, EventArgs e )
        {
            this.pageUpdater();
            this.currentPage--;// sx one.
            this.checkState();
        }

        private void lblCurrentPage_Click( object sender, EventArgs e )
        {

        }

        private void lblPageAfter_Click( object sender, EventArgs e )
        {
            this.pageUpdater();
            this.currentPage++;// dx one.
            this.checkState();
        }

        private void lblGoToPage_Click( object sender, EventArgs e )
        {

        }

        private void lblRowXchunk_Click( object sender, EventArgs e )
        {

        }



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


        /// <summary>
        /// change both params: it's no good to separate them.
        /// </summary>
        private void btnChangeBoth_Click( object sender, EventArgs e )
        {
            try
            {
                this.currentPage = int.Parse(this.txtGoToPage.Text);
                if (1 > this.currentPage
                    || this.lastPage < this.currentPage
                    )
                { throw new System.Exception("Page out of range. Range is [+1, Last]."); }
                this.lblStato.Text = "";
                this.lblStato.BackColor = System.Drawing.Color.Transparent;
                //
                this.rowXchunk = int.Parse(this.txtChunkSize.Text);// throws
                this.pageUpdater();// refresh calculations with PagingCalculator
                this.checkState();
            }
            catch (System.Exception ex)
            {
                this.lblStato.Text = ex.Message;
                this.lblStato.BackColor = System.Drawing.Color.Orange;
            }

        }


        private void defaultState()
        {
            this.rowXchunk = int.Parse(this.txtChunkSize.Text);// default value is present onConstruction
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
            // update the actual data in the grid.
            this.gridInCurrentForm.DataSource =
                this.cacherInstance.getChunk(
                    this.rowInf
                    , this.rowSup
                );
        }// checkState


    }// class
}//nmsp
