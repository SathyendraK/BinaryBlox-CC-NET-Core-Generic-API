
DROP Database [{{cookiecutter.project_db_name}}]


-- Create Database
CREATE DATABASE [{{cookiecutter.project_db_name}}]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'{{cookiecutter.project_db_name}}', FILENAME = N'/var/opt/mssql/data/{{cookiecutter.project_db_name}}.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'{{cookiecutter.project_db_name}}_log', FILENAME = N'/var/opt/mssql/data/{{cookiecutter.project_db_name}}_log.ldf' , SIZE = 1856KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [{{cookiecutter.project_db_name}}].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET ARITHABORT OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET  ENABLE_BROKER 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET RECOVERY FULL 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET  MULTI_USER 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET DB_CHAINING OFF 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [{{cookiecutter.project_db_name}}] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'{{cookiecutter.project_db_name}}', N'ON'
GO
USE [{{cookiecutter.project_db_name}}]
GO
