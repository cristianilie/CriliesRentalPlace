﻿CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(150) NOT NULL, 
    [Description] VARCHAR(2000) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [ImagePath] VARCHAR(300) NULL
)
