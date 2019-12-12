
select
	ROW_NUMBER() OVER (
		order by
		aut.nominativo
		asc) AS RowNumber
	,aut.id
	,aut.nominativo
	,aut.note
  from materie.dbo.autore aut

select
	aut.id
from materie.dbo.autore aut


select
nominativo
,note
from ( -- NO. Non va nella FROM ma nella WHERE
	select * from materie.dbo.autore
)
where [id]=10






declare @where_tail varchar(3500)
--select @where_tail = ''
--select @where_tail = NULL
select @where_tail = 'abra'
if @where_tail is NULL
or  @where_tail=''
	begin
		print 'nulla'
	end
else
	begin
		print 'piena'
	end
