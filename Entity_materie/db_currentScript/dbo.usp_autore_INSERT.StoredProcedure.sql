USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_INSERT]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_autore_INSERT]
	-- id
	@nominativo varchar(150)
	,@note text
as
insert into autore(
	-- id
	nominativo
	,note
)values(
	-- id
	@nominativo
	,@note
)
GO
