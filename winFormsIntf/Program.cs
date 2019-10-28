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
        //public static System.Collections.Stack formStack = new System.Collections.Stack();



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
