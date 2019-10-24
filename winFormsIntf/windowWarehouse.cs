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
        private const int thisTypeInstanceLimit = 2;
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
        //
        public windowWarehouse(System.Windows.Forms.Form currentForm)
        {
            this.thisTypeInstanceAccumulator = 0;
            this.currentWindowType = currentForm.GetType();
        }// Ctor()

        public int checkCurrentTypeActualConsistency()
        {
            this.thisTypeInstanceAccumulator = default(int);
            //while (0 < Program.formStack.Count; )
            for (int c=Program.formStack.Count; c>0; c--)
            {
                System.Windows.Forms.Form tmpForm = (System.Windows.Forms.Form)(Program.formStack.Peek());// TODO peek always reads the stack-top. Change into an array.
                if (tmpForm.GetType() == this.currentWindowType)
                {
                    this.thisTypeInstanceAccumulator++;
                }// else skip forms which do not correspond in type.
            }// for 
            // ready
            return this.thisTypeInstanceAccumulator;
        }// checkCurrentTypeActualConsistency

    }// class windowWarehouse


}// nmsp
