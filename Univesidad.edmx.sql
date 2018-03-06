
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/04/2018 21:47:29
-- Generated from EDMX file: C:\Users\elena\source\repos\WindowsFormsApp1\WindowsFormsApp1\Univesidad.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Universidad];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EstudianteGardo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EstudianteSet] DROP CONSTRAINT [FK_EstudianteGardo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EstudianteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstudianteSet];
GO
IF OBJECT_ID(N'[dbo].[GardoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GardoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EstudianteSet'
CREATE TABLE [dbo].[EstudianteSet] (
    [Identificacion] int  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [FechaNac] datetime  NOT NULL,
    [GradoId] int  NOT NULL
);
GO

-- Creating table 'GardoSet'
CREATE TABLE [dbo].[GardoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Grado] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Identificacion] in table 'EstudianteSet'
ALTER TABLE [dbo].[EstudianteSet]
ADD CONSTRAINT [PK_EstudianteSet]
    PRIMARY KEY CLUSTERED ([Identificacion] ASC);
GO

-- Creating primary key on [Id] in table 'GardoSet'
ALTER TABLE [dbo].[GardoSet]
ADD CONSTRAINT [PK_GardoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GradoId] in table 'EstudianteSet'
ALTER TABLE [dbo].[EstudianteSet]
ADD CONSTRAINT [FK_EstudianteGardo]
    FOREIGN KEY ([GradoId])
    REFERENCES [dbo].[GardoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteGardo'
CREATE INDEX [IX_FK_EstudianteGardo]
ON [dbo].[EstudianteSet]
    ([GradoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------