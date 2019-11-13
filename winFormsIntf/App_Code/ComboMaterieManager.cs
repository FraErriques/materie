using System;
using System.Collections.Generic;
using System.Text;


namespace winFormsIntf.App_Code
{


    public class comboRow
    {
        private string fieldName;
        private int fieldId;
        //
        public comboRow( string fieldName_par, int fieldId_par )
        {
            this.fieldId = fieldId_par;
            this.fieldName = fieldName_par;
        }

        public override string ToString()
        {
            return this.fieldName;
        }

        public int getId()
        {
            return this.fieldId;
        }
    };



    public class ComboMaterieManager
    {
        private System.Data.DataTable dtMateria;
        private int idOfSelectedItem;// in the comboMaterie

        
        //Ctor()
        public ComboMaterieManager()
        {
            this.dtMateria = Entity_materie.Proxies.usp_materia_LOOKUP_LOAD_SERVICE.usp_materia_LOOKUP_LOAD();// Proxy
        }//Ctor()

        public void populate_Combo_ddlMateria_for_LOAD(
            System.Windows.Forms.ComboBox ddlMaterie,
            int selectedElement// the default pre-selection is index==0 -> i.e. "selezione della Materia".
          )
        {
            //--------------popolamento : -----------------
            ddlMaterie.Items.Clear();
            ddlMaterie.Items.Add( 
                   new winFormsIntf.App_Code.comboRow(
                       "selezione della Materia" //--no query for this combo voice ---
                       ,0 // index in combo-box
                   )// end new_list_item
            );// end items_add
            if (null != dtMateria)
            {
                for( int c = 0; c < dtMateria.Rows.Count; c++)// dataTable is zero-based
                {
                    ddlMaterie.Items.Add(
                        new winFormsIntf.App_Code.comboRow(
                            (string)(dtMateria.Rows[c]["nomeMateria"])
                            ,(int)(dtMateria.Rows[c]["id"]) // index in combo-box
                        )// end new_list_item
                   );// end items_add
                }// end for.
                ddlMaterie.Items.Add(// NB. an additional item, for querying with no condition tail.
                        new winFormsIntf.App_Code.comboRow(
                            "Tutte le Materie"//--select without "where-tail" -----
                            , -1 // index in combo-box : Proxy queries on allMaterie when index<0
                        )// end new_list_item
                   );// end items_add
            }// else skip, on null dataTable(es. no connection).
            //--pre selection.
            ddlMaterie.SelectedIndex = 0;
        }// populate_Combo_ddlMateria_for_LOAD()


        public int ddlMaterie_SelectedIndexChanged(
            System.Windows.Forms.ComboBox ddlMaterie
            )
        {
            int selIndex = ddlMaterie.SelectedIndex;// good
            object selItem = ddlMaterie.SelectedItem;// good
            string selTxt = ddlMaterie.SelectedText;// bad
            object selVal = ddlMaterie.SelectedValue;// bad
            //
            this.idOfSelectedItem = default(int);
            try
            {
                idOfSelectedItem = ((winFormsIntf.App_Code.comboRow)(selItem)).getId();
            }// try
            catch (System.Exception ex)
            {
                string msg = "something wrong " + ex.Message;
            }// catch
            // ready
            return this.idOfSelectedItem;
        }// ddlMaterie_SelectedIndexChanged


    }// class ComboMaterieManager



}// nmsp
