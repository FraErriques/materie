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
            this.onPageOne();
        }

        private void lblLastPage_Click( object sender, EventArgs e )
        {
            this.onPageLast();
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

        private void btnGoToPage_Click( object sender, EventArgs e )
        {

        }

        private void btnChangeChunk_Click( object sender, EventArgs e )
        {

        }


        private void defaultState()
        {
            this.onPageOne();
        }

        private void onPageOne()
        {
            this.currentPage = +1;
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            //
            this.lblFirstPage.Enabled = false;
            //
            this.lblPageBefore.Enabled = false;
            //
            this.lblPageAfter.Enabled = true;
            //
            this.lblLastPage.Text =
                this.lastPageText +
                this.lastPage.ToString();
            this.lblLastPage.BackColor = System.Drawing.Color.GreenYellow;
            this.lblLastPage.Enabled = true;
        }

        private void onPageLast()
        {
            this.currentPage = this.lastPage;
            this.lblCurrentPage.Text =
                this.currentPageText +
                this.currentPage.ToString();
            this.lblCurrentPage.Enabled = false;
            //
            this.lblFirstPage.Enabled = true;
            //
            this.lblPageBefore.Enabled = true;
            //
            this.lblPageAfter.Enabled = false;
            //
            this.lblLastPage.Text =
                    this.lastPageText +
                    this.lastPage.ToString();
            this.lblLastPage.BackColor = System.Drawing.Color.Transparent;
            this.lblLastPage.Enabled = false;
        }

        private void checkState()
        {
            if (this.currentPage == 1)
            {
                this.defaultState();
            }
            else if (this.currentPage == this.lastPage)
            {
                this.onPageLast();
            }
            else// intermediate page
            {
                this.lblFirstPage.Enabled = true;
                //
                this.lblCurrentPage.Text =
                    this.currentPageText +
                    this.currentPage.ToString();
                this.lblCurrentPage.Enabled = false;
                //
                this.lblLastPage.Enabled = true;
            }
        }

    }// class
}//nmsp
