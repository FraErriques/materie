USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_zPrototipo]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_zPrototipo]
as
 --esempio buono per l'estrazione documenti, fissata materia ed autore
 select 
	ROW_NUMBER()  OVER (order by doc.id asc) as count_record
	, doc.id            as Doc_Id
	,doc.abstract	  as Doc_abstract 
	,aut.nominativo	  as Autore_nominativo
	,mat.nomeMateria  as Materia
from 	
  materie.dbo.docMulti			doc
  ,materie.dbo.autore			aut
  ,materie.dbo.materia_LOOKUP	mat
where 
	doc.ref_autore_id = aut.id
	and doc.ref_materia_id = mat.id 
	and mat.id = 1
	and aut.id = 1
GO
