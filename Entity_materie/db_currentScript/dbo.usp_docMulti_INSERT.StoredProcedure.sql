USE [materie]
GO
/****** Object:  StoredProcedure [dbo].[usp_docMulti_INSERT]    Script Date: 10/13/2024 8:13:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_docMulti_INSERT]
	@ref_job_id int,---------NB. must be specified and !=0, on Append.------------------------
	@ref_autore_id int,
	@ref_materia_id int,
	@_abstract text,
	@sourceName varchar(550),
	@doc image,
	-- out
	@result int out -- output the generated id_identity.---------
as
	begin transaction
	begin try
		if @ref_job_id<0--preserve zero, for the first_insert.----
			begin
			    -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
				RAISERROR( '---NB. @ref_job_id ----- must be specified and >=0. Zero on first_insert, positive on Append.',
						   16, -- Severity. -- RAISERROR with severity 11-19 will cause exeuction to jump to the CATCH block.
						   1 -- State.
						   );
			end--end if @ref_job_id<=0 else can continue.
		insert into docMulti(
			--id identity
			ref_job_id,
			ref_autore_id,
			ref_materia_id,
			abstract,
			sourceName,
			doc
				) values(
				--id identity,
				@ref_job_id,------------NB. must be specified and !=0, on Append.---------
				@ref_autore_id,--it's a foreign key: cannot be an invalid pointer.------------
				@ref_materia_id,--it's a foreign key: cannot be an invalid pointer.------------
				@_abstract,-----last chunk will be the only one equipped with. The semantic engine must find last chunk's id.
				@sourceName,--every chunk.----
				@doc
		)
		-- now retrieve the "id_identity" just created, to use it as ref_job_id in successive chunks.
		select @result = (select max(id) from docMulti)
		-- if you get here, you can commit.
		commit transaction
	end try
	begin catch
		rollback transaction
		select @result=-1 --error code
	end catch
	-- ready
	return @result

GO
