--DROP TABLE Cenario;
--DROP TABLE Complemento;
--DROP TABLE Template;

USE [master]
GO
/****** Object:  Database [PrediLang]    Script Date: 25/06/2024 11:48:00 ******/

CREATE DATABASE [PrediLang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PrediLang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PrediLang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PrediLang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PrediLang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PrediLang] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PrediLang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PrediLang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PrediLang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PrediLang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PrediLang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PrediLang] SET ARITHABORT OFF 
GO
ALTER DATABASE [PrediLang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PrediLang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PrediLang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PrediLang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PrediLang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PrediLang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PrediLang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PrediLang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PrediLang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PrediLang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PrediLang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PrediLang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PrediLang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PrediLang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PrediLang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PrediLang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PrediLang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PrediLang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PrediLang] SET  MULTI_USER 
GO
ALTER DATABASE [PrediLang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PrediLang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PrediLang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PrediLang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PrediLang] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PrediLang] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PrediLang] SET QUERY_STORE = OFF
GO
USE [PrediLang]
GO
/****** Object:  Table [dbo].[Cenario]    Script Date: 25/06/2024 11:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cenario](
	[IdCenario] [int] IDENTITY(1,1) NOT NULL,
	[IdTemplate] [int] NOT NULL,
	[Pergunta] [text] NOT NULL,
	[Resposta] [text] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_Cenario] PRIMARY KEY CLUSTERED 
(
	[IdCenario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Complemento]    Script Date: 25/06/2024 11:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Complemento](
	[IdComplemento] [int] IDENTITY(1,1) NOT NULL,
	[IdTemplate] [int] NOT NULL,
	[Pergunta] [text] NOT NULL,
	[Resposta] [text] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_Complemento] PRIMARY KEY CLUSTERED 
(
	[IdComplemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Template]    Script Date: 25/06/2024 11:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Template](
	[IdTemplate] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [text] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED 
(
	[IdTemplate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Complemento_Template]    Script Date: 25/06/2024 11:48:00 ******/
CREATE NONCLUSTERED INDEX [IX_Complemento_Template] ON [dbo].[Complemento]
(
	[IdTemplate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cenario]  WITH CHECK ADD  CONSTRAINT [FK_Cenario_Template] FOREIGN KEY([IdTemplate])
REFERENCES [dbo].[Template] ([IdTemplate])
GO
ALTER TABLE [dbo].[Cenario] CHECK CONSTRAINT [FK_Cenario_Template]
GO
ALTER TABLE [dbo].[Complemento]  WITH CHECK ADD  CONSTRAINT [FK_Complemento_Template] FOREIGN KEY([IdTemplate])
REFERENCES [dbo].[Template] ([IdTemplate])
GO
ALTER TABLE [dbo].[Complemento] CHECK CONSTRAINT [FK_Complemento_Template]
GO
USE [master]
GO
ALTER DATABASE [PrediLang] SET  READ_WRITE 
GO

