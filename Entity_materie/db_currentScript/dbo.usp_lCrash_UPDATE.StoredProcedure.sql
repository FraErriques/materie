USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_lCrash_UPDATE]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_lCrash_UPDATE]
	@id int,
	@card int
as
	update  [dbo].[lCrash]
		set card=@card
	where id=@id
GO
