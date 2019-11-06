using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{
    public partial class frmDocumentoInsert : Form
    {
        private System.Collections.ArrayList selectedDocFullPath;// of each of them.
        public struct UploadElement
        {
            public string client_path;
            public string web_server_path;
        };
        private int int_ref_autore_id = default(int);
        private int int_ref_materia_id = default(int);
        private string string_ref_autore_id;
        private string string_ref_materia_id;


        // Ctor()
        public frmDocumentoInsert()
        {// check login status
            bool isLoggedIn =
                winFormsIntf.CheckLogin.isLoggedIn(
                    (Entity_materie.BusinessEntities.Permesso.Patente)
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"]);
            if (!isLoggedIn)
            {
                winFormsIntf.frmError ErrorForm = new frmError(new System.Exception("user is not Logged In"
                    , new System.Exception("Go to Login Form and access, in order to proceed.")));
                ErrorForm.ShowDialog();// block on Error Form
            }// else is LoggedIn -> CanContinue
            //
            //// init graphics
            InitializeComponent();
            //
            try
            {
                this.int_ref_materia_id =
                    (int)(Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["chiaveDoppiaMateria"]);
                this.int_ref_autore_id =
                    (int)(Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["chiaveDoppiaAutore"]);
                // ..was : this.int_ref_materia_id = (int)(this.Session["chiaveDoppiaMateria"]);
                // .. this.int_ref_autore_id = (int)(this.Session["chiaveDoppiaAutore"]);
                //
                this.lblEsito.BackColor = System.Drawing.Color.Transparent;
                this.lblEsito.Text = "";
                //
                bool res = this.translateDoubleKey(); // call it to pass from IDs to names.
                if( res)
                {
                    this.lblEsito.Text = "DoubleKey validated.";
                    this.lblEsito.BackColor = System.Drawing.Color.Green;
                    //
                    this.lblDoubleKey.BackColor = System.Drawing.Color.Transparent;
                    this.lblDoubleKey.Text = "chiaveDoppiaMateria==" +
                        this.string_ref_materia_id + "  /---/  chiaveDoppiaAutore==" + this.string_ref_autore_id;
                }
                else
                {
                    this.lblEsito.Text = " Error: chiaveDoppia errata per Materia-Autore.";
                    this.lblEsito.BackColor = System.Drawing.Color.Red;
                    this.grbDocInsert.Enabled = false;// cannot proceed inserting Documento.
                }
            }
            catch (System.Exception ex)
            {
                string msg = ex.Message;
                this.lblEsito.BackColor = System.Drawing.Color.Red;
                this.lblEsito.Text = "Assenza della chiave doppia in Sessione. Allarme.";
                this.grbDocInsert.Enabled = false;// cannot proceed inserting Documento.
            }
        }// Ctor()



        /// <summary>
        /// prendere dalla Session la DoubleKey -che e' stata validata in AutoreLoad- e tradurla da ID a nomi
        /// per pubblicarla nella lblDoubleKey
        /// </summary>
        private bool translateDoubleKey()
        {
            // NB : query db x traduzione chiave doppia, da ID a nomi.
            bool res = false;// init to invalid
            int idMateriaPrescelta = 0;
            int idAutorePrescelto = 0;
            System.Data.DataSet ds;
            try
            {
                idMateriaPrescelta = this.int_ref_materia_id;
                idAutorePrescelto = this.int_ref_autore_id;
                ds = Entity_materie.Proxies.usp_chiaveDoppia_LOAD_SERVICE.usp_chiaveDoppia_LOAD();
                if (null == ds || 2 != ds.Tables.Count)
                {
                    throw new System.Exception(" Error: chiaveDoppia errata per Materia-Autore.");
                }// else continue.
                int hmMaterie = ds.Tables[0].Rows.Count;// Tables[0]==Materia
                int hmAutori = ds.Tables[1].Rows.Count; // Tables[1]==Autore
                //
                for (int c = 0; c < hmMaterie; c++)
                {
                    int curMateria = ((int)(ds.Tables[0].Rows[c]["id"])); // Tables[0]==Materia
                    if (idMateriaPrescelta == curMateria)
                    {
                        this.string_ref_materia_id = (string)(ds.Tables[0].Rows[c]["nomeMateria"]);
                        break;
                    }// else continue searching for Materia
                }// end for Materia
                //
                for (int c = 0; c < hmAutori; c++)
                {
                    int curAutore = ((int)(ds.Tables[1].Rows[c]["id"]));// Tables[1]==Autore
                    if (idAutorePrescelto == curAutore)
                    {
                        this.string_ref_autore_id = (string)(ds.Tables[1].Rows[c]["nominativo"]);
                        break;
                    }// else continue searching for Autore
                }// end for Autore
            }// end try
            catch (System.Exception ex)
            {
                string msg = ex.Message;
                this.lblEsito.Text = " Exception while processing chiaveDoppia per Materia-Autore." + ex.Message;
                this.lblEsito.BackColor = System.Drawing.Color.Red;
                res = false;
            }
            if (
                null != this.string_ref_materia_id && "" != this.string_ref_materia_id
                && null != this.string_ref_autore_id && "" != this.string_ref_autore_id
                )// both
            {
                res = true;
            }
            else
            {
                res = false;
            }
            // ready.
            return res;
        }// translateDoubleKey()




        /// <summary>
        /// crucial method, for cleaning up the instance ArrayList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDocumentoInsert_FormClosed( object sender, FormClosedEventArgs e )
        {// call Timbro menu manager, for removing the instance of the form that is in the proces of being closed.
            this.uscTimbro.removeSpecifiedWin(this);
        }// frmDocumentoInsert_FormClosed



        private void btnSearchFileSystem_Click( object sender, EventArgs e )
        {
            // this.folderBrowserDialog1.ShowDialog(this);
            this.openFileDialog1.ShowDialog(this);// the execution stops here and forks on the FileDialog
            // after the submitButton of the fileDialog, the execution continues from the next line:
            // for  ... insert the fullPaths in a chechedList
            if (null != this.selectedDocFullPath)
            {
                for (int c = 0; c < selectedDocFullPath.Count; c++)
                {
                    this.lvwDocSelection.Items.Add((string)(this.selectedDocFullPath[c]));
                }
            }// else nothing has been selected yet.
        }// btnSearchFileSystem_Click


        private void openFileDialog1_FileOk( object sender, CancelEventArgs e )
        {
            string[] selectedFiles = this.openFileDialog1.FileNames;
            if (null == this.selectedDocFullPath)
            {
                this.selectedDocFullPath = new System.Collections.ArrayList();
            }
            for (int c = 0; c < selectedFiles.Length; c++)
            {
                this.selectedDocFullPath.Add(selectedFiles[c]);
                //this.lvwDocSelection.Items.Add(selectedFiles[c]);
            }
            string baseString = "listView1_testoLungoDiBase/sssssssssssss/ddddddddddddddd/fffffffffffff/";
            for (int c = 0; c < 100; c++)
            {
                this.selectedDocFullPath.Add(baseString + c.ToString() + ".txt");
            }
        }// openFileDialog1_FileOk


    }// class
}// nmsp
