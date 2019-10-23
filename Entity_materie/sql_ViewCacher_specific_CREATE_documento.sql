					select 
						ROW_NUMBER() OVER (ORDER BY dm.sourceName asc) AS 'RowNumber'
						,dm.id 
						,mat.nomeMateria 
						,dm.abstract
						,dm.sourceName
						,dm.insertion_time
					from 
						docMulti dm
						, autore aut
						, materia_LOOKUP mat
--						, settoreCandidatura_LOOKUP sett
					where 
						abstract not like '_##__fake_abstract__##_'
						and aut.id=dm.ref_autore_id
						and mat.id = dm.ref_materia_id
						