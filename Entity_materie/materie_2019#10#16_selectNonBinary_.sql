select top 5 
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

select * from materie.dbo.materia_LOOKUP
select * from materie.dbo.materia_LOOKUP order by nomeMateria asc
--delete from materie.dbo.materia_LOOKUP where nomeMateria='Farlocco'

--insert into materie.dbo.materia_LOOKUP(
----
--nomeMateria
--)values(
----
--'Farlocco'
--)

select * from materie.dbo.materia_LOOKUP
select * from materie.dbo.autore 

select MAX(id) from materie.dbo.docMulti
select * from materie.dbo.docMulti where id=512

select * from materie.dbo.docMulti where id=527
select TOP 14  id,insertion_time, sourceName
from materie.dbo.docMulti
order by id desc


 
 [dbo].[usp_autore_LOAD_whoWroteOnMateria]
	@idMateria int
as
	if @idMateria >=0
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
 