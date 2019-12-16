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
        {//--------------popolamento : -----------------
            lsbMaterie.Items.Clear();
            //
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
                }// end for_each Materia.
            }// else skip, on null dataTable(es. no connection).
            // NB. NO pre selection, since it hides the line in the listBox.
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
