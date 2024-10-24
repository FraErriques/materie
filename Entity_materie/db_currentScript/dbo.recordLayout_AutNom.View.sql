USE [materie]
GO
/****** Object:  View [dbo].[recordLayout_AutNom]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

				create view [dbo].[recordLayout_AutNom] as
						SELECT
							ROW_NUMBER() OVER (ORDER BY aut.nominativo asc) AS 'RowNumber'
							,aut.id
							,aut.nominativo
							,aut.note
				from
					autore aut
				
GO
