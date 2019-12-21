using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{
    public partial class frmPrimes : Form
    {
        public frmPrimes()
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
            //---load Primes just onFormLoad ,so onCtor().
            //
            //------start example use of Cacher-PagingCalculator-Pager--------------------------
            int rowCardinalityTotalView;// out par
            string viewName;// out par
            int par_lastPage;// out par
            System.Data.DataTable chunkDataSource;// out par
            Entity_materie.BusinessEntities.PagingManager pagingManager;// out par
            string queryTail = "";
            //
            int defaultChunkSizeForThisGrid = 20;
            Process_materie.paginazione.costruzionePager.primaCostruzionePager(
                "Prime" // view theme
                , queryTail // whereTail
                , defaultChunkSizeForThisGrid // default
                , out rowCardinalityTotalView
                , out viewName
                , new Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder(
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_Primes_SERVICE.usp_ViewCacher_specific_CREATE_Primes
                  )
                , out par_lastPage
                , out chunkDataSource
                , out pagingManager
            );
            this.uscInterfacePager_Prime.Init(
                this.grdPrimes //  backdoor, to give the PagerInterface-control the capability of updating the grid.
                , defaultChunkSizeForThisGrid // defaultChunkSizeForThisGrid
                , pagingManager
            );// callBack in Interface::Pager
            this.grdPrimes.DataSource = chunkDataSource;// fill dataGrid
            //
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmPrimes_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmPrimes_FormClosed


    }// class
}
