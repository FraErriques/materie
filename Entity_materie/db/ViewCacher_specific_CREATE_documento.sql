USE [materie]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_materia_LOOKUP_LOAD]

SELECT	'Return Value' = @return_value

GO

select * from materie.dbo.autore
select * from materie.dbo.materia_LOOKUP
select * from materie.dbo.docMulti



--##
--USE [materie]
--GO

--/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_documento]    Script Date: 09/25/2019 13:17:23 ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--CREATE procedure [dbo].[usp_ViewCacher_specific_CREATE_documento]
--	@where_tail varchar(1500)
--	,@view_signature varchar(500)
--as
--declare @q varchar(7900)
--	begin transaction
--		begin try
--			if @where_tail is NULL
--			BEGIN
--				select @where_tail = ''
--			END -- else it's already a valid tail.
--			--
--			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
--			begin
--				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
--				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
--						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
--						   ,1 -- State.
--						   );
--			end--end if @view_signature is NULL else can continue.
---------------------------------------------------------------------------
--			select @q =
--			'
--				create view ' 
--				+ Ltrim(Rtrim( @view_signature))
--				+' as
-- 					select 
--						ROW_NUMBER() OVER (ORDER BY dm.sourceName asc) AS ''RowNumber''
--						,dm.id 
--						,mat.nomeMateria 
--						,dm.abstract
--						,dm.sourceName
--						,dm.insertion_time
--					from 
--						docMulti dm
--						, autore aut
--						, materia_LOOKUP mat
----						, settoreCandidatura_LOOKUP sett
--					where 
--						abstract not like ''_##__fake_abstract__##_''
--						and aut.id=dm.ref_autore_id
--						and mat.id = dm.ref_materia_id  '
--						+ @where_tail  -- ref_candidato_id = @ref_candidato_id
--			exec( @q )
--			-- if you get here, you can commit.
--			commit transaction
--	end try
--	begin catch
--		rollback transaction
--	end catch
--	-- ready
--GO
