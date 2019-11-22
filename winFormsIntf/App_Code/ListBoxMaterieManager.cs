using System;
using System.Text;


namespace winFormsIntf.App_Code
{

    

    public class ListBoxMaterieManager
    {
        private System.Data.DataTable dtMateria;
        private int idOfSelectedItem;// in the comboMaterie

        
        //Ctor()
        public ListBoxMaterieManager()
        {
            this.dtMateria = Entity_materie.Proxies.usp_materia_LOOKUP_LOAD_SERVICE.usp_materia_LOOKUP_LOAD();// Proxy
        }//Ctor()


        public void populate_Listbox_ddlMateria_for_LOAD(
            System.Windows.Forms.ListBox lsbMaterie
          )
        {
            //--------------popolamento : -----------------
            lsbMaterie.Items.Clear();
            lsbMaterie.Items.Add(// this line will be the title, which appears pre-selected.
                   new winFormsIntf.App_Code.GenericCoupleKeyValue(
                       "Elenco delle Materie ad oggi censite" //--no query for this combo voice ---
                       ,0 // index in combo-box
                   )// end new_list_item
             );// end items_add
            if (null != dtMateria)
            {
                for( int c = 0; c < dtMateria.Rows.Count; c++)// dataTable is zero-based
                {
                    lsbMaterie.Items.Add(
                        new winFormsIntf.App_Code.GenericCoupleKeyValue(
                            (string)(dtMateria.Rows[c]["nomeMateria"])
                            ,(int)(dtMateria.Rows[c]["id"]) // index in combo-box
                        )// end new_list_item
                   );// end items_add
                }// end for.
                //lsbMaterie.Items.Add(// NB. an additional item, for querying with no condition tail.
                //        new winFormsIntf.App_Code.comboRow(  -- NOT DESIRED IN THIS CASE
                //            "Tutte le Materie"//--select without "where-tail" -----
                //            , -1 // index in combo-box : Proxy queries on allMaterie when index<0
                //        )// end new_list_item
                //   );// end items_add
            }// else skip, on null dataTable(es. no connection).
            //--NO pre selection, since it hides the line in the listBox.
        }// populate_Combo_ddlMateria_for_LOAD()


        public int lsbMaterie_SelectedIndexChanged(
            System.Windows.Forms.ListBox lsbMaterie
            )
        {
            int selIndex = lsbMaterie.SelectedIndex;// good
            object selItem = lsbMaterie.SelectedItem;// good
            //string selTxt = lsbMaterie.SelectedText;// bad
            //object selVal = lsbMaterie.SelectedValue;// bad
            //
            this.idOfSelectedItem = default(int);
            try
            {
                idOfSelectedItem = ((winFormsIntf.App_Code.GenericCoupleKeyValue)(selItem)).getId();
            }// try
            catch (System.Exception ex)
            {
                string msg = "something wrong " + ex.Message;
            }// catch
            // ready
            return this.idOfSelectedItem;
        }// lsbMaterie_SelectedIndexChanged


    }// class ComboMaterieManager


}// nmsp
