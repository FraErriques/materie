using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace winFormsIntf
{
    public partial class frmUpdateAbstract : Form
    {
        int idAutoreSelected;
        int idMateriaSelected;
        int idDocumentoSelected;
        frmAutoreLoad.UpdateContentActions updateContentActions;


        /// <summary>
        /// NB. compulsory initialization, to distinguish between the types of content to update.
        /// NB. Session is used to initialize this form. No usage of the Constructor is available, since
        /// the Factory requires no_params_Ctors.
        /// 
        /// for the involved-table names, produce an enum. They are:
        /// Autore
        /// Materia
        /// Documento
        /// 
        /// the respective fields are: 
        /// Autore  - nome
        /// Autore  - note
        /// Materia - nomeMateria
        /// Documento - abstract
        /// </summary>
        /// <param name="tableName">the subject </param>
        /// <param name="id">the "id" column, of the selected row</param>
        public frmUpdateAbstract()
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
            // TODO : only "writers" could get here. Check whether a reader got here, kindly let him out.
            try
            {// from Session :
                updateContentActions = (frmAutoreLoad.UpdateContentActions)
                    (Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["update_action"]);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("illegal landing in page frmUpdateAbstract : action_type & entity_id must be provided in Session."
                    + ex.Message);
            }
            if( updateContentActions == frmAutoreLoad.UpdateContentActions.AutoreNome
                || updateContentActions==frmAutoreLoad.UpdateContentActions.AutoreAbstract)
            {
                try
                {// from Session :
                    idAutoreSelected = (int)(Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["idAutoreSelected"]);
                }
                catch( System.Exception ex)
                {
                    throw new System.Exception("illegal landing in page frmUpdateAbstract : idAutoreSelected missing in Session."
                        + ex.Message);
                }
            }// if update(something(Autore))
            else if (updateContentActions == frmAutoreLoad.UpdateContentActions.MateriaNome)
            {
                try
                {// from Session :
                    idMateriaSelected = (int)(Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["idMateriaSelected"]);
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("illegal landing in page frmUpdateAbstract : idMateriaSelected missing in Session."
                        + ex.Message);
                }
            }
            else if (updateContentActions == frmAutoreLoad.UpdateContentActions.DocumentoAbstract)
            {
                try
                {// from Session :
                    idDocumentoSelected = (int)(Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["idDocumentoSelected"]);
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("illegal landing in page frmUpdateAbstract : idDocumentoSelected missing in Session."
                        + ex.Message);
                }
            }
            else// no remaining cases
            {
                updateContentActions = frmAutoreLoad.UpdateContentActions.Invalid;// not a legal choice
                throw new System.Exception("illegal landing in page frmUpdateAbstract : not a legal updateAction-choice.");
            }
            this.lblStato.Text = updateContentActions.ToString();
            this.lblStato.BackColor = System.Drawing.Color.LightGreen;
            // done with action look up.
            //
            switch (updateContentActions)
            {
                case frmAutoreLoad.UpdateContentActions.AutoreNome:
                    {
                        string whereTail = " where id=@par ";
                        whereTail = whereTail.Replace("@par", idAutoreSelected.ToString());
                        System.Data.DataTable dt =
                            Entity_materie.Proxies.usp_autore_LOAD_SERVICE.usp_autore_LOAD(
                                whereTail
                            );
                        try
                        {
                            this.txtContentToBeUpdated.Text =
                                (string)(dt.Rows[0]["nominativo"]);
                        }
                        catch (System.Exception ex)
                        {
                            this.lblStato.Text = ex.Message;
                            this.lblStato.BackColor = System.Drawing.Color.Orange;
                        }
                        break;
                    }
                case frmAutoreLoad.UpdateContentActions.AutoreAbstract:
                    {
                        string whereTail = " where id=@par ";
                        whereTail = whereTail.Replace("@par", idAutoreSelected.ToString());
                        System.Data.DataTable dt =
                            Entity_materie.Proxies.usp_autore_LOAD_SERVICE.usp_autore_LOAD(
                                whereTail
                            );
                        try
                        {
                            this.txtContentToBeUpdated.Text =
                                (string)(dt.Rows[0]["note"]);
                        }
                        catch (System.Exception ex)
                        {
                            this.lblStato.Text = ex.Message;
                            this.lblStato.BackColor = System.Drawing.Color.Orange;
                        }
                        break;
                    }
                case frmAutoreLoad.UpdateContentActions.MateriaNome:
                    {
                        string whereTail = " where id=@par ";
                        whereTail = whereTail.Replace("@par", idMateriaSelected.ToString());
                        System.Data.DataTable dt =
                            Entity_materie.Proxies.usp_materia_LOOKUP_LOADWHERE_SERVICE.usp_materia_LOOKUP_LOADWHERE(
                                whereTail
                            );
                        try
                        {
                            this.txtContentToBeUpdated.Text =
                                (string)(dt.Rows[0]["nomeMateria"]);
                        }
                        catch (System.Exception ex)
                        {
                            this.lblStato.Text = ex.Message;
                            this.lblStato.BackColor = System.Drawing.Color.Orange;
                        }
                        break;
                    }
                case frmAutoreLoad.UpdateContentActions.DocumentoAbstract:
                    {
                        //
                        break;
                    }
                default:
                    {// if none of the preceding cases was the actual one, than the state is "Invalid".
                        throw new System.Exception("illegal landing in page frmUpdateAbstract.");
                        // break; unreachable code.
                    }
            }// switch


        }// Ctor()



        


        /// <summary>
        /// this method calls the Timbro's function which Disposes the frm that is on closure and removes it from the frm ArrayList.
        /// </summary>
        private void frmUpdateAbstract_FormClosed(object sender, FormClosedEventArgs e)
        {
            winFormsIntf.windowWarehouse.removeSpecifiedWin(this);
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["idAutoreSelected"] = null;// clean
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["update_action"] = null;// clean
        }// frmUpdateAbstract_FormClosed


        /// <summary>
        /// keep in mind the need for locks, due to the presence of multiple clients, which are concurrent in such write-activity on the db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommit_Click(object sender, EventArgs e)
        {

        }// btnCommit_Click


    }
}
