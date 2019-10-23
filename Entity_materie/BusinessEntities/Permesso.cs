using System;
using Entity_materie.Proxies;


namespace Entity_materie.BusinessEntities
{


    public class Permesso
    {



        /// <summary>
        /// ad hoc class, for the return value of GetPatente.
        /// It will be held in Session; so better a nested class, without method pointers
        /// that are wasted memory in Session.
        /// </summary>
        public class Patente
        {
            public int id_username;
            public string username;
            //
            public string livelloAccesso;
        }//
        //
        // an instance of the nested class.
        Patente patente = null;



        #region Ctors
        //


        public Permesso()// an empty ctor is needed for the LOADMULTI.
        { }



        public Permesso(
            string username
            )
        {
            this.patente = new Patente();
            this.patente.username = username;
        }

        public Permesso(
            int id_utente,
            string username,
            int id_permissionLevel
            )
        {
            this.patente = new Patente();
            this.patente.id_username = id_utente;
            this.patente.username = username;
            //
            // this.patente.permissionLevel = TODO
        }

 
        //
        #endregion Ctors




        /// <summary>
        /// requires valorization of this.username.
        /// // returns {int_theLevel, string_AreaAziendale}, filling the members.
        /// </summary>
        public Patente GetPatente()
        {
            Patente result = new Patente();// a brand new copy of "Patente" will be returned.
            //
            System.Data.DataTable dt =
                Entity_materie.Proxies.usp_permesso_LOADSINGLE_SERVICE.usp_permesso_LOADSINGLE(
                    this.patente.username
                );
            // all in try-catch; nullity of anything is trapped this way.
            try //---table 1
            {
                result.id_username = (Int32)dt.Rows[0].ItemArray[0];
                result.username = (string)dt.Rows[0].ItemArray[1];
                result.livelloAccesso = (string)dt.Rows[0].ItemArray[2];
            }
            catch (System.Exception)
            {
                result.id_username = 0;
                result.username = "utente not found";
            }
            //
            // ready
            return result;
        }//




    }// end class


}// end nmsp
