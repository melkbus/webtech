
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2016 16:33:59
-- Generated from EDMX file: \\vmware-host\Shared Folders\Documents\VUB\3ebach\Web Technologies\Project_web\WebApplication1\WebApplication1\Models\OnzeDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [webtech];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[account]', 'U') IS NOT NULL
    DROP TABLE [dbo].[account];
GO
IF OBJECT_ID(N'[dbo].[Event]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Event];
GO
IF OBJECT_ID(N'[dbo].[logboek]', 'U') IS NOT NULL
    DROP TABLE [dbo].[logboek];
GO
IF OBJECT_ID(N'[webtechModelStoreContainer].[Table]', 'U') IS NOT NULL
    DROP TABLE [webtechModelStoreContainer].[Table];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'account'
CREATE TABLE [dbo].[account] (
    [UserId] int  NOT NULL,
    [username] varchar(20)  NOT NULL,
    [passwordKey] varchar(20)  NOT NULL,
    [firstname] char(20)  NOT NULL,
    [lastname] char(20)  NOT NULL,
    [mail] varchar(30)  NOT NULL,
    [birthday] datetime  NOT NULL
);
GO

-- Creating table 'Event'
CREATE TABLE [dbo].[Event] (
    [EventId] int  NOT NULL,
    [EventName] varchar(20)  NOT NULL,
    [EventDescription] varchar(300)  NOT NULL,
    [EventDate] datetime  NULL,
    [EventLocation] nvarchar(max)  NULL,
    [EventPicture] nchar(10)  NULL,
    [EventPrice] int  NULL
);
GO

-- Creating table 'logboek'
CREATE TABLE [dbo].[logboek] (
    [EventID] int  NOT NULL,
    [UserID] int  NULL,
    [organises] int  NULL
);
GO

-- Creating table 'Table'
CREATE TABLE [dbo].[Table] (
    [AccountName] varchar(24)  NOT NULL,
    [password] varchar(63)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'account'
ALTER TABLE [dbo].[account]
ADD CONSTRAINT [PK_account]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [EventId] in table 'Event'
ALTER TABLE [dbo].[Event]
ADD CONSTRAINT [PK_Event]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [EventID] in table 'logboek'
ALTER TABLE [dbo].[logboek]
ADD CONSTRAINT [PK_logboek]
    PRIMARY KEY CLUSTERED ([EventID] ASC);
GO

-- Creating primary key on [AccountName], [password] in table 'Table'
ALTER TABLE [dbo].[Table]
ADD CONSTRAINT [PK_Table]
    PRIMARY KEY CLUSTERED ([AccountName], [password] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------