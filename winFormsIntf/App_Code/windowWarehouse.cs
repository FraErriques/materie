using System;
using System.Collections.Generic;
using System.Text;

namespace winFormsIntf
{

    /// <summary>
    /// la classe contiene un'enumerazione dei tipi censiti ed il costruttore prende a parametro una voce di quella enumerazione.
    /// Tale richiesta mirata sul tipo, porta a conoscere le istanze consentite e la loro modalita' di esecuzione (i.e. Show xor ShowDialog).
    /// </summary>
    public class windowWarehouse
    {

        #region Data

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
            ,frmPrototype = 12
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
        
        #endregion Data        

        # region Services_public_static


        public static void fillUpTypeWareHouse()
        {// fill up the warehouse of form types.
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmAutoreLoad.ToString()//1
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmAutoreLoad)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmDocumentoLoad.ToString()//2
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmDocumentoLoad)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmMateriaInsert.ToString()//3
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmMateriaInsert)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmAutoreInsert.ToString()//4
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmAutoreInsert)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmDocumentoInsert.ToString()//5
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmDocumentoInsert)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmError.ToString()//6
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmError)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmLogin.ToString()//7
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmLogin)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmLogViewer.ToString()//8
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmLogViewer)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmPrimes.ToString()//9
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmPrimes)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmChangePwd.ToString()//10
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmChangePwd)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmUpdateAbstract.ToString()//11
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmUpdateAbstract)
            );
            Program.frmTypeManagement.Add(winFormsIntf.windowWarehouse.CurrentWindowType.frmPrototype.ToString()//12
                , new windowWarehouse(windowWarehouse.CurrentWindowType.frmPrototype)
            );
        }// fillUpTypeWareHouse


        /// <summary>
        /// a non static class can contain a static method; it's intended as a Type-wise service.
        /// </summary>
        /// <param name="curWinType"></param>
        /// <returns></returns>
        public static System.Windows.Forms.Form frmSelector(winFormsIntf.windowWarehouse.CurrentWindowType curWinType)
        {
            System.Windows.Forms.Form res = null;
            //
            if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmAutoreLoad)
            {
                res = new winFormsIntf.frmAutoreLoad();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmDocumentoLoad)
            {
                res = new winFormsIntf.frmDocumentoLoad();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmAutoreInsert)
            {
                res = new winFormsIntf.frmAutoreInsert();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmChangePwd)
            {
                res = new winFormsIntf.frmChangePwd();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmDocumentoInsert)
            {
                res = new winFormsIntf.frmDocumentoInsert();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmError)
            {// NB. who assigns Session["error"] ?
                res = new winFormsIntf.frmError();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmLogin)
            {
                // winFormsIntf.frmLogin is not included in the main cycle. It's instantiated not from menus.
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmLogViewer)
            {
                res = new winFormsIntf.frmLogViewer();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmMateriaInsert)
            {
                res = new winFormsIntf.frmMateriaInsert();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmPrimes)
            {
                res = new winFormsIntf.frmPrimes();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmPrototype)
            {
                res = new winFormsIntf.frmPrototype();
            }
            else if (curWinType == winFormsIntf.windowWarehouse.CurrentWindowType.frmUpdateAbstract)
            {
                res = new winFormsIntf.frmUpdateAbstract();
            }
            else // no more Types
            {
                // invalid request; res stays null.
            }
            // ready
            return res;
        }//


        // Type-wise service. It's the Type selection comb.
        // throws just on Debug occurences
        public static bool subscribeNewFrm(winFormsIntf.windowWarehouse.CurrentWindowType curWinType)
        {
            bool res = false; // init to invalid.
            // Debug when needed : System.Console.WriteLine(curWinType.ToString());
            if(
                ((winFormsIntf.windowWarehouse)
                (Program.frmTypeManagement[curWinType.ToString()])).canOpenAnotherOne() )
            {//pettine selezione Tipi;Type selection comb.
                Program.activeInstancesFormList.Add(winFormsIntf.windowWarehouse.frmSelector(curWinType));//pettine selezione Tipi;
                //pettine selezione Tipi;Type selection comb.
                winFormsIntf.windowWarehouse.openingMode currentFrmOpeningMode =
                ((winFormsIntf.windowWarehouse)(Program.frmTypeManagement[curWinType.ToString()])). // NB. the method call is next line.
                        openingHowto();// get if the opening mode is Modal or not.
                if( currentFrmOpeningMode == windowWarehouse.openingMode.Modal)
                {// show the last born.
                    ((System.Windows.Forms.Form)(Program.activeInstancesFormList[Program.activeInstancesFormList.Count - 1])).ShowDialog();
                    res = true;
                }
                else if( currentFrmOpeningMode == windowWarehouse.openingMode.NotModal)// NB change here #
                {// show the last born.
                    ((System.Windows.Forms.Form)(Program.activeInstancesFormList[Program.activeInstancesFormList.Count - 1])).Show();
                    res = true;
                }
                else
                {// it's a Debug Exception. It should never occurr.
                    throw new System.Exception(" Invalid opening mode.");
                }
            }// if can open another win
            else
            {
                res = false;
                //System.Windows.Forms.MessageBox
                System.Windows.Forms.MessageBox.Show(
                    ((System.Windows.Forms.Form)(Program.activeInstancesFormList[Program.activeInstancesFormList.Count - 1]))
                    ," No more instances of type "
                    + curWinType.ToString()
                    + " available. Close something of this type."
                    , "Win Cardinality"
                 );
            }// else can open no more win
            // ready
            return res;
        }// subscribeNewFrm


        public static void emptyWinList()
        {
            for (int c = Program.activeInstancesFormList.Count; c > 0; c--)
            {
                if (null != Program.activeInstancesFormList[c - 1])
                {
                    ((System.Windows.Forms.Form)(Program.activeInstancesFormList[c - 1])).Dispose();
                    Program.activeInstancesFormList[c - 1] = null;//gc
                    Program.activeInstancesFormList.RemoveAt(c - 1);// remove the empty slot
                }// skip null entries; pass to a fixed-size_Array end reset the index.
            }
        }// emptyWinList()


        public static void removeSpecifiedWin(System.Windows.Forms.Form parFrm)
        {
            for (int c = Program.activeInstancesFormList.Count; c > 0; c--)
            {
                if (null != Program.activeInstancesFormList[c - 1])
                {
                    if (parFrm == (System.Windows.Forms.Form)(Program.activeInstancesFormList[c - 1]))
                    {
                        ((System.Windows.Forms.Form)(Program.activeInstancesFormList[c - 1])).Dispose();
                        Program.activeInstancesFormList[c - 1] = null;//gc
                        Program.activeInstancesFormList.RemoveAt(c - 1);// remove the empty slot
                    }
                }// skip null entries; pass to a fixed-size_Array end reset the index.
            }
        }// removeSpecifiedWin()


        # endregion Services_public_static

        #region Instance_methods


        // Ctor()
        public windowWarehouse(CurrentWindowType currentType)
        {
            this.thisTypeInstanceAccumulator = 0;
            this.currentWindowType = currentType;
            //
            if (this.currentWindowType == CurrentWindowType.frmAutoreLoad)
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmDocumentoLoad)
            {
                this.thisTypeInstanceLimit = 5;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmMateriaInsert)
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmAutoreInsert)
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmDocumentoInsert)
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmError)
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmLogin)
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmLogViewer)
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmPrimes)
            {
                this.thisTypeInstanceLimit = 2;
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmChangePwd)
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmUpdateAbstract)
            {
                this.thisTypeInstanceLimit = 1;
                this.curWinOpeningMode = windowWarehouse.openingMode.Modal;
            }
            else if (this.currentWindowType == CurrentWindowType.frmPrototype)
            {
                this.thisTypeInstanceLimit = 99;// it's a raw deal with prototypes :-)
                this.curWinOpeningMode = windowWarehouse.openingMode.NotModal;
            }// no cases remaining.
            else
            {
                throw new System.Exception(" A not-allowed type was passed to this factory.");
            }// else-if
        }// Ctor()


        // count for the cardinality of this.Type.
        public int checkCurrentTypeActualConsistency()
        {
            this.thisTypeInstanceAccumulator = default(int);
            //
            for (int c = 0; c < Program.activeInstancesFormList.Count; c++)
            {
                if (null != Program.activeInstancesFormList[c])
                {
                    string nomeDaArrayList = ((System.Windows.Forms.Form)(Program.activeInstancesFormList[c])).GetType().ToString();
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


        // check if the currentType==this.Type can accept yet another instance.
        public bool canOpenAnotherOne()
        {
            this.checkCurrentTypeActualConsistency();// refresh the counter
            if (this.thisTypeInstanceAccumulator < this.thisTypeInstanceLimit)
            {
                return true;
            }// else..
            return false;
        }// canOpenAnotherOne


        // check whether this.Type has to opened Modal or not( i.e. ShorDialogue() or Show() ).
        public openingMode openingHowto()
        {
            return this.curWinOpeningMode;
        }// openingHowto

        #endregion Instance_methods

    }// class windowWarehouse


}// nmsp
