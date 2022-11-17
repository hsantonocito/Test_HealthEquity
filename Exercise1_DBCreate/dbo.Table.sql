CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Make] VARCHAR(MAX) NULL, 
    [Model] VARCHAR(50) NULL, 
    [Year] INT NULL, 
    [Doors] INT NULL, 
    [Color] VARCHAR(50) NULL, 
    [Price] DECIMAL(18, 2) NULL
)
