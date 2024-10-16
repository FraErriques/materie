USE [materie]
GO
/****** Object:  User [appuser]    Script Date: 10/13/2024 8:26:01 PM ******/
CREATE USER [appuser] FOR LOGIN [appuser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [materieUser]    Script Date: 10/13/2024 8:26:01 PM ******/
CREATE USER [materieUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [appuser]
GO
ALTER ROLE [db_owner] ADD MEMBER [materieUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [materieUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [materieUser]
GO
/****** Object:  Table [dbo].[autore]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autore](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nominativo] [varchar](150) NOT NULL,
	[note] [text] NULL,
 CONSTRAINT [pk_autore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [autore_unique] UNIQUE NONCLUSTERED 
(
	[nominativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[recordLayout_AutNom]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

				create view [dbo].[recordLayout_AutNom] as
						SELECT
							ROW_NUMBER() OVER (ORDER BY aut.nominativo asc) AS 'RowNumber'
							,aut.id
							,aut.nominativo
							,aut.note
				from
					autore aut
				
GO
/****** Object:  Table [dbo].[materia_LOOKUP]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materia_LOOKUP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nomeMateria] [varchar](350) NOT NULL,
 CONSTRAINT [pk_materia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [materia_unique] UNIQUE NONCLUSTERED 
(
	[nomeMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docMulti]    Script Date: 10/13/2024 8:26:02 PM ******/
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
/****** Object:  View [dbo].[recordLayout_Doc]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

				create view [dbo].[recordLayout_Doc] as
 		select 
			ROW_NUMBER() OVER (		order by
										mat.nomeMateria
										,aut.nominativo
										,dm.insertion_time
										desc) AS 'RowNumber'
			,dm.id				as id_Documento
			,mat.nomeMateria    as nome_Materia
			,aut.nominativo		as nome_Autore
			,dm.abstract		as note_Documento
			,CONVERT(varchar, dm.insertion_time, 23)  as data_Inserimento_Doc
			,dm.sourceName		as sourceName
		from 
			docMulti dm
			, autore aut
			, materia_LOOKUP mat
		where 
			abstract not like '_##__fake_abstract__##_'
			and aut.id=dm.ref_autore_id
			and mat.id = dm.ref_materia_id  
GO
/****** Object:  View [dbo].[RecordLayout_AutOnMateria_due]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

				create view [dbo].[RecordLayout_AutOnMateria_due] as
					select
					ROW_NUMBER() OVER (
						order by
							viewBase.nomeAutore
						asc) AS RowNumber
					,viewBase.idAutore
					,viewBase.nomeAutore
					,viewBase.idMateria
					,viewBase.nomeMateria
					from materie.dbo.RecordLayout_AutOnMateria_uno viewBase
GO
/****** Object:  Table [dbo].[lCrash]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lCrash](
	[id] [int] NOT NULL,
	[card] [int] NOT NULL,
 CONSTRAINT [pk_lCrash] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permesso_LOOKUP]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permesso_LOOKUP](
	[id] [int] NOT NULL,
	[permissionDescription] [varchar](60) NOT NULL,
 CONSTRAINT [pk_permesso_LOOKUP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[utente]    Script Date: 10/13/2024 8:26:02 PM ******/
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
ALTER TABLE [dbo].[docMulti] ADD  DEFAULT ((0)) FOR [ref_job_id]
GO
ALTER TABLE [dbo].[docMulti] ADD  DEFAULT (getdate()) FOR [insertion_time]
GO
ALTER TABLE [dbo].[lCrash] ADD  DEFAULT ((0)) FOR [card]
GO
ALTER TABLE [dbo].[utente] ADD  DEFAULT ('o') FOR [mode]
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
ALTER TABLE [dbo].[lCrash]  WITH CHECK ADD  CONSTRAINT [fk_lCrash] FOREIGN KEY([id])
REFERENCES [dbo].[utente] ([id])
GO
ALTER TABLE [dbo].[lCrash] CHECK CONSTRAINT [fk_lCrash]
GO
ALTER TABLE [dbo].[utente]  WITH CHECK ADD  CONSTRAINT [fk_utente_permesso] FOREIGN KEY([ref_permissionLevel_id])
REFERENCES [dbo].[permesso_LOOKUP] ([id])
GO
ALTER TABLE [dbo].[utente] CHECK CONSTRAINT [fk_utente_permesso]
GO
/****** Object:  StoredProcedure [dbo].[LogViewer_web_materie]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[LogViewer_web_materie]
	@startDate varchar(14),
	@endDate varchar(14)
as
select
	--[when] as full_timestamp,
	substring([when], 1,4) as [anno],
	case
		when substring([when], 5,2)=1 then 'Gennaio'
		when substring([when], 5,2)=2 then 'Febbraio'
		when substring([when], 5,2)=3 then 'Marzo'
		when substring([when], 5,2)=4 then 'Aprile'
		when substring([when], 5,2)=5 then 'Maggio'
		when substring([when], 5,2)=6 then 'Giugno'
		when substring([when], 5,2)=7 then 'Luglio'
		when substring([when], 5,2)=8 then 'Agosto'
		when substring([when], 5,2)=9 then 'Settembre'
		when substring([when], 5,2)=10 then 'Ottobre'
		when substring([when], 5,2)=11 then 'Novembre'
		when substring([when], 5,2)=12 then 'Dicembre'
		else 'Invalid Month'
	end   as month_name,
	--substring([when], 5,2) as [mese], if you want month-ordinal instead of month-name.
	substring([when], 7,2) as [giorno],
	substring([when], 9,2)+':'+substring([when], 11,2) as [ora_minuto],
	substring([when],13,2) as [secondo],
	function_name as procedure_called,
	content	as [message],
	-- campi tecnici per il debug su server
	row_nature,
	stack_depth
from
	[Logging].[dbo].[materie_webBeta11_dbFrechet]--hard to let it a parameter; the whole query should become a string of dynamic sql.
where 
	convert(datetime,substring([when],1,8))>=convert(datetime,@startDate)
	and convert(datetime,substring([when],1,8))<=convert(datetime,@endDate)
	--and row_nature='t'
order by [when] desc
GO
/****** Object:  StoredProcedure [dbo].[LogViewer_win_materie]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[LogViewer_win_materie]
	@startDate varchar(14),
	@endDate varchar(14)
as
select
	--[when] as full_timestamp,
	substring([when], 1,4) as [anno],
	case
		when substring([when], 5,2)=1 then 'Gennaio'
		when substring([when], 5,2)=2 then 'Febbraio'
		when substring([when], 5,2)=3 then 'Marzo'
		when substring([when], 5,2)=4 then 'Aprile'
		when substring([when], 5,2)=5 then 'Maggio'
		when substring([when], 5,2)=6 then 'Giugno'
		when substring([when], 5,2)=7 then 'Luglio'
		when substring([when], 5,2)=8 then 'Agosto'
		when substring([when], 5,2)=9 then 'Settembre'
		when substring([when], 5,2)=10 then 'Ottobre'
		when substring([when], 5,2)=11 then 'Novembre'
		when substring([when], 5,2)=12 then 'Dicembre'
		else 'Invalid Month'
	end   as month_name,
	--substring([when], 5,2) as [mese], if you want month-ordinal instead of month-name.
	substring([when], 7,2) as [giorno],
	substring([when], 9,2)+':'+substring([when], 11,2) as [ora_minuto],
	substring([when],13,2) as [secondo],
	function_name as procedure_called,
	content	as [message],
	-- campi tecnici per il debug su server
	row_nature,
	stack_depth
from
	[Logging].[dbo].[materie_fatClientBeta11_dbFrechet] --hard to let it a parameter; the whole query should become a string of dynamic sql.
where 
	convert(datetime,substring([when],1,8))>=convert(datetime,@startDate)
	and convert(datetime,substring([when],1,8))<=convert(datetime,@endDate)
	--and row_nature='t'
order by [when] desc

GO
/****** Object:  StoredProcedure [dbo].[usp_autore_INSERT]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_autore_INSERT]
	-- id
	@nominativo varchar(150)
	,@note text
as
insert into autore(
	-- id
	nominativo
	,note
)values(
	-- id
	@nominativo
	,@note
)
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_LOAD]    Script Date: 10/13/2024 8:26:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_autore_LOAD_nominativo]    Script Date: 10/13/2024 8:26:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_autore_LOAD_search]    Script Date: 10/13/2024 8:26:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_autore_LOAD_whoWroteOnMateria]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_autore_LOAD_whoWroteOnMateria]
	@idMateria int
as
	if @idMateria > 0
		begin
			select  distinct
			aut.id				as idAutore
			,aut.nominativo		as nomeAutore
			,mate.id			as idMateria
			,mate.nomeMateria   as nomeMateria
			-- ,aut.note  the "text" data type is not selectable as "distinct", because it is not comparable.
			from
			materie.dbo.docMulti dm
			,materie.dbo.autore aut
			,materie.dbo.materia_LOOKUP mate
			where 
			dm.ref_autore_id=aut.id
			and dm.ref_materia_id=mate.id
			and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
			and mate.id=@idMateria
		end
	else
		begin
			select  distinct
			aut.id				as idAutore
			,aut.nominativo		as nomeAutore
			,mate.id			as idMateria
			,mate.nomeMateria   as nomeMateria
			-- ,aut.note  the "text" data type is not selectable as "distinct", because it is not comparable.
			from
			materie.dbo.docMulti dm
			,materie.dbo.autore aut
			,materie.dbo.materia_LOOKUP mate
			where 
			dm.ref_autore_id=aut.id
			and dm.ref_materia_id=mate.id
			-- NB. no condition whatsoever, iff @idMateria<0 (i.e. it means on all of the Subjects).		
		end
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_note_LOAD]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_autore_note_LOAD]
@id int
as
select
	[note]
from
	autore
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[usp_autore_note_UPDATE]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_autore_note_UPDATE]
@id int,
@note text
as
	update
		[autore]
	set
		[note]=@note
	where id = @id
GO
/****** Object:  StoredProcedure [dbo].[usp_chiaveDoppia_LOAD]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_chiaveDoppia_LOAD]
as
 -- first resultset
 select 
	mat.id
	,mat.nomeMateria
from materie.dbo.materia_LOOKUP mat
order by id
-- second resultset
select 
	aut.id
	,aut.nominativo
from materie.dbo.autore aut
order by id
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_abstract_LOAD]    Script Date: 10/13/2024 8:26:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_docMulti_abstract_UPDATE]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_docMulti_abstract_UPDATE]
@id int,
@_abstract text
as
	update
		[docMulti]
	set
		[abstract]=@_abstract
	where id = @id
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_dataMining]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_docMulti_dataMining]
	@id_last_phase int
as
	-- returns a datatable of ids, from last_chunk(in first row) to first_chunk(ref_job_id=0 in last row).--
	declare @ref_job_id int
	set @ref_job_id = @id_last_phase
	--
	select @ref_job_id -- NB. don't forget the last chunk.
	--
	while( @ref_job_id>0)
		begin
			-----------finalizzata a memorizzare la sequenza dei puntatori a chunk.-----------
			select ref_job_id from docMulti where id=@ref_job_id
			-----
			-----------stessa query di prima, con nuovo parametro,----------------------------
			-----------per far avanzare il ciclo while al chunk successivo--------------------
			select @ref_job_id = (select ref_job_id from docMulti where id=@ref_job_id)
			-----
		end
	--ready
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_get_sourceName]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_docMulti_get_sourceName]
	@id int
as
select sourceName from docMulti where id=@id
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_getBlobAtId]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_docMulti_getBlobAtId]
	@id_required_phase int
as
	-- returns a datatable of all columns, at id=@id_required_phase.
	select * from docMulti where id=@id_required_phase
	--ready
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_getDobleKey_at_DocId]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_docMulti_getDobleKey_at_DocId] 
	@DocId int
as
select 
ref_materia_id as idMateria
,ref_autore_id as idAutore
 from materie.dbo.docMulti doc
where
doc.id = @DocId 
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_getId_at_refAutoreId]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_docMulti_getId_at_refAutoreId]
	@ref_autore_id int
as
select 
	dm.id 
	,mat.nomeMateria
	,dm.abstract
	,dm.sourceName
	,dm.insertion_time
from 
	docMulti dm
	, autore aut
	, materia_LOOKUP mat
where 
	ref_autore_id = @ref_autore_id
	and abstract not like '_##__fake_abstract__##_'
	and aut.id=dm.ref_autore_id
	and mat.id = dm.ref_materia_id 
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_INSERT]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_docMulti_INSERT]
	@ref_job_id int,---------NB. must be specified and !=0, on Append.------------------------
	@ref_autore_id int,
	@ref_materia_id int,
	@_abstract text,
	@sourceName varchar(550),
	@doc image,
	-- out
	@result int out -- output the generated id_identity.---------
as
	begin transaction
	begin try
		if @ref_job_id<0--preserve zero, for the first_insert.----
			begin
			    -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @ref_job_id ----- must be specified and >=0. Zero on first_insert, positive on Append.',
						   16, -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   1 -- State.
						   );
			end--end if @ref_job_id<=0 else can continue.
		insert into docMulti(
			--id identity
			ref_job_id,
			ref_autore_id,
			ref_materia_id,
			abstract,
			sourceName,
			doc
				) values(
				--id identity,
				@ref_job_id,------------NB. must be specified and !=0, on Append.---------
				@ref_autore_id,--it's a foreign key: cannot be an invalid pointer.------------
				@ref_materia_id,--it's a foreign key: cannot be an invalid pointer.------------
				@_abstract,-----last chunk will be the only one equipped with. The semantic engine must find last chunk's id.
				@sourceName,--every chunk.----
				@doc
		)
		-- now retrieve the "id_identity" just created, to use it as ref_job_id in successive chunks.
		select @result = (select max(id) from docMulti)
		-- if you get here, you can commit.
		commit transaction
	end try
	begin catch
		rollback transaction
		select @result=-1 --error code
	end catch
	-- ready
	return @result

GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_LOAD_AutoreMateria]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_docMulti_LOAD_AutoreMateria]  
-- NB. selezione documenti sulla chiave doppia( autore, materia)  
 @idAutore int
 ,@idMateria int
as
  select 
	dm.id
	,dm.abstract
	,dm.sourceName
 from
	materie.dbo.docMulti dm
	,materie.dbo.autore aut
	,materie.dbo.materia_LOOKUP mate
 where 
	dm.ref_materia_id = @idMateria --Analisi
	and dm.ref_autore_id = @idAutore --Galiieo
	and aut.id = @idAutore
	and mate.id = @idMateria
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_SEARCH_CandidateDocuments]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_docMulti_SEARCH_CandidateDocuments]
	@id_set varchar( 6000)
as
-- NB. example of how to build this parameter from the application layer:
--declare @id_set varchar( 6000)
--select @id_set = ' (1,2,3)'

declare @query_mainPart varchar( 400)
select @query_mainPart =
'select 
		dm.id,
		c.nominativo as candidato,
		dm.abstract
	from
		[dbo].[docMulti] dm,
		[dbo].[autore]   aut '
	+' where 
		abstract not like ''_##__fake_abstract__##_''
		and dm.ref_autore_id = aut.id '
	--print @query_mainPart
-- decide whether to add an ending part
declare @wholeQuery varchar( 7000)
if( @id_set is not null )
	begin
		select @wholeQuery = @query_mainPart 
		+ ' and dm.id in ' + @id_set 
		+ ' order by abstract'
		--print @wholeQuery
	end
else
	begin
		select @wholeQuery = @query_mainPart + ' order by abstract'
		--print @wholeQuery
	end
-- ready
exec (@wholeQuery)
GO
/****** Object:  StoredProcedure [dbo].[usp_lCrash_CheckLine]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_lCrash_CheckLine]
	@id int
as
	declare @res int
	select @res = (select count(id) from [dbo].[lCrash]	where id=@id)
	return @res
GO
/****** Object:  StoredProcedure [dbo].[usp_lCrash_INSERT]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_lCrash_INSERT]
	@id int,
	@card int
as
	if @card is not null
	begin
		insert into [dbo].[lCrash](
			id,
			card
			) values(
				@id,
				@card
			)
	end
	else
	begin
		insert into [dbo].[lCrash](
			id
			) values(
				@id
				-- card defaults to zero
			)
	end
GO
/****** Object:  StoredProcedure [dbo].[usp_lCrash_LOADSINGLE]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_lCrash_LOADSINGLE]
	@id int
as
	select card from lCrash
	where id=@id
GO
/****** Object:  StoredProcedure [dbo].[usp_lCrash_UPDATE]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_lCrash_UPDATE]
	@id int,
	@card int
as
	update  [dbo].[lCrash]
		set card=@card
	where id=@id
GO
/****** Object:  StoredProcedure [dbo].[usp_materia_LOOKUP_INSERT]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_materia_LOOKUP_INSERT]
@nomeMateria varchar(350)
as
insert into [materia_LOOKUP] (
-- id
nomeMateria
	) values(
@nomeMateria
)
GO
/****** Object:  StoredProcedure [dbo].[usp_materia_LOOKUP_LOAD]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE procedure [dbo].[usp_materia_LOOKUP_LOAD]
as
select * from [dbo].[materia_LOOKUP]
order by nomeMateria   asc
GO
/****** Object:  StoredProcedure [dbo].[usp_materia_LOOKUP_LOADWHERE]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE procedure [dbo].[usp_materia_LOOKUP_LOADWHERE]
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
		 *
	from 
		[dbo].[materia_LOOKUP]  
	'
+ @where_tail
+ ' order by nomeMateria   asc '
exec( @code)
GO
/****** Object:  StoredProcedure [dbo].[usp_permesso_LOADSINGLE]    Script Date: 10/13/2024 8:26:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_utente_ChangePwd]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[usp_utente_ChangePwd]
	@username varchar(50),
	@password varchar(50),
	@kkey     varchar(150),
	@mode     char(1)
as
UPDATE utente
SET
		password=@password,
		kkey=@kkey,
		mode=@mode
WHERE
	username=@username
GO
/****** Object:  StoredProcedure [dbo].[usp_utente_INSERT]    Script Date: 10/13/2024 8:26:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_utente_LOADDECODEDSINGLE]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[usp_utente_LOADDECODEDSINGLE]
	@id int
as
	select
		username
	from utente
	where id=@id

GO
/****** Object:  StoredProcedure [dbo].[usp_utente_LOADSINGLE]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[usp_utente_LOADSINGLE]
	@username varchar(50)
as
	select
		*
	from utente
	where username=@username
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_generic_DROP]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewCacher_generic_DROP]
@view_signature varchar(500)
as
declare @cmd varchar(5500)--NB. no error check. On wrong name, throws.
select @cmd = ' drop view ' + @view_signature
exec( @cmd)

GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_generic_LOAD_interval]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewCacher_generic_LOAD_interval]
@min int
,@max int
,@view_signature varchar(500)
as
declare @cmd varchar(5500)--NB. no error check. On wrong name, throws.
--
select @cmd = ' select * from '
+ @view_signature
+ ' where RowNumber between  '
+ str( @min)
+ ' and '
+ str( @max)
--
exec( @cmd)

GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_generic_LOAD_length]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewCacher_generic_LOAD_length]
@view_signature varchar(500)
as
declare @cmd varchar(1500)
select @cmd =
	'select count(*) from ' --NB. [] required around numeric-beginning names.
	+ @view_signature
exec( @cmd)

GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_autOnMat_due]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_ViewCacher_specific_CREATE_autOnMat_due]
	@view_signature_uno varchar(500)
	,@view_signature_due varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if 
				@view_signature_uno is NULL or Ltrim(Rtrim( @view_signature_uno))=''
				or @view_signature_due is NULL or Ltrim(Rtrim( @view_signature_due))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature_x --- must be BOTH specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				create view ' 
				+ Ltrim(Rtrim( @view_signature_due))
				+' as
					select
					ROW_NUMBER() OVER (
						order by
							viewBase.nomeAutore
						asc) AS RowNumber
					,viewBase.idAutore
					,viewBase.nomeAutore
					,viewBase.idMateria
					,viewBase.nomeMateria
					from materie.dbo.'
					+ Ltrim(Rtrim( @view_signature_uno))+' viewBase'
			-- ready.
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_autOnMat_uno]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_ViewCacher_specific_CREATE_autOnMat_uno]
	@where_tail varchar(1500)
	,@view_signature varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if @where_tail is NULL
			BEGIN
				select @where_tail = ''
				-- NB. no condition whatsoever, iff @idMateria<0 (i.e. it means on all of the Subjects).
			END -- else it's already a valid tail, in the form:
			--and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
			--and mate.id=@idMateria
			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				create view ' 
				+ Ltrim(Rtrim( @view_signature))
				+' as
		select  distinct
			aut.id				as idAutore
			,aut.nominativo		as nomeAutore
			,mate.id			as idMateria
			,mate.nomeMateria   as nomeMateria
			-- ,aut.note  the "text" data type is not selectable as "distinct", because it is not comparable.
		from
			materie.dbo.docMulti dm
			,materie.dbo.autore aut
			,materie.dbo.materia_LOOKUP mate
		where
			dm.ref_autore_id=aut.id
			and dm.ref_materia_id=mate.id
			-- goes in whereTail and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
			-- goes in whereTail and mate.id=@idMateria
				 '
			+ @where_tail --goes in whereTail and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
							-- goes in whereTail and mate.id=@idMateria
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_autore]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewCacher_specific_CREATE_autore]
	@where_tail varchar(1500)
	,@view_signature varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if @where_tail is NULL
			BEGIN
				select @where_tail = ''
			END -- else it's already a valid tail.
			--
			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				create view ' 
				+ Ltrim(Rtrim( @view_signature))
				+' as
						SELECT
							ROW_NUMBER() OVER (ORDER BY aut.nominativo asc) AS ''RowNumber''
							,aut.id
							,aut.nominativo
							,aut.note
				from
					autore aut
				'
				+ @where_tail
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready
GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_documento]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_ViewCacher_specific_CREATE_documento]
	@where_tail varchar(1500)
	,@view_signature varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if @where_tail is NULL
			BEGIN
				select @where_tail = ''
			END -- else it's already a valid tail.
			--
			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				create view ' 
				+ Ltrim(Rtrim( @view_signature))
				+' as
 		select 
			ROW_NUMBER() OVER (		order by
										mat.nomeMateria
										,aut.nominativo
										,dm.insertion_time
										desc) AS ''RowNumber''
			,dm.id				as id_Documento
			,mat.nomeMateria    as nome_Materia
			,aut.nominativo		as nome_Autore
			,dm.abstract		as note_Documento
			,CONVERT(varchar, dm.insertion_time, 23)  as data_Inserimento_Doc
			,dm.sourceName		as sourceName
		from 
			docMulti dm
			, autore aut
			, materia_LOOKUP mat
		where 
			abstract not like ''_##__fake_abstract__##_''
			and aut.id=dm.ref_autore_id
			and mat.id = dm.ref_materia_id  '
			+ @where_tail  -- ref_candidato_id = @ref_candidato_id
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready

GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_logLocalhost]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[usp_ViewCacher_specific_CREATE_logLocalhost]
	@where_tail varchar(1500)
	,@view_signature varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if @where_tail is NULL
			BEGIN
				select @where_tail = ''
			END -- else it's already a valid tail.
			--
			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				create view ' 
				+ Ltrim(Rtrim( @view_signature))
				+' as
						SELECT TOP 1000
							ROW_NUMBER() OVER (ORDER BY [when] desc ) AS ''RowNumber''
	--[when] as full_timestamp,
	,substring([when], 1,4) as [anno],
	case
		when substring([when], 5,2)=1 then ''Gennaio''
		when substring([when], 5,2)=2 then ''Febbraio''
		when substring([when], 5,2)=3 then ''Marzo''
		when substring([when], 5,2)=4 then ''Aprile''
		when substring([when], 5,2)=5 then ''Maggio''
		when substring([when], 5,2)=6 then ''Giugno''
		when substring([when], 5,2)=7 then ''Luglio''
		when substring([when], 5,2)=8 then ''Agosto''
		when substring([when], 5,2)=9 then ''Settembre''
		when substring([when], 5,2)=10 then ''Ottobre''
		when substring([when], 5,2)=11 then ''Novembre''
		when substring([when], 5,2)=12 then ''Dicembre''
		else ''Invalid Month''
	end   as month_name,
	--substring([when], 5,2) as [mese], if you want month-ordinal instead of month-name.
	substring([when], 7,2) as [giorno],
	substring([when], 9,2)+'':''+substring([when], 11,2) as [ora_minuto],
	substring([when],13,2) as [secondo],
	function_name as procedure_called,
	content	as [message],
	-- campi tecnici per il debug su server
	row_nature,
	stack_depth
from
	[Logging].[dbo].[materie_fatClientBeta11_dbFrechet] '
					
				+ @where_tail
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready

GO
/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_Primes]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_ViewCacher_specific_CREATE_Primes]
	@where_tail varchar(1500)
	,@view_signature varchar(500)
as
declare @q varchar(7900)
	begin transaction
		begin try
			if @where_tail is NULL
			BEGIN
				select @where_tail = ''
			END -- else it's already a valid tail.
			--
			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				create view ' 
				+ Ltrim(Rtrim( @view_signature))
				+' as
					select 
						ROW_NUMBER() OVER (ORDER BY p.ordinal asc) AS ''RowNumber''
						, ordinal
						, prime  
					from 
						[PrimeData].[dbo].[Prime_sequence]  p  '
						+ @where_tail  -- where	p.ordinal  between  min and  max
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready

GO
/****** Object:  StoredProcedure [dbo].[usp_ViewGetChunk]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ViewGetChunk]
@view_signature varchar(350)
,@rowInf int
,@rowSup int
as
declare @q varchar(7900)
	begin transaction
		begin try
			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
			begin
				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   ,1 -- State.
						   );
			end--end if @view_signature is NULL else can continue.
-------------------------------------------------------------------------
			select @q =
			'
				select * from ' 
				+ Ltrim(Rtrim( @view_signature))
				+' where RowNumber between ' + CAST(@rowInf AS nvarchar(40)) 
				+' and ' + CAST(@rowSup AS nvarchar(40)) 
			exec( @q )
			-- if you get here, you can commit.
			commit transaction
	end try
	begin catch
		rollback transaction
	end catch
	-- ready
GO
/****** Object:  StoredProcedure [dbo].[usp_zPrototipo]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_zPrototipo]
as
 --esempio buono per l'estrazione documenti, fissata materia ed autore
 select 
	ROW_NUMBER()  OVER (order by doc.id asc) as count_record
	, doc.id            as Doc_Id
	,doc.abstract	  as Doc_abstract 
	,aut.nominativo	  as Autore_nominativo
	,mat.nomeMateria  as Materia
from 	
  materie.dbo.docMulti			doc
  ,materie.dbo.autore			aut
  ,materie.dbo.materia_LOOKUP	mat
where 
	doc.ref_autore_id = aut.id
	and doc.ref_materia_id = mat.id 
	and mat.id = 1
	and aut.id = 1
GO
/****** Object:  StoredProcedure [dbo].[usp_zzProtoDoc]    Script Date: 10/13/2024 8:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure  [dbo].[usp_zzProtoDoc]
as
select 
doc.id as IdDoc
,aut.nominativo as nomeAutore
,mat.nomeMateria  nomeMateria
,doc.abstract as AbstractDoc
--,doc.sourceName as sourceName -- cut off in production environement
from
materie.dbo.docMulti		doc
,materie.dbo.autore			aut
,materie.dbo.materia_LOOKUP mat
where
	doc.ref_autore_id = aut.id
	and doc.ref_materia_id = mat.id
	and doc.abstract not like '%_##__fake_abstract__##_%'
	-- follows tail optional portion
	and doc.abstract like '%Costanzo%'
	and doc.ref_materia_id=5
GO
