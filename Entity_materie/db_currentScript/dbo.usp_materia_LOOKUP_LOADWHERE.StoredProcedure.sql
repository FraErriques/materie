USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_materia_LOOKUP_LOADWHERE]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE procedure [dbo].[usp_materia_LOOKUP_LOADWHERE]
@where_tail varchar(5500)
as
declare @code varchar(5500)
if @where_tail is NULL
BEGIN
	select @where_tail = ''
END -- else it's already a valid tail.
select @code =
	'
	select
		 *
	from 
		[dbo].[materia_LOOKUP]  
	'
+ @where_tail
+ ' order by nomeMateria   asc '
exec( @code)
GO
