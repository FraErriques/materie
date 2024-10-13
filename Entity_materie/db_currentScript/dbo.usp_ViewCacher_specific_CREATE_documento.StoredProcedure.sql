USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_documento]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_ViewCacher_specific_CREATE_documento]
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
 		select 
			ROW_NUMBER() OVER (		order by
										mat.nomeMateria
										,aut.nominativo
										,dm.insertion_time
										desc) AS ''RowNumber''
			,dm.id				as id_Documento
			,mat.nomeMateria    as nome_Materia
			,aut.nominativo		as nome_Autore
			,dm.abstract		as note_Documento
			,CONVERT(varchar, dm.insertion_time, 23)  as data_Inserimento_Doc
			,dm.sourceName		as sourceName
		from 
			docMulti dm
			, autore aut
			, materia_LOOKUP mat
		where 
			abstract not like ''_##__fake_abstract__##_''
			and aut.id=dm.ref_autore_id
			and mat.id = dm.ref_materia_id  '
			+ @where_tail  -- ref_candidato_id = @ref_candidato_id
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready

GO
