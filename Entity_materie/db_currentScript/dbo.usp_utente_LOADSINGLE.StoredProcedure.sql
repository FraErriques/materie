USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_utente_LOADSINGLE]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[usp_utente_LOADSINGLE]
	@username varchar(50)
as
	select
		*
	from utente
	where username=@username
GO
