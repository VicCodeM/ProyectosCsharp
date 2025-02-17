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
  Correo_Electronico VARCHAR(255) NULL,
  CONSTRAINT FK_Empleados_Departamentos FOREIGN KEY (Id_Departamento) REFERENCES Departamentos(Id_Departamento)
);

CREATE TABLE Login (
  Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
  Usuario VARCHAR(255) UNIQUE NOT NULL,
  Password VARCHAR(255) NOT NULL,
  Tipo_Usuario VARCHAR(50) NOT NULL CHECK(Tipo_Usuario IN ('Admin', 'RH', 'RM','General','N5', 'N6')),
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
  Id_Orden INT NULL,
  Id_Usuario INT NOT NULL,
  Accion VARCHAR(255) NOT NULL,
  Fecha_Accion DATETIME NOT NULL DEFAULT GETDATE(),
  Descripcion TEXT NULL,
  Id_Empleado INT NULL,
  CONSTRAINT FK_Bitacora_OrdenServicio FOREIGN KEY (Id_Orden) REFERENCES OrdenServicio(Id_Orden),
  CONSTRAINT FK_Bitacora_Login FOREIGN KEY (Id_Usuario) REFERENCES Login(Id_Usuario)
);
