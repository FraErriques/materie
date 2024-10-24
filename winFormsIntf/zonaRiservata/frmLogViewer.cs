using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{
    public partial class frmLogViewer : Form
    {
        public frmLogViewer()
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
        }// Ctor()


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmLogViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
        }// frmLogViewer_FormClosed



        /// <summary>
        ///  sintassi richiesta dalla whereClause della stored che crea la viewLog
        ///  si chiama [usp_ViewCacher_specific_CREATE_logLocalhost]
        ///  
        ///  ' where 
        ///     convert(datetime,substring([when],1,8))>=convert(datetime,''20191204'')
        ///     and convert(datetime,substring([when],1,8))<=convert(datetime,''20191205'') 
        ///    order by [when] desc '
        ///  
        ///   " where 
        ///          " convert(datetime,substring([when],1,8))>=convert(datetime,"
        ///          + startStr_F_
        ///         ")"
        ///          " and convert(datetime,substring([when],1,8))<=convert(datetime,"
        ///          + endStr_F_
        ///         ")"
        ///          " order by [when] desc "
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogQuery_Click(object sender, EventArgs e)
        {
            string startStr_F_ = this.convertDateToSqlDateString(this.dtpStartDate.Value);
            string endStr_F_ = this.convertDateToSqlDateString(this.dtpEndDate.Value);
            string queryTail =
                " where "
                + " convert(datetime,substring([when],1,8))>=convert(datetime,'" // NB. essenziale l'apice singolo di Sql prima di chiudere la C#str.
                + startStr_F_
                + "')" // NB. essenziale l'apice singolo di Sql come primo carattere della C#str.
                + " and convert(datetime,substring([when],1,8))<=convert(datetime,'" // NB. essenziale l'apice singolo di Sql prima di chiudere la C#str.
                + endStr_F_
                + "')"; // NB. essenziale l'apice singolo di Sql come primo carattere della C#str.
                // NB. no ORDER BY admited in VIEWS+ " order by [when] desc ";
            //
            LogSinkFs.Wrappers.LogWrappers.SectionContent(
                queryTail
                , 0
                );
            //------start example use of Cacher-PagingCalculator-Pager--------------------------
            int rowCardinalityTotalView;// out par
            string viewName;// out par
            int par_lastPage;// out par
            System.Data.DataTable chunkDataSource;// out par
            Entity_materie.BusinessEntities.PagingManager pagingManager;// out par
            //
            int defaultChunkSizeForThisGrid = 25;
            Process_materie.paginazione.costruzionePager.primaCostruzionePager(
                "LogWinForm" // view theme
                , queryTail // whereTail
                , defaultChunkSizeForThisGrid // default
                , out rowCardinalityTotalView
                , out viewName
                , new Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder(
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_logLocalhost_SERVICE.usp_ViewCacher_specific_CREATE_logLocalhost
                  )
                , out par_lastPage
                , out chunkDataSource
                , out pagingManager
            );
            this.uscInterfacePager_logLocalhost.Init(
                this.grdLoggingDb //  backdoor,to give the PagerInterface-control the capability of updating the grid.
                , defaultChunkSizeForThisGrid // defaultChunkSizeForThisGrid
                , pagingManager
            );// callBack in Interface::Pager
            this.grdLoggingDb.DataSource = chunkDataSource;// fill dataGrid. On WinForms the assignement of DataSource
            //performs the DataBind.
            //
            // the following is an alternative, without View-creation:
            //this.grdLoggingDb.DataSource =
            //    Entity_materie.Proxies.LogViewer_win_materie_SERVICE.LogViewer_win_materie(
            //        startStr_F_
            //        , endStr_F_
            //    );// dataBound.
        }// QueryCommit


        /// <summary>
        /// the dateTimePicker is an interface control that exposes a calendar, to let the user pick a date.
        /// The selected value is of type System.DateTime. The programmer has to pass this method the frm.Control.Value.
        /// The return value is a string, as Sql wants it, which is "20191201" to mean 2019/December/01
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        private string convertDateToSqlDateString(System.DateTime selectedDate)
        {// pass the param as : this.dtpStartDate.Value;
            int selectedMonth = selectedDate.Month;
            int selectedYear = selectedDate.Year;
            int selectedDay = selectedDate.Day;
            string res = selectedYear.ToString();
            if (10 > selectedMonth) { res += "0"; }
            res += selectedMonth.ToString();
            if (10 > selectedDay) { res += "0"; }
            res += selectedDay.ToString();
            // NB. don't do the following way, since it depends on Locale.
            //string[] tokenizedStr = selectedDate.ToShortDateString().Split('/');
            //res = tokenizedStr[2] + tokenizedStr[0] + tokenizedStr[1];
            //res = tokenizedStr[2] + tokenizedStr[1] + tokenizedStr[0];
            //ready.
            return res;
        }// convertDateToSqlDateString

        private void grdLoggingDb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // do nothing
        }
    }// class
}// nmsp
