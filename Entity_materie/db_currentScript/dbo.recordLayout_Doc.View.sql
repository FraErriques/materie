USE [materie]
GO
/****** Object:  View [dbo].[recordLayout_Doc]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

				create view [dbo].[recordLayout_Doc] as
 		select 
			ROW_NUMBER() OVER (		order by
										mat.nomeMateria
										,aut.nominativo
										,dm.insertion_time
										desc) AS 'RowNumber'
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
			abstract not like '_##__fake_abstract__##_'
			and aut.id=dm.ref_autore_id
			and mat.id = dm.ref_materia_id  
GO
