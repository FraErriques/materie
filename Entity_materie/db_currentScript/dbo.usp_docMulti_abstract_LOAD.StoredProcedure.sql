USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_abstract_LOAD]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_docMulti_abstract_LOAD]
@id int
as
select
	[abstract]
from
	[docMulti]
where id = @id
GO
