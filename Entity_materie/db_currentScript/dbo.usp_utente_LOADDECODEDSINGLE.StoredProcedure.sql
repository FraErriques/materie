USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_utente_LOADDECODEDSINGLE]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[usp_utente_LOADDECODEDSINGLE]
	@id int
as
	select
		username
	from utente
	where id=@id

GO
