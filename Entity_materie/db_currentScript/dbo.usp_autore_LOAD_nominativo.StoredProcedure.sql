USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_LOAD_nominativo]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_autore_LOAD_nominativo]
	@id int
as
select 
	aut.nominativo
from 
	autore aut
where
	aut.id = @id
GO
