USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewGetChunk]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewGetChunk]
@view_signature varchar(350)
,@rowInf int
,@rowSup int
as
declare @q varchar(7900)
	begin transaction
		begin try
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
				select * from ' 
				+ Ltrim(Rtrim( @view_signature))
				+' where RowNumber between ' + CAST(@rowInf AS nvarchar(40)) 
				+' and ' + CAST(@rowSup AS nvarchar(40)) 
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready
GO
