CREATE TABLE [dbo].[Team]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Country] NVARCHAR(100) NOT NULL, 
    [City] NVARCHAR(100) NOT NULL, 
    [TitlesWon] INT NULL, 
    [CoachID] INT NOT NULL, 
    CONSTRAINT [FK_Team_CoachID] FOREIGN KEY ([CoachID]) REFERENCES [Coach]([Id])
)
