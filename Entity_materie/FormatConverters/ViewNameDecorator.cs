using System;
using System.Data;
using System.Configuration;


namespace Entity_materie.FormatConverters
{


    /// <summary>
    /// ViewNameDecorator puts square brackets around the viewName parameter.
    /// The database requires square brachets [] around the viewName.
    /// But the actual name on the db is without brackets.
    /// </summary>
    public static class ViewNameDecorator_SERVICE
    {


        public static string ViewNameDecorator(string viewName)
        {
            string res = "[";
            res += viewName;
            res += "]";
            return res;
        }// end SERVICE.


    }// end class

}// nmsp
