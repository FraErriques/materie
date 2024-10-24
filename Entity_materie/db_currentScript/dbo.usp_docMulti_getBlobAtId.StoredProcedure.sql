USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_getBlobAtId]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_docMulti_getBlobAtId]
	@id_required_phase int
as
	-- returns a datatable of all columns, at id=@id_required_phase.
	select * from docMulti where id=@id_required_phase
	--ready
GO
