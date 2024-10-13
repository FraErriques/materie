USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_chiaveDoppia_LOAD]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_chiaveDoppia_LOAD]
as
 -- first resultset
 select 
	mat.id
	,mat.nomeMateria
from materie.dbo.materia_LOOKUP mat
order by id
-- second resultset
select 
	aut.id
	,aut.nominativo
from materie.dbo.autore aut
order by id
GO
