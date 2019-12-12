using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity_materie.Proxies
{


    public abstract class usp_ViewCacher_specific_CREATE_autOnMat_due_SERVICE
    {


        public static int usp_ViewCacher_specific_CREATE_autOnMat_due(
			string view_signature_uno,
			string view_signature_due		//
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
            cmd.CommandText = "usp_ViewCacher_specific_CREATE_autOnMat_due";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parview_signature_uno = new SqlParameter();
            parview_signature_uno.Direction = ParameterDirection.Input;
            parview_signature_uno.DbType = DbType.String;
            parview_signature_uno.ParameterName = "@view_signature_uno";
			cmd.Parameters.Add( parview_signature_uno);// add to command
			parview_signature_uno.Value = view_signature_uno;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			//
            System.Data.SqlClient.SqlParameter parview_signature_due = new SqlParameter();
            parview_signature_due.Direction = ParameterDirection.Input;
            parview_signature_due.DbType = DbType.String;
            parview_signature_due.ParameterName = "@view_signature_due";
			cmd.Parameters.Add( parview_signature_due);// add to command
			parview_signature_due.Value = view_signature_due;// checks ok -> ProxyParemeter value assigned to the SqlParameter.

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
                        "eccezione in DataAccess::usp_ViewCacher_specific_CREATE_autOnMat_due_SERVICE : " + ex.Message,
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
