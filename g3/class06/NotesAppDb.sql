create database NotesAppDb;
go
use NotesAppDb;

create table Users(
	Id uniqueidentifier not null primary key,
	Email nvarchar(30) not null,
	Username nvarchar(50) not null,
	Password nvarchar(30) not null,
	FirstName nvarchar(20) not null,
	LastName nvarchar(30) not null,
	Age int not null,
)
go

create table Notes(
	Id uniqueidentifier not null primary key,
	Title nvarchar(30) not null,
	Description nvarchar(250) not null,
	DueDate datetime,
	CreatedDate datetime not null,
	ModifiedDate datetime,
	UserId uniqueidentifier not null foreign key references Users(Id)
);
go

declare @newUserId1 uniqueidentifier;
declare @newUserId2 uniqueidentifier;
select @newUserId1 = NEWID();
select @newUserId2 = NEWID();

insert into dbo.Users(Id, Email, Username, FirstName, LastName, Password, Age)
values (@newUserId1, 'test@test.com', 'stojanko.s', 'Stojanko', 'Stojkankoski', '123456', 23)

insert into dbo.Users(Id, Email, Username, FirstName, LastName, Password, Age)
values (@newUserId2, 'test2@test2.com', 'mirko.b', 'Mirko', 'Kolevski', '123456', 32)



insert into dbo.Notes(Id, Title, Description, CreatedDate, ModifiedDate, DueDate, UserId)
values(NEWID(), 'test1 from db', 'desc1 from db', GETDATE(), NULL, NULL, @newUserId1)

insert into dbo.Notes(Id, Title, Description, CreatedDate, ModifiedDate, DueDate, UserId)
values(NEWID(), 'test2 from db', 'desc2 from db', GETDATE(), NULL, NULL, @newUserId1)

insert into dbo.Notes(Id, Title, Description, CreatedDate, ModifiedDate, DueDate, UserId)
values(NEWID(), 'test3 from db', 'desc3 from db', GETDATE(), NULL, NULL, @newUserId2)

go