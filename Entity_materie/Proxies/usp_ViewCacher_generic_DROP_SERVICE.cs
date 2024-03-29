using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity_materie.Proxies
{

    // NB. manually modified !
    public abstract class usp_ViewCacher_generic_DROP_SERVICE
    {


        // NB. manually modified ! Since it's called onAppDomainDrop, the dbHandles have already been dropped and the getConnection generally fails
        // on first call. Due this, the need to loop on the connectWithCustomSingleXpath(). In general it succeeds at the second loop. 
        // If called just once, the probability of not getting the connection is very high and so the Views remain on the database.
        public static SqlConnection getConnection()
        {
            System.Data.SqlClient.SqlConnection res = null;
            while (null == res)
            {
                res =
                    DbLayer.ConnectionManager.connectWithCustomSingleXpath(
                    "ProxyGeneratorConnections/strings",// compulsory xpath
                    "materie"
                );
            }
            return res;
        }// getConnection()


        // NB. manually modified !
        public static int usp_ViewCacher_generic_DROP(
			string view_signature		//
		)
		{
            //
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = getConnection();// NB. manually modified !
            if (null == cmd.Connection)
            {
                return -1;// no conn
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ViewCacher_generic_DROP";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parview_signature = new SqlParameter();
            parview_signature.Direction = ParameterDirection.Input;
            parview_signature.DbType = DbType.String;
            parview_signature.ParameterName = "@view_signature";
			cmd.Parameters.Add( parview_signature);// add to command
			parview_signature.Value = view_signature;// checks ok -> ProxyParemeter value assigned to the SqlParameter.

            //
            try
            {
				//
                int rowsWritten =
                    cmd.ExecuteNonQuery();
                //
                if (-1 == rowsWritten )
                    writingSucceeded = 0;// rows written ok : manually modified.
                else
                    writingSucceeded = 4;// errore logico senza exception
				// when the View is not droppable( i.e. already dropped or wrong signature,..etc) an Exception is thrown.
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
                        "eccezione in DataAccess::usp_ViewCacher_generic_DROP_SERVICE : " + ex.Message,
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
