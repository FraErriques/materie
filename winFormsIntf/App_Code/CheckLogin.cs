using System;
using System.Text;



namespace winFormsIntf
{

    public static class CheckLogin
    {

        public static bool isLoggedIn(Entity_materie.BusinessEntities.Permesso.Patente parPatente)
        {
            bool res = false;// init to invalid
            if (null == parPatente)
            {
                return res;// not logged in
            }
            else
            {
                res = true;// is Logged
            }
            return res;
        }// isLoggedIn


    }// class


}// nmsp
