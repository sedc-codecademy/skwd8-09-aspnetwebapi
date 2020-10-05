CREATE TABLE [dbo].[Player]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [IsActive] BIT NULL, 
    [TeamID] INT NOT NULL, 
    [City] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    CONSTRAINT [FK_Player_TeamID] FOREIGN KEY ([TeamID]) REFERENCES [Team]([Id])
)
