use DBCARRITO
create table category(
Idcategoria int primary key identity,
descripcion varchar(100),
activo bit default 1,
FechaRegistro datetime default getdate()
)


create table marca(
IdMarca int primary key identity,
Descripcion varchar(100),
activo bit default 1,
FechaRegistro datetime default getdate()
)

create table producto(
IdProducto int primary key identity,
Nombre Varchar(500),
Descripcion varchar(500),
IdMarca int references marca(IdMarca),
Idcategoria int references category (Idcategoria),
Precio decimal(10,2) default 0,
Stock int,
RutaImagen varchar(100),
NombreImagen varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)

create table cliente(
IdCliente int primary key identity,
Nombres varchar(100),
Apellidos varchar(100),
Correo varchar(100),
Clave varchar(150),
Reestablecer bit default 0,
FechaRegistro datetime default getdate()
)

Create table carrito(
IdCarrito int primary key identity,
IdCliente int references cliente(IdCliente),
IdProducto int references producto(IdProducto),
Cantidad int
)

create table Venta(
IdVenta int primary key identity,
TotalProducto int,
IdCliente int references cliente (IdCliente),
MontoTotal decimal(10,2),
Contacto varchar(50),
IdDistrito varchar(10),
Telefono varchar(50),
Direccion varchar(500),
IdTransaccion varchar(50),
FechaVenta datetime default getdate()
)

create table detalle_venta(
IdDetalleVenta int primary key identity,
IdVenta int references Venta (IdVenta),
IdProducto int references PRODUCTO(IdProducto),
Cantidad int,
Total decimal(10,2)
)
-- Eliminar la tabla existen

-- Crear la nueva tabla
CREATE TABLE usuario (
  IdUsuario int primary key identity,
  Nombres varchar(100),
  Apellidos varchar(100),
  Correo varchar(100),
  Clave varchar(150),
  Reestablecer bit default 1,
  Activo bit default 1,
  FechaRegistro datetime default getdate()
);

create table departamento(
IdDepartamento varchar(2) not null,
Descripcion varchar(45) not null
)
create table provincia(
IdProvincia varchar(4) not null,
Descripcion varchar (45) not null,
IdDepartamento varchar(2) not null
)
Create table distrito(
IdDistrito varchar(6) not null,
Descripcion varchar(45) not null,
IdProvincia varchar(4) not null,
IdDepartamento varchar(2) not null,
)
