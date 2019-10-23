using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity_materie.Proxies
{


    public abstract class usp_ViewCacher_generic_LOAD_interval_SERVICE
    {


        public static System.Data.DataTable usp_ViewCacher_generic_LOAD_interval(
			Int32 min,
			Int32 max,
			string view_signature		//
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
                return null;// no conn
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ViewCacher_generic_LOAD_interval";
            //
            System.Data.DataTable resultset = new System.Data.DataTable("ResultSet");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;// bind adapter to the command.
			//
			//
            System.Data.SqlClient.SqlParameter parmin = new SqlParameter();
            parmin.Direction = ParameterDirection.Input;
            parmin.DbType = DbType.Int32;
            parmin.ParameterName = "@min";
			cmd.Parameters.Add( parmin);// add to command
			parmin.Value = min;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			//
            System.Data.SqlClient.SqlParameter parmax = new SqlParameter();
            parmax.Direction = ParameterDirection.Input;
            parmax.DbType = DbType.Int32;
            parmax.ParameterName = "@max";
			cmd.Parameters.Add( parmax);// add to command
			parmax.Value = max;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
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
                da.Fill(resultset);
				//
				//
            }
            catch (Exception ex)
            {
				//
				//
                resultset = null;
                //
                //---------------------exception nature discrimination----------------------
                // no integer map in the return value.
                LoggingToolsContainerNamespace.LoggingToolsContainer.DecideAndLog(
					ex,
					"eccezione in DataAccess::usp_ViewCacher_generic_LOAD_interval_SERVICE : " + ex.Message,
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
            return resultset;// one or more datatables.
        }// end service


    }// end class
}// end namespace
