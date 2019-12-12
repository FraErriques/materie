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
        ///  
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogQuery_Click(object sender, EventArgs e)
        {
            System.DateTime startDate;
            System.DateTime endDate;
            //
            startDate = this.dtpStartDate.Value;
            endDate = System.DateTime.Now;
            //
            string[] startStr = startDate.ToShortDateString().Split('/');
            string startStr_F_ = startStr[2] + startStr[1] + startStr[0];
            //
            string[] endStr = endDate.ToShortDateString().Split('/');
            string endStr_F_ = endStr[2] + endStr[1] + endStr[0];
            //
            this.grdLoggingDb.DataSource =
                Entity_materie.Proxies.LogViewer_win_materie_SERVICE.LogViewer_win_materie(
                    startStr_F_
                    ,endStr_F_
                );// dataBound.
        }// QueryCommit


    }// class
}// nmsp
