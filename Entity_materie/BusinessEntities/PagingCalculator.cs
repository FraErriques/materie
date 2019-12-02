using System;


namespace Entity_materie.BusinessEntities
{


    /// <summary>
    /// purpose of this class is to calculate {rowInf,rowSup} based on #chunkRequired cardinalityOfRowsInWholeView
    /// </summary>
    public class PagingCalculator
    {
        private int rowInf;
        private int rowSup;
        private int rowPerChunk;
        private int chunkRequired;
        private int cardinalityOfRowsInWholeView;
        private int lastPage;// updated at every change of chunk size.

        public PagingCalculator( 
            int par_chunkRequired
            , int par_rowPerChunk
            , int par_cardinalityOfRowsInWholeView
          )
        {
            this.rowPerChunk = par_rowPerChunk;
            this.chunkRequired = par_chunkRequired;
            this.cardinalityOfRowsInWholeView = par_cardinalityOfRowsInWholeView;
            //
            this.setRowInfSup();
        }

        public PagingCalculator(
            int par_chunkRequired
            , double par_percentageOfViewPerChunk // eg. the chunk is desired to be the 16,32%(ViewRow cardinality)
            , int par_cardinalityOfRowsInWholeView
          )
        {
            this.rowPerChunk = (int)System.Math.Ceiling(par_percentageOfViewPerChunk * par_cardinalityOfRowsInWholeView);
            this.chunkRequired = par_chunkRequired;
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
            this.chunkRequired = par_chunkRequired;
            this.rowPerChunk = par_rowPerChunk;
            this.setRowInfSup();// update rowBoundaries (Inf, Sup).
        }// updateRequest


        public void setRowInfSup()
        {
            this.lastPage = (int)System.Math.Ceiling(((double)this.cardinalityOfRowsInWholeView / (double)this.rowPerChunk));
            this.rowInf = this.rowPerChunk * (this.chunkRequired - 1) + 1;// first row, after the last row of previous chunk.
            this.rowSup = this.rowInf + this.rowPerChunk - 1;//last row of the required chunk; i.e. the first one of the successive chunk minus one.
        }//setRowInfSup


        public void getRowInfSup(
            out int outParRowInf
            , out int outParRowSup
            , out int outParLastPage
            )
        {
            outParRowInf = this.rowInf;
            outParRowSup = this.rowSup;
            outParLastPage = this.lastPage;
        }//getRowInfSup

    }// class


}// nmsp
