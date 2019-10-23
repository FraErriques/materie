using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace winFormsIntf
{


    public partial class Timbro : UserControl
    {

        public Timbro()
        {
            InitializeComponent();
        }


        private void autoreLoadToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if( this.Parent.GetType()==typeof(winFormsIntf.frmAutoreLoad) ) 
            {//do nothing. Just de-activate menu, since we're already in page.
            }
            else
            {
                winFormsIntf.frmAutoreLoad frmAutoreLoad_inst = new frmAutoreLoad();
                frmAutoreLoad_inst.ShowDialog();// this MODAL action suspends the execution; emaning that
                // the following lines will be executed only on closure of frmAutoreLoad_inst (asynchronous execution).
                ////instead
                //frmAutoreLoad_inst.Show();// this closes everything synchronously.
                //// this way the execution continues.
                //this.Close();NB. don't do that. This closes the main form, on closure of a slave one.
                //this.Dispose();
            }
        }

        private void documentoLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Parent.GetType() == typeof(winFormsIntf.frmDocumentoLoad))
            {//do nothing. Just de-activate menu, since we're already in page.
            }
            else
            {
                winFormsIntf.frmDocumentoLoad frmDocumentoLoad_inst = new frmDocumentoLoad();
                frmDocumentoLoad_inst.ShowDialog();// this MODAL action suspends the execution; emaning that
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.firstBlood.Dispose();
        }// autoreLoadToolStripMenuItem_Click


    }// class
}// nmsp
