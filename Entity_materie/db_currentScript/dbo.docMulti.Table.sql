USE [materie]
GO
/****** Object:  Table [dbo].[docMulti]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docMulti](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ref_job_id] [int] NOT NULL,
	[ref_autore_id] [int] NOT NULL,
	[ref_materia_id] [int] NOT NULL,
	[abstract] [text] NOT NULL,
	[sourceName] [varchar](550) NOT NULL,
	[doc] [image] NULL,
	[insertion_time] [datetime] NULL,
 CONSTRAINT [pk_docMulti] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[docMulti] ADD  DEFAULT ((0)) FOR [ref_job_id]
GO
ALTER TABLE [dbo].[docMulti] ADD  DEFAULT (getdate()) FOR [insertion_time]
GO
ALTER TABLE [dbo].[docMulti]  WITH CHECK ADD  CONSTRAINT [fk_docMulti_autore] FOREIGN KEY([ref_autore_id])
REFERENCES [dbo].[autore] ([id])
GO
ALTER TABLE [dbo].[docMulti] CHECK CONSTRAINT [fk_docMulti_autore]
GO
ALTER TABLE [dbo].[docMulti]  WITH CHECK ADD  CONSTRAINT [fk_docMulti_materia] FOREIGN KEY([ref_materia_id])
REFERENCES [dbo].[materia_LOOKUP] ([id])
GO
ALTER TABLE [dbo].[docMulti] CHECK CONSTRAINT [fk_docMulti_materia]
GO
