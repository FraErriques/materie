USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_generic_LOAD_interval]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewCacher_generic_LOAD_interval]
@min int
,@max int
,@view_signature varchar(500)
as
declare @cmd varchar(5500)--NB. no error check. On wrong name, throws.
--
select @cmd = ' select * from '
+ @view_signature
+ ' where RowNumber between  '
+ str( @min)
+ ' and '
+ str( @max)
--
exec( @cmd)

GO
