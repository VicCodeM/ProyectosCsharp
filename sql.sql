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
  Tipo_Usuario VARCHAR(50) NOT NULL CHECK(Tipo_Usuario IN ('Admin', 'Empleado', 'Cliente')),
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
  Estado VARCHAR(50) NOT NULL CHECK(Estado IN ('Pendiente', 'En Proceso', 'Completada')),
  CONSTRAINT FK_OrdenServicio_Login FOREIGN KEY (Id_Usuario) REFERENCES Login(Id_Usuario),
  CONSTRAINT FK_OrdenServicio_TiposFallaHardware FOREIGN KEY (Id_TipoFallaHardware) REFERENCES TiposFallaHardware(Id_TipoFallaHardware),
  CONSTRAINT FK_OrdenServicio_TiposFallaSoftware FOREIGN KEY (Id_TipoFallaSoftware) REFERENCES TiposFallaSoftware(Id_TipoFallaSoftware)
);

CREATE TABLE Bitacora (
  Id_Bitacora INT IDENTITY(1,1) PRIMARY KEY,
  Fecha_Accion DATETIME NOT NULL DEFAULT GETDATE(),
  Id_Usuario INT NOT NULL,
  Accion VARCHAR(255) NOT NULL,
  Descripcion TEXT NOT NULL,
  CONSTRAINT FK_Bitacora_Login FOREIGN KEY (Id_Usuario) REFERENCES Login(Id_Usuario)
);
------------------------------------------------------------------------------------------------------------------
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