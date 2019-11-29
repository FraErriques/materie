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
        private string currentPageText = "Current Page==";
        private string lastPageText = "Last Page==";

        public Pager()
        {
            InitializeComponent();
            //
            this.defaultState();
            // object o = this.Parent; not yet; needs a call postCtor.
        }// Ctor()

        public void Init( int par_lastPage )
        {
            this.lastPage = par_lastPage;
            this.defaultState();
        }

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
            object o = this.Parent;
            this.currentPage--;// sx one.
            this.checkState();
        }

        private void lblCurrentPage_Click( object sender, EventArgs e )
        {

        }

        private void lblPageAfter_Click( object sender, EventArgs e )
        {
            object o = this.Parent;
            this.currentPage++;// dx one.
            this.checkState();
        }

        private void lblGoToPage_Click( object sender, EventArgs e )
        {

        }

        private void lblRowXchunk_Click( object sender, EventArgs e )
        {

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
        }// checkState


    }// class
}//nmsp
