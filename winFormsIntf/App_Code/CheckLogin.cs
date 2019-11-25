using System;
using System.Text;



namespace winFormsIntf.App_Code
{


    public static class CheckLogin
    {


        public static bool isLoggedIn()
        {
            bool res = false;// init to invalid
            Entity_materie.BusinessEntities.Permesso.Patente patente = null;
            //
            try
            {
                object patente_obj = Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"];
                if (null == patente_obj)
                {// strategy: close all forms in activeInstancesFormList and goTo a frmLogin, with Timbro disabled.
                    // Oss. frmError should not have a Timbro, but only a goLogin button, which closes all and does what said above.
                    // nevertheless it's possible to close frmError from the (x) upRight and keep the activeInstancesFormList.
                    Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"] =
                        "current useer is NOT logged in : ALLARM ! ";
                    res = false;
                }
                else
                {
                    patente =// throws possibly due to cast.
                        (Entity_materie.BusinessEntities.Permesso.Patente)patente_obj;
                    res = true;// if notNull and castOk -> user is validly LoggedIn.
                }
            }
            catch (System.Exception ex)
            {
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"] =
                    "current useer is NOT logged in : ALLARM ! " + ex.Message;
                res = false;
            }
            // ready.
            return res;
        }// isLoggedIn


        public static Entity_materie.BusinessEntities.Permesso.Patente getPatente()
        {
            Entity_materie.BusinessEntities.Permesso.Patente patente = null;// init to invalid
            //
            try
            {
                object patente_obj = Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["lasciapassare"];
                if (null == patente_obj)
                {// strategy: close all forms in activeInstancesFormList and goTo a frmLogin, with Timbro disabled.
                    // Oss. frmError should not have a Timbro, but only a goLogin button, which closes all and does what said above.
                    // nevertheless it's possible to close frmError from the (x) upRight and keep the activeInstancesFormList.
                    // ready to return patente , which has been init-ed to null.    
                }
                else // throws possibly due to cast.
                {// if notNull and castOk -> user is validly LoggedIn.
                    patente =
                        (Entity_materie.BusinessEntities.Permesso.Patente)patente_obj;
                }// if got here, the return value "patente" has been assigned.
            }
            catch (System.Exception ex)
            {
                Common.Template_Singleton.TSingletonNotIDispose<System.Collections.Hashtable>.instance()["errore"] =
                    "NO user is logged in : ALLARM ! " + ex.Message;
                patente = null;
            }
            // ready.
            return patente;
        }// getPatente


    }// class


}// nmsp
