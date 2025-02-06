CREATE TABLE Departamentos (
  Id_Departamento INT IDENTITY(1,1) PRIMARY KEY,
  Nombre_Departamento VARCHAR(255) NOT NULL
);

CREATE TABLE Empleados (
  Id_Empleado INT IDENTITY(1,1) PRIMARY KEY,
  Id_Departamento INT NOT NULL,
  Nombre_Empleado VARCHAR(255) NOT NULL,
  Apellido_Paterno VARCHAR(255) NOT NULL,
  Apellido_Materno VARCHAR(255) NOT NULL,
  Correo_Electronico VARCHAR(255) NOT NULL,
  CONSTRAINT FK_Empleados_Departamentos FOREIGN KEY (Id_Departamento) REFERENCES Departamentos(Id_Departamento)
);

CREATE TABLE Login (
  Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
  Usuario VARCHAR(255) UNIQUE NOT NULL,
  Password VARCHAR(255) NOT NULL,
  Tipo_Usuario VARCHAR(50) NOT NULL CHECK(Tipo_Usuario IN ('Admin', 'Nivel2', 'Nivel3','Nivel4','Nivel5', 'Nivel6')),
  Id_Empleado INT UNIQUE NOT NULL,
  CONSTRAINT FK_Login_Empleados FOREIGN KEY (Id_Empleado) REFERENCES Empleados(Id_Empleado) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE TiposFallaHardware (
  Id_TipoFallaHardware INT IDENTITY(1,1) PRIMARY KEY,
  Descripcion VARCHAR(255) NOT NULL
);

CREATE TABLE TiposFallaSoftware (
  Id_TipoFallaSoftware INT IDENTITY(1,1) PRIMARY KEY,
  Descripcion VARCHAR(255) NOT NULL
);

CREATE TABLE OrdenServicio (
  Id_Orden INT IDENTITY(1,1) PRIMARY KEY,
  Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
  Fecha_Atendida DATETIME NULL,
  Fecha_Cerrada DATETIME NULL,
  Id_Usuario INT NOT NULL,
  Id_TipoFallaHardware INT NULL,
  Id_TipoFallaSoftware INT NULL,
  Descripcion_Problema TEXT NOT NULL,
  Observaciones TEXT NULL,
  Estado VARCHAR(50) NOT NULL CHECK(Estado IN ('Abierto' , 'Pendiente', 'Completado', 'Cancelado')),
  CONSTRAINT FK_OrdenServicio_Login FOREIGN KEY (Id_Usuario) REFERENCES Login(Id_Usuario),
  CONSTRAINT FK_OrdenServicio_TiposFallaHardware FOREIGN KEY (Id_TipoFallaHardware) REFERENCES TiposFallaHardware(Id_TipoFallaHardware),
  CONSTRAINT FK_OrdenServicio_TiposFallaSoftware FOREIGN KEY (Id_TipoFallaSoftware) REFERENCES TiposFallaSoftware(Id_TipoFallaSoftware)
);

CREATE TABLE Bitacora (
    Id_Bitacora INT IDENTITY(1,1) PRIMARY KEY,
    Fecha_Accion DATETIME NOT NULL DEFAULT GETDATE(),
    Id_Usuario INT NOT NULL,
    Accion VARCHAR(255) NOT NULL,
    Id_Orden INT NOT NULL,
    Estado_Anterior VARCHAR(50),
    Estado_Nuevo VARCHAR(50),
    Fecha_Atendida DATETIME,
    Fecha_Cerrada DATETIME,
    Descripcion VARCHAR(MAX),
    Observaciones VARCHAR(MAX),
    CONSTRAINT FK_Bitacora_Login FOREIGN KEY (Id_Usuario) REFERENCES Login(Id_Usuario)
);


CREATE TABLE Bitacora (
    Id_Bitacora INT IDENTITY(1,1) PRIMARY KEY,
    Fecha_Accion DATETIME NOT NULL DEFAULT GETDATE(),
    Id_Usuario INT NOT NULL,
    Accion VARCHAR(255) NOT NULL,
    Id_Orden INT NOT NULL, -- Para saber cuál orden se modificó o eliminó
    Estado_Anterior VARCHAR(50),
    Estado_Nuevo VARCHAR(50),
    Fecha_Atendida_Anterior DATETIME,
    Fecha_Cerrada_Anterior DATETIME,
    Descripcion_Anterior VARCHAR(MAX),  -- Cambio de TEXT a VARCHAR(MAX)
    Observaciones_Anterior VARCHAR(MAX), -- Cambio de TEXT a VARCHAR(MAX)
    CONSTRAINT FK_Bitacora_Login FOREIGN KEY (Id_Usuario) REFERENCES Login(Id_Usuario)
);

------------------------------------------------------------------------------------------------------------------
--trigger
CREATE TRIGGER trg_OrdenServicio_Update
ON OrdenServicio
AFTER UPDATE
AS
BEGIN
    DECLARE 
        @Id_Orden INT, 
        @Estado_Anterior VARCHAR(50), 
        @Estado_Nuevo VARCHAR(50), 
        @Fecha_Atendida_Anterior DATETIME, 
        @Fecha_Cerrada_Anterior DATETIME, 
        @Descripcion_Anterior VARCHAR(MAX), 
        @Observaciones_Anterior VARCHAR(MAX), 
        @Fecha_Atendida_Nueva DATETIME, 
        @Fecha_Cerrada_Nueva DATETIME, 
        @Descripcion_Nueva VARCHAR(MAX), 
        @Observaciones_Nuevas VARCHAR(MAX), 
        @Id_Usuario INT;

    -- Obtener los datos anteriores y nuevos
    SELECT 
        @Id_Orden = inserted.Id_Orden,
        @Estado_Nuevo = inserted.Estado,
        @Estado_Anterior = deleted.Estado,
        @Fecha_Atendida_Anterior = deleted.Fecha_Atendida,
        @Fecha_Cerrada_Anterior = deleted.Fecha_Cerrada,
        @Descripcion_Anterior = CAST(deleted.Descripcion_Problema AS VARCHAR(MAX)),
        @Observaciones_Anterior = CAST(deleted.Observaciones AS VARCHAR(MAX)),
        @Fecha_Atendida_Nueva = inserted.Fecha_Atendida,
        @Fecha_Cerrada_Nueva = inserted.Fecha_Cerrada,
        @Descripcion_Nueva = CAST(inserted.Descripcion_Problema AS VARCHAR(MAX)),
        @Observaciones_Nuevas = CAST(inserted.Observaciones AS VARCHAR(MAX)),
        @Id_Usuario = inserted.Id_Usuario
    FROM inserted
    INNER JOIN deleted ON inserted.Id_Orden = deleted.Id_Orden;

    -- Insertar en la tabla Bitacora
    INSERT INTO Bitacora 
    (Fecha_Accion, Id_Usuario, Accion, Id_Orden, 
    Estado_Anterior, Estado_Nuevo, Fecha_Atendida, 
    Fecha_Cerrada, Descripcion, Observaciones)
    VALUES 
    (GETDATE(), @Id_Usuario, 'Actualización de Orden', @Id_Orden, 
    @Estado_Anterior, @Estado_Nuevo, @Fecha_Atendida_Anterior, 
    @Fecha_Cerrada_Anterior, @Descripcion_Anterior, @Observaciones_Anterior);
    
    -- Insertar en la tabla Bitacora para cambios nuevos
    INSERT INTO Bitacora 
    (Fecha_Accion, Id_Usuario, Accion, Id_Orden, 
    Estado_Anterior, Estado_Nuevo, Fecha_Atendida, 
    Fecha_Cerrada, Descripcion, Observaciones)
    VALUES 
    (GETDATE(), @Id_Usuario, 'Actualización de Orden', @Id_Orden, 
    @Estado_Anterior, @Estado_Nuevo, @Fecha_Atendida_Nueva, 
    @Fecha_Cerrada_Nueva, @Descripcion_Nueva, @Observaciones_Nuevas);
END;

CREATE TRIGGER trg_OrdenServicio_Delete
ON OrdenServicio
AFTER DELETE
AS
BEGIN
    DECLARE @Id_Orden INT, 
            @Estado_Anterior VARCHAR(50), 
            @Estado_Nuevo VARCHAR(50), 
            @Fecha_Atendida_Anterior DATETIME, 
            @Fecha_Cerrada_Anterior DATETIME, 
            @Descripcion_Anterior VARCHAR(MAX),  
            @Observaciones_Anterior VARCHAR(MAX), 
            @Id_Usuario INT;

    -- Obtener los datos de la tabla deleted (la orden eliminada)
    SELECT @Id_Orden = deleted.Id_Orden,
           @Estado_Anterior = deleted.Estado,
           @Fecha_Atendida_Anterior = deleted.Fecha_Atendida,
           @Fecha_Cerrada_Anterior = deleted.Fecha_Cerrada,
           @Descripcion_Anterior = deleted.Descripcion_Problema,
           @Observaciones_Anterior = deleted.Observaciones,
           @Id_Usuario = deleted.Id_Usuario
    FROM deleted;

    -- Insertar en la tabla Bitacora
    INSERT INTO Bitacora (Fecha_Accion, Id_Usuario, Accion, Id_Orden, 
                          Estado_Anterior, Estado_Nuevo, Fecha_Atendida, 
                          Fecha_Cerrada, Descripcion, Observaciones)
    VALUES (GETDATE(), @Id_Usuario, 'Eliminación de Orden', @Id_Orden, 
            @Estado_Anterior, NULL, @Fecha_Atendida_Anterior, 
            @Fecha_Cerrada_Anterior, @Descripcion_Anterior, @Observaciones_Anterior);
END;




--procedimeintos ordenes de OrdenServicio
CREATE PROCEDURE sp_InsertarOrdenServicio
    @Id_Usuario INT,
    @Descripcion_Problema TEXT,
    @Id_TipoFallaHardware INT,
    @Id_TipoFallaSoftware INT,
    @Estado VARCHAR(50)
AS
BEGIN
    INSERT INTO OrdenServicio (Id_Usuario, Descripcion_Problema, Id_TipoFallaHardware, Id_TipoFallaSoftware, Estado)
    VALUES (@Id_Usuario, @Descripcion_Problema, @Id_TipoFallaHardware, @Id_TipoFallaSoftware, @Estado)
END
GO
--actualizar orden
CREATE PROCEDURE sp_ActualizarOrdenServicio
    @Id_Orden INT,
    @Id_Usuario INT,
    @Descripcion_Problema TEXT,
    @Id_TipoFallaHardware INT,
    @Id_TipoFallaSoftware INT,
    @Estado VARCHAR(50)
AS
BEGIN
    UPDATE OrdenServicio
    SET Id_Usuario = @Id_Usuario,
        Descripcion_Problema = @Descripcion_Problema,
        Id_TipoFallaHardware = @Id_TipoFallaHardware,
        Id_TipoFallaSoftware = @Id_TipoFallaSoftware,
        Estado = @Estado
    WHERE Id_Orden = @Id_Orden
END
GO

-- eliminar orden
CREATE PROCEDURE sp_EliminarOrdenServicio
    @Id_Orden INT
AS
BEGIN
    DELETE FROM OrdenServicio
    WHERE Id_Orden = @Id_Orden
END
GO
--------------------------------------------------------------------
-- CONSULTAS 
-- consulta general
SELECT 
  o.Id_Orden AS 'ID de Orden',
  l.Usuario AS 'Usuario',
  o.Fecha_Creacion AS 'Fecha de Creación',
  o.Fecha_Atendida AS 'Fecha de Atención',
  o.Fecha_Cerrada AS 'Fecha de Cierre',
  CASE 
    WHEN tfh.Descripcion IS NOT NULL THEN tfh.Descripcion
    ELSE tfs.Descripcion
  END AS 'Tipo de Falla',
  o.Descripcion_Problema AS 'Descripción del Problema',
  o.Observaciones AS 'Observaciones',
  o.Estado AS 'Estado (Status)'
FROM 
  OrdenServicio o
  INNER JOIN Login l ON o.Id_Usuario = l.Id_Usuario
  LEFT JOIN TiposFallaHardware tfh ON o.Id_TipoFallaHardware = tfh.Id_TipoFallaHardware
  LEFT JOIN TiposFallaSoftware tfs ON o.Id_TipoFallaSoftware = tfs.Id_TipoFallaSoftware
ORDER BY 
  o.Fecha_Creacion DESC;

  -- consulta por usuario

  SELECT 
  o.Id_Orden AS 'ID de Orden',
  l.Usuario AS 'Usuario',
  o.Fecha_Creacion AS 'Fecha de Creación',
  CASE 
    WHEN tfh.Descripcion IS NOT NULL THEN tfh.Descripcion
    ELSE tfs.Descripcion
  END AS 'Tipo de Falla',
  o.Descripcion_Problema AS 'Descripción del Problema',
  o.Observaciones AS 'Observaciones',
  o.Fecha_Atendida AS 'Fecha de Atención',
  o.Estado AS 'Estado (Status)',
  o.Fecha_Cerrada AS 'Fecha de Cierre'
FROM 
  OrdenServicio o
  INNER JOIN Login l ON o.Id_Usuario = l.Id_Usuario
  LEFT JOIN TiposFallaHardware tfh ON o.Id_TipoFallaHardware = tfh.Id_TipoFallaHardware
  LEFT JOIN TiposFallaSoftware tfs ON o.Id_TipoFallaSoftware = tfs.Id_TipoFallaSoftware
WHERE 
  l.Usuario = 'nombre_de_usuario'
ORDER BY 
  o.Fecha_Creacion DESC;

  --CONSULTA POR HADAWARE
  SELECT 
  o.Id_Orden AS 'ID de Orden',
  l.Usuario AS 'Usuario',
  o.Fecha_Creacion AS 'Fecha de Creación',
  o.Fecha_Atendida AS 'Fecha de Atención',
  o.Fecha_Cerrada AS 'Fecha de Cierre',
  tfh.Descripcion AS 'Tipo de Falla de Hardware',
  o.Descripcion_Problema AS 'Descripción del Problema',
  o.Observaciones AS 'Observaciones',
  o.Estado AS 'Estado (Status)'
FROM 
  OrdenServicio o
  INNER JOIN Login l ON o.Id_Usuario = l.Id_Usuario
  INNER JOIN TiposFallaHardware tfh ON o.Id_TipoFallaHardware = tfh.Id_TipoFallaHardware
ORDER BY 
  o.Fecha_Creacion DESC;

  --CONSULTA POR SOFWARE
  SELECT 
  o.Id_Orden AS 'ID de Orden',
  l.Usuario AS 'Usuario',
  o.Fecha_Creacion AS 'Fecha de Creación',
  o.Fecha_Atendida AS 'Fecha de Atención',
  o.Fecha_Cerrada AS 'Fecha de Cierre',
  tfs.Descripcion AS 'Tipo de Falla de Software',
  o.Descripcion_Problema AS 'Descripción del Problema',
  o.Observaciones AS 'Observaciones',
  o.Estado AS 'Estado (Status)'
FROM 
  OrdenServicio o
  INNER JOIN Login l ON o.Id_Usuario = l.Id_Usuario
  INNER JOIN TiposFallaSoftware tfs ON o.Id_TipoFallaSoftware = tfs.Id_TipoFallaSoftware
ORDER BY 
  o.Fecha_Creacion DESC;

  -- Consulta por fechas
  SELECT 
  o.Id_Orden AS 'ID de Orden',
  l.Usuario AS 'Usuario',
  o.Fecha_Creacion AS 'Fecha de Creación',
  o.Fecha_Atendida AS 'Fecha de Atención',
  o.Fecha_Cerrada AS 'Fecha de Cierre',
  tfh.Descripcion AS 'Tipo de Falla de Hardware',
  tfs.Descripcion AS 'Tipo de Falla de Software',
  o.Descripcion_Problema AS 'Descripción del Problema',
  o.Observaciones AS 'Observaciones',
  o.Estado AS 'Estado (Status)'
FROM 
  OrdenServicio o
  INNER JOIN Login l ON o.Id_Usuario = l.Id_Usuario
  LEFT JOIN TiposFallaHardware tfh ON o.Id_TipoFallaHardware = tfh.Id_TipoFallaHardware
  LEFT JOIN TiposFallaSoftware tfs ON o.Id_TipoFallaSoftware = tfs.Id_TipoFallaSoftware
WHERE 
  o.Fecha_Creacion BETWEEN '2022-01-01' AND '2022-12-31'
ORDER BY 
  o.Fecha_Creacion DESC;

  -- por estado

SELECT 
  o.Id_Orden AS 'ID de Orden',
  l.Usuario AS 'Usuario',
  o.Fecha_Creacion AS 'Fecha de Creación',
  o.Fecha_Atendida AS 'Fecha de Atención',
  o.Fecha_Cerrada AS 'Fecha de Cierre',
  tfh.Descripcion AS 'Tipo de Falla de Hardware',
  tfs.Descripcion AS 'Tipo de Falla de Software',
  o.Descripcion_Problema AS 'Descripción del Problema',
  o.Observaciones AS 'Observaciones',
  o.Estado AS 'Estado (Status)'
FROM 
  OrdenServicio o
  INNER JOIN Login l ON o.Id_Usuario = l.Id_Usuario
  LEFT JOIN TiposFallaHardware tfh ON o.Id_TipoFallaHardware = tfh.Id_TipoFallaHardware
  LEFT JOIN TiposFallaSoftware tfs ON o.Id_TipoFallaSoftware = tfs.Id_TipoFallaSoftware
WHERE 
  o.Estado = 'Pendiente'  -- Filtrar por estado 'Pendiente'
ORDER BY 
  o.Fecha_Creacion DESC;


  --incert prueba
  INSERT INTO Departamentos (Nombre_Departamento)
VALUES 
('Recursos Humanos'),
('Desarrollo de Software'),
('Soporte Técnico'),
('Finanzas'),
('Marketing');

INSERT INTO Empleados (Id_Departamento, Nombre_Empleado, Apellido_Paterno, Apellido_Materno, Correo_Electronico)
VALUES 
(1, 'Juan', 'Pérez', 'Gómez', 'juan.perez@empresa.com'),
(2, 'María', 'López', 'Martínez', 'maria.lopez@empresa.com'),
(3, 'Carlos', 'García', 'Hernández', 'carlos.garcia@empresa.com'),
(4, 'Ana', 'Rodríguez', 'Díaz', 'ana.rodriguez@empresa.com'),
(5, 'Luis', 'Sánchez', 'González', 'luis.sanchez@empresa.com');


INSERT INTO Login (Usuario, Password, Tipo_Usuario, Id_Empleado)
VALUES 
('juanperez', '123456', 'Empleado', 1),
('marialopez', '123456', 'Empleado', 2),
('carlosgarcia', '123456', 'Empleado', 3),
('anrodriguez', '123456', 'Empleado', 4),
('lssanchez', '123456', 'Admin', 5);

INSERT INTO TiposFallaHardware (Descripcion)
VALUES 
('Falla en el disco duro'),
('Falla en la tarjeta gráfica'),
('Falla en la placa base'),
('Falla en la memoria RAM'),
('Falla en el procesador');

INSERT INTO TiposFallaSoftware (Descripcion)
VALUES 
('Error en el sistema operativo'),
('Error en la aplicación de software'),
('Error en la configuración del sistema'),
('Error en la actualización del software'),
('Error en la instalación del software');

INSERT INTO OrdenServicio (Fecha_Creacion, Fecha_Atendida, Fecha_Cerrada, Id_Usuario, Id_TipoFallaHardware, Id_TipoFallaSoftware, Descripcion_Problema, Observaciones, Estado)
VALUES 
(GETDATE(), NULL, NULL, 1, 1, NULL, 'El disco duro de mi computadora no funciona', NULL, 'Pendiente'),
(GETDATE(), NULL, NULL, 2, NULL, 2, 'La aplicación de software no se ejecuta correctamente', NULL, 'Pendiente'),
(GETDATE(), NULL, NULL, 3, 3, NULL, 'La placa base de mi computadora está dañada', NULL, 'Pendiente'),
(GETDATE(), NULL, NULL, 4, NULL, 4, 'El sistema operativo no se actualiza correctamente', NULL, 'Pendiente'),
(GETDATE(), NULL, NULL, 5, 5, NULL, 'El procesador de mi computadora está sobrecargado', NULL, 'Pendiente');



SELECT DISTINCT Estado
FROM dbo.OrdenServicio
WHERE Estado NOT IN ('Abierto', 'Pendiente', 'Completado', 'Cancelado');


ALTER TABLE dbo.OrdenServicio
ADD CONSTRAINT CK__OrdenServ__Estad__46E78A0C
CHECK (Estado IN ('Abierto', 'Pendiente', 'Completado', 'Cancelado'));


ALTER TABLE Login
DROP CONSTRAINT CK__Login__Tipo_Usua__3E52440B;

UPDATE Login
SET Tipo_Usuario = 
    CASE Tipo_Usuario
        WHEN 'Admin' THEN 1
        WHEN 'Nivel2' THEN 2
        WHEN 'Nivel3' THEN 3
        WHEN 'Nivel4' THEN 4
        WHEN 'Nivel5' THEN 5
        WHEN 'Nivel6' THEN 6
        ELSE 0  -- o algún otro valor por defecto
    END;

ALTER TABLE Login
ALTER COLUMN Tipo_Usuario INT;

--elminar ck
ALTER TABLE Login
DROP CONSTRAINT CK__Login__Tipo_Usua__3E52440B;

UPDATE Login
SET Tipo_Usuario = 
    CASE Tipo_Usuario
        WHEN 'Admin' THEN 1
        WHEN 'Nivel2' THEN 2
        WHEN 'Nivel3' THEN 3
        WHEN 'Nivel4' THEN 4
        WHEN 'Nivel5' THEN 5
        WHEN 'Nivel6' THEN 6
        ELSE 0  -- o algún otro valor por defecto
    END;

ALTER TABLE Login
ALTER COLUMN Tipo_Usuario INT;