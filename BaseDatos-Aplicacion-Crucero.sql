USE [master]
GO
/****** Object:  Database [AplicacionCrucero]    Script Date: 6/3/2023 03:47:51 ******/
CREATE DATABASE [AplicacionCrucero]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AplicacionCrucero', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AplicacionCrucero.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AplicacionCrucero_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AplicacionCrucero_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AplicacionCrucero] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AplicacionCrucero].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AplicacionCrucero] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET ARITHABORT OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AplicacionCrucero] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AplicacionCrucero] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AplicacionCrucero] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AplicacionCrucero] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET RECOVERY FULL 
GO
ALTER DATABASE [AplicacionCrucero] SET  MULTI_USER 
GO
ALTER DATABASE [AplicacionCrucero] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AplicacionCrucero] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AplicacionCrucero] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AplicacionCrucero] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AplicacionCrucero] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AplicacionCrucero] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AplicacionCrucero', N'ON'
GO
ALTER DATABASE [AplicacionCrucero] SET QUERY_STORE = OFF
GO
USE [AplicacionCrucero]
GO
/****** Object:  Table [dbo].[Capitanes]    Script Date: 6/3/2023 03:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capitanes](
	[id_capitan] [int] NOT NULL,
	[Hora_Viajes] [int] NOT NULL,
	[Viajes_realizados] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_capitan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cruceros]    Script Date: 6/3/2023 03:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cruceros](
	[id_crucero] [int] IDENTITY(1,1) NOT NULL,
	[Matricula] [varchar](9) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Camarotes] [int] NOT NULL,
	[Salones] [int] NOT NULL,
	[Casinos] [int] NOT NULL,
	[Piscinas] [int] NOT NULL,
	[Gimnacios] [int] NOT NULL,
	[Capacidad_bodega] [float] NOT NULL,
	[Peso_total_bodega] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_crucero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 6/3/2023 03:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[id_empleado] [int] NOT NULL,
	[Puesto] [int] NOT NULL,
	[Fecha_ingreso] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipajes]    Script Date: 6/3/2023 03:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipajes](
	[id_equipaje] [int] NOT NULL,
	[Bolsos] [int] NOT NULL,
	[Maletas] [int] NOT NULL,
	[Peso_maletas] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_equipaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pasajeros]    Script Date: 6/3/2023 03:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasajeros](
	[id_pasajero] [int] NOT NULL,
	[Correo] [varchar](30) NULL,
	[Clase] [int] NOT NULL,
	[Casino] [bit] NOT NULL,
	[Piscina] [bit] NOT NULL,
	[Gimnacio] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pasajero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 6/3/2023 03:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[DNI] [int] NOT NULL,
	[Celular] [float] NOT NULL,
	[Nacionalidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tripulantes]    Script Date: 6/3/2023 03:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tripulantes](
	[id_persona] [int] NOT NULL,
	[id_crucero] [int] NOT NULL,
	[id_viaje] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Viajes]    Script Date: 6/3/2023 03:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viajes](
	[id_viaje] [int] IDENTITY(1,1) NOT NULL,
	[Ciudad_partida] [int] NOT NULL,
	[Destino] [int] NOT NULL,
	[Fecha_inicio] [varchar](50) NOT NULL,
	[id_tipo_crucero] [int] NOT NULL,
	[Camarotes_premium] [int] NOT NULL,
	[Camarotes_turista] [int] NOT NULL,
	[Costo_premium] [float] NOT NULL,
	[Costo_turista] [float] NOT NULL,
	[Duracion_viaje] [int] NOT NULL,
 CONSTRAINT [PK__Viajes__29535AC3936A6F24] PRIMARY KEY CLUSTERED 
(
	[id_viaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Capitanes]  WITH CHECK ADD FOREIGN KEY([id_capitan])
REFERENCES [dbo].[Persona] ([id_persona])
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([id_empleado])
REFERENCES [dbo].[Persona] ([id_persona])
GO
ALTER TABLE [dbo].[Equipajes]  WITH CHECK ADD FOREIGN KEY([id_equipaje])
REFERENCES [dbo].[Pasajeros] ([id_pasajero])
GO
ALTER TABLE [dbo].[Pasajeros]  WITH CHECK ADD FOREIGN KEY([id_pasajero])
REFERENCES [dbo].[Persona] ([id_persona])
GO
ALTER TABLE [dbo].[Tripulantes]  WITH CHECK ADD FOREIGN KEY([id_crucero])
REFERENCES [dbo].[Cruceros] ([id_crucero])
GO
ALTER TABLE [dbo].[Tripulantes]  WITH CHECK ADD FOREIGN KEY([id_persona])
REFERENCES [dbo].[Persona] ([id_persona])
GO
ALTER TABLE [dbo].[Tripulantes]  WITH CHECK ADD  CONSTRAINT [FK__Tripulant__id_vi__4AB81AF0] FOREIGN KEY([id_viaje])
REFERENCES [dbo].[Viajes] ([id_viaje])
GO
ALTER TABLE [dbo].[Tripulantes] CHECK CONSTRAINT [FK__Tripulant__id_vi__4AB81AF0]
GO
ALTER TABLE [dbo].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK__Viajes__id_tipo___38996AB5] FOREIGN KEY([id_tipo_crucero])
REFERENCES [dbo].[Cruceros] ([id_crucero])
GO
ALTER TABLE [dbo].[Viajes] CHECK CONSTRAINT [FK__Viajes__id_tipo___38996AB5]
GO
USE [master]
GO
ALTER DATABASE [AplicacionCrucero] SET  READ_WRITE 
GO
