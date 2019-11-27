﻿using System;


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

        public PagingCalculator( 
            int par_chunkRequired
            , int par_rowPerChunk
            , int par_cardinalityOfRowsInWholeView
          )
        {
            this.rowPerChunk = par_rowPerChunk;
            this.chunkRequired = par_chunkRequired;
            this.cardinalityOfRowsInWholeView = par_cardinalityOfRowsInWholeView;
        }


        public void setRowInfSup()
        {
            this.rowInf = this.rowPerChunk * (this.chunkRequired - 1) + 1;// first row, after the last row of previous chunk.
            this.rowSup = this.rowInf + this.rowPerChunk - 1;//last row of the required chunk; i.e. the first one of the successive chunk minus one.
            //int rowPerChunk = this.cardinalityOfRowsInWholeView
        }//

    }// class


}// nmsp
