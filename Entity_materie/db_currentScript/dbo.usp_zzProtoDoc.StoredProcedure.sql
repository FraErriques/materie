USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_zzProtoDoc]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure  [dbo].[usp_zzProtoDoc]
as
select 
doc.id as IdDoc
,aut.nominativo as nomeAutore
,mat.nomeMateria  nomeMateria
,doc.abstract as AbstractDoc
--,doc.sourceName as sourceName -- cut off in production environement
from
materie.dbo.docMulti		doc
,materie.dbo.autore			aut
,materie.dbo.materia_LOOKUP mat
where
	doc.ref_autore_id = aut.id
	and doc.ref_materia_id = mat.id
	and doc.abstract not like '%_##__fake_abstract__##_%'
	-- follows tail optional portion
	and doc.abstract like '%Costanzo%'
	and doc.ref_materia_id=5
GO
