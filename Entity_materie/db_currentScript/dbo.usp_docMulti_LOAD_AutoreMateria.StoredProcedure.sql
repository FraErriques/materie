USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_LOAD_AutoreMateria]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_docMulti_LOAD_AutoreMateria]  
-- NB. selezione documenti sulla chiave doppia( autore, materia)  
 @idAutore int
 ,@idMateria int
as
  select 
	dm.id
	,dm.abstract
	,dm.sourceName
 from
	materie.dbo.docMulti dm
	,materie.dbo.autore aut
	,materie.dbo.materia_LOOKUP mate
 where 
	dm.ref_materia_id = @idMateria --Analisi
	and dm.ref_autore_id = @idAutore --Galiieo
	and aut.id = @idAutore
	and mate.id = @idMateria
GO
