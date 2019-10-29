using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace winFormsIntf
{





    static class Program
    {
        //public static System.Collections.Hashtable Session = null; both substituted by appropriate Singletons
        //public static System.Windows.Forms.Form firstBlood = null;
        public static System.Collections.ArrayList formList = new System.Collections.ArrayList();
        public static windowWarehouse[] activeInstances = null;
        //
            //public enum CurrentWindowType
            //{
            //    // invalid
            //    Invalid = 0
            //    ///	effective opening modes
            //    ,frmAutoreLoad = 1
            //    ,frmDocumentoLoad = 2
            //    ,frmMateriaInsert = 3
            //    ,frmAutoreInsert = 4
            //    ,frmDocumentoInsert = 5
            //    ,frmError = 6
            //    ,frmLogin = 7
            //    ,frmLogViewer = 8
            //    ,frmPrimes = 9
            //    ,frmChangePwd = 10
            //    ,frmUpdateAbstract = 11
            //}// enum



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {// the first two instructions are required from the Framework, to be executed before the other ones.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //
            // the following statement both makes "new" of the HashTable and sets the "lasciapassare" to null.
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] = null;// not yet loggedIn
            //
            activeInstances = new windowWarehouse[11];
            activeInstances[0] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmAutoreLoad);
            activeInstances[1] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmDocumentoLoad);
            activeInstances[2] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmMateriaInsert);
            activeInstances[3] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmAutoreInsert);// = 4
            activeInstances[4] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmDocumentoInsert);// = 5
            activeInstances[5] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmError);// = 6
            activeInstances[6] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmLogin);// = 7
            activeInstances[7] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmLogViewer);// = 8
            activeInstances[8] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmPrimes);// = 9
            activeInstances[9] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmChangePwd);// = 10
            activeInstances[10] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmUpdateAbstract);// = 11

            // try and locate the frmLogin.
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Left = 0;
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().Top = 0;
            Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance().DesktopLocation = new System.Drawing.Point( 0, 0);
            //// the actual Interface show-up time.
            Application.Run( Common.Template_Singleton.TSingleton<winFormsIntf.frmLogin>.instance() );// was firstBlood
            // this is the firstBlood variable, let Singleton.
        }// main


    }//class
}// nmsp
