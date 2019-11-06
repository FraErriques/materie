using System;
using System.Collections.Generic;
using System.Text;

namespace winFormsIntf
{

    public class windowWarehouse
    {
        public enum CurrentWindowType
        {
            // invalid
            Invalid = 0
            ///	effective opening modes
            ,frmAutoreLoad = 1
            ,frmDocumentoLoad = 2
            ,frmMateriaInsert = 3
            ,frmAutoreInsert = 4
            ,frmDocumentoInsert = 5
            ,frmError = 6
            ,frmLogin = 7
            ,frmLogViewer = 8
            ,frmPrimes = 9
            ,frmChangePwd = 10
            ,frmUpdateAbstract = 11
        }// enum
        private CurrentWindowType currentWindowType;
        private int thisTypeInstanceAccumulator;
        private int thisTypeInstanceLimit;// depends on typeof(currentWindowType)
        public enum openingMode
        {
            // invalid
            Invalid = 0,
            ///	effective opening modes
            // Non-exclusive_NotModal
            NotModal = 1,
            // Exclusive_Modal
            Modal = 2
        }// enum
        openingMode curWinOpeningMode;
        
        
        // Ctor()
        public windowWarehouse(CurrentWindowType currentType)
        {
            this.thisTypeInstanceAccumulator = 0;
            this.currentWindowType = currentType;
            //
            if( this.currentWindowType == CurrentWindowType.frmAutoreLoad )
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmDocumentoLoad )
            {
                this.thisTypeInstanceLimit = 5;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmMateriaInsert )
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmAutoreInsert )
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmDocumentoInsert )
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmError )
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmLogin )
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmLogViewer )
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmPrimes )
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmChangePwd )
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if ( this.currentWindowType == CurrentWindowType.frmUpdateAbstract )
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }// no cases remaining.
            else
            {
                throw new System.Exception(" A not-allowed type was passed to this factory.");
            }// else-if
        }// Ctor()


        public int checkCurrentTypeActualConsistency()
        {
            this.thisTypeInstanceAccumulator = default(int);
            //
            for (int c = 0; c < Program.formList.Count; c++)
            {
                if (null != Program.formList[c])
                {
                    string nomeDaArrayList = ((System.Windows.Forms.Form)(Program.formList[c])).GetType().ToString();
                    nomeDaArrayList = nomeDaArrayList.Remove(0, 13);// i.e. remove "winFormsIntf." from left
                    string nomeDaThisCurrentWindowType = this.currentWindowType.ToString();
                    if( nomeDaArrayList == nomeDaThisCurrentWindowType )
                    {
                        this.thisTypeInstanceAccumulator++;
                    }// else skip forms which do not correspond in type.
                }// skip null entries;  reset the index.
            }// for
            // ready
            return this.thisTypeInstanceAccumulator;
        }// checkCurrentTypeActualConsistency


        public bool canOpenAnotherOne()
        {
            this.checkCurrentTypeActualConsistency();// refresh the counter
            if (this.thisTypeInstanceAccumulator < this.thisTypeInstanceLimit)
            {
                return true;
            }// else..
            return false;
        }// canOpenAnotherOne

        public openingMode openingHowto()
        {
            return this.curWinOpeningMode;
        }// openingHowto

    }// class windowWarehouse


}// nmsp
