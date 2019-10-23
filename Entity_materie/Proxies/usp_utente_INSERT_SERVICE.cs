using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity_materie.Proxies
{


    public abstract class usp_utente_INSERT_SERVICE
    {


        public static int usp_utente_INSERT(
			string username,
			string password,
			string kkey,
			string mode,
			Int32 ref_permissionLevel_id		//
		)
		{
            //
            SqlCommand cmd = new SqlCommand();
			cmd.Connection =
				DbLayer.ConnectionManager.connectWithCustomSingleXpath(
					"ProxyGeneratorConnections/strings",// compulsory xpath
					"materie"
				);
            if( null==cmd.Connection)
                return -1;// no conn
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_utente_INSERT";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parusername = new SqlParameter();
            parusername.Direction = ParameterDirection.Input;
            parusername.DbType = DbType.String;
            parusername.ParameterName = "@username";
			cmd.Parameters.Add( parusername);// add to command
			parusername.Value = username;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			//
            System.Data.SqlClient.SqlParameter parpassword = new SqlParameter();
            parpassword.Direction = ParameterDirection.Input;
            parpassword.DbType = DbType.String;
            parpassword.ParameterName = "@password";
			cmd.Parameters.Add( parpassword);// add to command
			parpassword.Value = password;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			//
            System.Data.SqlClient.SqlParameter parkkey = new SqlParameter();
            parkkey.Direction = ParameterDirection.Input;
            parkkey.DbType = DbType.String;
            parkkey.ParameterName = "@kkey";
			cmd.Parameters.Add( parkkey);// add to command
			parkkey.Value = kkey;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			//
            System.Data.SqlClient.SqlParameter parmode = new SqlParameter();
            parmode.Direction = ParameterDirection.Input;
            parmode.DbType = DbType.String;
            parmode.ParameterName = "@mode";
			cmd.Parameters.Add( parmode);// add to command
			parmode.Value = mode;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			//
            System.Data.SqlClient.SqlParameter parref_permissionLevel_id = new SqlParameter();
            parref_permissionLevel_id.Direction = ParameterDirection.Input;
            parref_permissionLevel_id.DbType = DbType.Int32;
            parref_permissionLevel_id.ParameterName = "@ref_permissionLevel_id";
			cmd.Parameters.Add( parref_permissionLevel_id);// add to command
			parref_permissionLevel_id.Value = ref_permissionLevel_id;// checks ok -> ProxyParemeter value assigned to the SqlParameter.

            //
            try
            {
				//
                int rowsWritten =
                    cmd.ExecuteNonQuery();
                //
                if (1 <= rowsWritten )
                    writingSucceeded = 0;// rows written ok
                else
                    writingSucceeded = 4;// errore logico senza exception
				//
				//
            }
            catch (Exception ex)
            {
				//
				//
				/// <returns>
				/// -1  no connection
				/// 0   ok
				/// 1   sqlException chiave duplicata
				/// 2   sqlException diversa da chiave duplicata
				/// 3   eccezione NON sql
				/// 4   errore logico senza Exception
				/// ...
				/// >4  altre eccezioni TODO:dettagliare in fututo
				/// 
				/// </returns>
                //
                //---------------------exception nature discrimination----------------------
                writingSucceeded =
                    LoggingToolsContainerNamespace.LoggingToolsContainer.DecideAndLog(
                        ex,
                        "eccezione in DataAccess::usp_utente_INSERT_SERVICE : " + ex.Message,
						0 // verbosity
                );
                //
            }// end catch
            finally
            {
				if (null != cmd.Connection)
					if (System.Data.ConnectionState.Open == cmd.Connection.State)
						cmd.Connection.Close();
            }
            // ready
            return writingSucceeded;// writing result is an integer.
        }// end service


    }// end class
}// end namespace
