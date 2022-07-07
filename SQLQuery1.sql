CREATE DATABASE ActivosFijos
--DROP DATABASE ActivosFijos
USE ActivosFijos

GO
CREATE TABLE Departamentos (
	DepID int NOT NULL IDENTITY(1, 1),
	Descripcion varchar(100) NOT NULL,
	Estado bit,
	PRIMARY KEY (DepID)
)
GO
--TRUNCATE TABLE Departamentos;

GO
CREATE TABlE TipoDeActivos (
	TActivoID int NOT NULL IDENTITY(1, 1),
	Descripcion varchar(100) NOT NULL,
	CCCompra int NOT NULL, 
	CCDepreciacion int NOT NULL, 
	Estado bit,
	PRIMARY KEY (TActivoID)
)
GO
--DROP TABLE TipoDeActivos;

GO
CREATE TABlE Empleados (
	EmpID int NOT NULL IDENTITY(1, 1),
	Nombre varchar(100) NOT NULL,
	Cedula numeric(11,0) NOT NULL,
	DepID int NOT Null,
	Usuario varchar(50) NOT NULL,
	Clave varchar(50) NOT NULL,
	FechaIngreso date NOT NULL,
	Estado bit NOT NULL,
	PRIMARY KEY (EmpID),
	FOREIGN KEY (DepID) REFERENCES Departamentos(DepID)
)
GO
--DROP TABLE Empleados;

GO
CREATE TABlE ActivosFijos (
	AFijoID int NOT NULL IDENTITY(1, 1),
	Descripcion varchar(100) NOT NULL,
	DepID int NOT Null,
	TActivoID int NOT NULL,
	FechaRegistro date NOT NULL,
	Valor decimal(10, 2) NOT NULL,
	DepreAcumulada decimal(10, 2) NOT NULL,
	PRIMARY KEY (AFijoID),
	FOREIGN KEY (DepID) REFERENCES Departamentos(DepID),
	FOREIGN KEY (TActivoID) REFERENCES TipoDeActivos(TActivoID)
)
GO
--DROP TABLE ActivosFijos;

INSERT INTO Departamentos 
VALUES 
	('Finanzas', 0),
	('RRHH', 0),
	('Tecnologia', 1),
	('Administracion', 0),
	('Marketing', 0),
	('Compras', 0),
	('Logistica y Operaciones', 0),
	('Control de Gestion', 0);

--UPDATE Departamentos SET Descripcion = 'Mensajeria' WHERE DepID = 2

Select * From Departamentos