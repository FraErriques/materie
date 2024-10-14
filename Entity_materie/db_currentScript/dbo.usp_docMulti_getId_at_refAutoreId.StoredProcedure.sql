USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_getId_at_refAutoreId]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_docMulti_getId_at_refAutoreId]
	@ref_autore_id int
as
select 
	dm.id 
	,mat.nomeMateria
	,dm.abstract
	,dm.sourceName
	,dm.insertion_time
from 
	docMulti dm
	, autore aut
	, materia_LOOKUP mat
where 
	ref_autore_id = @ref_autore_id
	and abstract not like '_##__fake_abstract__##_'
	and aut.id=dm.ref_autore_id
	and mat.id = dm.ref_materia_id 
GO
