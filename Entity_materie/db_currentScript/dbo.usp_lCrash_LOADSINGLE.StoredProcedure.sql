USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_lCrash_LOADSINGLE]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_lCrash_LOADSINGLE]
	@id int
as
	select card from lCrash
	where id=@id
GO
