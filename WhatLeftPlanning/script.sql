USE [master]
GO

IF EXISTS (Select name from sys.databases where name = N'PlanningDB')
	ALTER DATABASE [PlanningDB] set single_user WITH rollback IMMEDIATE
go
	
IF EXISTS (Select name from sys.databases where name = N'PlanningDB')
	DROP DATABASE [PlanningDB]
GO
/****** Object:  Database [PlanningDB]    Script Date: 09/04/2018 10:36:44 a. m. ******/
CREATE DATABASE [PlanningDB]
 
ALTER DATABASE [PlanningDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PlanningDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PlanningDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PlanningDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PlanningDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PlanningDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PlanningDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PlanningDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PlanningDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PlanningDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PlanningDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PlanningDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PlanningDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PlanningDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PlanningDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PlanningDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PlanningDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PlanningDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PlanningDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PlanningDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PlanningDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PlanningDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PlanningDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PlanningDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PlanningDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PlanningDB] SET  MULTI_USER 
GO
ALTER DATABASE [PlanningDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PlanningDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PlanningDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PlanningDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PlanningDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PlanningDB] SET QUERY_STORE = OFF
GO
USE [PlanningDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PlanningDB]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 09/04/2018 10:36:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 09/04/2018 10:36:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolUsuario]    Script Date: 09/04/2018 10:36:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolUsuario](
	[UsuarioID] [int] NOT NULL,
	[RolID] [int] NOT NULL,
 CONSTRAINT [PK_RolUsuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[RolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 09/04/2018 10:36:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TipoID] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripción] [nvarchar](250) NULL,
	[Estado] [varchar](2) NOT NULL,
 CONSTRAINT [pkTarea] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarea_Detalle]    Script Date: 09/04/2018 10:36:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea_Detalle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TareaID] [int] NOT NULL,
	[FechaIni] [date] NOT NULL,
	[FechaFin] [date] NULL,
	[Estado] [varchar](2) NOT NULL,
 CONSTRAINT [pkTarea_Detalle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TareaAsignadas]    Script Date: 09/04/2018 10:36:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TareaAsignadas](
	[TareaID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
 CONSTRAINT [PK_TareaAsignadas] PRIMARY KEY CLUSTERED 
(
	[TareaID] ASC,
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Tarea]    Script Date: 09/04/2018 10:36:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Tarea](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [pkTipo_Tarea] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 09/04/2018 10:36:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](25) NOT NULL,
	[Apellido] [nvarchar](25) NOT NULL,
	[Nick] [nvarchar](25) NOT NULL,
	[Contraseña] [nvarchar](max) NOT NULL,
 CONSTRAINT [pkUsuarios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioGrupo]    Script Date: 09/04/2018 10:36:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioGrupo](
	[GrupoID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[TipoIntegrante] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_UsuarioGrupo] PRIMARY KEY CLUSTERED 
(
	[GrupoID] ASC,
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (2, N'Lider')
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (3, N'Normal')
SET IDENTITY_INSERT [dbo].[Rol] OFF
INSERT [dbo].[RolUsuario] ([UsuarioID], [RolID]) VALUES (1, 1)
INSERT [dbo].[RolUsuario] ([UsuarioID], [RolID]) VALUES (1, 2)
INSERT [dbo].[RolUsuario] ([UsuarioID], [RolID]) VALUES (1, 3)
SET IDENTITY_INSERT [dbo].[Tipo_Tarea] ON 

INSERT [dbo].[Tipo_Tarea] ([ID], [Nombre]) VALUES (1, N'Diaria')
INSERT [dbo].[Tipo_Tarea] ([ID], [Nombre]) VALUES (2, N'Temporal')
SET IDENTITY_INSERT [dbo].[Tipo_Tarea] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID], [Nombre], [Apellido], [Nick], [Contraseña]) VALUES (1, N'Jesus', N'Dicent', N'Admin', N'VhKWfY5q9CpRTSqbwSpe6A==')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Grupo] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Tarea] ADD  DEFAULT ('A') FOR [Estado]
GO
ALTER TABLE [dbo].[Tarea_Detalle] ADD  DEFAULT (getdate()) FOR [FechaIni]
GO
ALTER TABLE [dbo].[Tarea_Detalle] ADD  DEFAULT ('S') FOR [Estado]
GO
ALTER TABLE [dbo].[UsuarioGrupo] ADD  DEFAULT ('I') FOR [TipoIntegrante]
GO
ALTER TABLE [dbo].[RolUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolUsuario_Rol] FOREIGN KEY([RolID])
REFERENCES [dbo].[Rol] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolUsuario] CHECK CONSTRAINT [FK_RolUsuario_Rol]
GO
ALTER TABLE [dbo].[RolUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolUsuario_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolUsuario] CHECK CONSTRAINT [FK_RolUsuario_Usuario]
GO
ALTER TABLE [dbo].[Tarea]  WITH CHECK ADD  CONSTRAINT [fkTareaTipoID] FOREIGN KEY([TipoID])
REFERENCES [dbo].[Tipo_Tarea] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarea] CHECK CONSTRAINT [fkTareaTipoID]
GO
ALTER TABLE [dbo].[Tarea_Detalle]  WITH CHECK ADD  CONSTRAINT [fkDetalleTareaID] FOREIGN KEY([TareaID])
REFERENCES [dbo].[Tarea] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarea_Detalle] CHECK CONSTRAINT [fkDetalleTareaID]
GO
ALTER TABLE [dbo].[TareaAsignadas]  WITH CHECK ADD  CONSTRAINT [FK_TareaAsignadas_Tarea] FOREIGN KEY([TareaID])
REFERENCES [dbo].[Tarea_Detalle] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TareaAsignadas] CHECK CONSTRAINT [FK_TareaAsignadas_Tarea]
GO
ALTER TABLE [dbo].[TareaAsignadas]  WITH CHECK ADD  CONSTRAINT [FK_TareaAsignadas_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TareaAsignadas] CHECK CONSTRAINT [FK_TareaAsignadas_Usuario]
GO
ALTER TABLE [dbo].[UsuarioGrupo]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioGrupo_Grupo] FOREIGN KEY([GrupoID])
REFERENCES [dbo].[Grupo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioGrupo] CHECK CONSTRAINT [FK_UsuarioGrupo_Grupo]
GO
ALTER TABLE [dbo].[UsuarioGrupo]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioGrupo_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioGrupo] CHECK CONSTRAINT [FK_UsuarioGrupo_Usuario]
GO
ALTER TABLE [dbo].[Tarea]  WITH CHECK ADD  CONSTRAINT [chkTareaEstado] CHECK  (([Estado]='A' OR [Estado]='D' OR [Estado]='I'))
GO
ALTER TABLE [dbo].[Tarea] CHECK CONSTRAINT [chkTareaEstado]
GO
ALTER TABLE [dbo].[Tarea_Detalle]  WITH CHECK ADD  CONSTRAINT [chkTareaDetalleEstado] CHECK  (([Estado]='C' OR [Estado]='S'))
GO
ALTER TABLE [dbo].[Tarea_Detalle] CHECK CONSTRAINT [chkTareaDetalleEstado]
GO
ALTER TABLE [dbo].[UsuarioGrupo]  WITH CHECK ADD  CONSTRAINT [CHK_TipoIntegrante] CHECK  (([TipoIntegrante]='L' OR [TipoIntegrante]='I'))
GO
ALTER TABLE [dbo].[UsuarioGrupo] CHECK CONSTRAINT [CHK_TipoIntegrante]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios asignados a la tareas
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TareaAsignadas', @level2type=N'CONSTRAINT',@level2name=N'FK_TareaAsignadas_Tarea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tareas asignadas del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TareaAsignadas', @level2type=N'CONSTRAINT',@level2name=N'FK_TareaAsignadas_Usuario'
GO
USE [master]
GO
ALTER DATABASE [PlanningDB] SET  READ_WRITE 
GO
