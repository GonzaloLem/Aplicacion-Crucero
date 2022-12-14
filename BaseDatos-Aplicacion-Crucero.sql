USE [master]
GO
/****** Object:  Database [AplicacionCrucero]    Script Date: 20/12/2022 00:49:28 ******/
CREATE DATABASE [AplicacionCrucero]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AplicacionCrucero', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AplicacionCrucero.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AplicacionCrucero_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AplicacionCrucero_log.ldf' , SIZE = 66560KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [AplicacionCrucero] SET  DISABLE_BROKER 
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
/****** Object:  Table [dbo].[Capitan]    Script Date: 20/12/2022 00:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capitan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HorasDeViaje] [int] NOT NULL,
	[ViajesRealizadosConLaEmpresa] [int] NOT NULL,
 CONSTRAINT [PK_Capitan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Crucero]    Script Date: 20/12/2022 00:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crucero](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Matricula] [varchar](8) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Camarotes] [int] NOT NULL,
	[Salones] [int] NOT NULL,
	[Casinos] [int] NOT NULL,
	[Piscinas] [int] NOT NULL,
	[Gimnacios] [int] NOT NULL,
	[CapacidadBodega] [float] NOT NULL,
	[PesoTotalDeLaBodega] [float] NOT NULL,
 CONSTRAINT [PK_Crucero] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 20/12/2022 00:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Puesto] [int] NOT NULL,
	[FechaDeIngreso] [datetime] NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipaje]    Script Date: 20/12/2022 00:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipaje](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Bolsos] [int] NOT NULL,
	[Maletas] [int] NOT NULL,
	[PesoTotalMaletas] [float] NOT NULL,
 CONSTRAINT [PK_Equipaje] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pasajero]    Script Date: 20/12/2022 00:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasajero](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [varchar](50) NULL,
	[Clase] [int] NOT NULL,
	[ID_Equipaje] [int] NOT NULL,
	[Casino] [bit] NOT NULL,
	[Piscina] [bit] NOT NULL,
	[Gimnacio] [bit] NOT NULL,
 CONSTRAINT [PK_Pasajero] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 20/12/2022 00:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[DNI] [int] NOT NULL,
	[Nacionalidad] [int] NOT NULL,
	[Celular] [float] NOT NULL,
	[ID_Pasajero] [int] NULL,
	[ID_Empleado] [int] NULL,
	[ID_Capitan] [int] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tripulante]    Script Date: 20/12/2022 00:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tripulante](
	[ID_Tripulante] [int] IDENTITY(1,1) NOT NULL,
	[ID_Persona] [int] NOT NULL,
	[ID_Viaje] [int] NOT NULL,
	[ID_Crucero] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tripulante] PRIMARY KEY CLUSTERED 
(
	[ID_Tripulante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Viaje]    Script Date: 20/12/2022 00:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viaje](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CiudadDePartida] [int] NOT NULL,
	[Destino] [int] NOT NULL,
	[FechaDeInicio] [varchar](50) NOT NULL,
	[ID_Crucero] [int] NOT NULL,
	[CamarotesPremium] [int] NOT NULL,
	[CamarotesTurista] [int] NOT NULL,
	[CostoPremium] [float] NOT NULL,
	[CostoTurista] [float] NOT NULL,
	[DuracionDelViaje] [int] NOT NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Capitan] ON 

INSERT [dbo].[Capitan] ([ID], [HorasDeViaje], [ViajesRealizadosConLaEmpresa]) VALUES (1, 4000, 0)
INSERT [dbo].[Capitan] ([ID], [HorasDeViaje], [ViajesRealizadosConLaEmpresa]) VALUES (2, 4569, 0)
SET IDENTITY_INSERT [dbo].[Capitan] OFF
GO
SET IDENTITY_INSERT [dbo].[Crucero] ON 

INSERT [dbo].[Crucero] ([ID], [Matricula], [Nombre], [Camarotes], [Salones], [Casinos], [Piscinas], [Gimnacios], [CapacidadBodega], [PesoTotalDeLaBodega]) VALUES (1, N'VHK-4555', N'Perla Negra', 139, 23, 10, 3, 6, 856733, 0)
INSERT [dbo].[Crucero] ([ID], [Matricula], [Nombre], [Camarotes], [Salones], [Casinos], [Piscinas], [Gimnacios], [CapacidadBodega], [PesoTotalDeLaBodega]) VALUES (2, N'NAA-1762', N'Titanic', 300, 31, 12, 4, 7, 64123, 0)
INSERT [dbo].[Crucero] ([ID], [Matricula], [Nombre], [Camarotes], [Salones], [Casinos], [Piscinas], [Gimnacios], [CapacidadBodega], [PesoTotalDeLaBodega]) VALUES (3, N'OVD-7002', N'Ocean', 85, 10, 2, 1, 1, 6402, 0)
INSERT [dbo].[Crucero] ([ID], [Matricula], [Nombre], [Camarotes], [Salones], [Casinos], [Piscinas], [Gimnacios], [CapacidadBodega], [PesoTotalDeLaBodega]) VALUES (5, N'XSO-7598', N'Carnival Cruz Line', 500, 73, 15, 5, 10, 150123, 0)
INSERT [dbo].[Crucero] ([ID], [Matricula], [Nombre], [Camarotes], [Salones], [Casinos], [Piscinas], [Gimnacios], [CapacidadBodega], [PesoTotalDeLaBodega]) VALUES (6, N'YLX-3795', N'Princess Cruises', 123, 6, 2, 0, 0, 3412, 0)
INSERT [dbo].[Crucero] ([ID], [Matricula], [Nombre], [Camarotes], [Salones], [Casinos], [Piscinas], [Gimnacios], [CapacidadBodega], [PesoTotalDeLaBodega]) VALUES (7, N'JBE-5724', N'Norwegian Cruise Line', 780, 125, 17, 15, 0, 60000, 0)
INSERT [dbo].[Crucero] ([ID], [Matricula], [Nombre], [Camarotes], [Salones], [Casinos], [Piscinas], [Gimnacios], [CapacidadBodega], [PesoTotalDeLaBodega]) VALUES (8, N'KYW-4609', N'Cunard Line', 80, 15, 0, 1, 1, 2812, 0)
INSERT [dbo].[Crucero] ([ID], [Matricula], [Nombre], [Camarotes], [Salones], [Casinos], [Piscinas], [Gimnacios], [CapacidadBodega], [PesoTotalDeLaBodega]) VALUES (9, N'FMY-2371', N'Ventura', 120, 5, 0, 0, 0, 1500, 0)
SET IDENTITY_INSERT [dbo].[Crucero] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([ID], [Puesto], [FechaDeIngreso]) VALUES (1, 1, CAST(N'2022-12-12T21:37:58.000' AS DateTime))
INSERT [dbo].[Empleado] ([ID], [Puesto], [FechaDeIngreso]) VALUES (2, 4, CAST(N'2022-12-12T00:25:14.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Equipaje] ON 

INSERT [dbo].[Equipaje] ([ID], [Bolsos], [Maletas], [PesoTotalMaletas]) VALUES (1, 1, 1, 15)
INSERT [dbo].[Equipaje] ([ID], [Bolsos], [Maletas], [PesoTotalMaletas]) VALUES (1003, 1, 1, 15)
INSERT [dbo].[Equipaje] ([ID], [Bolsos], [Maletas], [PesoTotalMaletas]) VALUES (1004, 1, 1, 5)
SET IDENTITY_INSERT [dbo].[Equipaje] OFF
GO
SET IDENTITY_INSERT [dbo].[Pasajero] ON 

INSERT [dbo].[Pasajero] ([ID], [Correo], [Clase], [ID_Equipaje], [Casino], [Piscina], [Gimnacio]) VALUES (1, N'gonzalonl308@gmail.com', 0, 1, 1, 1, 1)
INSERT [dbo].[Pasajero] ([ID], [Correo], [Clase], [ID_Equipaje], [Casino], [Piscina], [Gimnacio]) VALUES (1002, N'martina@gmail.com', 1, 1003, 0, 1, 0)
INSERT [dbo].[Pasajero] ([ID], [Correo], [Clase], [ID_Equipaje], [Casino], [Piscina], [Gimnacio]) VALUES (1003, N'leo@gmail.com', 0, 1004, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Pasajero] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([ID], [Nombre], [Apellido], [Edad], [DNI], [Nacionalidad], [Celular], [ID_Pasajero], [ID_Empleado], [ID_Capitan]) VALUES (1, N'Gonzalo', N'Lemiña', 21, 43593947, 1, 1134153038, 1, NULL, NULL)
INSERT [dbo].[Persona] ([ID], [Nombre], [Apellido], [Edad], [DNI], [Nacionalidad], [Celular], [ID_Pasajero], [ID_Empleado], [ID_Capitan]) VALUES (2, N'Valeria', N'Vazquez', 44, 44232745, 1, 1566445599, NULL, 1, NULL)
INSERT [dbo].[Persona] ([ID], [Nombre], [Apellido], [Edad], [DNI], [Nacionalidad], [Celular], [ID_Pasajero], [ID_Empleado], [ID_Capitan]) VALUES (7, N'Roko', N'Gonzalez', 60, 60783131, 1, 1577815599, NULL, NULL, 1)
INSERT [dbo].[Persona] ([ID], [Nombre], [Apellido], [Edad], [DNI], [Nacionalidad], [Celular], [ID_Pasajero], [ID_Empleado], [ID_Capitan]) VALUES (8, N'Santino', N'Gilardi', 50, 50648123, 9, 1133691233, NULL, NULL, 2)
INSERT [dbo].[Persona] ([ID], [Nombre], [Apellido], [Edad], [DNI], [Nacionalidad], [Celular], [ID_Pasajero], [ID_Empleado], [ID_Capitan]) VALUES (10, N'Paola', N'Vazquez', 44, 44591231, 0, 1231231312, NULL, 2, NULL)
INSERT [dbo].[Persona] ([ID], [Nombre], [Apellido], [Edad], [DNI], [Nacionalidad], [Celular], [ID_Pasajero], [ID_Empleado], [ID_Capitan]) VALUES (1003, N'Martina', N'Lemiña', 15, 59315123, 10, 1151231231, 1002, NULL, NULL)
INSERT [dbo].[Persona] ([ID], [Nombre], [Apellido], [Edad], [DNI], [Nacionalidad], [Celular], [ID_Pasajero], [ID_Empleado], [ID_Capitan]) VALUES (1004, N'Leonardo', N'Gilardi', 44, 21512312, 20, 3312123123, 1003, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Tripulante] ON 

INSERT [dbo].[Tripulante] ([ID_Tripulante], [ID_Persona], [ID_Viaje], [ID_Crucero], [Estado]) VALUES (3, 1, 3, 2, 1)
INSERT [dbo].[Tripulante] ([ID_Tripulante], [ID_Persona], [ID_Viaje], [ID_Crucero], [Estado]) VALUES (4, 2, 3, 2, 1)
INSERT [dbo].[Tripulante] ([ID_Tripulante], [ID_Persona], [ID_Viaje], [ID_Crucero], [Estado]) VALUES (5, 7, 4, 9, 1)
INSERT [dbo].[Tripulante] ([ID_Tripulante], [ID_Persona], [ID_Viaje], [ID_Crucero], [Estado]) VALUES (7, 8, 7, 2, 1)
INSERT [dbo].[Tripulante] ([ID_Tripulante], [ID_Persona], [ID_Viaje], [ID_Crucero], [Estado]) VALUES (8, 1003, 3, 2, 1)
INSERT [dbo].[Tripulante] ([ID_Tripulante], [ID_Persona], [ID_Viaje], [ID_Crucero], [Estado]) VALUES (9, 1004, 7, 2, 1)
SET IDENTITY_INSERT [dbo].[Tripulante] OFF
GO
SET IDENTITY_INSERT [dbo].[Viaje] ON 

INSERT [dbo].[Viaje] ([ID], [CiudadDePartida], [Destino], [FechaDeInicio], [ID_Crucero], [CamarotesPremium], [CamarotesTurista], [CostoPremium], [CostoTurista], [DuracionDelViaje]) VALUES (2, 4, 104, N'1/1/2022 18:44:05', 5, 175, 325, 74676, 62230, 490)
INSERT [dbo].[Viaje] ([ID], [CiudadDePartida], [Destino], [FechaDeInicio], [ID_Crucero], [CamarotesPremium], [CamarotesTurista], [CostoPremium], [CostoTurista], [DuracionDelViaje]) VALUES (3, 0, 100, N'14/2/2023 18:45:09', 2, 105, 195, 89916, 74930, 590)
INSERT [dbo].[Viaje] ([ID], [CiudadDePartida], [Destino], [FechaDeInicio], [ID_Crucero], [CamarotesPremium], [CamarotesTurista], [CostoPremium], [CostoTurista], [DuracionDelViaje]) VALUES (4, 0, 0, N'31/8/2023 18:36:05', 9, 42, 78, 18331, 15276, 268)
INSERT [dbo].[Viaje] ([ID], [CiudadDePartida], [Destino], [FechaDeInicio], [ID_Crucero], [CamarotesPremium], [CamarotesTurista], [CostoPremium], [CostoTurista], [DuracionDelViaje]) VALUES (5, 4, 107, N'13/12/2022 17:44:34', 3, 29, 56, 75590, 62992, 496)
INSERT [dbo].[Viaje] ([ID], [CiudadDePartida], [Destino], [FechaDeInicio], [ID_Crucero], [CamarotesPremium], [CamarotesTurista], [CostoPremium], [CostoTurista], [DuracionDelViaje]) VALUES (6, 2, 9, N'29/1/2023 19:01:07', 8, 28, 52, 10807, 9006, 158)
INSERT [dbo].[Viaje] ([ID], [CiudadDePartida], [Destino], [FechaDeInicio], [ID_Crucero], [CamarotesPremium], [CamarotesTurista], [CostoPremium], [CostoTurista], [DuracionDelViaje]) VALUES (7, 1, 6, N'4/1/2023 22:41:58', 2, 105, 195, 16689, 13908, 244)
INSERT [dbo].[Viaje] ([ID], [CiudadDePartida], [Destino], [FechaDeInicio], [ID_Crucero], [CamarotesPremium], [CamarotesTurista], [CostoPremium], [CostoTurista], [DuracionDelViaje]) VALUES (8, 3, 100, N'4/1/2023 23:16:29', 6, 43, 80, 80314, 66929, 527)
SET IDENTITY_INSERT [dbo].[Viaje] OFF
GO
ALTER TABLE [dbo].[Pasajero]  WITH CHECK ADD  CONSTRAINT [FK_Pasajero_Equipaje] FOREIGN KEY([ID_Equipaje])
REFERENCES [dbo].[Equipaje] ([ID])
GO
ALTER TABLE [dbo].[Pasajero] CHECK CONSTRAINT [FK_Pasajero_Equipaje]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Capitan] FOREIGN KEY([ID_Capitan])
REFERENCES [dbo].[Capitan] ([ID])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Capitan]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Empleado] FOREIGN KEY([ID_Empleado])
REFERENCES [dbo].[Empleado] ([ID])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Empleado]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Pasajero] FOREIGN KEY([ID_Pasajero])
REFERENCES [dbo].[Pasajero] ([ID])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Pasajero]
GO
ALTER TABLE [dbo].[Tripulante]  WITH CHECK ADD  CONSTRAINT [FK_Tripulante_Crucero] FOREIGN KEY([ID_Crucero])
REFERENCES [dbo].[Crucero] ([ID])
GO
ALTER TABLE [dbo].[Tripulante] CHECK CONSTRAINT [FK_Tripulante_Crucero]
GO
ALTER TABLE [dbo].[Tripulante]  WITH CHECK ADD  CONSTRAINT [FK_Tripulante_Viaje] FOREIGN KEY([ID_Viaje])
REFERENCES [dbo].[Viaje] ([ID])
GO
ALTER TABLE [dbo].[Tripulante] CHECK CONSTRAINT [FK_Tripulante_Viaje]
GO
ALTER TABLE [dbo].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Crucero] FOREIGN KEY([ID_Crucero])
REFERENCES [dbo].[Crucero] ([ID])
GO
ALTER TABLE [dbo].[Viaje] CHECK CONSTRAINT [FK_Viaje_Crucero]
GO
USE [master]
GO
ALTER DATABASE [AplicacionCrucero] SET  READ_WRITE 
GO
