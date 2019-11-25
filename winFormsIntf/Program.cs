using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;


namespace winFormsIntf
{



    static class Program
    {
        public static System.Collections.ArrayList activeInstancesFormList = new System.Collections.ArrayList();
        public static System.Collections.Hashtable frmTypeManagement = new System.Collections.Hashtable();

        
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

            // Application.Run(new frmChangePwd());// try without login : OK does not pass & then crashes due to unBuilt frmTypeManagement

            //// NO richiede fillUpTypeWareHouse() bool res = winFormsIntf.windowWarehouse.subscribeNewFrm(windowWarehouse.CurrentWindowType.frmError);
            //Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"] = "from Test-Area.";
            //(new winFormsIntf.frmError()).ShowDialog();
            ////(new winFormsIntf.frmError(new System.Exception("from Test-Area."))).ShowDialog();


            //--#############################################################----------------------- END test area
            // the following statement both makes "new" of the HashTable "Sessione" and sets the "lasciapassare" to null.
            Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"] = null;// not yet loggedIn
            winFormsIntf.windowWarehouse.fillUpTypeWareHouse();// the fixed-size tree of known form types. A window manager (i.e. windowWarehouse)
            // for each of the types. Such window manager accesses the instances 
            // NB. this Array of Types has fixed length at compile time. It cannot be mixed up with the array of instances,
            // whose length varies at runtime, due to the user behaviour.
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

////---test create & drop 40 Views --------------------------
//for (int c = 0; c < 40; c++)
//{
//    Entity_materie.BusinessEntities.ViewDynamics.accessPoint("autore");
//    string designedViewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;
//    winFormsIntf.CacherDbView cacherInstance = new winFormsIntf.CacherDbView(
//         "" // where tail
//        , Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(designedViewName)
//        , new CacherDbView.SpecificViewBuilder(
//            Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
//            )
//         );
//    //
//    System.Threading.Thread.Sleep(9000);
//}

//bool res =
//((winFormsIntf.windowWarehouse)
//    (bogo_activeInstances[winFormsIntf.windowWarehouse.CurrentWindowType.frmAutoreLoad.ToString()])).canOpenAnotherOne();

////Type t = typeof(String);
//Type t = typeof( winFormsIntf.frmError);
////System.Reflection.CallingConventions.
//ConstructorInfo[] frmErrorGetCtors = t.GetConstructor( ( BindingFlags.CreateInstance);
//    // ( "Substring",     new Type[] { typeof(int), typeof(int) });

//Object result =
//    frmErrorGetCtors[0].Invoke(new Object[] {"test from Reflection."} );
////.Invoke( ("Hello, World!", new Object[] { 7, 5 });
//System.Console.WriteLine( ((winFormsIntf.frmError)(result)).ShowDialog() );
//Console.WriteLine("{0} returned \"{1}\".", frmErrorGetCtors[0]);
/* This code example produces the following output:
    System.String Substring(Int32, Int32) returned "World".
*/

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
