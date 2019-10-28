using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winFormsIntf
{

    public class windowWarehouse
    {
        private Type currentWindowType;
        private int thisTypeInstanceAccumulator;
        private int thisTypeInstanceLimit;// depends on typeof(currentWindowType)
        private enum openingMode
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
        public windowWarehouse(System.Windows.Forms.Form currentForm)
        {
            this.thisTypeInstanceAccumulator = 0;
            this.currentWindowType = currentForm.GetType();
            //
            //if( currentForm.GetType() is  frmAutoreLoad )
            //
            if( this.currentWindowType == typeof( frmAutoreLoad) )
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if (currentForm.GetType() == typeof(frmDocumentoLoad ))
            {
                this.thisTypeInstanceLimit = 5;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if (currentForm.GetType() == typeof(frmMateriaInsert ))
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (currentForm.GetType() == typeof(frmAutoreInsert ))
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (currentForm.GetType() == typeof(frmDocumentoInsert ))
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (currentForm.GetType() == typeof(frmError ))
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (currentForm.GetType() == typeof(frmLogin ))
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (currentForm.GetType() == typeof(frmLogViewer ))
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if (currentForm.GetType() == typeof(frmPrimes ))
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if (currentForm.GetType() == typeof(frmChangePwd ))
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (currentForm.GetType() == typeof(frmUpdateAbstract ))
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }// no cases remaining.
        }// Ctor()


        public int checkCurrentTypeActualConsistency()
        {
            this.thisTypeInstanceAccumulator = default(int);
            //
            for (int c = 0; c < Program.formList.Count; c++)
            {
                if (null != Program.formList[c])
                {
                    if (((System.Windows.Forms.Form)(Program.formList[c])).GetType() == this.currentWindowType)
                    {
                        this.thisTypeInstanceAccumulator++;
                    }// else skip forms which do not correspond in type.
                }// skip null entries;  reset the index.
            }// for
            // ready
            return this.thisTypeInstanceAccumulator;
        }// checkCurrentTypeActualConsistency


    }// class windowWarehouse


}// nmsp
