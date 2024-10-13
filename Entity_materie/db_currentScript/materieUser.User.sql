USE [materie]
GO
/****** Object:  User [materieUser]    Script Date: 10/13/2024 8:13:14 PM ******/
CREATE USER [materieUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [materieUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [materieUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [materieUser]
GO
