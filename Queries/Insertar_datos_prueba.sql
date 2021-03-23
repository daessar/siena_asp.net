INSERT INTO es_usuarios(
usu_documento,
usu_tipodoc,
usu_nombre,
usu_celular,
usu_email,
usu_genero,
usu_aprendiz,
usu_egresado,
usu_areaformacion,
usu_fechaegresado,
usu_direccion,
usu_barrio,
usu_ciudad,
usu_departamento,
usu_fecharegistro)
VALUES(
2345678,'CC','Camilo',30012,'camilo@camilo.com','M',0,1,'ADSI',GETDATE(),'Cra 22 #34-50','El sol','Manizales','Caldas',GETDATE())

SELECT * FROM es_usuarios