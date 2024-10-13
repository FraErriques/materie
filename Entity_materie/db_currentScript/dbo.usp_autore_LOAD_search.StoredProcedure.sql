USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_LOAD_search]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_autore_LOAD_search]
as
select
	dm.id as doc
	,aut.id as autore
	, aut.nominativo
	, dm.abstract
	, dm.insertion_time
from
	docMulti	dm
	, autore aut
where 
	abstract not like '_##__fake_abstract__##_'
	and dm.ref_autore_id = aut.id
order by
	insertion_time desc
GO
