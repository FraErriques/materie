select top 5 
dm.id, dm.ref_job_id, dm.ref_autore_id, dm.ref_materia_id,dm.abstract,dm.sourceName,dm.insertion_time
from materie.dbo.docMulti dm
order by dm.id desc

select
dm.id, dm.doc
from materie.dbo.docMulti dm
where id>343
order by dm.id desc
