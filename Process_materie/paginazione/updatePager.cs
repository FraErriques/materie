using System;
using System.Collections.Generic;
using System.Text;

namespace Process_materie.paginazione
{


    /* Il Process dovra' essere comune fra le diverse interfacce. In questo caso Web::Pager e
         * WinForms::Pager dovranno chiamare Process_materie::paginazione con risultati identici.
         * Ciascuna interfaccia passera' in input le proprie label, textBox,etc.. e ricevera' in
         * output le istanze degli oggetti di Entity manipolati, i.e. Cacher e PagingCalculator.
         * Nella segnatura del presente metodo, i primi due parametri sono stati costruiti e 
         * forniti in out da Process:paginazione::costruzione. I tre ultimi parametri, sono qui
         * forniti in out a beneficio dell'interfaccia chiamante, che fa DataBind.
         */
    public static class updatePager
    {

        public static void aggiornamentoPaginazione(
            Entity_materie.BusinessEntities.Cacher cacherInstance
            ,Entity_materie.BusinessEntities.PagingCalculator pagingCalc
            ,int par_chunkRequired
            ,int par_rowPerChunk
            ,out int rowInf
            ,out int rowSup
            ,out int lastPage
            ,out System.Data.DataTable dataSource
            )
        {
            pagingCalc.updateRequest(
                par_chunkRequired
                , par_rowPerChunk
            );
            pagingCalc.getRowInfSup(
                out rowInf
                , out rowSup
                , out lastPage
                );
            dataSource = cacherInstance.getChunk(
                rowInf
                , rowSup
            );



            //dataSource = Entity_materie.Proxies.usp_ViewGetChunk_SERVICE.usp_ViewGetChunk(
            //    Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(
            //        prototypeCacher.get_viewName()
            //      )
            //    , rowInf
            //    , rowSup
            //    );
        }


    }//

}
