 
  
  select * from materie.dbo.autore
  select * from materie.dbo.materia_LOOKUP
  select * from materie.dbo.docMulti

--use [materie]  
--GO
--create procedure usp_docMulti_LOAD_AutoreMateria  
---- NB. selezione documenti sulla chiave doppia( autore, materia)  
-- @idAutore int
-- ,@idMateria int
--as
--  select 
--	dm.id
--	,dm.abstract
--	,dm.sourceName
-- from
--	materie.dbo.docMulti dm
--	,materie.dbo.autore aut
--	,materie.dbo.materia_LOOKUP mate
-- where 
--	dm.ref_materia_id = @idMateria --Analisi
--	and dm.ref_autore_id = @idAutore --Galiieo
--	and aut.id = @idAutore
--	and mate.id = @idMateria
--GO
	
	
// NB. selezione autori che hanno scritto su di una materia

--use [materie]
--GO
--create procedure usp_autore_LOAD_whoWroteOnMateria
--	@idMateria int
--as
--  select distinct
--	aut.id
--	,aut.nominativo 
--	-- ,aut.note  the "text" data type is not selectable as "distinct", because it is not comparable.
-- from
--	materie.dbo.docMulti dm
--	,materie.dbo.autore aut
--	,materie.dbo.materia_LOOKUP mate
-- where 
--	dm.ref_materia_id=@idMateria-- ref to Materia found in Documento
--	and dm.ref_autore_id=aut.id
--	and mate.id=@idMateria
--GO
