
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/27/2017 16:39:47
-- Generated from EDMX file: G:\Vinit\yProject - Copy\yProjectDataAccess\DiscussionDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DiscussionDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_QuestionAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_QuestionAnswer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Answers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answers];
GO
IF OBJECT_ID(N'[dbo].[Questions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questions];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Answers'
CREATE TABLE [dbo].[Answers] (
    [aid] int  NOT NULL,
    [abody] varchar(max)  NULL,
    [adate] datetime  NULL,
    [alikes] int  NULL,
    [uid] int  NOT NULL,
    [qid] int  NOT NULL,
    [Question_qid] int  NOT NULL,
    [aapprove] int  NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [qid] int  NOT NULL,
    [qtitle] varchar(max)  NULL,
    [qbody] varchar(max)  NULL,
    [qtags] varchar(max)  NULL,
    [qlikes] int  NULL,
    [qcomments] int  NULL,
    [uid] int  NOT NULL,
    [qdate] datetime  NULL,
    [User_uid] int  NOT NULL,
    [qapprove] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [uid] int  NOT NULL,
    [uname] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [aid] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [PK_Answers]
    PRIMARY KEY CLUSTERED ([aid] ASC);
GO

-- Creating primary key on [qid] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([qid] ASC);
GO

-- Creating primary key on [uid] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([uid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Question_qid] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [FK_QuestionAnswer]
    FOREIGN KEY ([Question_qid])
    REFERENCES [dbo].[Questions]
        ([qid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionAnswer'
CREATE INDEX [IX_FK_QuestionAnswer]
ON [dbo].[Answers]
    ([Question_qid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------