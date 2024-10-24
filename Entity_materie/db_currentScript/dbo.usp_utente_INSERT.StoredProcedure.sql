USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_utente_INSERT]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[usp_utente_INSERT]
	@username				varchar(50),
	@password				varchar(50),
	@kkey					varchar(150),
	@mode					char(1),
	@ref_permissionLevel_id int
as
insert into utente(
--id
[username],
[password],
[kkey],
[mode],
[ref_permissionLevel_id]
       ) values(
--id
@username,
@password,
@kkey,
@mode,
@ref_permissionLevel_id
)
GO
