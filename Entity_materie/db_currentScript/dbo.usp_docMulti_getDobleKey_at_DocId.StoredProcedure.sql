USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_getDobleKey_at_DocId]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_docMulti_getDobleKey_at_DocId] 
	@DocId int
as
select 
ref_materia_id as idMateria
,ref_autore_id as idAutore
 from materie.dbo.docMulti doc
where
doc.id = @DocId 
GO
