USE [materie]
 
EXEC  [dbo].[usp_ViewCacher_generic_LOAD_interval]
		@min = 2,
		@max = 4,
		@view_signature = N'[123#test#caching#@_]'

EXEC  [dbo].[usp_ViewGetChunk]
		N'[123#test#caching#@_]'
		,2
		,4
		
		