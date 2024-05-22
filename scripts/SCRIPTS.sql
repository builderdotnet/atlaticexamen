use master 
go 
if exists (select 1 from sys.databases where name ='BibliotecarioJuanCalla')
begin 
	drop database BibliotecarioJuanCalla
end 
go 
create database BibliotecarioJuanCalla
go 
use BibliotecarioJuanCalla
go
create table Estado (
idEstado int  primary key identity(1,1), 
codEstado varchar(4) unique , 
nombre varchar(250) , 
esActivo bit default 1, 
tabla varchar(50) default 'LIBRO'
)
go 
create table Categoria (
idCategoria int primary key identity (1,1), 
nombre varchar(250), 
esActivo bit default 1 
)
go
create table Estante (
idEstante int primary key identity (1,1) , 
nombre varchar(250), 
esActivo bit default 1 
)
go 
create table Libro
(
idLibro int primary key identity(1,1), 
nombreLibro varchar(250) ,  
codigoBarra varchar(25) unique , 
numeroCopias int default 1 ,   
idCategoria int references Categoria(idCategoria),
esActivo bit default 1, 
observacion varchar(2500) 
)
go 
create table Inventario (
idInventario int primary key identity (1,1), 
idLibro int references Libro(idLibro),
idEstante int references Estante (idEstante), 
stockInicial int , 
stockActual int , 
esActivo bit default 1 , 
unique (idLibro ,idEstante)
)


go 
create table Usuario (
idUsuario int primary key identity(1,1), 
nombres varchar(250) , 
apellidos varchar(250), 
documentoIdentidad varchar(20) unique  , 
telefono varchar(20) , 
email varchar(200), 
direccion varchar(250), 
ubigeo varchar(250), 
esActivo bit default 1 
)
go
create table ListaNegra 
(
idLista int primary key identity(1,1), 
idUsuario int references Usuario (idUsuario),
observacion varchar(2000), 
idPrestamo int 
)
go 
create table Prestamo (
idPrestamo int primary key identity(1,1), 
idUsuario int references Usuario (idUsuario), 
fechaPrestamo datetime default getdate(), 
idEstado int references Estado (idEstado), 
observacion varchar(2000), 
)
go 
create table PrestamoDetalle (
idPrestamoDetalle int identity (1,1) primary key, 
idPrestamo int references Prestamo(idPrestamo),
idLibro int references Libro (idLibro) , 
idEstado int references Estado (idEstado), 
idEstante int references Estante (idEstante),
fechaEntrega datetime , 
cobroPrestamo decimal (14,4) default 1.00,
cobroPerdida decimal (14,4) default 1.00,
observacion varchar(250) 
)
go 
create table PrestamoBitacora (
idBitacora int primary key identity(1,1), 
idEstado int references Estado(idEstado), 
idPrestamo int references Prestamo (idPrestamo), 
fechaOperacion datetime default getdate(), 
idUsuario int references Usuario(idUsuario), 
Observacion varchar(2000)
)
go 

insert into Estado values ('PEND', 'Pendiente Aprobacion', 1, 'PRESTAMO')
insert into Estado values ('APRO', 'Aprobado', 1, 'PRESTAMO')
insert into Estado values ('RECH', 'Rechazado', 1, 'PRESTAMO')
insert into Estado values ('PERD', 'Perdido', 1, 'PRESTAMO')
insert into Estado values ('DEVU', 'Devuelto', 1, 'PRESTAMO')
go
insert into Categoria (nombre) values ('Aventura')
insert into Categoria (nombre) values ('Tecnologia')
insert into Categoria (nombre) values ('Fantasia')

go 
insert into Estante(nombre) values ('A')
insert into Estante(nombre) values ('B')
insert into Estante(nombre) values ('C') 
go 
insert into Libro values ( 'Harry potter 1', 'HAR20240121', 40,3 ,1 ,'' )
insert into Libro values ( 'Harry potter 3', 'HAR20240123', 5,3 ,1 ,'' )
insert into Libro values ( 'Harry potter 2', 'HAR20240122', 10,3 ,1 ,'' )

insert into Libro values ( 'Matalache', 'MATA20240121', 20,3 ,1 ,'' )
insert into Libro values ( 'Perros Hambrientos', 'PERR20240122', 15,2 ,1 ,'' )

go
insert into Usuario values ('Juan', 'Calla', '44840472','','builderdotnet@gmail.com', 'Psj los geranios mz c 15', 'SAN JUAN DE LURIGANCHO',1)
insert into Usuario values ('Axell', 'Caceres', '44840471','','xxx@gmail.com', ' los xxxxx', 'SAN JUAN DE LURIGANCHO',1)
insert into Usuario values ('Marco', 'Perez', '44840473','','abc@gmail.com', 'Psj los brasil 223', 'MIRAFLORES',1)
insert into Usuario values ('Juliana', 'Cruz', '44840470','','test@gmail.com', 'Psj los liros', 'LINCE',1)
go
insert into ListaNegra values (3,'Usuario con muchas perdidas',null)
go 
go  
insert into Inventario values (1,1,40,20,1)
insert into Inventario values (2,3,5,5,1)
insert into Inventario values (3,2,10,10,1)
insert into Inventario values (4,1,20,20,1)


go 
select * from Prestamo
select * from PrestamoDetalle 
go 