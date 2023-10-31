using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleClassic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Data.DataTable dt =
                Entity_materie.Proxies.usp_utente_LOADSINGLE_SERVICE.usp_utente_LOADSINGLE("admin");
            string str_thePwd = null;
            string str_theKkey = null;
            string str_theMode = null;
            try
            {
                object thePwd = dt.Rows[0]["password"];
                object theKkey = dt.Rows[0]["kkey"];
                object theMode = dt.Rows[0]["mode"];
                str_thePwd = (string)thePwd;
                str_theKkey = (string)theKkey;
                str_theMode = (string)theMode;
                if ("m" != str_theMode)
                { throw new System.Exception("not in multiEcryption"); }
            }
            catch (System.Exception ex)
            {
                // we're assuming mode=='m'==multi
                System.Console.WriteLine(ex.Message);
            }

            string inChiaro =
                Common.CryptoStore.Callers.Decriptazione.DecriptazioneSequenza(
                    str_thePwd // sequenza
                    , str_theKkey // kkey
                    , str_theMode[0] // assuming mode=='multi'
                    );
            Console.WriteLine(inChiaro);
        }
    }
}

/* cantina
 * 
 * 
 *   esempio di update da tabella omologa. NB. necessaria specificazione completa degli insiemi dbName.role.tableName.fieldName
 update materie.dbo.utente
set 
	materie.dbo.utente.[password]=(select [password] from cv_db.dbo.utente where cv_db.dbo.utente.username='admin')
	,materie.dbo.utente.[kkey]=(select [kkey] from cv_db.dbo.utente where cv_db.dbo.utente.username='admin')
where materie.dbo.utente.[id]=2;

 */