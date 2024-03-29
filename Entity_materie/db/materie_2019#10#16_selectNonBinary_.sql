
exec materie.dbo.usp_ViewGetChunk 
'[123#test#caching#@_]'
,4
,9



--create view [123#test#caching#@_]
--as
--	select 
--		ROW_NUMBER() OVER (ORDER BY m.nomeMateria asc) AS 'RowNumber'
--		, id
--		, nomeMateria
--	from 
--		materie.dbo.materia_LOOKUP  m  
--GO

--drop view   [123#test#caching#@_]
select * from  [123#test#caching#@_]
where [ID] between 2 and 5
GO


--create procedure [dbo].[usp_ViewGetChunk]
--@view_signature varchar(350)
--,@rowInf int
--,@rowSup int
--as
--declare @q varchar(7900)
--	begin transaction
--		begin try
--			if @view_signature is NULL or Ltrim(Rtrim( @view_signature))=''
--			begin
--				-- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
--				RAISERROR( '---NB. @view_signature ----- must be specified and non-empty.'
--						   ,16 -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
--						   ,1 -- State.
--						   );
--			end--end if @view_signature is NULL else can continue.
---------------------------------------------------------------------------
--			select @q =
--			'
--				select * from ' 
--				+ Ltrim(Rtrim( @view_signature))
--				+' where RowNumber between ' + CAST(@rowInf AS nvarchar(40)) 
--				+' and ' + CAST(@rowSup AS nvarchar(40)) 
--			exec( @q )
--			-- if you get here, you can commit.
--			commit transaction
--	end try
--	begin catch
--		rollback transaction
--	end catch
--	-- ready
--GO-- END proc

--##

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

--##@



select 
doc.id as id_doc
, doc.ref_materia_id as ref_materia_id
, doc.sourceName      as FileFullPath
 , mat.nomeMateria as Materia
 , aut.nominativo as Autore
 
--delete
 select *
from 
	materie.dbo.docMulti	
	--,materie.dbo.materia_LOOKUP mat
	--,materie.dbo.autore			aut
where 
	ref_autore_id = 14
	ref_materia_id in (21)
	and mat.id=doc.ref_materia_id
	and aut.id = doc.ref_autore_id



select 
doc.id as id_doc
, doc.ref_materia_id as ref_materia_id
, doc.sourceName      as FileFullPath
 , mat.nomeMateria as Materia
 , aut.nominativo as Autore
from 
	materie.dbo.docMulti		doc
	,materie.dbo.materia_LOOKUP mat
	,materie.dbo.autore			aut
where 
	ref_materia_id in (12)
	and mat.id=doc.ref_materia_id
	and aut.id = doc.ref_autore_id

 --,4,15,17,6,3,7,10,19,23,20,21)
	and ref_autore_id in (2,11,6,8,3,4,7,5,14)

select 
doc.id as id_doc
,ref_materia_id as ref_materia_id
, sourceName      as FileFullPath
, mat.nomeMateria as Materia
, aut.nominativo as Autore
from 
	materie.dbo.docMulti		doc
	,materie.dbo.materia_LOOKUP mat
	,materie.dbo.autore			aut
where 
	ref_materia_id in (12,4,15,17,6,3,7,10,19,23,20,21)
	and ref_autore_id in (2,11,6,8,3,4,7,5,14)
	and mat.id=doc.ref_materia_id
	and aut.id = doc.ref_autore_id

--delete from materie.dbo.materia_LOOKUP
--where materie.dbo.materia_LOOKUP.id in  (12,4,15,17,6,3,7,10,19,23,20,21)

--delete from materie.dbo.autore
--where autore.id in  (2,11,6,8,3,4,7,5,14)

select * from materie.dbo.docMulti
where id=68

select * from materie.dbo.docMulti
where abstract not like '%fake%'

--truncate table materie.dbo.docMulti

select *
--delete
from materie.dbo.docMulti
where id>=94 and id<=152

select * from utente
select * from permesso_LOOKUP


select --top 5 
dm.id, dm.ref_job_id, dm.ref_autore_id, dm.ref_materia_id,dm.abstract,dm.sourceName,dm.insertion_time
from materie.dbo.docMulti dm
order by dm.id desc

select
dm.id, dm.doc
from materie.dbo.docMulti dm
where id>343
order by dm.id desc

select * from materie.dbo.utente
select * from materie.dbo.permesso_LOOKUP

select * from materie.dbo.materia_LOOKUP order by nomeMateria asc
select * from materie.dbo.autore order by nominativo asc

select * from materie.dbo.materia_LOOKUP order by nomeMateria asc
--delete from materie.dbo.materia_LOOKUP where nomeMateria='Farlocco'

--insert into materie.dbo.materia_LOOKUP(
----
--nomeMateria
--)values(
----
--'Farlocco'
--)

--NB. View names can contain column ':'
create View [20191114#13:23:38#473] as
select * from materie.dbo.materia_LOOKUP
GO

select * from [123]

create View [123] as
select * from materie.dbo.materia_LOOKUP
GO

select * from materie.dbo.autore 

select MAX(id) from materie.dbo.docMulti
select * from materie.dbo.docMulti where id=512

select * from materie.dbo.docMulti where id=527
select TOP 14  id,insertion_time, sourceName
from materie.dbo.docMulti
order by id desc


 
--create procedure [dbo].[usp_autore_LOAD_whoWroteOnMateria]
--	@idMateria int
--as
--	if @idMateria > 0
--		begin
--			select  distinct
--			aut.id				as idAutore
--			,aut.nominativo		as nomeAutore
--			,mate.id			as idMateria
--			,mate.nomeMateria   as nomeMateria
--			-- ,aut.note  the "text" data type is not selectable as "distinct", because it is not comparable.
--			from
--			materie.dbo.docMulti dm
--			,materie.dbo.autore aut
--			,materie.dbo.materia_LOOKUP mate
--			where 
--			dm.ref_autore_id=aut.id
--			and dm.ref_materia_id=mate.id
--			and dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
--			and mate.id=@idMateria
--		end
--	else
--		begin
--			select  distinct
--			aut.id				as idAutore
--			,aut.nominativo		as nomeAutore
--			,mate.id			as idMateria
--			,mate.nomeMateria   as nomeMateria
--			-- ,aut.note  the "text" data type is not selectable as "distinct", because it is not comparable.
--			from
--			materie.dbo.docMulti dm
--			,materie.dbo.autore aut
--			,materie.dbo.materia_LOOKUP mate
--			where 
--			dm.ref_autore_id=aut.id
--			and dm.ref_materia_id=mate.id
--			-- NB. no condition whatsoever, iff @idMateria<0 (i.e. it means on all of the Subjects).		
--		end
--GO

		
--// ##
--use [materie]
--ALTER TABLE [dbo].[materia_LOOKUP]
--ADD CONSTRAINT materia_unique UNIQUE ( nomeMateria);

--use [materie]
--ALTER TABLE [dbo].[autore]
--ADD CONSTRAINT autore_unique UNIQUE ( nominativo);

USE [materie]
GO

/****** Object:  Table [dbo].[autore]    Script Date: 11/13/2019 15:53:16 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[autore](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nominativo] [varchar](150) NOT NULL,
	[note] [text] NULL,
 CONSTRAINT [pk_autore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [autore_unique] UNIQUE NONCLUSTERED 
(
	[nominativo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




USE [materie]
GO

/****** Object:  Table [dbo].[materia_LOOKUP]    Script Date: 11/13/2019 15:47:02 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[materia_LOOKUP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nomeMateria] [varchar](350) NOT NULL,
 CONSTRAINT [pk_materia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
--##
USE [materie]
GO

/****** Object:  Table [dbo].[materia_LOOKUP]    Script Date: 11/13/2019 15:49:34 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[materia_LOOKUP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nomeMateria] [varchar](350) NOT NULL,
 CONSTRAINT [pk_materia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [materia_unique] UNIQUE NONCLUSTERED 
(
	[nomeMateria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
--##
USE [materie]
GO

/****** Object:  StoredProcedure [dbo].[usp_ViewCacher_specific_CREATE_autore]    Script Date: 11/14/2019 16:12:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--create procedure [dbo].[usp_ViewCacher_specific_CREATE_autore]
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




 