create database Practica
go
use Practica
declare @user nvarchar(100) = 'xxxxx'
declare @pass nvarchar(100) = 'xxxxx'
go
use Practica
create table Users(
	UserID int identity(1,1) primary key, 
	LoginName nvarchar(100) unique not null, 
	Password nvarchar(100) not null, 
	FirstName nvarchar(100) not null, 
	LastName nvarchar(100) not null, 
	Position nvarchar(100) not null, 
	Email nvarchar(100) not null
)
go
create table Tb_Cliente(
	NUI nchar (10) primary key, 
	Nombre nvarchar(100) not null, 
	Telefono nchar(10) not null, 
	Direccion nvarchar(100) not null
)
go
create table Tb_Pagos(
	Id_tipo nchar(2),
	Nombre nchar(20), 
	CONSTRAINT Id_tipo Primary KEY (Id_tipo),
)
go
create table Tb_Factura(
	Nro_Factura int primary key, 
	Fecha datetime not null,
	IdCliente nchar(10) not null,
	IdPago nchar(2)
	CONSTRAINT fk_cliente FOREIGN KEY (IdCliente) REFERENCES Tb_Cliente (NUI),
	CONSTRAINT fk_Pago FOREIGN KEY (IdPago) REFERENCES Tb_Pagos (Id_tipo)
)
go
create table Tb_Categoria (
	ID_Categoria Char (1) primary key,
	Nombre nvarchar(100),
	Descripcion nvarchar(100), 
)
go
create table Tb_Producto (
	Id_Producto int identity (1,1) primary key,
	Tipo Char(1),
	Nombre nvarchar(100),
	Descripcion nvarchar(100), 
	Marca nvarchar(100),
	Precio float, 
	Stock int
	CONSTRAINT fk_categoria FOREIGN KEY (Tipo) REFERENCES Tb_Categoria (ID_Categoria)
)
go
Create table Tb_Ventas(
	Id_Ventas int identity (1,1),
	Id_Factura int,
	Id_Producto int,
	Total float, 
	Cantidad int,
	Nombre nchar(100),
	CONSTRAINT Id_Ventas Primary KEY (Id_Ventas,Id_Factura,Id_Producto),
	CONSTRAINT fk_Factura FOREIGN KEY (Id_Factura) REFERENCES Tb_Factura (Nro_Factura),
	CONSTRAINT fk_Producto FOREIGN KEY (Id_Producto) REFERENCES Tb_Producto (Id_Producto)
)
/*
----------------METODOS---------------------------------------------------
*/
--Metodos del cliente
use Practica
go
create procedure MostrarCliente
as
select * from Tb_Cliente
go
use Practica
go
create proc InsertarCliente
@NUI  nchar(10),
@nombre nvarchar(100), 
@telf  nchar(10), 
@direc nvarchar(100)
as
insert into Tb_Cliente values (@NUI,@nombre,@telf,@direc)
go
use Practica
go
create proc EliminarCliente 
@nui int 
as
delete from Tb_Cliente where NUI=@nui 
go 
use Practica
go
create proc EditarCliente 
@nui nchar (10),
@nombre nvarchar(100), 
@telf  nvarchar(100), 
@direc nvarchar(100)
as 
update Tb_Cliente set Nombre=@nombre,Telefono=@telf,Direccion=@direc
where NUI=@nui 
go 
--Metodos del Producto
Use Practica
go
create proc InsertarProductos
@Tipo char(1),
@nombre nvarchar(100), 
@desc  nvarchar(100), 
@marca nvarchar(100), 
@precio float,
@stock int
as
insert into Tb_Producto values(@Tipo,@nombre,@desc,@marca,@precio,@stock)
go
use Practica
go
create proc MostrarProductos 
as 
select * from Tb_Producto 
go
use Practica
go
create proc MostrarProductosEspecifico
@filter char(1)
as 
select Id_Producto as "Cod.Producto",Nombre,Descripcion,Marca,Precio,Stock
from Tb_Producto
Where Tipo=@filter
go
create view Vw_Prodcompleto
as 
select a.Id_Producto as 'Cod.Producto',b.Nombre as Categoria,a.Nombre,a.Marca,a.Descripcion,a.Precio,a.Stock
from Tb_Producto a join Tb_Categoria b on a.Tipo=b.ID_Categoria 
go
create proc filtroBusqueda
@filtro nvarchar(100),
@def char(1)
as
if @def='Y' 
Select * from Vw_Prodcompleto where @filtro=Categoria;
else
select * from Vw_Prodcompleto
go
create proc EditarProductos 
@Tipo char(1),
@nombre nvarchar(100), 
@desc  nvarchar(100), 
@marca nvarchar(100), 
@precio float,
@stock int,
@id int
as 
update Tb_Producto set Nombre=@nombre,Descripcion=@desc,Marca=@marca,Precio=@precio,Stock=@stock
where Id_Producto=@id
go
use Practica
go
create proc EliminarProducto 
@idpro int 
as
delete from Tb_Producto where Id_Producto=@idpro 
go 
--Metodos de Factura
Use Practica
go
create proc InsertarFactura
@NRO int,
@Fecha datetime, 
@cliente  nchar(10),
@IdPago nchar(2)
as
insert into Tb_Factura values(@NRO,@Fecha,@cliente,@IdPago)
go
--Metodos de Venta
Use Practica
go
create proc MostrarVentasTotales
as 
select * from Tb_Ventas 
go
create proc MostrarVentasFactura
@Nro int
as 
select * from Tb_Ventas where Id_Factura=@Nro 
go

create proc InsertarVentas
@Id_Factura int,
@Id_Producto int,
@Total float, 
@Cantidad int,
@Nombre nchar(100)
as
insert into Tb_Ventas values (@Id_Factura,@Id_Producto,@Total,@Cantidad,@Nombre)
go

create proc EliminarVentas
as 
Delete from Tb_Ventas
go

create proc SumaTotalVentas
@Id_Factura int
as
Select SUM(total) 
from Tb_Ventas
Where Id_Factura=@Id_Factura
go
create proc MostrarFactura
as 
Select * from Tb_Factura
go
--Metodos de busqueda


---IMPRIMIR VENTA 
create proc ImprimirVent
@Nro int
as
select Id_Factura,Id_Producto,Nombre,Total,Cantidad
from Tb_Ventas
where Id_Factura=@Nro
go

create proc MostrarVentas 
as 
select * from Tb_Ventas
go