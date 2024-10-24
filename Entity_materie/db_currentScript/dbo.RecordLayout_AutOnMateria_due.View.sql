USE [materie]
GO
/****** Object:  View [dbo].[RecordLayout_AutOnMateria_due]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

				create view [dbo].[RecordLayout_AutOnMateria_due] as
					select
					ROW_NUMBER() OVER (
						order by
							viewBase.nomeAutore
						asc) AS RowNumber
					,viewBase.idAutore
					,viewBase.nomeAutore
					,viewBase.idMateria
					,viewBase.nomeMateria
					from materie.dbo.RecordLayout_AutOnMateria_uno viewBase
GO
