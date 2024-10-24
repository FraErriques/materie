USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_abstract_UPDATE]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_docMulti_abstract_UPDATE]
@id int,
@_abstract text
as
	update
		[docMulti]
	set
		[abstract]=@_abstract
	where id = @id
GO
