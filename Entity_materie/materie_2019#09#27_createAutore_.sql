USE [materie]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_ViewCacher_specific_CREATE_autore]
		@where_tail = N' where nominativo like ''%Galil%'' and note like ''%scient%'' ',
		@view_signature = N'ginoSabo'

SELECT	'Return Value' = @return_value

GO
