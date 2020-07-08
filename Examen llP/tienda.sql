create database Tienda
go

create schema factura
go

create table factura.cliente (
	idCliente int primary key not null,
	nombre varchar(25),
	apellido varchar(25),
	direccion varchar(50),
)
AS
BEGIN
insert into cliente (idCliente, Nombre, apellido, direccion) VALUES(@idCliente, @Jeizel, @Sabillon, @Suavitel, @ColMontePinar);
insert into cliente(idCliente, Nombre, apellido, direccion) VALUES(@idCliente, @Walter, @Castillo, @Snicker, @Marcal);
insert into cliente(idCliente, Nombre, apellido, direccion) VALUES(@idCliente, @Ericka, @Catellanos, @LecheSula, @BarrioSanAntonio);
END

create table factura.producto(
	idProducto int primary key not null,
	nombreProducto varchar(40),
	descripcion varchar(50)
)
AS
BEGIN
insert into producto(idProducto, nombreProducto, descripcion) VALUES(@idProducto, @Suavitel, @Elamordemama);
insert into producto(idProducto, nombreProducto, descripcion) VALUES(@idProducto, @Snicker, @Cometeelmundo);
insert into producto(idProducto, nombreProducto, descripcion) VALUES(@idProducto, @LecheSula, @Mileche);
END

create table factura.Venta(
	idVenta int primary key not null,
	fechaVenta date,
	precio int,
	cantidad int,
	idCliente int foreign key references factura.cliente(idCliente),
	idProducto int foreign key references factura.producto(idProducto)
)
AS
BEGIN
insert into venta(idVenta, fechaVenta, precio, cantidad, idCliente, idProducto) VALUES (@idVenta, @fechaVenta, @precio, @cantidad, @idCliente, @idProducto);
