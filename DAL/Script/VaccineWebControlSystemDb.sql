
create table TiposUsuarios(TipoUsuarioId int primary key identity(1,1),
Descripcion varchar(20)
);
go
create table Provincias(ProvinciaId int primary key identity(1,1),
Descripcion varchar(100)
);
go
Create table Ciudades(CiudadId int primary key identity(1,1),
Descripcion varchar(100)
);
go
create table Municipios(MunicipioId int primary key identity(1,1),
Descripcion varchar(100)
);
go
create table Usuarios(UsuarioId int primary key identity(1,1),
Fecha date,
Imagen varchar(300),
Nombres varchar(30),
Apellidos varchar(30),
Sexo int,
Direccion varchar(100),
Cedula varchar(20),
Telefono Varchar(15),
Email varchar(50),
CiudadId int,
NombresUsuarios varchar(30),
TipoUsuario varchar(30),
Contrasena varchar(30),
);
go
create table Vacunas(VacunaId int primary key identity(1,1),
Descripcion varchar(40),
);
go
create table Pacientes(PacienteId int primary key identity(1,1),
Nombres varchar(30),
Apellidos varchar(30),
Edad int,
Sexo int,
Direccion varchar(100),
Telefono varchar(15),
Cedula varchar(20)
);
go
create table Historiales(HistorialId int primary key identity(1,1),
Fecha varchar(18),
CentroSalud varchar(50),
ProvinciaId int,
MunicipioId int,
PacienteId int,
);
go
create table HistorialDetalle(Id int primary key identity(1,1),
HistorialId int,
VacunaId int,
Dosis int,
Fecha varchar(18)
);
