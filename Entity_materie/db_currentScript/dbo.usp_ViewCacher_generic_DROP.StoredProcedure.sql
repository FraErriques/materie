USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_generic_DROP]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewCacher_generic_DROP]
@view_signature varchar(500)
as
declare @cmd varchar(5500)--NB. no error check. On wrong name, throws.
select @cmd = ' drop view ' + @view_signature
exec( @cmd)

GO
