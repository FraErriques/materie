using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

//-----NB. manually modified. Necessary to reset mistake-counter 

namespace Entity_materie.Proxies
{


    public abstract class usp_lCrash_UPDATE_SERVICE
    {


        public static int usp_lCrash_UPDATE(
			Int32 id,
			Int32 card		//
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
            cmd.CommandText = "usp_lCrash_UPDATE";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parid = new SqlParameter();
            parid.Direction = ParameterDirection.Input;
            parid.DbType = DbType.Int32;
            parid.ParameterName = "@id";
			cmd.Parameters.Add( parid);// add to command
			if( 0<id )
			{
				parid.Value = id;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parid.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parcard = new SqlParameter();
            parcard.Direction = ParameterDirection.Input;
            parcard.DbType = DbType.Int32;
            parcard.ParameterName = "@card";
			cmd.Parameters.Add( parcard);// add to command
            if (0 <= card)//-----NB. manually modified. Necessary to reset mistake-counter on a right login (iff the counter was<=3).
            {// TODO do not forget the manual modification !  NB TODO replicate the manual modification, from SourceSafe, each time the Proxy is regenerated.
                parcard.Value = card;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
            }
            else// negative values forbidden anyway; they would constitute a credit on wrong logins.
            {
                parcard.Value = System.DBNull.Value;
            }


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
                        "eccezione in DataAccess::usp_lCrash_UPDATE_SERVICE : " + ex.Message,
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
