using System;
using System.Text;


namespace Process_materie.paginazione
{


    public static class TryChangePage_SERVICE
    {


        public static bool TryChangePage(
            ref Entity_materie.BusinessEntities.PagingManager pagingManager
            , out System.Data.DataTable current_DataSource// refreshes the dataGrid, in case of chunk-change.
         )
        {
            bool isRequestValidForDataChange = false;// init to invalid, and initialize "out" params, since it's compulsory.
            current_DataSource = null;// in case the tryChange fails. The caller has to check for it.
            //----### NB. if the user erroneously asked for the same page with same chunk size, it's surely a mistake and a round trip to the 
            //            server has to be avoided. Such check has not to be placed in each single interface; it's an architectural principle
            //            and has to be placed as a common factor in Process::.
            //-----preliminary stability check--------
            if (null == pagingManager)
                { return false; }
            //
            if(  pagingManager.pagingCalculator.required_rowXchunk == pagingManager.pagingCalculator.actual_rowXchunk
                && pagingManager.pagingCalculator.required_currentPage == pagingManager.pagingCalculator.actual_currentPage )
            {
                isRequestValidForDataChange = false;
            }
            else
            {
                isRequestValidForDataChange = true;
            }
            //----###
            if (isRequestValidForDataChange)
            {
                // the call to pagingCalculator_Instance.getRowInfSup( set out params to presentValues, in case the tryChange fails.                
                bool isAfeasibleChange =// a second level of evaluation. The preceeding "isRequestValidForDataChange" concerned consistency.
                    pagingManager.pagingCalculator.tryEvaluateScenario(//--it's just a tryMethod. It does not modify members.
                        pagingManager.pagingCalculator.required_rowXchunk// the present one concerns feasibility, based on the data in the View.
                        , pagingManager.pagingCalculator.required_currentPage
                        , pagingManager.cacherInstance.get_rowCardinalityTotalView()
                    );
                if (!isAfeasibleChange)
                {
                    isRequestValidForDataChange = false;
                    pagingManager.pagingCalculator.required_currentPage = pagingManager.pagingCalculator.actual_currentPage;
                    pagingManager.pagingCalculator.required_rowXchunk = pagingManager.pagingCalculator.actual_rowXchunk;
                }
                else// the change is feasible
                {//NB. needed refresh.
                    pagingManager.pagingCalculator.cardinalityOfRowsInWholeView = pagingManager.cacherInstance.get_rowCardinalityTotalView();
                    pagingManager.pagingCalculator.viewName = pagingManager.cacherInstance.get_viewName();
                    pagingManager.pagingCalculator.updateRequest(//--set the new values
                        pagingManager.pagingCalculator.required_currentPage
                        , pagingManager.pagingCalculator.required_rowXchunk
                    );
                    pagingManager.pagingCalculator.getRowInfSup(//---get the consequences of the new values
                        out pagingManager.pagingCalculator.rowInf
                        , out pagingManager.pagingCalculator.rowSup
                        , out pagingManager.pagingCalculator.actual_lastPage
                    );
                    current_DataSource = pagingManager.cacherInstance.getChunk(
                         pagingManager.pagingCalculator.rowInf // a new data-chunk
                        , pagingManager.pagingCalculator.rowSup
                    );
                    // NB.----update Pager::members on success-----
                    pagingManager.pagingCalculator.actual_currentPage = pagingManager.pagingCalculator.required_currentPage;
                    pagingManager.pagingCalculator.actual_rowXchunk = pagingManager.pagingCalculator.required_rowXchunk;
                    pagingManager.pagingCalculator.required_lastPage = pagingManager.pagingCalculator.actual_lastPage;
                    isRequestValidForDataChange = true;// pageChange succeeded
                    //
                    current_DataSource = pagingManager.cacherInstance.getChunk(
                        pagingManager.pagingCalculator.rowInf
                        , pagingManager.pagingCalculator.rowSup
                    );
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
