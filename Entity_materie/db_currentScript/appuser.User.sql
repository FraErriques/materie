USE [materie]
GO
/****** Object:  User [appuser]    Script Date: 10/13/2024 8:13:14 PM ******/
CREATE USER [appuser] FOR LOGIN [appuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [appuser]
GO
