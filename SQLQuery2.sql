USE db_modelo
GO

 -- REGISTROS tabla Tipo
 INSERT INTO dbo.Semestre(nombre,anio, estado) values ('2019-II',2019,'A')
 go
 INSERT INTO dbo.Semestre(nombre,anio, estado) values ('2019-II',2019,'I')
 go
 INSERT INTO dbo.Semestre(nombre,anio, estado) values ('2020-II',2020,'I')
 go
 INSERT INTO dbo.Semestre(nombre,anio, estado) values ('2020-II',2020,'A')
 go

 SELECT * FROM dbo.Semestre


  INSERT INTO dbo.Modelo(nombre,descripcion, estado) values ('Modelo1','','A')
 go
  INSERT INTO dbo.Modelo(nombre,descripcion, estado) values ('Modelo2','modelo2','A')
 go
  INSERT INTO dbo.Modelo(nombre,descripcion, estado) values ('Modelo3','','A')
 go


 SELECT * FROM dbo.Modelo

 

 -- REGISTROS tabla Persona

INSERT INTO dbo.Docente values (45455612,'73800414','Lanchipa Valencia','Enrique','M','elanchipa@upt.pe','952301452','Docente','TC','C','','A')
go
INSERT INTO dbo.Docente values (20202020,'12354656','Osco mamani','Ebert','M','osco@upt.pe','952301452','Docente','TP','C','','A')
go
INSERT INTO dbo.Docente values (84251648,'54563221','Rodrigues Roma','Elard','M','elard@upt.pe','952301452','Docente','TC','B','','A')
go

 
 
 SELECT * FROM dbo.Docente


 -- REGISTROS tabla usuario

INSERT INTO dbo.usuario values (1,'elanchipa','123456','Administrador','','A')
go
INSERT INTO dbo.usuario values (2,'eosco','123456','Usuario','','A')
go
INSERT INTO dbo.usuario values (3,'edroma',HASHBYTES('MD5','123456'),'Usuario','','I')
go

UPDATE dbo.usuario SET clave='e10adc3949ba59abbe56e057f20f883e' WHERE usuario_id=1
go
UPDATE dbo.usuario SET clave='81dc9bdb52d04dc20036dbd8313ed055' WHERE usuario_id=2
go
UPDATE dbo.usuario SET clave='81dc9bdb52d04dc20036dbd8313ed055' WHERE usuario_id=3
go
 
 
 SELECT * FROM dbo.usuario
