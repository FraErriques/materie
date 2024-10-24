USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_autOnMat_uno]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_ViewCacher_specific_CREATE_autOnMat_uno]
	@where_tail varchar(1500)
	,@view_signature varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if @where_tail is NULL
			BEGIN
				select @where_tail = ''
				-- NB. no condition whatsoever, iff @idMateria<0 (i.e. it means on all of the Subjects).
			END -- else it's already a valid tail, in the form:
			--and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
			--and mate.id=@idMateria
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
		select  distinct
			aut.id				as idAutore
			,aut.nominativo		as nomeAutore
			,mate.id			as idMateria
			,mate.nomeMateria   as nomeMateria
			-- ,aut.note  the "text" data type is not selectable as "distinct", because it is not comparable.
		from
			materie.dbo.docMulti dm
			,materie.dbo.autore aut
			,materie.dbo.materia_LOOKUP mate
		where
			dm.ref_autore_id=aut.id
			and dm.ref_materia_id=mate.id
			-- goes in whereTail and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
			-- goes in whereTail and mate.id=@idMateria
				 '
			+ @where_tail --goes in whereTail and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
							-- goes in whereTail and mate.id=@idMateria
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready
GO
