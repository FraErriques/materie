
	SELECT
	ROW_NUMBER() OVER (ORDER BY aut.nominativo asc) AS 'RowNumber'
	,aut.id
	,aut.nominativo
	,aut.note
	from
	autore aut
--##
select
		aut.id
		,aut.nominativo
		,aut.note
	from 
		autore aut
		
select * from materie.dbo.materia_LOOKUP		
select * from materie.dbo.docMulti

