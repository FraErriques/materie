/*
query on a first View, creating a second View with addition of ROW_NUMBER
*/  
  select
	ROW_NUMBER() OVER (
		order by
		viewBase.nomeAutore
		asc) AS RowNumber
	,viewBase.idAutore
	,viewBase.nomeAutore
	,viewBase.idMateria
	,viewBase.nomeMateria
  from materie.dbo.[testViewBaseNoRowN] viewBase

select *  from materie.dbo.[testViewBaseNoRowN] viewBase
