DROP DATABASE Veterinaria_404888
GO
CREATE DATABASE Veterinaria_404888
GO
USE Veterinaria_404888
GO
CREATE TABLE clientes
(
	cod_cliente INT IDENTITY(1,1),
	nom_cliente VARCHAR(30) NOT NULL,
	sexo_cliente BIT NOT NULL,
	fecha_alta DATETIME NOT NULL,
	fecha_baja DATETIME,
	CONSTRAINT pk_clientes PRIMARY KEY (cod_cliente)
)
CREATE TABLE tipo_mascotas
(
	cod_tipo INT IDENTITY(1,1),
	decripcion VARCHAR(30) NOT NULL,
	fecha_alta DATETIME NOT NULL,
	fecha_baja DATETIME,
	CONSTRAINT pk_tipo_mascotas PRIMARY KEY (cod_tipo)
)
CREATE TABLE mascotas
(
	cod_mascota INT IDENTITY(1,1),
	nom_mascota VARCHAR(30) NOT NULL,
	tipo_mascota INT NOT NULL,
	fecha_nacimiento DATETIME,
	cod_dueno INT,
	fecha_alta DATETIME NOT NULL,
	fecha_baja DATETIME,
	CONSTRAINT pk_mascotas PRIMARY KEY (cod_mascota),
	CONSTRAINT fk_mas_cli FOREIGN KEY (cod_dueno)
		REFERENCES clientes (cod_cliente),
	CONSTRAINT fk_mas_tipo FOREIGN KEY (tipo_mascota)
		REFERENCES tipo_mascotas(cod_tipo)
)

CREATE TABLE atenciones
(
	cod_atencion INT IDENTITY(1,1),
	descripcion VARCHAR(200) NOT NULL,
	importe DECIMAL(10,2) NOT NULL,
	fecha_atencion DATETIME NOT NULL,
	cod_mascota INT NOT NULL,
	fecha_baja DATETIME,
	CONSTRAINT pk_atenciones PRIMARY KEY (cod_atencion),
	CONSTRAINT fk_ate_mas FOREIGN KEY (cod_mascota)
		REFERENCES mascotas(cod_mascota)
)
GO

CREATE PROCEDURE SP_OBTENER_CLIENTE
	@cod INT
AS
BEGIN
	SELECT nom_cliente, sexo_cliente, cod_cliente
	FROM clientes
	WHERE fecha_baja IS NULL
	AND cod_cliente = @cod
END

GO

CREATE PROCEDURE SP_OBTENER_CLIENTES
AS
BEGIN
	SELECT nom_cliente, sexo_cliente, cod_cliente
	FROM clientes
	WHERE fecha_baja IS NULL
END

GO

CREATE PROCEDURE SP_OBTENER_CLIENTES_FILTRO
	@fecha_desde DATETIME, @fecha_hasta DATETIME, @nom_cliente VARCHAR(30), @sexo VARCHAR(1) = '%', @cod VARCHAR(12) = '%'
AS
BEGIN
	SELECT cod_cliente, nom_cliente, sexo_cliente, fecha_alta
	FROM clientes
	WHERE fecha_baja IS NULL
	AND fecha_alta BETWEEN @fecha_desde AND @fecha_hasta
	AND nom_cliente LIKE '%' + @nom_cliente + '%'
	AND sexo_cliente LIKE @sexo
	AND cod_cliente LIKE @cod
END

GO

CREATE PROCEDURE SP_AGREGAR_CLIENTE
	@nombre VARCHAR(30), @sexo BIT
AS
BEGIN
	INSERT INTO clientes(nom_cliente, sexo_cliente, fecha_alta)
	OUTPUT inserted.cod_cliente
	VALUES (@nombre, @sexo, GETDATE())
END

GO
CREATE PROCEDURE SP_BAJAR_CLIENTE
	@cod INT
AS
BEGIN
	UPDATE clientes
	SET fecha_baja = GETDATE()
	WHERE cod_cliente = @cod;
	UPDATE mascotas
	SET fecha_baja = GETDATE()
	WHERE cod_dueno = @cod;
	UPDATE atenciones
	SET fecha_baja = GETDATE()
	WHERE cod_atencion IN (SELECT cod_atencion
	                       FROM atenciones a JOIN mascotas m ON a.cod_mascota = m.cod_mascota
						   WHERE cod_dueno = @cod)
END

GO

CREATE PROCEDURE SP_MODIFICAR_CLIENTE
	@nombre VARCHAR(30), @sexo BIT, @cod INT
AS
BEGIN
	UPDATE clientes
	SET nom_cliente = @nombre, sexo_cliente = @sexo
	OUTPUT inserted.cod_cliente
	WHERE cod_cliente = @cod
END

GO

CREATE PROCEDURE SP_OBTENER_MASCOTAS
	@fecha_desde DATETIME, @fecha_hasta DATETIME, @nom_cliente VARCHAR(30), @nom_mascota VARCHAR(30), @cod VARCHAR(12) = '%', @tipo VARCHAR(12) = '%', @edad VARCHAR(12) = '%'
AS
BEGIN
	SELECT cod_mascota, nom_cliente, nom_mascota, t.decripcion, DATEDIFF(YEAR, fecha_nacimiento, GETDATE()), m.fecha_alta, fecha_nacimiento, cod_cliente, t.cod_tipo
	FROM mascotas m JOIN tipo_mascotas t ON m.tipo_mascota = t.cod_tipo JOIN clientes c ON m.cod_dueno = c.cod_cliente
	WHERE m.fecha_baja IS NULL
	AND nom_cliente LIKE '%' + @nom_cliente + '%'
	AND nom_mascota LIKE '%' + @nom_mascota + '%'
	AND m.fecha_alta BETWEEN @fecha_desde AND @fecha_hasta
	AND m.tipo_mascota LIKE @tipo
	AND m.cod_mascota LIKE @cod
	AND DATEDIFF(YEAR, fecha_nacimiento, GETDATE()) LIKE @edad
END

GO

CREATE PROCEDURE SP_OBTENER_MASCOTAS_CLIENTE
	@cod_cliente INT
AS
BEGIN
	SELECT nom_mascota, DATEDIFF(YEAR, fecha_nacimiento, GETDATE()), t.decripcion, cod_mascota, cod_tipo
	FROM mascotas m JOIN tipo_mascotas t ON m.tipo_mascota = t.cod_tipo
	WHERE cod_dueno = @cod_cliente
	AND m.fecha_baja IS NULL
END

GO

CREATE PROCEDURE SP_AGREGAR_MASCOTA
	@nombre VARCHAR(30), @tipo INT, @fecha_nacimiento DATETIME, @cod_dueno INT
AS
BEGIN
	INSERT INTO mascotas(nom_mascota, tipo_mascota, fecha_nacimiento, cod_dueno, fecha_alta)
	OUTPUT inserted.cod_mascota
	VALUES(@nombre, @tipo, @fecha_nacimiento, @cod_dueno, GETDATE())
END

GO

CREATE PROCEDURE SP_BAJAR_MASCOTA
	@cod INT
AS
BEGIN
	UPDATE mascotas
	SET fecha_baja = GETDATE()
	WHERE cod_mascota = @cod;
	UPDATE atenciones
	SET fecha_baja = GETDATE()
	WHERE cod_mascota = @cod;
END

GO

CREATE PROCEDURE SP_MODIFICAR_MASCOTA
	@cod INT, @nombre VARCHAR(30), @tipo INT, @fecha_nacimiento DATETIME
AS
BEGIN
	UPDATE mascotas
	SET nom_mascota = @nombre, tipo_mascota = @tipo, fecha_nacimiento = @fecha_nacimiento
	WHERE cod_mascota = @cod
END

GO
CREATE PROCEDURE SP_OBTENER_TIPOS
AS
BEGIN
	SELECT cod_tipo, decripcion
	FROM tipo_mascotas
	WHERE fecha_baja IS NULL
END

GO

CREATE PROCEDURE SP_AGREGAR_TIPO
	@desc VARCHAR(30)
AS
BEGIN
	INSERT INTO tipo_mascotas(decripcion, fecha_alta)
	VALUES (@desc, GETDATE())
END

GO

CREATE PROCEDURE SP_OBTENER_ATENCION
	@cod INT
AS
BEGIN
	SELECT cod_atencion, descripcion, importe, fecha_atencion
	FROM atenciones a
	WHERE cod_atencion = @cod
END

GO

CREATE PROCEDURE SP_OBTENER_ATENCIONES
	@fecha_desde DATETIME, @fecha_hasta DATETIME, @cod VARCHAR(12) = '%', @importe_min DECIMAL(10,2) = -99999999.99, @importe_max DECIMAL(10,2) = 99999999.99, @nom_cliente VARCHAR(30), @nom_mascota VARCHAR(30), @descripcion VARCHAR(200)
AS
BEGIN
	SELECT cod_atencion, nom_cliente,  nom_mascota + ' - ' + t.decripcion, descripcion, fecha_atencion, importe
	FROM atenciones a JOIN mascotas m ON a.cod_mascota = m.cod_mascota JOIN clientes c ON m.cod_dueno = c.cod_cliente JOIN tipo_mascotas t ON m.tipo_mascota = t.cod_tipo
	WHERE a.fecha_baja IS NULL
	AND fecha_atencion BETWEEN @fecha_desde AND @fecha_hasta
	AND cod_atencion LIKE @cod
	AND importe BETWEEN @importe_min AND @importe_max
	AND nom_cliente LIKE '%' + @nom_cliente + '%'
	AND nom_mascota LIKE '%' + @nom_mascota + '%'
	AND a.descripcion LIKE '%' + @descripcion + '%'
END

GO

CREATE PROCEDURE SP_OBTENER_ATENCIONES_MASCOTA
	@cod_mascota INT
AS
BEGIN
	SELECT cod_atencion, descripcion, importe, fecha_atencion
	FROM atenciones
	WHERE cod_mascota = @cod_mascota
	AND fecha_baja IS NULL
END

GO

CREATE PROCEDURE SP_AGREGAR_ATENCION
	@descripcion VARCHAR(200), @importe DECIMAL(10,2), @fecha_atencion DATETIME, @cod_mascota INT
AS
BEGIN
	INSERT INTO atenciones(descripcion, importe, fecha_atencion, cod_mascota) VALUES (@descripcion, @importe, @fecha_atencion, @cod_mascota)
END

GO

CREATE PROCEDURE SP_BAJAR_ATENCION
	@cod INT
AS
BEGIN
	UPDATE atenciones
	SET fecha_baja = GETDATE()
	WHERE cod_atencion = @cod
END
GO

CREATE PROCEDURE SP_MODIFICAR_ATENCION
	@descripcion VARCHAR(200), @importe DECIMAL(10,2), @fecha_atencion DATETIME, @cod INT
AS
BEGIN
	UPDATE atenciones
	SET descripcion = @descripcion, importe = @importe, fecha_atencion = @fecha_atencion
	WHERE cod_atencion = @cod
END

GO
SET DATEFORMAT DMY
INSERT INTO clientes(nom_cliente, sexo_cliente, fecha_alta) VALUES ('Tomás', 1, '04/10/2022')
INSERT INTO clientes(nom_cliente, sexo_cliente, fecha_alta) VALUES ('Maria', 0, '15/08/2023')
GO
INSERT INTO tipo_mascotas(decripcion, fecha_alta) VALUES ('Perro', '01/01/2022')
INSERT INTO tipo_mascotas(decripcion, fecha_alta) VALUES ('Gato', '01/01/2022')
INSERT INTO tipo_mascotas(decripcion, fecha_alta) VALUES ('Araña', '01/01/2022')
INSERT INTO tipo_mascotas(decripcion, fecha_alta) VALUES ('Iguana', '01/01/2022')
GO
INSERT INTO mascotas(nom_mascota, tipo_mascota, fecha_nacimiento, cod_dueno, fecha_alta) VALUES ('Boby', 1, '20/05/2022', 1, '29/12/2022')
INSERT INTO mascotas(nom_mascota, tipo_mascota, fecha_nacimiento, cod_dueno, fecha_alta) VALUES ('Pelusa', 2, '30/03/2021', 1, '04/10/2022')
INSERT INTO mascotas(nom_mascota, tipo_mascota, fecha_nacimiento, cod_dueno, fecha_alta) VALUES ('Kosmo', 3, '10/05/2022', 2, '10/05/2022')
INSERT INTO mascotas(nom_mascota, tipo_mascota, fecha_nacimiento, cod_dueno, fecha_alta) VALUES ('Cactus', 4, '02/06/2023', 2, '15/08/2023')
GO
INSERT INTO atenciones(descripcion, importe, fecha_atencion, cod_mascota) VALUES ('Vacunación Completa', 600,'29/12/2022', 1)
INSERT INTO atenciones(descripcion, importe, fecha_atencion, cod_mascota) VALUES ('Castración', 200,'04/10/2022', 2)
INSERT INTO atenciones(descripcion, importe, fecha_atencion, cod_mascota) VALUES ('Revisión', 900,'15/08/2023', 4)
