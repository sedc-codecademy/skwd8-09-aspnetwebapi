CREATE TABLE [dbo].[Coach]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Age] INT NULL, 
    [TeamID] INT NOT NULL, 
    CONSTRAINT [FK_Coach_TeamID] FOREIGN KEY ([TeamID]) REFERENCES [Team]([Id])
)
