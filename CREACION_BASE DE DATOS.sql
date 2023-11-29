
--Creacion de base de datos 

CREATE DATABASE  bd_CitasMedicas

CREATE DATABASE bd_CitasMedicas
ON PRIMARY (
	NAME = 'bd_CitasMedicas_DATA',
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.HAL_9001\MSSQL\DATA\bd_CitasMedicas.mdf',
	SIZE = 50,
	MAXSIZE = UNLIMITED,
	FILEGROWTH = 10%
)
LOG ON (
	NAME = 'bd_CitasMedicas_LOG',
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.HAL_9001\MSSQL\DATA\bd_CitasMedicas_LOG.ldf',
	SIZE = 25,
	MAXSIZE = 250,
	FILEGROWTH = 5%
)

--Usa la base de datos recién creada

use bd_CitasMedicas

--Crear tablas

create table Pacientes(
	idPaciente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	pacDNi char(8) NOT NULL,
	pacNombres NVARCHAR(50) not null,
	pacApellidos VARCHAR(50) not null,
	pacEdad int not null,
	pacGenero char(1) not null,
	pacCelular varchar(15),
	pacEmail varchar(30),
)

Create table Citas (
idCitas int IDentity (1,1) PRIMARY KEY not null,
idPaciente int not null
CONSTRAINT FK_Pacientes_Citas FOREIGN KEY
			REFERENCES Pacientes(idPaciente),
ctCodigo char(10) not null,
ctFechaRegistro datetime not null,last_name
ctFechaCita datetime not null,
ctEspecialidad nvarchar(20) not null,
ctMedico nvarchar(50),
ctEstado nvarchar(20),
ctDiagnostico nvarchar(200) not null,
ctCosto money
)

--Editar el atribudo ctCodigo

alter table Citas add constraint ctCodigo unique(ctCodigo)


--verificando...
select * from Pacientes

select * from Citas

--ingresado datos randow en pacientes

insert into Pacientes (pacDNi, pacNombres, pacApellidos, pacEdad, pacGenero, pacCelular, pacEmail) values (32635408, 'Bernie', 'Crosoer', 23, 'F', 927377307, 'bcrosoer0@tiny.cc');
insert into Pacientes (pacDNi, pacNombres, pacApellidos, pacEdad, pacGenero, pacCelular, pacEmail) values (55993705, 'Otis', 'Sandle', 40, 'F', 913881806, 'osandle1@hugedomains.com');
insert into Pacientes (pacDNi, pacNombres, pacApellidos, pacEdad, pacGenero, pacCelular, pacEmail) values (89837281, 'Dena', 'Le Noir', 19, 'F', 940340671, 'dlenoir2@vistaprint.com');

--ingresado datos randow en citas


insert into Citas (idPaciente, ctCodigo, ctFechaRegistro, ctFechaCita, ctEspecialidad, ctMedico, ctEstado, ctDiagnostico, ctCosto) values (1, 3934643065, '6/18/2023', '9/2/2023', 'Cardiología', 'Ophelia', 'ppullam porttitor', 'In hac habitasse', '$8.26');
insert into Citas (idPaciente, ctCodigo, ctFechaRegistro, ctFechaCita, ctEspecialidad, ctMedico, ctEstado, ctDiagnostico, ctCosto) values (2, 7760389554, '7/29/2023', '8/5/2023', 'Odontología', 'Brendis', 'Fusce consequat.', 'Maecenas tincidunt lacus at velit.', '$3.70');
insert into Citas (idPaciente, ctCodigo, ctFechaRegistro, ctFechaCita, ctEspecialidad, ctMedico, ctEstado, ctDiagnostico, ctCosto) values (3, 1920199510, '10/7/2023', '11/27/2022', 'Medicina General', 'Sonnie', 'Nullam sit amet.', 'Sed sagittis. Nam congue, risus semper.', '$1.11');


--verificando...
select * from Pacientes

select * from Citas






