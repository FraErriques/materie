﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Process_materie.paginazione
{

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
