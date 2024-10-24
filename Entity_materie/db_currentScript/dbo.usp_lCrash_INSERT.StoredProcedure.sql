USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_lCrash_INSERT]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_lCrash_INSERT]
	@id int,
	@card int
as
	if @card is not null
	begin
		insert into [dbo].[lCrash](
			id,
			card
			) values(
				@id,
				@card
			)
	end
	else
	begin
		insert into [dbo].[lCrash](
			id
			) values(
				@id
				-- card defaults to zero
			)
	end
GO
