USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_materia_LOOKUP_LOAD]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE procedure [dbo].[usp_materia_LOOKUP_LOAD]
as
select * from [dbo].[materia_LOOKUP]
order by nomeMateria   asc
GO
