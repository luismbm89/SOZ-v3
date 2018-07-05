drop table Producto;
drop table Categoria;
drop table Marca;
drop table Proveedor;
drop table Venta;
drop table Cliente;
drop table Caja;

create table Caja(
NoSeq int identity(1,1) primary key,
Fecha datetime default getdate(),
FechaApertura datetime default getdate(),
FechaCierre datetime default getdate(),
MontoApertura money default 0,
MontoCierre money default 0,
VentaDiaria as MontoCierre-MontoApertura,
Estado bit default 0);

insert into Caja values(default,default,default,'35000',default)

Update Caja  set FechaCierre=default, MontoCierre='50000' where Convert(varchar,Fecha,103)='12/06/2018' and NoSeq in (Select max(NoSeq) from Caja where Convert(varchar,Fecha,103)='12/06/2018')

Select Convert(varchar,MontoApertura)[Monto] from Caja where Convert(varchar,Fecha,103)='12/06/2018' and MontoApertura>0

create table Categoria(
Cod int identity(1,1) primary key,
Descripcion varchar(70) unique
);

insert into Categoria values ('Granos Básicos')

create table Marca(
Cod int identity(1,1) primary key,
Descripcion varchar(70) unique
);

insert into Marca values ('Halcon');
insert into Marca values ('Tierniticos');
insert into Marca values ('Don Beto');
create table Producto(
NoSeq int primary key,
BarCode varchar(12) unique,
Code varchar(50) unique,
Descripcion varchar(150),
Categoria int references Categoria,
Marca int references Marca,
Costo money,
PrecioVenta money
);
insert into Producto values (1,'012345678910','PT-ARR001','Arroz Halcon',1,1,'5000','6000')
insert into Producto values (2,'109876543210','PT-FRI001','Frijol Tierniticos',1,2,'895','1000')
insert into Producto values (3,'654987321100','PT-AZU001','Azucar Don Beto',1,3,'1050.54','1500.54')

SELECT [NoSeq],[BarCode],[Code],[Descripcion],[Categoria],[Marca],[Costo],[PrecioVenta] FROM [Producto]

create table Proveedor(
Cod int identity(1,1) primary key,
Nombre varchar(150) unique,
Contacto varchar(150),
Telefono varchar(20),
Celular varchar(20),
Direccion varchar(150),
Correo varchar(150),
Comentarios varchar(150)
);
Create table Cliente(
Cod int identity(1,1) primary key,
Nombre varchar(150) unique,
Contacto varchar(150),
Telefono varchar(20),
Celular varchar(20),
Direccion varchar(150),
Correo varchar(150),
Comentarios varchar(150)
);

insert into Cliente values ('Contado','','','','','','');

Create table Venta(
Cod int primary key,
Fecha datetime default getdate(),
Cliente int references Cliente,
Total Money,
TipoPago varchar(50),
Referencia varchar(10)
);