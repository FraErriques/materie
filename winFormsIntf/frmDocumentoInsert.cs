﻿using System;
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



        #region multi_upload
        //------------------------------------------------------------------------------------------------

        //// porta singolo file in chechedList : sostituito dalla selezion multipla nella Dialog.
        //protected void btnAllega_Click(object sender, EventArgs e)
        //{
            //string dbg = this.uploadFile.Value;
            //if (null == this.Session["arlUploadPaths"])//----------TODO  dbg
            //{
            //    this.Session["arlUploadPaths"] = new ArrayList();
            //}// else already built.
            ////
            //if (// add to chkList only valid items
            //    null != dbg
            //    && "" != dbg
            //    )
            //{
            //    this.chkMultiDoc.Items.Add(new ListItem(dbg));
            //    int presentCardinality = this.chkMultiDoc.Items.Count;
            //    this.chkMultiDoc.Items[presentCardinality - 1].Selected = true;
            //    // NB. the upload must be performed, before emptying the upload-html-control.
            //    this.allegaSingoloFile();// on current selection; i.e. a scalar item. throws on empty selection.
            //}// else skip an invalid selection.
            //// ready
        //}//


        /// <summary>
        /// btnSubmit is used to communicate the final decision of the user:
        ///     after he reviews the check-list of the web_srv uploaded files, he finally
        ///     confirms what to send to the db_srv( i.e. the checked ones only).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDocsFromWebToDb_Click(object sender, EventArgs e)
        {
            string _abstract;
            int ref_autore_id;
            int ref_materia_id;
//string sourceName;
            bool result = true;// bool mask.
            //
            bool validForWriting = default(bool);// a not-valid-forWriting item does not affect the whole insertion.
            //int acc = 0;
            //
            foreach (ListViewItem itemRow in lvwDocSelection.Items)
            {
                if (itemRow.Checked)
                {
                    for (int i = 0; i < itemRow.SubItems.Count; i++)
                    {
                        if (i > 0) { throw new System.Exception("docPath must have only one element ! Do debug."); }//else can continue.
                        string fullPath = itemRow.SubItems[i].Text;
//MessageBox.Show(fullPath);
//this.allegaSingoloFile(fullPath );// on current selection; i.e. a scalar item. throws on empty selection.
//UploadElement uploadElement = new UploadElement();// prepare data-structure,as desired by Entity_materie
// Get the filename_only from client_fullpath.
//string fileName_only = System.IO.Path.GetFileName(fullPath); // TODO ? serve
//uploadElement.client_path = fullPath;
                        validForWriting = this.validationForWrite(
                            out _abstract,
                            out ref_autore_id,
                            out ref_materia_id
                            //, ref acc // the accumulator is used, as index, to acces an array in Session and incremented by the calee.
                            //, out sourceName
                        );
                        if (true == validForWriting)
                        {
                            Entity_materie.BusinessEntities.docMulti dm = new Entity_materie.BusinessEntities.docMulti(
                                ref_autore_id
                                , ref_materia_id
                                );
                            int entityDbInsertionResult =
                                dm.FILE_from_FS_insertto_DB(
                                    ref_autore_id,
                                    ref_materia_id,
                                    _abstract,
                                    fullPath // TODO sourceName
                                );
                            result &= (0 < entityDbInsertionResult);// each insertion must return the lastGeneratedId, which>0.
                        }// else NOTvalidForWriting -> skip item.
                        result &= validForWriting;// update the result, to last insertion outcome.
                    }// for each sub-element
                }// else skip an item that has been un-checked, after uploading from client to web_srv.
            }// foreach
            // ready
            if (!result)
            {
                LoggingToolsContainerNamespace.LoggingToolsContainer.DecideAndLog(
                    null,// original exception type
                    "Non e' stato possibile inserire il lavoro.",
                    0);
                //this.pnlInteractiveControls.Enabled = true;// let the user correct errors on page.
                //this.divUpload.Enabled = true;// let the user correct errors on page.
                this.grbDocInsert.Enabled = true;// let the user correct errors on page.
                this.lblEsito.Text = "Non e' stato possibile inserire il lavoro.";
                this.lblEsito.BackColor = System.Drawing.Color.Red;
                return;// on page
            }// if !result i.e. docMulti non inserito
            else
            {
                LoggingToolsContainerNamespace.LoggingToolsContainer.DecideAndLog(
                    null,// original exception type
                    "Il lavoro e' stato inserito correttamente.",
                    0);
                //----navigate to "scadenziario", where the inserted phase is visible.
                this.lblEsito.Text = "Il lavoro e' stato inserito correttamente.";
                this.lblEsito.BackColor = System.Drawing.Color.Green;
        //this.Session["errore"] = null;// gc  TODO
        //this.Session["arlUploadPaths"] = null;// gc
        //this.Session["ref_candidato_id"] = null;// gc --- NB.
        // this.Response.Redirect("candidatoLoad.aspx");  TODO  stay in page with lblStatus & freeze
            }// else  i.e. ok docMulti inserito.
        }//---end submit()




        ///// <summary>
        ///// upload a single token( file) from an attachment-list( check-list).
        ///// </summary>
        ///// <param name="theFileToBeUploaded"></param>
        //protected void allegaSingoloFile( string fullPath)
        //{
        //    UploadElement uploadElement = new UploadElement();// TODO store
        //    // Get the filename_only from client_fullpath.
        //    string fileName_only = System.IO.Path.GetFileName( fullPath); // this.uploadFile.PostedFile.FileName);
        //    uploadElement.client_path = fullPath; // this.uploadFile.PostedFile.FileName;
        //    ////
        //    ConfigurationLayer.ConfigurationService cs = new
        //        ConfigurationLayer.ConfigurationService("FileTransferTempPath/fullpath");
        //    string serverPath = cs.GetStringValue("path");
        //    // NB. adapt in App.config to the server file system.
        //    // add ending part.
        //    serverPath += "\\upload";
        //    //
        //    // Ensure the folder exists
        //    if (!System.IO.Directory.Exists(serverPath))
        //    {
        //        System.IO.Directory.CreateDirectory(serverPath);
        //    }// else already present on the web server file system.
        //    //// Save the file to the folder, on the web-server.
        //    string fullPath_onWebServer = System.IO.Path.Combine(serverPath, fileName_only);
        //    uploadElement.web_server_path = fullPath_onWebServer;// TODO dbg.
        //    //if (null == this.Session["arlUploadPaths"])
        //    //{
        //    //    throw new System.Exception("TODO call btnAllega() first!");
        //    //}// else ok.
        //    //((System.Collections.ArrayList)(this.Session["arlUploadPaths"])).Add(uploadElement);
        //    //// ready
        //    //this.uploadFile.PostedFile.SaveAs(fullPath_onWebServer);//--NB.---crucial system call: from client do web-srv.
        //}// end uploadButton_Click()




        //------------------------------------------------------------------------------------------------
        #endregion multi_upload




        private bool validationForWrite(
            //----parametri validazione---------
                out string _abstract,// get the content of TextBox
                out int ref_autore_id, // get the content of DoubleKey
                out int ref_materia_id // get the content of DoubleKey
            )
        {
            bool result = true;// used as bitmask with & operator.
            //
            _abstract = this.textBox1.Text; // TODO names
            if (
                null != _abstract
                && "" != _abstract
                )
            {
                result &= true;
            }
            else
            {
                result &= false;
            }
            //
            ref_autore_id = this.int_ref_autore_id;
            if (
                0 < ref_autore_id)
            {
                result &= true;
            }
            else
            {
                result &= false;
            }
            //
            ref_materia_id = this.int_ref_materia_id;
            if (
                0 < ref_materia_id)
            {
                result &= true;
            }
            else
            {
                result &= false;
            }
            /*
             * NB. the acc index is incremented, AFTER array-access, and returned to the caller, 
             * which manages the loop.
             */
            // TODO sourceName = ((UploadElement)((System.Collections.ArrayList)(this.Session["arlUploadPaths"]))[acc++]).web_server_path; //sourceName
            //sourceName = "TODO";
            //if (
            //    null != sourceName
            //    && "" != sourceName
            //    )
            //{
            //    result &= true;
            //}
            //else
            //{
            //    result &= false;
            //}
            //
            // ready
            return result;
        }// end validationForWrite.

        private void btnFromFsToDb_Click(object sender, EventArgs e)
        {
            this.btnDocsFromWebToDb_Click(sender, e);// TODO : only one delegate
        }


    }// class
}// nmsp
