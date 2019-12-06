using System;
using System.Text;


namespace Process_materie.paginazione
{


    public static class TryChangePage_SERVICE
    {

        public static bool TryChangePage(
            //--section actual parameters; they are "ref" since they can be modified, in case of approval of the required ones.
            // NB. they cannot be "out" since their preceeding value counts. Instead "out" params
            // need be initialized before their use, which would erase their content.
            //--section actual parameters
            ref int actual_currentPage
            , ref int actual_rowXchunk
            , ref int actual_lastPage
            //
            //-- section Entity::instances. They are used to calculate something.
            , Entity_materie.BusinessEntities.PagingCalculator pagingCalculator_Instance
            , Entity_materie.BusinessEntities.Cacher cacher_Instance
            //
            //-- section required values: they need be validated before usage; in case of validation success, they will overwrite the "actual" ones.
            , ref int required_Page
            , ref int required_ChunkSize
            //
            //-- section "out"; such parameters are derived from the query of a new chunk, in case of approval of the requiredValues.
            , ref int outPar_RowInf// in case of rejection of the required parameters, these variables will contain the last good value,
            , ref int outPar_RowSup// which is the one they contained before the wrong request.
            , ref int outPar_LastPage
            //
            , out System.Data.DataTable current_DataSource// refreshes the dataGrid, in case of chunk-change.
         )
        {
            bool isRequestValidForDataChange = false;// init to invalid, and initialize "out" params, since it's compulsory.
            current_DataSource = null;// in case the tryChange fails. The caller has to check for it.
            //----### NB. if the user erroneously asked for the same page with same chunk size, it's surely a mistake and a round trip to the 
            //            server has to be avoided. Such check has not to be placed in each single interface; it's an architectural principle
            //            and has to be placed as a common factor in Process::.
            if (required_ChunkSize == actual_rowXchunk
                && required_Page == actual_currentPage)
            {
                isRequestValidForDataChange = false;
            }
            else
            {
                isRequestValidForDataChange = true;
            }
            //----###
            if( isRequestValidForDataChange)
            {
                // the call to pagingCalculator_Instance.getRowInfSup( set out params to presentValues, in case the tryChange fails.                
                bool isAfeasibleChange =// a second level of evaluation. The preceeding "isRequestValidForDataChange" concerned consistency.
                    pagingCalculator_Instance.tryEvaluateScenario(//--it's just a tryMethod. It does not modify members.
                        required_ChunkSize// the present one concerns feasibility, based on the data in the View.
                        , required_Page
                    );
                if (!isAfeasibleChange)
                {
                    isRequestValidForDataChange = false;
                    required_Page = actual_currentPage;
                    required_ChunkSize = actual_rowXchunk;
                }
                else// the change is feasible
                {
                    pagingCalculator_Instance.updateRequest(//--set the new values
                        required_Page
                        , required_ChunkSize
                    );
                    pagingCalculator_Instance.getRowInfSup(//---get the consequences of the new values
                        out outPar_RowInf// if we get here, we will have new values.
                        , out outPar_RowSup
                        , out outPar_LastPage
                    );
                    current_DataSource = cacher_Instance.getChunk(
                        outPar_RowInf// a new data-chunk
                        , outPar_RowSup
                    );// NB.----update Pager::members on success-----
                    actual_currentPage = required_Page;
                    actual_rowXchunk = required_ChunkSize;
                    actual_lastPage = outPar_LastPage;
                    isRequestValidForDataChange = true;// pageChange succeeded
                }// else : pageChange succeeded
            }// if the request was not for the same combination of chunkSize and Page; so if it was a valid request.
            else
            {// no data change occurred.
                isRequestValidForDataChange = false;
            }
            //ready
            return isRequestValidForDataChange;
        }// TryChangePage


    }// class

}// nmsp
