using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity_materie.Proxies
{


    public abstract class usp_ViewCacher_specific_CREATE_logLocalhost_SERVICE
    {


        public static int usp_ViewCacher_specific_CREATE_logLocalhost(
			string where_tail,
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
                return -1;// no conn
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ViewCacher_specific_CREATE_logLocalhost";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parwhere_tail = new SqlParameter();
            parwhere_tail.Direction = ParameterDirection.Input;
            parwhere_tail.DbType = DbType.String;
            parwhere_tail.ParameterName = "@where_tail";
			cmd.Parameters.Add( parwhere_tail);// add to command
			parwhere_tail.Value = where_tail;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
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
                        "eccezione in DataAccess::usp_ViewCacher_specific_CREATE_logLocalhost_SERVICE : " + ex.Message,
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


/*------------------------------cantina------------stored_proc_chiamata: NB c'e' un table_name da adeguare, in caso cambio-Log.
 * USE [materie]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[usp_ViewCacher_specific_CREATE_logLocalhost]
	@where_tail varchar(1500)
	,@view_signature varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if @where_tail is NULL
			BEGIN
				select @where_tail = ''
			END -- else it's already a valid tail.
			--
			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				create view ' 
				+ Ltrim(Rtrim( @view_signature))
				+' as
						SELECT TOP 1000
							ROW_NUMBER() OVER (ORDER BY [when] desc ) AS ''RowNumber''
	--[when] as full_timestamp,
	,substring([when], 1,4) as [anno],
	case
		when substring([when], 5,2)=1 then ''Gennaio''
		when substring([when], 5,2)=2 then ''Febbraio''
		when substring([when], 5,2)=3 then ''Marzo''
		when substring([when], 5,2)=4 then ''Aprile''
		when substring([when], 5,2)=5 then ''Maggio''
		when substring([when], 5,2)=6 then ''Giugno''
		when substring([when], 5,2)=7 then ''Luglio''
		when substring([when], 5,2)=8 then ''Agosto''
		when substring([when], 5,2)=9 then ''Settembre''
		when substring([when], 5,2)=10 then ''Ottobre''
		when substring([when], 5,2)=11 then ''Novembre''
		when substring([when], 5,2)=12 then ''Dicembre''
		else ''Invalid Month''
	end   as month_name,
	--substring([when], 5,2) as [mese], if you want month-ordinal instead of month-name.
	substring([when], 7,2) as [giorno],
	substring([when], 9,2)+'':''+substring([when], 11,2) as [ora_minuto],
	substring([when],13,2) as [secondo],
	function_name as procedure_called,
	content	as [message],
	-- campi tecnici per il debug su server
	row_nature,
	stack_depth
from
	[Logging].[dbo].[winForms_materie_Beta11] --NB. change table-name here.
	'
					
				+ @where_tail
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready
GO

 * 
 */