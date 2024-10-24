USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_LOAD]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_autore_LOAD]
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
		aut.id
		,aut.nominativo
		,aut.note
	from 
		autore aut
	'
+ @where_tail
exec( @code)
GO
