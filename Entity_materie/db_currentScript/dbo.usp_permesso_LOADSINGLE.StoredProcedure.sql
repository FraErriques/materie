USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_permesso_LOADSINGLE]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_permesso_LOADSINGLE]
	@username varchar(50)
as
-- datatable utente
select  	
	ut.id id_utente
	, ut.username username
	,p.permissionDescription  livelloAccesso
from 
	utente ut
	,permesso_LOOKUP p
where 
	ut.username =  @username
	and ut.ref_permissionLevel_id=p.id
GO
