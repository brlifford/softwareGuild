use master 
go

if exists(select * from sys.databases where Name='MovieCatalog')
drop database MovieCatalog
go

create database MovieCatalog
go

use MovieCatalog
go

if exists(select * from sys.tables where name='Movie')
	drop table Movie
go

if exists(select * from sys.tables where name='Rating')
	drop table Rating
go

if exists(select * from sys.tables where name='Genre')
	drop table Genre
go

create table Genre (
	GenreId int identity(1,1) primary key not null,
	GenreType varchar(50) not null
)

create table Rating (
	RatingId int identity(1,1) primary key not null,
	RatingName varchar(50) not null
)

create table Movie (
	MovieId int identity(1,1) primary key not null,
	RatingId int foreign key references Rating(RatingId) null,
	GenreId int foreign key references Genre(GenreId) not null,
	Title varchar(50) not null
)

if exists(select * from INFORMATION_SCHEMA.ROUTINES 
	where ROUTINE_NAME='MovieSelectAll')
		drop procedure MovieSelectAll
go

create procedure MovieSelectAll
as
	select MovieId, Title, GenreType, RatingName
	from Movie m
		inner join Genre g on m.GenreId = g.GenreId
		left join Rating r on m.RatingId = r.RatingId
	order by Title
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME='MovieSelectById')
		drop procedure MovieSelectById
go

create procedure MovieSelectById(
	@MovieId int
)
as
	select MovieId, Title, GenreId, RatingId
	from Movie
	where MovieId = @MovieId
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME='MovieInsert')
		drop procedure MovieInsert
go

create procedure MovieInsert(
	@MovieId int output,
	@GenreId int,
	@RatingId int,
	@Title varchar(50)
)
as
	insert into Movie (GenreId, RatingId, Title)
	values (@GenreId, @RatingId, @Title)

	set @MovieId = SCOPE_IDENTITY()
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME='MovieUpdate')
		drop procedure MovieUpdate
go

create procedure MovieUpdate(
	@MovieId int,
	@GenreId int,
	@RatingId int,
	@Title varchar(50)
)
as
	update Movie
		set GenreId = @GenreId,
		RatingId = @RatingId,
		Title = @Title
	where MovieId = @MovieId
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME='MovieDelete')
		drop procedure MovieDelete
go

create procedure MovieDelete(
	@MovieId int
)
as
	delete from Movie
	where MovieId = @MovieId
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME='RatingSelectAll')
		drop procedure RatingSelectAll
go

create procedure RatingSelectAll
as
	select RatingId, RatingName
	from Rating
	order by RatingName
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME='GenreSelectAll')
		drop procedure GenreSelectAll
go

create procedure GenreSelectAll
as
	select GenreId, GenreType
	from Genre
	order by GenreType
go


set identity_insert Genre on

insert into Genre (GenreId, GenreType)
values (1, 'Action'),
		(2, 'Horror'),
		(3, 'Kids'),
		(4, 'Mystery'),
		(5, 'Romance'),
		(6, 'Sci-Fi')

set identity_insert Genre off

set identity_insert Rating on

insert into Rating (RatingId, RatingName)
values (1, 'G'),
		(2, 'PG'),
		(3, 'PG-13'),
		(4, 'R')

set identity_insert Rating off

set identity_insert Movie on

insert into Movie (MovieId, RatingId, GenreId, Title)
values (1, 1, 3, 'The Lion King'),
	(2, 4, 6, 'Terminator'),
	(3, 4, 2, 'Friday the 13th'),
	(4, null, 6, 'This movie has no rating')

set identity_insert Movie off