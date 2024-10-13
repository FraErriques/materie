USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_autOnMat_due]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_ViewCacher_specific_CREATE_autOnMat_due]
	@view_signature_uno varchar(500)
	,@view_signature_due varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if 
				@view_signature_uno is NULL or Ltrim(Rtrim( @view_signature_uno))=''
				or @view_signature_due is NULL or Ltrim(Rtrim( @view_signature_due))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature_x --- must be BOTH specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				create view ' 
				+ Ltrim(Rtrim( @view_signature_due))
				+' as
					select
					ROW_NUMBER() OVER (
						order by
							viewBase.nomeAutore
						asc) AS RowNumber
					,viewBase.idAutore
					,viewBase.nomeAutore
					,viewBase.idMateria
					,viewBase.nomeMateria
					from materie.dbo.'
					+ Ltrim(Rtrim( @view_signature_uno))+' viewBase'
			-- ready.
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready
GO
