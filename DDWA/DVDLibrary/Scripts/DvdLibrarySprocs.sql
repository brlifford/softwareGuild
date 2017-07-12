use DvdLibrary
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'RatingsSelectAll')
	drop procedure RatingsSelectAll
go

create procedure RatingsSelectAll
as
begin
	select RatingId, RatingName
	from Ratings
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'RatingSelectById')
	drop procedure RatingSelectById
go

create procedure RatingSelectById(
	@RatingId int
)as
begin
	select RatingId, RatingName
	from Ratings
	where RatingId = @RatingId
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'RatingSelectByName')
	drop procedure RatingSelectByName
go

create procedure RatingSelectByName(
	@RatingName varchar(5)
)as
begin
	select RatingId, RatingName
	from Ratings
	where RatingName = @RatingName
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DirectorSelectByName')
	drop procedure DirectorSelectByName
go

create procedure DirectorSelectByName(
	@DirectorName nvarchar(50)
)as
begin
	select DirectorId, DirectorName
	from Directors
	where DirectorName = @DirectorName
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DirectorSelectById')
	drop procedure DirectorSelectById
go

create procedure DirectorSelectById(
	@DirectorId int
)as
begin
	select DirectorId, DirectorName
	from Directors
	where DirectorId = @DirectorId
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DirectorsSelectAll')
	drop procedure DirectorsSelectAll
go

create procedure DirectorsSelectAll
as
begin
	select DirectorId, DirectorName
	from Directors
	order by DirectorName
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdsSelectAll')
	drop procedure DvdsSelectAll
go

create procedure DvdsSelectAll
as
begin
	select DvdId, Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes
	from Dvds
	order by Title
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdInsert')
	drop procedure DvdInsert
go

create procedure DvdInsert(
	@DvdId int output,
	@Title nvarchar(50),
	@DirectorId int,
	@DirectorName nvarchar(50),
	@ReleaseDate datetime2,
	@RatingId int,
	@RatingName varchar(5),
	@DvdNotes nvarchar(500)
)as

begin
	insert into Dvds (Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes)
	values (@Title, @DirectorId, @DirectorName, @ReleaseDate, @RatingId,
		 @RatingName, @DvdNotes)

	set @DvdId = SCOPE_IDENTITY();
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdUpdate')
	drop procedure DvdUpdate
go

create procedure DvdUpdate(
	@DvdId int output,
	@Title nvarchar(50),
	@DirectorId int,
	@DirectorName nvarchar(50),
	@ReleaseDate datetime2,
	@RatingId int,
	@RatingName varchar(5),
	@DvdNotes nvarchar(500)
)as

begin
	update Dvds set
		Title = @Title, 
		DirectorId = @DirectorId, 
		DirectorName = @DirectorName, 
		ReleaseDate = @ReleaseDate, 
		RatingId = @RatingId,
		RatingName = @RatingName, 
		DvdNotes = @DvdNotes
	where DvdId = @DvdId
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdDelete')
	drop procedure DvdDelete
go

create procedure DvdDelete(
	@DvdId int
) as
begin
	begin transaction
	delete from Dvds where DvdId = @DvdId;

	commit transaction
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectById')
	drop procedure DvdSelectById
go

create procedure DvdSelectById(
	@DvdId int
) as
begin
	select DvdId, Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes
	from Dvds
	where DvdId = @DvdId
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectByTitle')
	drop procedure DvdSelectByTitle
go

create procedure DvdSelectByTitle(
	@Title nvarchar(50)
) as
begin
	select DvdId, Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes
	from Dvds
	where Title = @Title
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectByDate')
	drop procedure DvdSelectByDate
go

create procedure DvdSelectByDate(
	@ReleaseDate datetime2
) as
begin
	select DvdId, Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes
	from Dvds
	where ReleaseDate = @ReleaseDate
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectByDirector')
	drop procedure DvdSelectByDirector
go

create procedure DvdSelectByDirector(
	@DirectorName nvarchar(50)
) as
begin
	select DvdId, Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes
	from Dvds
	where DirectorName = @DirectorName
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectByRating')
	drop procedure DvdSelectByRating
go

create procedure DvdSelectByRating(
	@DirectorName nvarchar(50)
) as
begin
	select DvdId, Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes
	from Dvds
	where DirectorName = @DirectorName
end
go

if exists(select *	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectDetails')
	drop procedure DvdSelectDetails
go

create procedure DvdSelectDetails(
	@DvdId int
) as
begin
	select DvdId, Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes
	from Dvds
	where DvdId = @DvdId
end
go