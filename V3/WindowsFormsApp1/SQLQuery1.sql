 set nocount on;
drop table DetalleCompra;
drop table DetalleVenta;
drop table Compra;
drop table Producto;
drop table Categoria;
drop table Marca;
drop table Proveedor;
drop table Gasto;
drop table Venta;
drop table Caja;
drop view VwDetalle;
drop view VwInventario;

create table Caja(
NoSeq int  primary key,
Fecha datetime default getdate(),
FechaApertura datetime default getdate(),
FechaCierre datetime default getdate(),
MontoApertura money default 0,
MontoCierre money default 0,
VentaDiaria as MontoCierre-MontoApertura,
Estado bit default 0);

create table Categoria(
Cod int identity(1,1) primary key,
Descripcion varchar(70) unique,
Estado bit default 0
);

insert into Categoria(Descripcion,Estado) values ('Granos Básicos',1)

create table Marca(
Cod int identity(1,1) primary key,
Descripcion varchar(70) unique,
Estado bit default 0
);

insert into Marca(Descripcion,Estado) values ('Halcon',1);
insert into Marca(Descripcion,Estado) values ('Tierniticos',1);
insert into Marca(Descripcion,Estado) values ('Don Beto',1);
Select * from Marca
create table Producto(
NoSeq int primary key,
BarCode varchar(15) unique,
Code varchar(50),
Descripcion varchar(150),
Categoria int references Categoria,
Marca int references Marca,
IVA bit default 0,
Costo money,
PrecioVenta money,
Estado bit default 1
);
insert into Producto values (166,'1234561234567','S/D','',1,1,0,'0','0',1);
insert into Producto values (1,'7441027501669','S/D','Salsa Don Beto 145ml',1,1,1,'345','345',1);
insert into Producto values (2,'7441027501799','S/D','Salsa Don Beto 750ml',1,1,1,'1200','1200',1);
insert into Producto values (3,'7441011922241','S/D','Miel Abeja 250ml',1,1,1,'1500','1500',1);
insert into Producto values (4,'9555507107208','S/D','Leche Condesada 390g',1,1,1,'560','560',1);
insert into Producto values (5,'7441027502093','S/D','Salsa Tomate 700ml',1,1,1,'1200','1200',1);
insert into Producto values (6,'4701001581667','S/D','Aceite Ideal 3000ml',1,1,1,'2650','2650',1);
insert into Producto values (7,'7441027501980','S/D','Aceite Don Beto 1500ml',1,1,1,'1520','1520',1);
insert into Producto values (8,'7441027500358','S/D','Frijol Rojo Premium 900g',1,1,1,'1250','1250',1);
insert into Producto values (9,'744102750105','S/D','Frijol Rojo Tiernitico 900g',1,1,1,'1150','1150',1);
insert into Producto values (10,'7441027500341','S/D','Frijo Negro Premium  900g',1,1,1,'1075','1075',1);
insert into Producto values (11,'7441027500006','S/D','Frijol Negro Tiernitico 900g',1,1,1,'1000','1000',1);
insert into Producto values (12,'7441027602472','S/D','Café Naranjo 500g',1,1,1,'2295','2295',1);
insert into Producto values (13,'7441027601024','S/D','Café Naranjo 250g',1,1,1,'1150','1150',1);
insert into Producto values (14,'7441027602595','S/D','Café Naranjo 1000g',1,1,1,'4370','4370',1);
insert into Producto values (15,'7441129250304','S/D','Café Economico 200g',1,1,1,'1000','1000',1);
insert into Producto values (16,'748366123505','S/D','Café Rey Tradicional 250g',1,1,1,'1040','1040',1);
insert into Producto values (17,'7443005850363','S/D','Arroz Halcon 99% 1800kg',1,1,1,'1595','1595',1);
insert into Producto values (18,'7441007110300','S/D','Arroz Montes de Oro Verde 2000kg',1,1,1,'1750','1750',1);
insert into Producto values (19,'7441027502451','S/D','Azucar Don Beto 800g',1,1,1,'560','560',1);
insert into Producto values (20,'7441027502420','S/D','Azucar Don Beto 1800kg',1,1,1,'1125','1125',1);
insert into Producto values (21,'7441027502444','S/D','Azucar Don Beto 4800kg',1,1,1,'3100','3100',1);
insert into Producto values (22,'7443005850462','S/D','Arroz Precocido 900g',1,1,1,'890','890',1);
insert into Producto values (23,'7441007160510','S/D','Arroz Montes de Oro Verde 4000kg',1,1,1,'3450','3450',1);
insert into Producto values (24,'756956000815','S/D','Gallete Best ',1,1,1,'1070','1070',1);
insert into Producto values (25,'7441027502529','S/D','Frijol Rojo Don Beto 900g',1,1,1,'950','950',1);
insert into Producto values (26,'7441027502550','S/D','Frijol Halcon Negro 900g',1,1,1,'900','900',1);
insert into Producto values (27,'7441027502543','S/D','Frijol Halcon Rojo 900g',1,1,1,'1100','1100',1);
insert into Producto values (28,'7441027500402','S/D','Frijol Jumbo Negro 900g',1,1,1,'850','850',1);
insert into Producto values (29,'7441027500822','S/D','Chile Don Beto 250g',1,1,1,'850','850',1);
insert into Producto values (30,'7441027501942','S/D','Champiñon 284g',1,1,1,'450','450',1);
insert into Producto values (31,'7441027500808','S/D','Garbanzo 2800kg',1,1,1,'2100','2100',1);
insert into Producto values (32,'7441027501591','S/D','Champiñon  2840kg',1,1,1,'3300','3300',1);
insert into Producto values (33,'7441027502048','S/D','Salsa Inglesa 3785kg',1,1,1,'3800','3800',1);
insert into Producto values (34,'7441027502062','S/D','Salsa Tomate 4000kg',1,1,1,'3200','3200',1);
insert into Producto values (35,'7443010090037','S/D','Frijol Colina 800g',1,1,1,'750','750',1);
insert into Producto values (36,'7441027500433','S/D','Frijol Compitas 900g',1,1,1,'825','825',1);
insert into Producto values (37,'7443005850530','S/D','Arroz Halcon 90% 1800g',1,1,1,'1550','1550',1);
insert into Producto values (38,'7430058501027','S/D','Arroz Halcon 95% 1800g',1,1,1,'1675','1675',1);
insert into Producto values (39,'7441003600102','S/D','Sal Sol 500g',1,1,1,'310','310',1);
insert into Producto values (40,'7441007110201','S/D','Arros Amarillo  1800g',1,1,1,'1125','1125',1);
insert into Producto values (41,'7441027500464','S/D','Arroz Halcon 80% 1800g',1,1,1,'1150','1150',1);
insert into Producto values (42,'7441027502437','S/D','Cubas 400g',1,1,1,'700','700',1);
insert into Producto values (43,'7441027500099','S/D','Lentejas 400g',1,1,1,'550','550',1);
insert into Producto values (44,'7441027500129','S/D','Maiz Palomita 400g',1,1,1,'425','425',1);
insert into Producto values (45,'7441027500136','S/D','Garbanzo 400g',1,1,1,'750','750',1);
insert into Producto values (46,'744102750082','S/D','Frijol Blanco 400g',1,1,1,'495','495',1);
insert into Producto values (47,'7441049570094','S/D','Sardina 75g',1,1,1,'460','460',1);
insert into Producto values (48,'7410031394741','S/D','Atun Azul 165g',1,1,1,'1030','1030',1);
insert into Producto values (49,'7410031394758','S/D','Atun Verde 165g',1,1,1,'990','990',1);
insert into Producto values (50,'76632430623','S/D','Nuber Blanca 160g',1,1,1,'1100','1100',1);
insert into Producto values (51,'7441008154754','S/D','Scott 122g',1,1,1,'435','435',1);
insert into Producto values (52,'79907210233','S/D','Pañal Brazil 27lb',1,1,1,'3040','3040',1);
insert into Producto values (53,'79907210232','S/D','Pañal Brazil 22lb',1,1,1,'2530','2530',1);
insert into Producto values (54,'7806506316708','S/D','Sisters ',1,1,1,'38','38',1);
insert into Producto values (55,'7806506316715','S/D','Sisters ',1,1,1,'455','455',1);
insert into Producto values (56,'7406233300000','S/D','Pompom ',1,1,1,'1285','1285',1);
insert into Producto values (57,'79907210231','S/D','Pañal Brazil 15lb',1,1,1,'2350','2350',1);
insert into Producto values (58,'75022733004','S/D','Pañal Brazil 29lb',1,1,1,'2870','2870',1);
insert into Producto values (59,'7441027501829','S/D','Precan  900g',1,1,1,'950','950',1);
insert into Producto values (60,'7441011946827','S/D','Alimento Conejo 1000kg',1,1,1,'590','590',1);
insert into Producto values (61,'7441011922050','S/D','Alimento Pollo 2000kg',1,1,1,'900','900',1);
insert into Producto values (62,'7441011945608','S/D','Alpiste 400g',1,1,1,'560','560',1);
insert into Producto values (63,'7441011945646','S/D','Mezcla Canario 400g',1,1,1,'610','610',1);
insert into Producto values (64,'7441011945639','S/D','Mezcla Perico 400g',1,1,1,'950','950',1);
insert into Producto values (65,'7441011945615','S/D','Semilla Girasol 250g',1,1,1,'490','490',1);
insert into Producto values (66,'7441011945622','S/D','Mezcla para Loras 400g',1,1,1,'550','550',1);
insert into Producto values (67,'7441011945691','S/D','Maiz Quebrado 1,8kg',1,1,1,'800','800',1);
insert into Producto values (68,'7141027501829','S/D','Alimento Cachorro 900g',1,1,1,'950','950',1);
insert into Producto values (69,'7441027502376','S/D','Alimento Adulto 1,8kg',1,1,1,'1250','1250',1);
insert into Producto values (70,'7441011945660','S/D','Candela ',1,1,1,'50','50',1);
insert into Producto values (71,'7443005850097','S/D','Saquita Halcon 10kg',1,1,1,'7450','7450',1);
insert into Producto values (72,'7441027500471','S/D','Saquita Halcon 10kg',1,1,1,'6150','6150',1);
insert into Producto values (73,'7443005850479','S/D','Saquita Halcon 8kg',1,1,1,'5950','5950',1);
insert into Producto values (74,'7441007110904','S/D','Saquita Halcon 8kg',1,1,1,'4895','4895',1);
insert into Producto values (75,'7443005850387','S/D','Saquita Halcon 7kg',1,1,1,'5995','5995',1);
insert into Producto values (76,'7441007110188','S/D','Saquita Halcon 8kg',1,1,1,'6850','6850',1);
insert into Producto values (77,'5062606201877','S/D','Frijol Blanco 1kg',1,1,1,'990','990',1);
insert into Producto values (78,'5062606201878','S/D','Lentejas 1kg',1,1,1,'1100','1100',1);
insert into Producto values (79,'5062606201879','S/D','Garbanzos 1kg',1,1,1,'1500','1500',1);
insert into Producto values (80,'5062606201880','S/D','Maiz Palomita 1kg',1,1,1,'800','800',1);
insert into Producto values (81,'5062606201881','S/D','Azucar Saco 1kg',1,1,1,'600','600',1);
insert into Producto values (82,'5062606201882','S/D','Arroz Saco 80% 1kg',1,1,1,'540','540',1);
insert into Producto values (83,'5062606201883','S/D','Arroz Saco 90% 1kg',1,1,1,'695','695',1);
insert into Producto values (84,'5062606201884','S/D','Arroz Saco 95% 1kg',1,1,1,'790','790',1);
insert into Producto values (85,'5062606201885','S/D','Arroz Precocido 1kg',1,1,1,'810','810',1);
insert into Producto values (86,'5062606201886','S/D','Frijol Rojo Saco 1kg',1,1,1,'750','750',1);
insert into Producto values (87,'5062606201887','S/D','Frijo Negro Saco 1kg',1,1,1,'725','725',1);
insert into Producto values (88,'7622210461742','S/D','Trident 102g',1,1,1,'300','300',1);
insert into Producto values (89,'7622210267832','S/D','Halls 25,2g',1,1,1,'300','300',1);
insert into Producto values (90,'040000514510','S/D','Peanut 49,3g',1,1,1,'650','650',1);
insert into Producto values (91,'040000514251','S/D','Snicker 52,7g',1,1,1,'650','650',1);
insert into Producto values (92,'770299304165','S/D','Trululu 18g',1,1,1,'100','100',1);
insert into Producto values (93,'7441027500792','S/D','Garbanzos 400g 400g',1,1,1,'350','350',1);
insert into Producto values (94,'7441027500976','S/D','Palmito  440g',1,1,1,'1650','1650',1);
insert into Producto values (95,'7441027501959','S/D','Champiñon 432g',1,1,1,'590','590',1);
insert into Producto values (96,'7441027500419','S/D','Frijol Jumbo Rojo 900g',1,1,1,'990','990',1);
insert into Producto values (97,'7443010090020','S/D','Frijol Trocha Rojo 900g',1,1,1,'775','775',1);
insert into Producto values (98,'7443010090021','S/D','Frijol Trocha Negro 900g',1,1,1,'675','675',1);
insert into Producto values (99,'755111732035','S/D','Galleta Cocthel 216g',1,1,1,'515','515',1);
insert into Producto values (100,'755111989057','S/D','Galleta Soda Tony 160g',1,1,1,'1000','1000',1);
insert into Producto values (101,'7441163405784','S/D','Galleta Boquita Queso 434g',1,1,1,'1100','1100',1);
insert into Producto values (102,'755111170202','S/D','Galleta Cuetara 160g',1,1,1,'705','705',1);
insert into Producto values (103,'7441027500457','S/D','Arroz Halcon 900g',1,1,1,'590','590',1);
insert into Producto values (104,'73170100127','S/D','Fideo Caracolito 250g',1,1,1,'495','495',1);
insert into Producto values (105,'731701001033','S/D','Spaguetti Pasta Roma 250g',1,1,1,'450','450',1);
insert into Producto values (106,'731701001293','S/D','Canelon 250g',1,1,1,'780','780',1);
insert into Producto values (107,'7443005850608','S/D','Arroz Halcon Balnco 4kg',1,1,1,'3100','3100',1);
insert into Producto values (108,'7443005850592','S/D','Arroz Halcon Rojo 4kg',1,1,1,'3400','3400',1);
insert into Producto values (109,'7441000713942','S/D','Mimasa 700g',1,1,1,'900','900',1);
insert into Producto values (110,'7441000712495','S/D','Tortimasa 500g',1,1,1,'795','795',1);
insert into Producto values (111,'7441029500417','S/D','Empanizador Bimbo 165g',1,1,1,'500','500',1);
insert into Producto values (112,'7441029556759','S/D','Pan Bimbo 450g',1,1,1,'1200','1200',1);
insert into Producto values (113,'7441029556735','S/D','Pan Bimbo 560g',1,1,1,'1400','1400',1);
insert into Producto values (114,'7441027502536','S/D','Frijol Don Beto 900g',1,1,1,'750','750',1);
insert into Producto values (115,'7441027500940','S/D','Firijol Rojo Compita 900g',1,1,1,'975','975',1);
insert into Producto values (116,'7443010090044','S/D','Frijol  Colina Negro 800g',1,1,1,'650','650',1);
insert into Producto values (117,'7443002260141','S/D','Achiote 100g',1,1,1,'300','300',1);
insert into Producto values (118,'7441027501300','S/D','Petit Pois 576g',1,1,1,'450','450',1);
insert into Producto values (119,'7441027501928','S/D','Maiz Dulce 240g',1,1,1,'330','330',1);
insert into Producto values (120,'7441027501935','S/D','Maiz Dulce 832g',1,1,1,'430','430',1);
insert into Producto values (121,'7441027501577','S/D','Maiz Dulce 2840g',1,1,1,'2800','2800',1);
insert into Producto values (122,'7441027501301','S/D','Petit Pois 2840g',1,1,1,'2100','2100',1);
insert into Producto values (123,'5062606180123','S/D','Ofertas Frijol + Azucar ',1,1,1,'2500','2500',1);
insert into Producto values (124,'5062606180124','S/D','Ofertas  Frijol x 3 ',1,1,1,'2700','2700',1);
insert into Producto values (125,'5062606180125','S/D','Ofertas Frijol + Azucar ',1,1,1,'2200','2200',1);
insert into Producto values (126,'5062606180126','S/D','Ofertas Frijol x 3 ',1,1,1,'2300','2300',1);
insert into Producto values (127,'759094074014','S/D','Dulci Kuhl ',1,1,1,'100','100',1);

SELECT [NoSeq],[BarCode],[Code],[Descripcion],[Categoria],[Marca],[Costo],[PrecioVenta] FROM [Producto]

create table Proveedor(
Cod int identity(1,1) primary key,
Nombre varchar(150) unique,
Contacto varchar(150),
Telefono varchar(20),
Celular varchar(20),
Direccion varchar(150),
Correo varchar(150),
Comentarios varchar(150),
Estado bit default 0
);
insert into Proveedor values ('Empaques Agroindustriales S.A.','Vinicio','2439-0008','6296-3324','200 mts Norte, antigua estación del ferrocarril, San Rafael, Alajuela','ruta14@empagro.com','Proveedor de Frijol',1)
insert into Proveedor values ('Rosa Tropical S.A.','Vinicio','2439-0008','6296-3324','200 mts Norte, antigua estación del ferrocarril, San Rafael, Alajuela','ruta14@empagro.com','Proveedor de Arroz',1)

--Update Proveedor set Nombre='Luis Miguel',Contacto='Miminator',Telefono=24406484'',Celular='8829979',Direccion='San Antonio del Tejar',Correo='luis.mbm89@gmail.com',Comentarios='Proveedor de Sistema informaticos' where Cod=3

Select Cod,Nombre,Contacto,Telefono,Celular,Direccion,Correo,Comentarios,ROW_NUMBER()over(order by Nombre)NoSeq from Proveedor

Create table Venta(
Cod int primary key,
Fecha datetime default getdate(),
Cliente varchar(150),
SubTotal Money,
Descuento Money,
IVA money,
Total as IVA+SubTotal-Descuento,
TipoPago varchar(50),
Referencia varchar(10) default 'N/A',
Estado bit default 0
);
create table Compra(
Cod int primary key,
Fecha datetime default getdate(),
Vencimiento datetime default getdate(),
Numero varchar(50),
SubTotal money,
Descuento money,
IVA money,
Total as SubTotal-Descuento+IVA,
Proveedor int references Proveedor
);
--Insert into Compra values (1,default,default,'123456','4500','0','5460',1);
create table DetalleCompra(
NoSeq int not null,
Compra int references Compra,
primary key(NoSeq,Compra),
Producto int references Producto,
Cantidad decimal,
Precio money,
Total as Cantidad*Precio
);
--insert into DetalleCompra values (1,1,31,50,2100);
set dateformat dmy;
--insert into Compra values (1,'27/06/2018','27/07/2018','123456','5000','500','750','5250',1);

--insert into Venta(Cod,Cliente,SubTotal,Descuento,IVA,TipoPago) values (1,'Contado','15000','Efectivo')
--insert into Venta(Cod,Cliente,SubTotal,Descuento,IVA,TipoPago,Referencia) values (1,'Contado','15000','Efectivo','0123456789')

Create table DetalleVenta(
Cod int not null,
Venta int references Venta,
Producto int references Producto,
Descripcion varchar(200),
Cantidad decimal,
Precio money,
SubTotal as Precio*Cantidad, 
IVA money default 0,
Descuento money default 0,
Total as (Precio*Cantidad)-Descuento+IVA,
primary key(Venta,Cod,Producto),
Fecha datetime default getdate(),
Estado bit default 1
);
--Insert into DetalleVenta(Cod,Venta,Producto,Cantidad,Precio,IVA,Descuento,Fecha,Estado) values (1,1,1,1,'500','135','50',default,1)
Create table Gasto(
Cod int primary key,
Fecha datetime default getdate(),
Descripcion varchar(50),
Total Money,
Observaciones varchar(150),
Referencia varchar(20),
Estado bit default 0,
flag bit default 0
);

Select *,[Venta]-[Gasto] [Total] from (
Select sum(Gasto)[Gasto],sum(Venta)[Venta] from (
Select isnull(sum(Total),0)[Venta],0[Gasto] from Venta where convert(varchar,Fecha,103)=''
union all
Select 0,isnull(sum(Total),0)[Gasto] from Gasto where convert(varchar,Fecha,103)=''
)a
)b

Select count(*),MontoApertura from Caja where Convert(varchar,Fecha,103)='22/06/2018' and FechaApertura=FechaCierre group by MontoApertura


Select isnull(max(NoSeq),0)+1 NoSeq from Caja where FechaApertura=FechaCierre and Estado=0 and Convert(varchar,FechaApertura,103)='22/06/2018'

Select isnull(sum(Total),0)[Total] from Venta where TipoPago='Efectivo' and Fecha <=getdate()

go
Create view VwDetalle as 
Select Venta,NoSeq,Code,dv.Descripcion,Cantidad,Precio,SubTotal,dv.IVA,Descuento,Total from DetalleVenta dv inner join Producto p on dv.Producto=p.NoSeq
go
Select * from VwDetalle
where Venta=1

Update Proveedor 
set Nombre='Rosa Tropical S.A.',Contacto='Vinicio',Telefono='2439-0008',Celular='6296-3324',Direccion='200 mts Norte, antigua estación del ferrocarril, San Rafael, Alajuela',Correo='ruta14@empagro.com',Comentarios='Proveedor de Arroz',Estado='1' 
where Cod=2

go
create view VwInventario as
Select NoSeq,sum(Entradas)[Entradas],sum(Salidas)[Salidos],sum(Saldo)[Saldo] from (
Select p.NoSeq,isnull(a.Entradas,0)[Entradas],isnull(a.Salidas,0)[Salidas],isnull(Entradas+Salidas,0)[Saldo] from (
Select Producto,sum(Cantidad)[Entradas],0[Salidas] from DetalleCompra group by Producto
union all
Select Producto,0,sum(Cantidad*-1)[Salidas] from DetalleVenta group by Producto
)a right join Producto p on a.Producto=p.NoSeq)b group by NoSeq
go

select * from DetalleCompra


Select NoSeq from (Select Cod,ROW_NUMBER() over(partition by convert(varchar,Fecha,103)order by Cod asc)NoSeq  from Venta)a where Cod='1'