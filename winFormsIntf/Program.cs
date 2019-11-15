﻿using System;
using System.Collections.Generic;

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
            //    ,frmPrototype = 12
            //}// enum



        /// <summary>
        /// The main entry point for the application. This class' static data will be used mostly as Singletons.
        /// NB. due to winForms characteristics, the entry point(i.e. Main) has to be "STAThread". Complex bugs
        /// come out when the MTAThread setting is used instead.
        /// </summary>
        [STAThread]
        static void Main()
        {// the first two instructions are required from the Framework, to be executed before the other ones.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //
            //--###############################--test area: put here some test, when the need is to execute them, instead of the actual Main().
            for (int c = 0; c < 200; c++)
            {
                Entity_materie.BusinessEntities.ViewDynamics.accessPoint("autore");
                string designedViewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;
                CacherDbView cacherInstance = new CacherDbView(
                    // no more  Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()
                     "" // where tail
                    , Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(designedViewName)
                    , new CacherDbView.SpecificViewBuilder(
                        Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
                        )
                     );
                //
                System.Threading.Thread.Sleep(9000);
            }
            //--#############################################################----------------------- END test area
            // the following statement both makes "new" of the HashTable "Sessione" and sets the "lasciapassare" to null.
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] = null;// not yet loggedIn
            //
            activeInstances = new windowWarehouse[12];// NB. update here ! TODO pass to a binary tree with ["names"] as indexes.
            activeInstances[0] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmAutoreLoad);// frmAutoreLoad
            activeInstances[1] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmDocumentoLoad);// frmDocumentoLoad
            activeInstances[2] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmMateriaInsert);// frmMateriaInsert
            activeInstances[3] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmAutoreInsert);// frmAutoreInsert
            activeInstances[4] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmDocumentoInsert);// frmDocumentoInsert
            activeInstances[5] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmError);// frmError
            activeInstances[6] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmLogin);// frmLogin
            activeInstances[7] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmLogViewer);// frmLogViewer
            activeInstances[8] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmPrimes);// frmPrimes
            activeInstances[9] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmChangePwd);// frmChangePwd
            activeInstances[10] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmUpdateAbstract);// UpdateAbstract
            activeInstances[11] = new windowWarehouse(windowWarehouse.CurrentWindowType.frmPrototype );//  Proto

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


# region cantina


//public static class Foo
//{
//    public static readonly DoViewDestruction Finalise;

//    static Foo()
//    {// One time only constructor. Cannot be called explicitly.
//        Finalise = new DoViewDestruction();
//    }


//    public static void accessPoint(string themeDecoration)
//    {
//        string theWholeName = themeDecoration;
//        theWholeName +=
//            DateTime.Now.Year.ToString()
//            + "|"
//            + DateTime.Now.Month.ToString()
//            + "|"
//            + DateTime.Now.Day.ToString()
//            + "#"
//            + DateTime.Now.Hour.ToString()
//            + ":"
//            + DateTime.Now.Minute.ToString()
//            + ":"
//            + DateTime.Now.Second.ToString()
//            + "#"
//            + DateTime.Now.Millisecond.ToString();
//        //
//        Finalise.addView(theWholeName);
//    }//


//    public sealed class DoViewDestruction
//    {// Destructor here is just a neme, to remember that it will be executed at the end of the static object (Foo) that holds it.
//        public System.Collections.ArrayList viewNames;
//        public string lastGeneratedView;

//        public DoViewDestruction(// in spite of its name, it's a Constructor().
//          )// in spite of its name, it's a Constructor().
//        {// Ctor()
//            if (null == this.viewNames)
//            {
//                this.viewNames = new System.Collections.ArrayList();// allocate the View name store.
//            }// else it's already been cnstructed.
//        }// Ctor()

//        public void addView(string viewName_par)
//        {
//            this.viewNames.Add(viewName_par);
//            this.lastGeneratedView = viewName_par;
//        }

//        ~DoViewDestruction()
//        {// One time only destructor. Use it to drop the application-db-Views.
//            for (int c = 0; c < this.viewNames.Count; c++)
//            {// delete view, generated by localhostApp.
//                Entity_materie.Proxies.usp_ViewCacher_generic_DROP_SERVICE.usp_ViewCacher_generic_DROP(
//                    Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(
//                        (string)(this.viewNames[c]) )
//                );
//            }
//        }// ~DoViewDestruction()
//    }// class DoViewDestruction

//}// class Foo


//class StaticClass 
//{
//   static StaticClass() {
//       AppDomain.CurrentDomain.ProcessExit +=
//           StaticClass_Dtor;
//   }

//   static void StaticClass_Dtor(object sender, EventArgs e) {
//        // clean it up
//   }
//}

//--##
//public static class Foo
//{
//    private static readonly Destructor Finalise = new Destructor();

//    static Foo()
//    {
//        // One time only constructor.
//    }

//    private sealed class Destructor
//    {
//        ~Destructor()
//        {
//            // One time only destructor.
//        }
//    }
//}// class Foo

# endregion cantina
