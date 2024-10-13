USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_note_UPDATE]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_autore_note_UPDATE]
@id int,
@note text
as
	update
		[autore]
	set
		[note]=@note
	where id = @id
GO
