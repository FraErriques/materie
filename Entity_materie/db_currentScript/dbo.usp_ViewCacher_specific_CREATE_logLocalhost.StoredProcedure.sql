USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_logLocalhost]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[usp_ViewCacher_specific_CREATE_logLocalhost]
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
	[Logging].[dbo].[materie_fatClientBeta11_dbFrechet] '
					
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
