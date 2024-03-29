
select * from materie.dbo.autore

  select 
	d.id	as idDoc
	,c.nominativo as autoreDoc
	,d.abstract   as noteDocumento
   from 
	cv_db.dbo.doc_multi d
	,cv_db.dbo.candidato c
  where 
	c.id=d.ref_candidato_id
	and abstract not like '%_##__fake_abstract__##_%'
    and d.id between 1 and 12
  
  select * from materie.dbo.materia_LOOKUP
  select * from materie.dbo.autore
  select * from materie.dbo.docMulti

  select 
	aut.id
	,aut.nominativo
	,aut.note 
  from 
	materie.dbo.autore aut
  where
	aut.nominativo like '%Galil%'
	and aut.note like '%Scientifico%'
	
	
  select 
	aut.id
  from 
	materie.dbo.autore aut
  where
	aut.nominativo like '%Galil%'
	and aut.note like '%Scientifico%' 
  
  select 
	aut.id
	,aut.nominativo
	,aut.note 
  from 
	materie.dbo.autore aut
	,materie.dbo.docMulti doc
  where
	
 --esempio buono per l'estrazione documenti, fissata materia ed autore
 select 
	doc.id            as Doc_Id
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

--use [materie]
--GO
--create procedure usp_zPrototipo
--as
-- --esempio buono per l'estrazione documenti, fissata materia ed autore
-- select 
--	ROW_NUMBER()  OVER (order by doc.id asc) as count_record
--	, doc.id            as Doc_Id
--	,doc.abstract	  as Doc_abstract 
--	,aut.nominativo	  as Autore_nominativo
--	,mat.nomeMateria  as Materia
--from 	
--  materie.dbo.docMulti			doc
--  ,materie.dbo.autore			aut
--  ,materie.dbo.materia_LOOKUP	mat
--where 
--	doc.ref_autore_id = aut.id
--	and doc.ref_materia_id = mat.id 
--	and mat.id = 1
--	and aut.id = 1
--GO -- end usp_zPrototipo


	
-- sottocasi
-- fissata solo la materia
 select 
	doc.id
	,doc.abstract
	,aut.nominativo
	--,mat.nomeMateria fissata solo la materia
from 	
  materie.dbo.docMulti			doc
  ,materie.dbo.autore			aut
  ,materie.dbo.materia_LOOKUP	mat
where 
	doc.ref_autore_id = aut.id
	and doc.ref_materia_id = mat.id 
	and mat.id = 1
	-- and aut.id = 1

-- fissato solo l'autore
 select 
	doc.id
	,doc.abstract
	,aut.nominativo   -- fissata solo l'autore
	,mat.nomeMateria
from 	
  materie.dbo.docMulti			doc
  ,materie.dbo.autore			aut
  ,materie.dbo.materia_LOOKUP	mat
where 
	doc.ref_autore_id = aut.id
	and doc.ref_materia_id = mat.id 
	--and mat.id = 1
	and aut.id = 1
--##
				SELECT
							ROW_NUMBER() OVER (ORDER BY aut.nominativo asc) AS 'RowNumber'
							,aut.id
							,aut.nominativo
							,aut.note
				from
					autore aut
				where 
				 note like '%scien%' and nominativo like '%Galil%' 
				
				
					note like '%scien%'
					and nominativo like '%Galil%'
				'
				+ @where_tail
				
				'note like ''%scien%'' and nominativo like ''%Galil%'' '