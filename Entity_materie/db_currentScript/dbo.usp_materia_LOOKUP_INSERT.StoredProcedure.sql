USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_materia_LOOKUP_INSERT]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_materia_LOOKUP_INSERT]
@nomeMateria varchar(350)
as
insert into [materia_LOOKUP] (
-- id
nomeMateria
	) values(
@nomeMateria
)
GO
