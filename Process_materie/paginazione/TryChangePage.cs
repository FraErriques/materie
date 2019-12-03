using System;
using System.Text;


namespace Process_materie.paginazione
{


    public static class TryChangePage_SERVICE
    {

        public static bool TryChangePage(
            int currentPage
            , int lastPage
            , int rowXchunk
            , int requiredPage
            , Entity_materie.BusinessEntities.PagingCalculator pagingCalculatorInstance
            , Entity_materie.BusinessEntities.Cacher cacherInstance
            , out int outParRowInf
            , out int outParRowSup
            , out int outParLastPage
            , out System.Data.DataTable curDataSource
         )
        {
            bool res = false;// init to invalid.
            pagingCalculatorInstance.getRowInfSup(// set to presentValues, in case the tryChange fails.
                out outParRowInf// else if it succeeds, new values will be assigned.
                , out outParRowSup
                , out outParLastPage
            );
            curDataSource = null;// in case the tryChange fails. 
            //
            bool isAfeasibleChange =
                pagingCalculatorInstance.tryEvaluateScenario(
                    rowXchunk
                    , requiredPage
                );
            if (!isAfeasibleChange)
            {
                res = false;
            }
            else// the change is feasible
            {
                pagingCalculatorInstance.updateRequest(
                    requiredPage
                    , rowXchunk
                );
                pagingCalculatorInstance.getRowInfSup(
                    out outParRowInf
                    , out outParRowSup
                    , out outParLastPage
                );
                curDataSource = cacherInstance.getChunk(
                    outParRowInf
                    , outParRowSup
                );
                res = true;// pageChange succeeded
            }// else : pageChange succeeded
            //ready
            return res;
        }// TryChangePage


    }// class

}// nmsp
