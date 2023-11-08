USE [master]
GO
/****** Object:  Database [Fabrica]    Script Date: 7/11/2023 21:16:18 ******/
CREATE DATABASE [Fabrica]


GO
USE [Fabrica]
GO
/****** Object:  User [test]    Script Date: 7/11/2023 21:16:18 ******/

CREATE TABLE [dbo].[DetallesPedidos](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[Pedido_id] [int] NOT NULL,
	[Producto_id] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [int] NULL,
	[Costo] [decimal](2, 2) NOT NULL,
 CONSTRAINT [DetallesPedidos_PK] PRIMARY KEY CLUSTERED 
(
	[Pedido_id] ASC,
	[Producto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 7/11/2023 21:16:18 ******/
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
/****** Object:  Table [dbo].[Pedidos]    Script Date: 7/11/2023 21:16:18 ******/
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
/****** Object:  Table [dbo].[Productos]    Script Date: 7/11/2023 21:16:18 ******/
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
USE [master]
GO
ALTER DATABASE [Fabrica] SET  READ_WRITE 
GO
