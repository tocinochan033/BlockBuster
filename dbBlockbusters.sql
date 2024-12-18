USE [master]
GO
/****** Object:  Database [COCKBUSTERS]    Script Date: 12/10/2024 7:00:05 PM ******/
CREATE DATABASE [COCKBUSTERS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'COCKBUSTERS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\COCKBUSTERS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'COCKBUSTERS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\COCKBUSTERS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [COCKBUSTERS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [COCKBUSTERS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [COCKBUSTERS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET ARITHABORT OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [COCKBUSTERS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [COCKBUSTERS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [COCKBUSTERS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [COCKBUSTERS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [COCKBUSTERS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [COCKBUSTERS] SET  MULTI_USER 
GO
ALTER DATABASE [COCKBUSTERS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [COCKBUSTERS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [COCKBUSTERS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [COCKBUSTERS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [COCKBUSTERS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [COCKBUSTERS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [COCKBUSTERS] SET QUERY_STORE = ON
GO
ALTER DATABASE [COCKBUSTERS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [COCKBUSTERS]
GO
/****** Object:  Table [dbo].[actor]    Script Date: 12/10/2024 7:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[actor](
	[id_actor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[apellido] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_actor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[director]    Script Date: 12/10/2024 7:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[director](
	[id_director] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[apellido] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_director] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estatus]    Script Date: 12/10/2024 7:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estatus](
	[id_estatus] [int] IDENTITY(1,1) NOT NULL,
	[estatus] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genero]    Script Date: 12/10/2024 7:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genero](
	[id_genero] [int] IDENTITY(1,1) NOT NULL,
	[genero] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[idioma]    Script Date: 12/10/2024 7:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idioma](
	[id_idioma] [int] IDENTITY(1,1) NOT NULL,
	[idioma] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pelicula]    Script Date: 12/10/2024 7:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pelicula](
	[id_pelicula] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [nvarchar](255) NOT NULL,
	[fecha] [int] NOT NULL,
	[duracion_min] [int] NOT NULL,
	[id_idioma] [int] NOT NULL,
	[id_genero] [int] NOT NULL,
	[id_estatus] [int] NOT NULL,
	[id_actor] [int] NOT NULL,
	[id_director] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[actor] ON 

INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (1, N'Tom', N'Cruise')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (2, N'Will', N'Smith')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (3, N'Leonardo', N'DiCaprio')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (4, N'Brad', N'Pitt')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (5, N'Emily', N'Kinney')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (6, N'Andrew', N'Lincoln')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (7, N'Norman', N'Rodeeus')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (8, N'Melissa', N'McBride')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (9, N'Lauren', N'Cohan')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (10, N'CILLIAN', N'MURPHY')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (11, N'MARCOS', N'MEDEIROS')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (12, N'JUAN', N'CARLOS')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (13, N'MALPHITE', N'AECHEVERIA')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (14, N'ESTAVAN', N'HERNANDEZ')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (15, N'CARLOS', N'BAZQUEX')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (16, N'SANDRA', N'MEGUIMIN')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (17, N'JUAN', N'CARLOS')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (18, N'IFA', N'FIA')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (19, N'DIRECTOR', N'ACTOR')
INSERT [dbo].[actor] ([id_actor], [nombre], [apellido]) VALUES (20, N'MARCO', N'ANTONIO')
SET IDENTITY_INSERT [dbo].[actor] OFF
GO
SET IDENTITY_INSERT [dbo].[director] ON 

INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (1, N'Christopher', N'Nolan')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (2, N'Quentin', N'Tarantino')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (3, N'Steven', N'Spielberg')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (4, N'Martin', N'Scorsese')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (5, N'John', N'Carpenter')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (6, N'Clint', N'Eastwood')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (7, N'Austin', N'Amelio')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (8, N'ADAM', N'SANDLER')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (9, N'JAMES ', N'CAMERON')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (10, N'JOSE', N'ANTONIO')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (11, N'JUAN CARLOS', N'BODOQUE')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (12, N'JUAN', N'CARLOS')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (13, N'FELIPE', N'VAZQUEZ')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (14, N'LYRA', N'BELAQUA')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (15, N'JUAQUIN', N'ORTEGA')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (16, N'HOLA', N'JIJIJIJ')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (17, N'FEDERICO', N'PELUCHE')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (18, N'FF', N'FFF')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (19, N'PRUEBA3', N'PRUEBA32')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (20, N'ACTOR', N'DIRECTOR')
INSERT [dbo].[director] ([id_director], [nombre], [apellido]) VALUES (21, N'CRISTIAN', N'HERNANDEZ')
SET IDENTITY_INSERT [dbo].[director] OFF
GO
SET IDENTITY_INSERT [dbo].[estatus] ON 

INSERT [dbo].[estatus] ([id_estatus], [estatus]) VALUES (1, N'Disponible')
INSERT [dbo].[estatus] ([id_estatus], [estatus]) VALUES (2, N'No Disponible')
INSERT [dbo].[estatus] ([id_estatus], [estatus]) VALUES (3, N'En Reparación')
INSERT [dbo].[estatus] ([id_estatus], [estatus]) VALUES (4, N'Reservada')
SET IDENTITY_INSERT [dbo].[estatus] OFF
GO
SET IDENTITY_INSERT [dbo].[genero] ON 

INSERT [dbo].[genero] ([id_genero], [genero]) VALUES (1, N'Acción')
INSERT [dbo].[genero] ([id_genero], [genero]) VALUES (2, N'Comedia')
INSERT [dbo].[genero] ([id_genero], [genero]) VALUES (3, N'Drama')
INSERT [dbo].[genero] ([id_genero], [genero]) VALUES (4, N'Ciencia Ficción')
INSERT [dbo].[genero] ([id_genero], [genero]) VALUES (5, N'Fantasía')
INSERT [dbo].[genero] ([id_genero], [genero]) VALUES (6, N'Terror')
INSERT [dbo].[genero] ([id_genero], [genero]) VALUES (7, N'Romance')
SET IDENTITY_INSERT [dbo].[genero] OFF
GO
SET IDENTITY_INSERT [dbo].[idioma] ON 

INSERT [dbo].[idioma] ([id_idioma], [idioma]) VALUES (1, N'Español')
INSERT [dbo].[idioma] ([id_idioma], [idioma]) VALUES (2, N'Inglés')
INSERT [dbo].[idioma] ([id_idioma], [idioma]) VALUES (3, N'Francés')
INSERT [dbo].[idioma] ([id_idioma], [idioma]) VALUES (4, N'Alemán')
INSERT [dbo].[idioma] ([id_idioma], [idioma]) VALUES (5, N'Japonés')
SET IDENTITY_INSERT [dbo].[idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[pelicula] ON 

INSERT [dbo].[pelicula] ([id_pelicula], [titulo], [fecha], [duracion_min], [id_idioma], [id_genero], [id_estatus], [id_actor], [id_director]) VALUES (1, N'Blood Feast ', 1963, 152, 4, 3, 2, 4, 1)
INSERT [dbo].[pelicula] ([id_pelicula], [titulo], [fecha], [duracion_min], [id_idioma], [id_genero], [id_estatus], [id_actor], [id_director]) VALUES (2, N'Night of the Living Dead', 1968, 145, 1, 6, 3, 3, 2)
INSERT [dbo].[pelicula] ([id_pelicula], [titulo], [fecha], [duracion_min], [id_idioma], [id_genero], [id_estatus], [id_actor], [id_director]) VALUES (3, N'Dawn of the Dead', 1978, 166, 1, 3, 2, 1, 3)
INSERT [dbo].[pelicula] ([id_pelicula], [titulo], [fecha], [duracion_min], [id_idioma], [id_genero], [id_estatus], [id_actor], [id_director]) VALUES (5, N'A Clockwork Orange', 1989, 168, 4, 3, 2, 5, 2)
INSERT [dbo].[pelicula] ([id_pelicula], [titulo], [fecha], [duracion_min], [id_idioma], [id_genero], [id_estatus], [id_actor], [id_director]) VALUES (6, N'Kill Bill', 1789, 135, 2, 2, 4, 7, 1)
SET IDENTITY_INSERT [dbo].[pelicula] OFF
GO
ALTER TABLE [dbo].[pelicula]  WITH CHECK ADD FOREIGN KEY([id_actor])
REFERENCES [dbo].[actor] ([id_actor])
GO
ALTER TABLE [dbo].[pelicula]  WITH CHECK ADD FOREIGN KEY([id_estatus])
REFERENCES [dbo].[estatus] ([id_estatus])
GO
ALTER TABLE [dbo].[pelicula]  WITH CHECK ADD FOREIGN KEY([id_genero])
REFERENCES [dbo].[genero] ([id_genero])
GO
ALTER TABLE [dbo].[pelicula]  WITH CHECK ADD FOREIGN KEY([id_idioma])
REFERENCES [dbo].[idioma] ([id_idioma])
GO
ALTER TABLE [dbo].[pelicula]  WITH CHECK ADD  CONSTRAINT [FK_pelicula_director] FOREIGN KEY([id_director])
REFERENCES [dbo].[director] ([id_director])
GO
ALTER TABLE [dbo].[pelicula] CHECK CONSTRAINT [FK_pelicula_director]
GO
USE [master]
GO
ALTER DATABASE [COCKBUSTERS] SET  READ_WRITE 
GO
