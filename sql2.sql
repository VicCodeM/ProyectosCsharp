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

ALTER TABLE Bitacora ALTER COLUMN Id_Orden INT NULL;

--datos originales
SET IDENTITY_INSERT Departamentos ON;

INSERT INTO Departamentos (Id_Departamento, Nombre_Departamento) VALUES
(5101, 'DIRECCION EJECUTIVA'),
(5111, 'DIRECCION FINANCIERA'),
(5121, 'CONTABILIDAD'),
(5131, 'INGRESOS'),
(5141, 'DIRECCION ADMINISTRATIVA'),
(5151, 'RECURSOS MATERIALES'),
(5161, 'SISTEMAS'),
(5171, 'CENTRO DE INFORMACION'),
(5201, 'DIRECCION COMERCIAL'),
(5211, 'MEDICION'),
(5221, 'REZAGO'),
(5241, 'PADRON DE USUARIOS'),
(5251, 'EJECUCION Y COBRANZA'),
(5301, 'DIRECCION TECNICA'),
(5311, 'COMITES RURALES'),
(5321, 'CALIDAD DEL AGUA'),
(5341, 'POZOS'),
(5342, 'REDES DE DISTRIBICION'),
(5344, 'ESTUDIOS Y PROYECTOS'),
(5401, 'SANEAMIENTO'),
(5411, 'PTAR');

SET IDENTITY_INSERT Departamentos OFF;

SET IDENTITY_INSERT Empleados ON;

INSERT INTO Empleados (
    Id_Empleado, 
    Id_Departamento, 
    Nombre_Empleado, 
    Apellido_Paterno, 
    Apellido_Materno, 
    Correo_Electronico
)
VALUES
(12, 5301, 'NORMA PATRICIA', 'PEREZ', 'HERNANDEZ', ''),
(32, 5241, 'HECTOR ARMANDO', 'MORALES', 'REYES', ''),
(79, 5201, 'PATRICIA', 'RICO', 'DE LA ROSA', ''),
(93, 5151, 'LUZ MARIA', 'GUEVARA', 'FELIZ', ''),
(109, 5151, 'JUAN GABRIEL', 'LOPEZ', 'ORTIZ', ''),
(121, 5131, 'RAMON ANTONIO', 'GONZALEZ', 'MIRAMONTES', ''),
(170, 5201, 'HUMBERTO', 'GONZALEZ', 'MIRAMONTES', ''),
(234, 5111, 'SONIA GUADALUPE', 'ARMENDARIZ', 'NARANJO', ''),
(235, 5344, 'FELIPE', 'ONTIVEROS', 'TECLA', ''),
(244, 5342, 'LEOPOLDO', 'CARDENAS', 'PEREZ', ''),
(312, 5121, 'MIRIAM ELIZABET', 'CASTAÑON', 'DIAZ', ''),
(331, 5342, 'PEDRO', 'REAZA', 'LICON', ''),
(334, 5342, 'ALMA DELIA', 'BARAY', 'PEDROZA', ''),
(336, 5344, 'JUAN MANUEL', 'SAM LEE', 'GRANADOS', ''),
(343, 5401, 'JAIME', 'RAMOS', 'JUAREZ', ''),
(364, 5321, 'SILVIA VIRGINA', 'ANDRADE', 'QUIÑONES', ''),
(384, 5111, 'CELY FLOR', 'MENDOZA', 'LEGARDA', ''),
(391, 5161, 'SERGIO ENRIQUE', 'FIERRO', 'ORDOÑEZ', ''),
(395, 5151, 'ADOLFO', 'LARA', 'CHAVEZ', ''),
(416, 5342, 'DAVID', 'AGUIRRE', 'RAMOS', ''),
(418, 5141, 'ARMANDO', 'FLORES', 'CARRILLO', ''),
(424, 5342, 'JOSE DE JESUS', 'GUZMAN', 'ESPARZA', ''),
(425, 5342, 'DAVID', 'DIAZ', 'SALINAS', ''),
(429, 5121, 'NORMA LETICIA', 'RIVAS', 'GONZALEZ', ''),
(440, 5211, 'FLOR SUSANA', 'ARMENDARIZ', 'NARANJO', ''),
(450, 5241, 'ALVARO', 'LOYA', 'DIAZ', ''),
(461, 5151, 'CELSO', 'ORDOÑEZ', 'AVIÑA', ''),
(462, 5151, 'JOSE DOLORES', 'ORTEGA', 'CHAVEZ', ''),
(465, 5221, 'DANIEL', 'SIGALA', 'REYES', ''),
(469, 5344, 'LUIS FEDERICO', 'NAJERA', 'AGUIRRE', ''),
(473, 5201, 'JORGE', 'MANJARREZ', 'TAPIA', ''),
(474, 5211, 'FRANCISCO', 'ESTRADA', 'OLIVAS', ''),
(475, 5342, 'ROBERTO', 'GALAVIZ', 'SERRANO', ''),
(501, 5131, 'ALIN', 'MENDOZA', 'TORRES', ''),
(506, 5342, 'BRIGIDO', 'MANCINAS', 'LOYA', ''),
(507, 5201, 'CAYETANO', 'MENDOZA', 'HERNANDEZ', ''),
(521, 5344, 'MARCELO', 'FELIX', 'MENDOZA', ''),
(524, 5201, 'GERARDO', 'MOLINAR', 'MARTINEZ', ''),
(527, 5211, 'JOSE MANUEL', 'CISNEROS', 'RAMIREZ', ''),
(531, 5342, 'JUAN MANUEL', 'PORTILLO', 'SIMENTAL', ''),
(541, 5321, 'MARISELA', 'ROJO', 'ARMENTA', ''),
(555, 5211, 'LEONEL HIPOLITO', 'BABONOYABA', 'OLIVAS', ''),
(557, 5311, 'DANIEL IVAN', 'MENDOZA', 'CHAVEZ', ''),
(569, 5301, 'JESUS ARNOLDO', 'LUNA', 'PEREZ', ''),
(587, 5131, 'RAMONA ISELA', 'CARRASCO', 'GONZALEZ', ''),
(589, 5221, 'BIBIANO', 'MANJARREZ', 'ZAMARRON', ''),
(592, 5342, 'GERMAN AARON', 'RODRIGUEZ', 'JAIME', ''),
(607, 5342, 'MARCO ANTONIO', 'GUZMAN', 'MORALES', ''),
(611, 5201, 'MARTHA PAOLA', 'DELGADO', 'CONTRERAS', ''),
(616, 5341, 'JORGE LUIS', 'PRIETO', 'RODRIGUEZ', ''),
(618, 5342, 'ARNOLDO', 'NUÑEZ', 'ACOSTA', ''),
(634, 5131, 'YADIRA', 'RODRIGUEZ', 'QUEZADA', ''),
(648, 5241, 'IVAN AMERICO', 'ORTIZ', 'CADENA', ''),
(650, 5211, 'EMILIO', 'ORDOÑEZ', 'NAJERA', ''),
(656, 5342, 'REYES', 'NUÑEZ', '', ''),
(660, 5342, 'JORGE ALEJANDRO', 'HERNANDEZ', 'PARRA', ''),
(664, 5342, 'JAVIER', 'MOLINA', 'AVILES', ''),
(667, 5201, 'CLAUIDA ILIANA', 'MIRELES', 'CORRAL', ''),
(670, 5211, 'CARLOS HORACIO', 'CANO', 'GONZALEZ', ''),
(672, 5342, 'ERICK MIGUEL', 'MOLINA', 'AVILES', ''),
(674, 5411, 'EFRAIN', 'LEGARDA', 'RAMIREZ', ''),
(678, 5411, 'ALEXIS', 'HERMOSILLO', 'DOMINGUEZ', ''),
(681, 5211, 'ERIKA SELENE', 'CORRAL', 'GONZALEZ', ''),
(690, 5211, 'ANGEL GILDARDO', 'ZAPATA', 'LOZANO', ''),
(691, 5211, 'CARLOS', 'LICANO', 'GONZALEZ', ''),
(692, 5211, 'EIDDY YARDIEL', 'HERNANDEZ', 'GONZALEZ', ''),
(693, 5342, 'ARTTURO AMARO', 'GAYTAN', 'MANJARREZ', ''),
(695, 5211, 'OTONIEL', 'MONTES', 'PINELA', ''),
(698, 5211, 'ALEX JESUA', 'CHAVEZ', 'OTERO', ''),
(704, 5211, 'ESTEBAN', 'VAZQUEZ', 'CASTILLO', ''),
(705, 5211, 'LUIS GUADALUPE', 'MORENO', 'LUNA', ''),
(706, 5211, 'JOSE IVAN', 'SANDIVAL', 'MARTINEZ', ''),
(710, 5342, 'RAFAEL HUMBERTO', 'NUÑEZ', 'CANO', ''),
(716, 5151, 'ALFREDO', 'RODELAS', 'MARTINEZ', ''),
(717, 5301, 'JULIAN', 'CARDENAS', 'GARCIA', ''),
(718, 5342, 'MONSERRATE', 'CERVANTES', 'GONZALEZ', ''),
(721, 5211, 'EVER OMAR', 'VILLALBA', 'CARO', ''),
(724, 5201, 'KAREN ITZEL', 'BANDA', 'DURAN', ''),
(726, 5342, 'JONATHAN URIEL', 'ARAGONEZ', 'QUEZADA', ''),
(728, 5131, 'RUBI', 'ORDOÑEZ', 'AGUILAR', ''),
(731, 5101, 'MIGUEL ANGEL', 'LOPEZ', 'GRANADOS', ''),
(733, 5342, 'HECTOR ALAN', 'SAENZ', 'CHAVEZ', ''),
(734, 5201, 'ALAN', 'DE LA PEÑA', 'RODRIGUEZ', ''),
(736, 5342, 'JOSE LUIS', 'MIRAMONTES', 'DELGADILLO', ''),
(737, 5321, 'LUIS ANGEL', 'GONZALEZ', 'VILLA', ''),
(739, 5101, 'JAVIER ALEJANDR', 'ARZAGA', 'CANO', ''),
(740, 5201, 'GABRIELA', 'MENDOZA', 'CUEVAS', ''),
(741, 5211, 'GLADYS CECILIA', 'MARQUEZ', 'GALAVIZ', ''),
(742, 5151, 'KARLA', 'ERIVES', 'GONZALEZ', ''),
(749, 5201, 'SERGIO ULISES', 'ACOSTA', 'RASCON', ''),
(750, 5241, 'MARTIN', 'SALAZAR', 'ARANA', ''),
(752, 5401, 'ALI CESAR', 'PEREZ', 'CHACON', ''),
(753, 5141, 'HUGO MARCIAL', 'AGUILAR', 'PEÑA', ''),
(754, 5401, 'IRIS MICHELLE', 'SAENZ', 'CHAVEZ', ''),
(755, 5111, 'LOURDES LIZET', 'BLANCO', 'PEREZ', ''),
(757, 5311, 'EVA GUILLERMINA', 'GILL', 'TORRES', ''),
(758, 5201, 'REYNA LISSETH', 'ADRIANO', 'PEREZ', ''),
(759, 5131, 'EDITH ANAHI', 'PORTILLO', 'MONTES', ''),
(760, 5251, 'NOE', 'ESTRADA', 'CAMUÑEZ', ''),
(764, 5201, 'MAURICIO', 'PEÑA', 'GONZALEZ', ''),
(768, 5211, 'EDGAR', 'DE ANDA', 'GONZALEZ', ''),
(769, 5121, 'REYNA ESMERALDA', 'ESPINO', 'PALMA', ''),
(772, 5221, 'ERIC', 'GUERRERO', 'LOPEZ', ''),
(773, 5161, 'LUIS', 'GUERRERO', 'VALVERDE', ''),
(774, 5141, 'LUIS ANGEL', 'ANCHONDO', 'CHAVEZ', ''),
(775, 5101, 'MARIA LUISA', 'REYES', 'DOMINGUEZ', ''),
(776, 5111, 'LORENA', 'ARAGONEZ', 'MACIAS', ''),
(777, 5201, 'MIREYA', 'RASCON', 'DELGADO', ''),
(778, 5201, 'CECILIA ESTHER', 'SAENZ', 'TRAIANA', ''),
(780, 5341, 'HECTOR ISAC', 'FLORES', 'MACIAS', ''),
(781, 5101, 'ALONDRA', 'GUTIERREZ', 'OLIVAS', ''),
(782, 5221, 'BRANDON ALEXIS', 'TARANGO', 'QUEZADA', ''),
(783, 5201, 'JOSE LUIS', 'REYES', 'ORTIZ', ''),
(784, 5211, 'CARLOS', 'HUGO', 'LOZANO', ''),
(786, 5221, 'LUIS ARMANDO', 'GIRON', 'MIRANDA', ''),
(789, 5342, 'RICARDO', 'HERNANDEZ', 'PARRA', ''),
(790, 5241, 'VICTOR MANUEL', 'GARCIA', 'FRESCAS', ''),
(794, 5221, 'EDWIN ALAN', 'SIERRA', 'CASTILLO', ''),
(795, 5411, 'FRANCISCO MANUE', 'HERMOSILLO', 'CHAVARRIA', ''),
(796, 5131, 'NABIL', 'CARMONA', 'MONCLOVA', ''),
(797, 5211, 'EDGAR ULISES', 'RASCON', 'CASTELLANO', ''),
(798, 5131, 'ESTEFANY', 'GARCIA', 'NUÑEZ', ''),
(799, 5201, 'EDGAR RICARDO', 'CASTILLO', 'DELGADO', ''),
(800, 5151, 'ORIAN ABRIL', 'CHAVEZ', 'CHUMACERO', ''),
(802, 5251, 'LUIS ANGEL', 'VAZQUEZ', 'RAMIREZ', ''),
(803, 5301, 'RENE EDUARDO', 'ARAGONEZ', 'QUEZADA', ''),
(805, 5301, 'LORENZO', 'MACIAS', 'LEGARDA', ''),
(806, 5141, 'NORMA IVETTE', 'LERMA', 'CORDOVA', ''),
(810, 5221, 'IMANOL', 'BUENROSTRO', 'CHAVEZ', ''),
(815, 5241, 'ALEJANDRO', 'LOYA', 'LOYA', ''),
(817, 5301, 'MARTIN ALONSO', 'RUIZ', 'FERNANDEZ', ''),
(819, 5301, 'RICARDO', 'VILLALBA', 'CARO', ''),
(826, 5342, 'DANIEL ANTONIO', 'HERNANDEZ', 'PEREZ', ''),
(827, 5342, 'PAUL ALEJANDRO', 'CONTRERAS', 'MANJARREZ', ''),
(830, 5201, 'VICTOR ROBERTO', 'SAENZ', 'ROJAS', ''),
(831, 5342, 'CESAR ADRIAN', 'PEÑA', 'LOYA', ''),
(832, 5141, 'GERALDINE', 'LOYA', 'MENDEZ', ''),
(833, 5251, 'DIANA ARELI', 'ORTEGA', 'GARCIA', ''),
(840, 5311, 'LUIS RAUL', 'PEREZ', 'TREJO', ''),
(841, 5342, 'CRISTIAN ALEXIS', 'CAMARENA', 'RENTERIA', ''),
(844, 5211, 'UVER OMAR', 'CALZADILLAS', 'MALDONADO', ''),
(845, 5344, 'ERIC ARNOLDO', 'RIVERA', 'MARTINEZ', ''),
(851, 5151, 'SAUL', 'SERVIN', 'VEGA', ''),
(853, 5344, 'IRAM ROMEL', 'CHAVEZ', 'LERMA', ''),
(856, 5201, 'RICARDO EPIFANO', 'ARREAGA', 'BANDA', ''),
(861, 5342, 'JOEL', 'GARCIA', 'ESCUDERO', ''),
(862, 5342, 'JAVIER ALEJANDR', 'MACIAS', 'GARCIA', ''),
(863, 5342, 'LUIS', 'GUTIERREZ', 'QUEZADA', ''),
(864, 5211, 'CESAR MIGUEL', 'CARREON', 'MORENO', ''),
(869, 5221, 'PEDRO EMMANUEL', 'ARMENDARIZ', 'CHACON', ''),
(875, 5342, 'RAFAEL', 'CONTRERAS', 'POLANCO', ''),
(876, 5342, 'MARTIN ALFREDO', 'ESPINOZA', 'GUEREQUE', ''),
(879, 5342, 'LUIS RAUL', 'NUÑEZ', 'RASCON', ''),
(882, 5151, 'RENE SALVADOR', 'AGUIRRE', 'RIVAS', ''),
(883, 5241, 'OSCAR GABRIEL', 'GONZALEZ', 'MARTINEZ', ''),
(884, 5241, 'JOSTTIN ADRIAN', 'BLANCO', 'GONZALEZ', ''),
(885, 5141, 'MARCELA', 'MALDONADO', 'OCHOA', ''),
(886, 5342, 'DIEGO ALBERTO', 'LOPEZ', 'MALDONADO', ''),
(887, 5344, 'JAZMIN', 'MARQUEZ', 'BUSTAMANTE', ''),
(888, 5131, 'LYDIA JUDITH', 'OCHOA', 'ORDOÑEZ', ''),
(890, 5161, 'NATANAEL', 'TORRES', 'MARQUEZ', ''),
(891, 5141, 'ANGEL JESUS', 'FIGUEROA', '', ''),
(892, 5241, 'JOAQUIN ARIBEL', 'DOMINGUEZ', 'MACIAS', '');

SET IDENTITY_INSERT Empleados OFF;


-- Insertar departamentos
INSERT INTO Departamentos (Nombre_Departamento) VALUES 
('Sistemas'),
('Recursos Humanos'),
('Soporte Técnico');

-- Insertar empleados
INSERT INTO Empleados (Id_Departamento, Nombre_Empleado, Apellido_Paterno, Apellido_Materno, Correo_Electronico) VALUES 
(1, 'Juan', 'Pérez', 'Gómez', 'juan.perez@sistema.com'),
(2, 'Ana', 'López', 'Martínez', 'ana.lopez@rh.com'),
(3, 'Carlos', 'Hernández', 'Ruiz', 'carlos.hernandez@soporte.com');

-- Insertar usuarios en la tabla Login
INSERT INTO Login (Usuario, Password, Tipo_Usuario, Id_Empleado) VALUES 
('admin', 'Admin123', 'Admin', 1), 
('ana.rh', 'RH2024', 'Nivel2', 2), 
('carlos.soporte', 'Soporte321', 'Nivel3', 3);


-- Insertar tipos de fallas de hardware
INSERT INTO TiposFallaHardware (Descripcion) VALUES 
('Fallo en el disco duro'),
('Problema con la memoria RAM'),
('Sobrecalentamiento del procesador'),
('Fuente de poder defectuosa'),
('Pantalla no enciende'),
('Problema con la tarjeta de red');

-- Insertar tipos de fallas de software
INSERT INTO TiposFallaSoftware (Descripcion) VALUES 
('Error en el sistema operativo'),
('Problema con la instalación de software'),
('Virus o malware detectado'),
('Error en la configuración de red'),
('Aplicación no responde'),
('Incompatibilidad de software');


INSERT INTO Bitacora (Id_Orden, Id_Usuario, Accion, Descripcion)  
VALUES (1, 2, 'Modificación', 'Se actualizó la descripción del problema.');
