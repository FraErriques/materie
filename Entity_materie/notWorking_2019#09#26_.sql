USE [materie]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_ViewCacher_specific_CREATE_autore]
		@where_tail = N'note like ''%scien%'' and nominativo like  ''%Galil%'' ',
		@view_signature = N'asdrakan2019giovedi26'

SELECT	'Return Value' = @return_value

GO


'note like '%scien%' and nominativo like  '%Galil%'