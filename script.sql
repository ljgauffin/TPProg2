USE [master]
GO
/****** Object:  Database [Fabrica]    Script Date: 21/11/2023 02:41:01 ******/
CREATE DATABASE [Fabrica]
 
GO
USE [Fabrica]
GO
/****** Object:  User [test]    Script Date: 21/11/2023 02:41:02 ******/
/****** Object:  Table [dbo].[DetallesPedidos]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesPedidos](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[Pedido_id] [int] NOT NULL,
	[Producto_id] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Costo] [decimal](10, 2) NOT NULL,
 CONSTRAINT [DetallesPedidos_PK] PRIMARY KEY CLUSTERED 
(
	[Pedido_id] ASC,
	[Producto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [Estados_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[NombreCliente] [varchar](100) NULL,
	[CuitCliente] [varchar](100) NULL,
	[CorreoCliente] [varchar](100) NULL,
	[FechaPedido] [datetime] NULL,
	[FechaEntrega] [date] NULL,
	[Estado_id] [int] NULL,
 CONSTRAINT [Pedidos_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Imagen] [varchar](100) NULL,
	[Precio] [decimal](10, 2) NULL,
	[Costo] [decimal](10, 2) NULL,
 CONSTRAINT [Productos_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetallesPedidos]  WITH CHECK ADD  CONSTRAINT [DetallesPedidos_FK] FOREIGN KEY([Pedido_id])
REFERENCES [dbo].[Pedidos] ([id])
GO
ALTER TABLE [dbo].[DetallesPedidos] CHECK CONSTRAINT [DetallesPedidos_FK]
GO
ALTER TABLE [dbo].[DetallesPedidos]  WITH CHECK ADD  CONSTRAINT [DetallesPedidos_FK_1] FOREIGN KEY([Producto_id])
REFERENCES [dbo].[Productos] ([id])
GO
ALTER TABLE [dbo].[DetallesPedidos] CHECK CONSTRAINT [DetallesPedidos_FK_1]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [Pedidos_FK] FOREIGN KEY([Estado_id])
REFERENCES [dbo].[Estados] ([id])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [Pedidos_FK]
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_PRODUCTO]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_PRODUCTO]
@id int
AS 
BEGIN
SELECT * from Fabrica.dbo.Productos where id = @id
END 
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_PRODUCTOS]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_PRODUCTOS]
@nombre varchar(50) = ''
AS 
BEGIN
declare @nombreBusqueda varchar(52) = '%'+@nombre+'%'
SELECT * FROM Fabrica.dbo.Productos where Nombre  like @nombreBusqueda

END
GO
/****** Object:  StoredProcedure [dbo].[CREAR_PRODUCTO]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREAR_PRODUCTO]
@nombre varchar(100),
@descripcion varchar(100),
@costo decimal(10,2),
@precio decimal(10,2)
AS 
BEGIN

	INSERT INTO Fabrica.dbo.Productos (Nombre,Descripcion,Costo, Precio)
	values(@nombre, @descripcion, @costo, @precio)
	
	return @@identity

END
GO
/****** Object:  StoredProcedure [dbo].[MODIFICAR_PRODUCTO]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_PRODUCTO]
@id int,
@nombre varchar(100),
@descripcion varchar(100),
@costo decimal(10,2),
@precio decimal(10,2)
AS 
BEGIN

	UPDATE Fabrica.dbo.Productos 
	SET Nombre = @nombre, Descripcion = @descripcion, Costo =@costo, Precio = @precio
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CAMBIAR_ESTADO_PEDIDO]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CAMBIAR_ESTADO_PEDIDO]
@pedidoId int,
@estadoId int
AS 
update Pedidos 
set Estado_id = @estadoId where id = @pedidoId

GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_DETALLE_PEDIDO]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_DETALLE_PEDIDO]
@id int
AS 
BEGIN
select DP.id, dp.Pedido_id, dp.Producto_id, dp.Cantidad, DP.Precio, dp.Costo, p.Nombre NombreProducto from DetallesPedidos DP
left join Productos P on DP.Producto_id = p.id
where DP.Pedido_id = @id
order by Producto_id

END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_ESTADOS]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_ESTADOS]

AS 
BEGIN
select * from Estados order by id

END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PEDIDOS]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_PEDIDOS]
@desde date = null,
@hasta date = null,
@estado int = 0
AS 
BEGIN
if(@desde is null)
begin
set @desde = dateadd(DAY, -1, getdate())
end

if(@hasta is null)
begin
set @desde = dateadd(month, 1, getdate()) 
end

select p.id, p.NombreCliente, p.CuitCliente, p.CorreoCliente, p.FechaPedido, p.FechaEntrega, p.Estado_id, E.Nombre NombreEstado from Pedidos P
left join Estados E on P.Estado_id = E.id
where Estado_id = @estado and FechaEntrega between @desde and @hasta

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_PRODUCTO]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_PRODUCTO]
@id int
AS 
begin
	delete from Fabrica.dbo.productos
	where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE]
@pedido int,
@producto int,
@cantidad int
AS 
BEGIN
declare @precio decimal (10,2)
declare @costo decimal (10,2)

select @precio=Precio, @costo=Costo from Productos where id= @producto
INSERT INTO  Fabrica.dbo.DetallesPedidos (Pedido_id, Producto_id, Cantidad, Precio, Costo)
values (@pedido, @producto, @cantidad, @precio, @costo)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO]
@nombre varchar(100),
@cuit varchar(100),
@correo varchar(100),
@fecha varchar(100),
@pedidoId int output
AS 
BEGIN
INSERT INTO  Fabrica.dbo.Pedidos (NombreCliente , CuitCliente, CorreoCliente, FechaPedido, FechaEntrega , Estado_id)
values(@nombre, @cuit, @correo, getdate(), @fecha, 0)

set @pedidoId = @@identity

END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE]    Script Date: 21/11/2023 02:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_REPORTE]
@desde datetime ,
@hasta datetime 
as
BEGIN 
select p.id, p.NombreCliente, p.CuitCliente, p.CorreoCliente, p.FechaPedido, e.Nombre, count(dp.Cantidad) CantArticulos, 
sum(dp.Costo *dp.Cantidad) Costo,  sum(dp.Precio*dp.Cantidad) Precio, sum(dp.Precio*dp.Cantidad) -  sum(dp.Costo *dp.Cantidad) Ganancia 
from Pedidos p 
inner join DetallesPedidos dp on p.id =dp.Pedido_id 
INNER JOIN  Productos p2 on dp.Producto_id = p2.id 
INNER JOIN Estados e on e.id = p.Estado_id 
where p.FechaPedido BETWEEN @desde and @hasta

group by p.id, p.NombreCliente, p.CuitCliente, p.CorreoCliente, p.FechaPedido, e.Nombre
order by p.FechaPedido asc

END 
GO


INSERT INTO Fabrica.dbo.Estados (Nombre) VALUES
	 (N'Pendiente'),
	 (N'En progreso'),
	 (N'Entregado'),
	 (N'Cancelado');


INSERT INTO Fabrica.dbo.Productos (Nombre,Descripcion,Imagen,Precio,Costo) VALUES
	 (N'Rosca M 10 x 1 - Cincado Amarillo ',N'Rosca M 10 x 1 - Version tp',N'no se ',25628.00,5000.00),
	 (N'Caño Rosacado 10 x 1 ',N'Caño Rosacado 10 x 1 1,50',N'no se ',30730.59,15365.00),
	 (N'Caño 7,60 - Rosca M 8x1 - 5 a 20 mm ',N'Caño 7,60 - Rosca M 8x1 - 5 a 20 mm 80,00',NULL,39948.89,19974.00),
	 (N'Caño 7,60 - Rosca M 8x1 Macho-Hembra ',N'Caño 7,60 - Rosca M 8x1 Macho-Hembra 80,00 ',NULL,25898.88,12949.00),
	 (N'Caño 9,60 - Rosca M 10x1 - 5 a 20 mm',N'Caño 9,60 - Rosca M 10x1 - 5 a 20 mm 80,00 Unidad',NULL,29228.51,14614.00),
	 (N'Caño 9,60 - Rosca M 10x1 Macho-Hembra 85,00 ',N'Caño 9,60 - Rosca M 10x1 Macho-Hembra 85,00 ',NULL,13244.75,6622.00),
	 (N'Caño 9,60 - Rosca M 10x1 Macho-Hembra 250,00 ',N'Caño 9,60 - Rosca M 10x1 Macho-Hembra 250,00 ',NULL,34908.98,17454.00),
	 (N'Caño 12,7 - Rosca M 10x1 - 5 a 20 mm 200,00',N'Caño 12,7 - Rosca M 10x1 - 5 a 20 mm 200,00',NULL,4014.43,2007.00),
	 (N'Caño 12,7 - Rosca M 10x1 - 5 a 20 mm 1000,00 ',N'Caño 12,7 - Rosca M 10x1 - 5 a 20 mm 1000,00 ',NULL,12512.52,6256.00),
	 (N'Caño 12,7 - Rosca M 10x1 - Hembra 5 a 20 mm 100,00 ',N'Caño 12,7 - Rosca M 10x1 - Hembra 5 a 20 mm 100,00 ',NULL,51222.66,25611.00);
INSERT INTO Fabrica.dbo.Productos (Nombre,Descripcion,Imagen,Precio,Costo) VALUES
	 (N'Caño 12,7 - Rosca M 10x1 - Hembra 5 a 20 mm 180,00 ',N'Caño 12,7 - Rosca M 10x1 - Hembra 5 a 20 mm 180,00 ',NULL,33370.73,16685.00),
	 (N'Caño 12,7 - Rosca M 10x1 - Hembra 5 a 20 mm 1250,00 ',N'Caño 12,7 - Rosca M 10x1 - Hembra 5 a 20 mm 1250,00 ',NULL,26356.81,13178.00),
	 (N'Perforado',N'Perforado',NULL,45044.97,22522.00),
	 (N'Curvado',N'Curvado',NULL,41860.61,20930.00),
	 (N'Pliegue 3/8"',N'Pliegue 3/8"',NULL,8074.84,4037.00),
	 (N'Pliegue 1/2"',N'Pliegue 1/2"',NULL,45658.61,22829.00),
	 (N'Estriado o torsionado simple',N'Estriado o torsionado simple',NULL,17462.88,8731.00),
	 (N'Torsionado doble',N'Torsionado doble',NULL,26020.08,13010.00),
	 (N'W 3/16" 97 x 21 x 1,25 ',N'W 3/16" 97 x 21 x 1,25 ',NULL,36980.30,18490.00),
	 (N'W 1/4" 97 x 21 x 1,25',N'W 1/4" 97 x 21 x 1,25',NULL,35618.62,17809.00);
INSERT INTO Fabrica.dbo.Productos (Nombre,Descripcion,Imagen,Precio,Costo) VALUES
	 (N'M 10 x 1 97 x 21 x 1,25',N'M 10 x 1 97 x 21 x 1,25',NULL,13278.92,6639.00),
	 (N'1/2" - 26 NF 97 x 21 x 1,25',N'1/2" - 26 NF 97 x 21 x 1,25',NULL,38112.97,19056.00),
	 (N'M 10x1 18 x 20 x 22',N'M 10x1 18 x 20 x 22',NULL,58604.25,29302.00),
	 (N'M 10x1 Con toma tierra (*) 18 x 20 x 22',N'M 10x1 Con toma tierra (*) 18 x 20 x 22',NULL,48368.46,24184.00),
	 (N'M 10x1 + 3/16" W 18 x 20 x 22 ',N'M 10x1 + 3/16" W 18 x 20 x 22 ',NULL,9750.73,4875.00),
	 (N'M 10x1 + 3/16" W C/toma tierra (*) 18 x 20 x 22',N'M 10x1 + 3/16" W C/toma tierra (*) 18 x 20 x 22',NULL,9264.51,4632.00),
	 (N'',N'',NULL,14.00,1.00),
	 (N'Caño x2 ',N'Caño tp',NULL,5.00,3.00);



	 INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-06-01 00:00:00.0','2023-06-06',2),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-12-27 00:00:00.0','2023-12-28',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-12-28 00:00:00.0','2023-12-30',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-12-29 00:00:00.0','2024-01-01',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-12-30 00:00:00.0','2024-01-02',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-12-31 00:00:00.0','2024-01-01',2),
	 (N'aaaaa',N'123',N'aaaaaa','2023-11-20 20:33:33.707','2023-11-20',1),
	 (N'z<x',N'<zx',N'<zx','2023-11-20 21:45:00.65','2023-11-21',0),
	 (N'string',N'string',N'string','2023-11-20 21:45:13.803','2023-11-21',0),
	 (N'a verr',N'asdasd',N'asdadads','2023-11-21 00:46:15.25','2023-11-22',1);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-06-02 00:00:00.0','2023-06-04',3),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-06-03 00:00:00.0','2023-06-07',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-06-04 00:00:00.0','2023-06-09',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-06-05 00:00:00.0','2023-06-09',3),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-06-06 00:00:00.0','2023-06-10',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-06-07 00:00:00.0','2023-06-08',2),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-06-08 00:00:00.0','2023-06-09',3),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-06-09 00:00:00.0','2023-06-13',3),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-06-10 00:00:00.0','2023-06-11',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-06-11 00:00:00.0','2023-06-12',3);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-06-12 00:00:00.0','2023-06-13',3),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-06-13 00:00:00.0','2023-06-14',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-06-14 00:00:00.0','2023-06-16',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-06-15 00:00:00.0','2023-06-17',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-06-16 00:00:00.0','2023-06-18',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-06-17 00:00:00.0','2023-06-22',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-06-18 00:00:00.0','2023-06-20',3),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-06-19 00:00:00.0','2023-06-21',3),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-06-20 00:00:00.0','2023-06-25',2),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-06-21 00:00:00.0','2023-06-26',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-06-22 00:00:00.0','2023-06-27',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-06-23 00:00:00.0','2023-06-26',3),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-06-24 00:00:00.0','2023-06-29',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-06-25 00:00:00.0','2023-06-26',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-06-26 00:00:00.0','2023-06-30',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-06-27 00:00:00.0','2023-07-02',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-06-28 00:00:00.0','2023-07-01',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-06-29 00:00:00.0','2023-07-02',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-06-30 00:00:00.0','2023-07-01',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-07-01 00:00:00.0','2023-07-06',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-07-02 00:00:00.0','2023-07-07',3),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-07-03 00:00:00.0','2023-07-07',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-07-04 00:00:00.0','2023-07-07',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-07-05 00:00:00.0','2023-07-08',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-07-06 00:00:00.0','2023-07-10',3),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-07-07 00:00:00.0','2023-07-08',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-07-08 00:00:00.0','2023-07-11',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-07-09 00:00:00.0','2023-07-14',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-07-10 00:00:00.0','2023-07-12',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-07-11 00:00:00.0','2023-07-15',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-07-12 00:00:00.0','2023-07-14',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-07-13 00:00:00.0','2023-07-16',3),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-07-14 00:00:00.0','2023-07-19',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-07-15 00:00:00.0','2023-07-17',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-07-16 00:00:00.0','2023-07-17',3),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-07-17 00:00:00.0','2023-07-20',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-07-18 00:00:00.0','2023-07-19',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-07-19 00:00:00.0','2023-07-20',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-07-20 00:00:00.0','2023-07-25',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-07-21 00:00:00.0','2023-07-23',3);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-07-22 00:00:00.0','2023-07-26',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-07-23 00:00:00.0','2023-07-28',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-07-24 00:00:00.0','2023-07-28',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-07-25 00:00:00.0','2023-07-28',3),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-07-26 00:00:00.0','2023-07-29',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-07-27 00:00:00.0','2023-07-30',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-07-28 00:00:00.0','2023-07-30',2),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-07-29 00:00:00.0','2023-07-31',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-07-30 00:00:00.0','2023-08-01',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-07-31 00:00:00.0','2023-08-05',3);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-08-01 00:00:00.0','2023-08-06',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-08-02 00:00:00.0','2023-08-04',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-08-03 00:00:00.0','2023-08-06',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-08-04 00:00:00.0','2023-08-07',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-08-05 00:00:00.0','2023-08-09',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-08-06 00:00:00.0','2023-08-07',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-08-07 00:00:00.0','2023-08-11',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-08-08 00:00:00.0','2023-08-12',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-08-09 00:00:00.0','2023-08-14',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-08-10 00:00:00.0','2023-08-14',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-08-11 00:00:00.0','2023-08-16',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-08-12 00:00:00.0','2023-08-13',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-08-13 00:00:00.0','2023-08-16',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-08-14 00:00:00.0','2023-08-15',3),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-08-15 00:00:00.0','2023-08-19',3),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-08-16 00:00:00.0','2023-08-17',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-08-17 00:00:00.0','2023-08-22',3),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-08-18 00:00:00.0','2023-08-20',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-08-19 00:00:00.0','2023-08-23',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-08-20 00:00:00.0','2023-08-25',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-08-21 00:00:00.0','2023-08-26',2),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-08-22 00:00:00.0','2023-08-23',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-08-23 00:00:00.0','2023-08-25',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-08-24 00:00:00.0','2023-08-27',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-08-25 00:00:00.0','2023-08-29',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-08-26 00:00:00.0','2023-08-31',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-08-27 00:00:00.0','2023-09-01',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-08-28 00:00:00.0','2023-08-30',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-08-29 00:00:00.0','2023-08-31',3),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-08-30 00:00:00.0','2023-09-04',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-08-31 00:00:00.0','2023-09-04',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-09-01 00:00:00.0','2023-09-02',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-09-02 00:00:00.0','2023-09-06',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-09-03 00:00:00.0','2023-09-08',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-09-04 00:00:00.0','2023-09-06',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-09-05 00:00:00.0','2023-09-10',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-09-06 00:00:00.0','2023-09-08',3),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-09-07 00:00:00.0','2023-09-10',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-09-08 00:00:00.0','2023-09-10',3),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-09-09 00:00:00.0','2023-09-13',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-09-10 00:00:00.0','2023-09-12',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-09-11 00:00:00.0','2023-09-16',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-09-12 00:00:00.0','2023-09-13',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-09-13 00:00:00.0','2023-09-15',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-09-14 00:00:00.0','2023-09-19',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-09-15 00:00:00.0','2023-09-17',3),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-09-16 00:00:00.0','2023-09-21',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-09-17 00:00:00.0','2023-09-21',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-09-18 00:00:00.0','2023-09-19',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-09-19 00:00:00.0','2023-09-24',3);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-09-20 00:00:00.0','2023-09-24',3),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-09-21 00:00:00.0','2023-09-22',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-09-22 00:00:00.0','2023-09-27',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-09-23 00:00:00.0','2023-09-28',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-09-24 00:00:00.0','2023-09-27',3),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-09-25 00:00:00.0','2023-09-30',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-09-26 00:00:00.0','2023-10-01',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-09-27 00:00:00.0','2023-10-02',3),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-09-28 00:00:00.0','2023-10-03',2),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-09-29 00:00:00.0','2023-10-02',3);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-09-30 00:00:00.0','2023-10-01',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-10-01 00:00:00.0','2023-10-04',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-10-02 00:00:00.0','2023-10-07',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-10-03 00:00:00.0','2023-10-08',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-10-04 00:00:00.0','2023-10-09',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-10-05 00:00:00.0','2023-10-08',3),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-10-06 00:00:00.0','2023-10-07',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-10-07 00:00:00.0','2023-10-08',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-10-08 00:00:00.0','2023-10-13',3),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-10-09 00:00:00.0','2023-10-13',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-10-10 00:00:00.0','2023-10-13',3),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-10-11 00:00:00.0','2023-10-12',3),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-10-12 00:00:00.0','2023-10-14',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-10-13 00:00:00.0','2023-10-18',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-10-14 00:00:00.0','2023-10-17',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-10-15 00:00:00.0','2023-10-20',3),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-10-16 00:00:00.0','2023-10-17',3),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-10-17 00:00:00.0','2023-10-18',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-10-18 00:00:00.0','2023-10-22',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-10-19 00:00:00.0','2023-10-22',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-10-20 00:00:00.0','2023-10-25',3),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-10-21 00:00:00.0','2023-10-25',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-10-22 00:00:00.0','2023-10-26',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-10-23 00:00:00.0','2023-10-25',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-10-24 00:00:00.0','2023-10-26',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-10-25 00:00:00.0','2023-10-27',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-10-26 00:00:00.0','2023-10-31',2),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-10-27 00:00:00.0','2023-10-31',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-10-28 00:00:00.0','2023-10-29',2),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-10-29 00:00:00.0','2023-11-01',2);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-10-30 00:00:00.0','2023-11-01',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-10-31 00:00:00.0','2023-11-01',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-11-01 00:00:00.0','2023-11-02',2),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-11-02 00:00:00.0','2023-11-05',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-11-03 00:00:00.0','2023-11-07',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-11-04 00:00:00.0','2023-11-07',2),
	 (N'Mendez, Mauricio',N'33108129450',N'MauricioMendez@gmail.com','2023-11-05 00:00:00.0','2023-11-06',2),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-11-06 00:00:00.0','2023-11-07',3),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-11-07 00:00:00.0','2023-11-09',2),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-11-08 00:00:00.0','2023-11-12',3);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-11-09 00:00:00.0','2023-11-14',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-11-10 00:00:00.0','2023-11-11',3),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-11-11 00:00:00.0','2023-11-16',2),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-11-12 00:00:00.0','2023-11-15',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-11-13 00:00:00.0','2023-11-15',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-11-14 00:00:00.0','2023-11-19',2),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-11-15 00:00:00.0','2023-11-16',2),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-11-16 00:00:00.0','2023-11-17',2),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-11-17 00:00:00.0','2023-11-19',3),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-11-18 00:00:00.0','2023-11-23',3);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-11-19 00:00:00.0','2023-11-20',3),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-11-20 00:00:00.0','2023-11-23',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-11-21 00:00:00.0','2023-11-26',2),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-11-22 00:00:00.0','2023-11-26',1),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-11-23 00:00:00.0','2023-11-24',0),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-11-24 00:00:00.0','2023-11-25',0),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-11-25 00:00:00.0','2023-11-27',1),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-11-26 00:00:00.0','2023-11-28',1),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-11-27 00:00:00.0','2023-11-29',0),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-11-28 00:00:00.0','2023-12-02',0);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-11-29 00:00:00.0','2023-12-02',1),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-11-30 00:00:00.0','2023-12-05',0),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-12-01 00:00:00.0','2023-12-05',0),
	 (N'Ruiz, Aurora',N'31192624457',N'AuroraRuiz@gmail.com','2023-12-02 00:00:00.0','2023-12-07',0),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-12-03 00:00:00.0','2023-12-07',0),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-12-04 00:00:00.0','2023-12-09',1),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-12-05 00:00:00.0','2023-12-09',0),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-12-06 00:00:00.0','2023-12-09',0),
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-12-07 00:00:00.0','2023-12-10',0),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-12-08 00:00:00.0','2023-12-10',0);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Rubio, Antonio',N'89170512449',N'AntonioRubio@gmail.com','2023-12-09 00:00:00.0','2023-12-11',0),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-12-10 00:00:00.0','2023-12-13',1),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-12-11 00:00:00.0','2023-12-12',0),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-12-12 00:00:00.0','2023-12-14',0),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-12-13 00:00:00.0','2023-12-17',0),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-12-14 00:00:00.0','2023-12-16',0),
	 (N'Suarez, Eva',N'19980287935',N'EvaSuarez@gmail.com','2023-12-15 00:00:00.0','2023-12-20',0),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-12-16 00:00:00.0','2023-12-20',0),
	 (N'Gonzalez, Omar',N'96492039860',N'OmarGonzalez@gmail.com','2023-12-17 00:00:00.0','2023-12-21',0),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-12-18 00:00:00.0','2023-12-23',0);
INSERT INTO Fabrica.dbo.Pedidos (NombreCliente,CuitCliente,CorreoCliente,FechaPedido,FechaEntrega,Estado_id) VALUES
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-12-19 00:00:00.0','2023-12-22',0),
	 (N'Herrero, Iris',N'29381321412',N'IrisHerrero@gmail.com','2023-12-20 00:00:00.0','2023-12-24',0),
	 (N'Leon, Maximiliano',N'29694317678',N'MaximilianoLeon@gmail.com','2023-12-21 00:00:00.0','2023-12-24',0),
	 (N'Arias, Javier',N'66834751053',N'JavierArias@gmail.com','2023-12-22 00:00:00.0','2023-12-25',0),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-12-23 00:00:00.0','2023-12-24',0),
	 (N'Medina, Alexia',N'30392371269',N'AlexiaMedina@gmail.com','2023-12-24 00:00:00.0','2023-12-27',1),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-12-25 00:00:00.0','2023-12-26',1),
	 (N'Soto, Gabriela',N'34206144058',N'GabrielaSoto@gmail.com','2023-12-26 00:00:00.0','2023-12-29',1);





