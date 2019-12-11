
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
