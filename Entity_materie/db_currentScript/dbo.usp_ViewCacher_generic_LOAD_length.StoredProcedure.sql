USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_generic_LOAD_length]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewCacher_generic_LOAD_length]
@view_signature varchar(500)
as
declare @cmd varchar(1500)
select @cmd =
	'select count(*) from ' --NB. [] required around numeric-beginning names.
	+ @view_signature
exec( @cmd)

GO
