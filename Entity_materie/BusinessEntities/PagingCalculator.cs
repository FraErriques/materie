using System;


namespace Entity_materie.BusinessEntities
{


    /// <summary>
    /// purpose of this class is to calculate {rowInf,rowSup} based on #chunkRequired cardinalityOfRowsInWholeView
    /// </summary>
    public class PagingCalculator
    {
        public int actual_currentPage;
        public int actual_rowXchunk;
        public int actual_lastPage;
        //
        public int required_currentPage;// for validation
        public int required_rowXchunk;// for validation
        public int required_lastPage;
        //
        public int rowInf;// for the query of the required chunk.
        public int rowSup;
        //---the following data are permanent and for that they have only one version.
        public string viewName;
        public int cardinalityOfRowsInWholeView;


        //Ctor
        public PagingCalculator( 
            int par_chunkRequired
            , int par_rowPerChunk
            , int par_cardinalityOfRowsInWholeView
          )
        {
            this.actual_rowXchunk = this.required_rowXchunk = par_rowPerChunk;
            this.required_currentPage = this.actual_currentPage = +1;// on Ctor().
            this.cardinalityOfRowsInWholeView = par_cardinalityOfRowsInWholeView;
            //
            this.setRowInfSup();
        }


        // Ctor
        public PagingCalculator(
            int par_chunkRequired
            , double par_percentageOfViewPerChunk // eg. the chunk is desired to be the 16,32%(ViewRow cardinality)
            , int par_cardinalityOfRowsInWholeView
          )
        {
            this.actual_rowXchunk = (int)System.Math.Ceiling(par_percentageOfViewPerChunk * par_cardinalityOfRowsInWholeView);
            this.required_currentPage = this.actual_currentPage = +1;// on Ctor().
            this.cardinalityOfRowsInWholeView = par_cardinalityOfRowsInWholeView;
            //
            this.setRowInfSup();
        }



        public void updateRequest(
            int par_chunkRequired
            , int par_rowPerChunk
            // , int par_cardinalityOfRowsInWholeView this is fixed, on the same View.
        )
        {
            this.required_currentPage = par_chunkRequired;
            this.actual_rowXchunk = par_rowPerChunk;
            this.setRowInfSup();// update rowBoundaries (Inf, Sup).
        }// updateRequest



        private void setRowInfSup()
        {
            
            this.actual_lastPage = (int)System.Math.Ceiling(((double)this.cardinalityOfRowsInWholeView / (double)this.actual_rowXchunk ));
            this.rowInf = this.actual_rowXchunk * (this.required_currentPage - 1) + 1;// first row, after the last row of previous chunk.
            this.rowSup = this.rowInf + this.actual_rowXchunk - 1;//last row of the required chunk; i.e. the first one of the
            // successive chunk minus one.
        }//setRowInfSup


        // evaluate the feasibility of a request.
        public bool tryEvaluateScenario(
            int requiredRowXchunk
            , int requiredPage
            , int par_cardinalityOfRowsInWholeView
            )
        {
            bool res = false;//init to invalid.
            //
            int lastPageInScenario = (int)System.Math.Ceiling(((double)par_cardinalityOfRowsInWholeView / (double)requiredRowXchunk));
            if (requiredPage < +1 || requiredPage > lastPageInScenario)
            { res = false; }
            else
            { res = true; }
            // ready.
            return res;
        }//setRowInfSup


        // get the picture of present scenario.
        public void getRowInfSup(
            out int outParRowInf
            , out int outParRowSup
            , out int outParLastPage
            )
        {
            outParRowInf = this.rowInf;
            outParRowSup = this.rowSup;
            outParLastPage = this.actual_lastPage;
        }//getRowInfSup


    }// class


}// nmsp
