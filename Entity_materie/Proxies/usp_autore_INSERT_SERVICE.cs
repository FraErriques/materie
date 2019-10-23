using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity_materie.Proxies
{


    public abstract class usp_autore_INSERT_SERVICE
    {


        public static int usp_autore_INSERT(
			string nominativo,
			string note,
			System.Data.SqlClient.SqlTransaction trx		//
		)
		{
            //
            SqlCommand cmd = new SqlCommand();
            if (null == trx)
            {
				cmd.Connection =
					DbLayer.ConnectionManager.connectWithCustomSingleXpath(
						"ProxyGeneratorConnections/strings",// compulsory xpath
						"materie"
					);
            }
            else
            {
                cmd.Connection = trx.Connection;
                cmd.Transaction = trx;
            }            
            if( null==cmd.Connection)
                return -1;// no conn
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_autore_INSERT";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parnominativo = new SqlParameter();
            parnominativo.Direction = ParameterDirection.Input;
            parnominativo.DbType = DbType.String;
            parnominativo.ParameterName = "@nominativo";
			cmd.Parameters.Add( parnominativo);// add to command
			parnominativo.Value = nominativo;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			//
            System.Data.SqlClient.SqlParameter parnote = new SqlParameter();
            parnote.Direction = ParameterDirection.Input;
            parnote.DbType = DbType.String;
            parnote.ParameterName = "@note";
			cmd.Parameters.Add( parnote);// add to command
			parnote.Value = note;// checks ok -> ProxyParemeter value assigned to the SqlParameter.

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
                        "eccezione in DataAccess::usp_autore_INSERT_SERVICE : " + ex.Message,
						0 // verbosity
                );
                //
            }// end catch
            finally
            {
				if( null == trx)
				{
					if (null != cmd.Connection)
						if (System.Data.ConnectionState.Open == cmd.Connection.State)
							cmd.Connection.Close();
                }// else preserve transaction
            }
            // ready
            return writingSucceeded;// writing result is an integer.
        }// end service


    }// end class
}// end namespace
