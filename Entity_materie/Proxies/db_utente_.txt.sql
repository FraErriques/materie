select * from cv_db.dbo.utente
select * from materie.dbo.utente
select * from materie.dbo.lCrash

insert into materie.dbo.utente(
--id,
username,
[password],
kkey,
mode,
ref_permissionLevel_id
)values(
--id,
'admin',
'*X*0#WZ;',
'079049089116098092066060059072',
'm',
1 -- ref_permissionLevel_id
)

insert into materie.dbo.utente(
--id,
username,
[password],
kkey,
mode,
ref_permissionLevel_id
)values(
--id,
'scrittore',
'scrittore',
'0',
'o',
2 -- ref_permissionLevel_id
)


select * from materie.dbo.permesso_LOOKUP

insert into materie.dbo.permesso_LOOKUP(
id,
permissionDescription)
values(
3, --id
'reader'
)

(select [username] from  cv_db.dbo.utente where id=6),
'*X*0#WZ;',
(select [kkey] from  cv_db.dbo.utente where id=6),
(select [mode] from  cv_db.dbo.utente where id=6),
