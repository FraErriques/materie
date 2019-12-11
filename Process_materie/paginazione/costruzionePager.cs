using System;
using System.Collections.Generic;
using System.Text;

namespace Process_materie.paginazione
{

    public static class costruzionePager
    {

        public static void primaCostruzionePager(
            //--in
            string viewTheme // it's just the prefix for the name; the whole name is this prefix after decoration on time-seed.
            , string ViewWhereTail
            , int rowXchunk
            //---out
            , out int rowCardinalityTotalView
            , out string viewName // the actual whole name in the db. Useful for db-administrators.
            , Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder proxyPointer // the ProxyPointer
            , out int par_lastPage
            , out System.Data.DataTable chunkDataSource
            , out Entity_materie.BusinessEntities.PagingManager pm
         )
        {
            pm = new Entity_materie.BusinessEntities.PagingManager(//----NB. out--------------------
                viewTheme
                , ViewWhereTail
                , proxyPointer
                , rowXchunk // default rowXchunk, on first call.
            );
            //--- out -----
            rowCardinalityTotalView = pm.rowCardinalityTotalView;// out
            viewName = pm.viewName;// out
            par_lastPage = pm.pagingCalculator.actual_lastPage;// out
            chunkDataSource = pm.chunkDataSource;// out
        }// primaCostruzionePager


    }// class
}// nmsp
