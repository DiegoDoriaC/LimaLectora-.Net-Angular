create database LimaLectora;
use LimaLectora;
set dateformat dmy

create table areas
(
	idArea int primary key not null identity(1,1),
	cargo varchar(45) not null,
	sueldo decimal(10,2) not null
);
go

create table generos
(
	idGenero int primary key not null identity (1,1),
	nombre varchar(30)
);
go

create table metodoPagos
(
	idMetodoPago int primary key not null identity(1,1),
	nombre varchar(25)
);
go

create table clientes
(
	idCliente int primary key not null identity(1000,1),
	dni varchar(9) not null,
	nombre varchar(30) not null,
	apellido varchar(30) not null,
	-- Campos nulos --
	email varchar(45) null,
	telefono varchar(9) null,
	esActivo bit default 1
);
go

create table empleados
(
	idEmpleado int primary key not null identity(2000,1),
	idArea int references areas,
	dni varchar(9) not null,
	nombre varchar(30) not null,
	apellido varchar(30) not null,
	telefono varchar(9) not null,
	fechaIngreso date not null,
	-- Campos nulos --
	email varchar(45) null,
	direccion varchar(40) null,
	esActivo bit default 1
);
go

create table accesos
(
	idAcceso int primary key not null identity (1,1),
	clave varchar(150) not null,
	idEmpleado int not null references empleados
);
go

create table libros
(
	idLibro int primary key not null identity(3000,1),
	idGenero int references generos,
	nombre varchar(50) not null,
	autor varchar(25) not null,
	editorial varchar(20) not null,
	precio int not null,
	anioPublicacion int not null,
	stock int default 0,
	url varchar(550),
	esActivo bit default 1
);
go

create table proveedores
(
	idProveedor int primary key not null identity(4000,1),
	nombre varchar(25) not null,
	ruc varchar(11) not null,
	email varchar(40) not null,
	-- Campos nulos --
	telefono varchar(9),
	esActivo bit default 1
);
go

create table recepciones
(
	idRecepcion int primary key not null identity(5000,1),
	idLibro int references libros not null,
	idEmpleado int references empleados not null,
	idProveedor int references proveedores not null,
	cantidad int not null,
	fechaIngreso date
);
go

create table comprobantes
(
	idComprobante int primary key not null identity(7000,1),
	idCliente int references clientes not null,
	idEmpleado int references empleados not null,
	idMetodoPago int references metodoPagos not null,
	total decimal(10,2),
	fechaVenta date default(getdate())
);
go

create table ventas
(
	idVenta int primary key not null identity(6000,1),
	idComprobante int references comprobantes,
	idlibro int references libros not null,
	cantidad int not null,
	precio decimal(10,2) not null,
	total decimal(10,2)
);
go

insert into areas values
	('Limpieza', 1200),
	('Vendedor', 2200),
	('Almacenero', 1500),
	('Seguridad', 1700)
go

insert into generos values
	('Drama'),
	('Romance'),
	('Comedia'),
	('Terror'),
	('Suspenso'),
	('Aventura'),
	('Ficcion')
go

insert into metodoPagos values
	('Efectivo'),
	('Deposito'),
	('Transferencia'),
	('Banca Movil')
go

insert into clientes values
	('72557870', 'Diego', 'Doria Crisostomo', 'Diego@gmail.com', '924109364' ,1),
	('72557875', 'Javier', 'Doria Crisostomo', 'Javier@gmail.com', '932306660' ,1),
	('16130231', 'Hugo', 'Doria Baustista', 'Hugo@gmail.com', '984139924' ,1)
go

insert into empleados values
	(1, '16130376', 'Elena', 'Crisostomo Bautista', '974221252', '13-02-2024', 'Elena@gamil.com', 'Ate-Horacio Zeballos', 2)
go

insert into libros values
	( 5, 'El dia que se perdio la cordura', 'Javier Castillo', 'Anagrama', 78, 2014, 0, 'https://images.cdn3.buscalibre.com/fit-in/360x360/0b/68/0b68a08e4322fb80fe61ba03c0bca729.jpg', 1),
	( 1, 'La pareja de al lado', 'Shari Lapena', 'Debolsillo', 59, 2021, 0, 'https://www.crisol.com.pe/media/catalog/product/cache/cf84e6047db2ba7f2d5c381080c69ffe/9/7/9788466342803_ulcekzvwusxazoqq.jpg', 1),
	( 7, 'Futuro azul', 'Eoin Colfer', 'Penguin Random', 19, 2009, 0, 'https://www.crisol.com.pe/media/catalog/product/cache/f6d2c62455a42b0d712f6c919e880845/f/u/futuro-azul_bxbb4ivqejrh1iin.jpg', 1),
	( 4, 'El silencio de la ciudad blanca', 'Eva Garcia Saenz', 'Editorial Planeta', 89, 2016, 0, 'https://proassetspdlcom.cdnstatics2.com/usuaris/libros/thumbs/99665d90-f8e2-4345-b96c-10c318baf1b0/d_360_620/portada_el-silencio-de-la-ciudad-blanca_eva-garcia-saenz-de-urturi_201704051340.webp', 1)
go

insert into proveedores values
	('Grupo Lectora', '11547589326', 'lectora@lectora.com', '984733120', 1),
	('Libreria S.A.C', '11258636490', 'libreria@gmail.com', '940372438', 1),
	('Libros Ya', '10086543721', 'librosya@librosya.com', '940371214', 1),
	('Grupo Lee', '17563857609', 'grupolee@leegroup.com', '988703328', 1)
go

select * from areas;
select * from generos;
select * from metodoPagos;
select * from clientes;
select * from empleados;
select * from libros;
select * from proveedores;