USE [master]
GO
/****** Object:  Database [Fabrica]    Script Date: 12/11/2023 19:39:29 ******/
CREATE DATABASE [Fabrica]
 
GO
USE [Fabrica]
GO
/****** Object:  User [test]    Script Date: 12/11/2023 19:39:29 ******/
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[DetallesPedidos]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  Table [dbo].[Estados]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  Table [dbo].[Pedidos]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  Table [dbo].[Productos]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[CONSULTAR_PRODUCTO]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[CONSULTAR_PRODUCTOS]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[CREAR_PRODUCTO]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[MODIFICAR_PRODUCTO]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_DETALLE_PEDIDO]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_ESTADOS]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PEDIDOS]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_PRODUCTO]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 12/11/2023 19:39:29 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 12/11/2023 19:39:29 ******/
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
USE [master]
GO
ALTER DATABASE [Fabrica] SET  READ_WRITE 
GO

INSERT INTO Fabrica.dbo.Estados (Nombre) VALUES
	 (N'Pendiente'),
	 (N'En progreso'),
	 (N'Entregado'),
	 (N'Cancelado');

