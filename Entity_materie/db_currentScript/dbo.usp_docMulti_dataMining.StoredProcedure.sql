USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_dataMining]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_docMulti_dataMining]
	@id_last_phase int
as
	-- returns a datatable of ids, from last_chunk(in first row) to first_chunk(ref_job_id=0 in last row).--
	declare @ref_job_id int
	set @ref_job_id = @id_last_phase
	--
	select @ref_job_id -- NB. don't forget the last chunk.
	--
	while( @ref_job_id>0)
		begin
			-----------finalizzata a memorizzare la sequenza dei puntatori a chunk.-----------
			select ref_job_id from docMulti where id=@ref_job_id
			-----
			-----------stessa query di prima, con nuovo parametro,----------------------------
			-----------per far avanzare il ciclo while al chunk successivo--------------------
			select @ref_job_id = (select ref_job_id from docMulti where id=@ref_job_id)
			-----
		end
	--ready
GO
