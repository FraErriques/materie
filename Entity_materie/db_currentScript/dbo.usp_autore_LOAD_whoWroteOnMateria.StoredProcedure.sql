USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_LOAD_whoWroteOnMateria]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_autore_LOAD_whoWroteOnMateria]
	@idMateria int
as
	if @idMateria > 0
		begin
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
			and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
			and mate.id=@idMateria
		end
	else
		begin
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
			-- NB. no condition whatsoever, iff @idMateria<0 (i.e. it means on all of the Subjects).		
		end
GO
