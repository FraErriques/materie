USE [materie]
GO
/****** Object:  Table [dbo].[utente]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[utente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[kkey] [varchar](150) NULL,
	[mode] [char](1) NOT NULL,
	[ref_permissionLevel_id] [int] NOT NULL,
 CONSTRAINT [pk_utente_materie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[utente] ADD  DEFAULT ('o') FOR [mode]
GO
ALTER TABLE [dbo].[utente]  WITH CHECK ADD  CONSTRAINT [fk_utente_permesso] FOREIGN KEY([ref_permissionLevel_id])
REFERENCES [dbo].[permesso_LOOKUP] ([id])
GO
ALTER TABLE [dbo].[utente] CHECK CONSTRAINT [fk_utente_permesso]
GO
