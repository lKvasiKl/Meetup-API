CREATE TABLE [dbo].[Speakers]
(
	[Id] INT CONSTRAINT [PK_Speaker] PRIMARY KEY IDENTITY(1, 1), 
    [Name] NVARCHAR(128) NOT NULL CONSTRAINT [UK_Speaker_Name] UNIQUE
)
