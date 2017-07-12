use [master]
go

if exists (select * from sysdatabases where name='DvdLibrary')
	drop database DvdLibrary
go

create database DvdLibrary
go

use DvdLibrary
go

if exists(select * from sys.tables where name = 'Dvds')
	drop table Dvds
go

if exists(select * from sys.tables where name = 'Ratings')
	drop table Ratings
go

if exists(select * from sys.tables where name = 'Directors')
	drop table Directors
go

create table Directors(
	DirectorId int identity(1,1) not null primary key,
	DirectorName nvarchar(50) not null
)

create table Ratings(
	RatingId int identity(1,1) not null primary key,
	RatingName varchar(5) not null
)

create table Dvds(
	DvdId int identity(1,1) not null primary key,
	Title nvarchar(50) not null,
	DirectorId int not null foreign key references Directors(DirectorId),
	DirectorName nvarchar(50) not null,
	ReleaseDate datetime2 not null,
	RatingId int not null foreign key references Ratings(RatingId),
	RatingName varchar(5) not null,
	DvdNotes nvarchar(500) null
)