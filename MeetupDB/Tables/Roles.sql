﻿CREATE TABLE [dbo].[Roles]
(
	[Id] INT CONSTRAINT [PK_Role] PRIMARY KEY, 
    [Name] NVARCHAR(32) NOT NULL CONSTRAINT [UK_Role_Name] UNIQUE
)
