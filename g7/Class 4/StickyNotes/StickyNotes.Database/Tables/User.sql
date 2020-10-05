CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CreatedOn] SMALLDATETIME NOT NULL, 
    [DeletedOn] SMALLDATETIME NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL
)
