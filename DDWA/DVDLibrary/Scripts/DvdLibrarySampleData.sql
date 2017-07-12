use DvdLibrary
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdLibrarySampleData')
	drop procedure DvdLibrarySampleData
go

create procedure DvdLibrarySampleData
as
begin
	delete from Ratings;
	delete from Directors;
	delete from Dvds;

	set identity_insert Ratings on;

	insert into Ratings (RatingId, RatingName)
	values (1, 'G'),
	(2, 'PG'),
	(3, 'PG-13'),
	(4, 'R'),
	(5, 'NR');

	set identity_insert Ratings off;

	set identity_insert Directors on;

	insert into Directors (DirectorId, DirectorName)
	values (1, 'Steven Spielberg'),
	(2, 'J.J. Abrams'),
	(3, 'George Lucas'),
	(4, 'Francis Ford Coppola'),
	(5, 'Example Exampleton')

	set identity_insert Directors off;
	
	set identity_insert Dvds on;
	 
	insert into Dvds (DvdId, Title, DirectorId, DirectorName, ReleaseDate, RatingId,
		 RatingName, DvdNotes)
	values (1, 'Indiana Jones: Raiders of the Lost Ark', 1, 'Steven Spielberg', '1981', 2, 'PG', 'Face melting!'),
	(2, 'Star Wars: The Force Awakens', 2, 'J.J. Abrams', '2015', 3, 'PG-13', 'The newest Star Wars that feels closest to the original trilogy'),
	(3, 'Star Wars', 3, 'George Lucas', '1977', 2, 'PG', 'Episode IV'),
	(4, 'Star Wars: Episode I - The Phantom Menace', 3, 'George Lucas', '1999', 2, 'PG', 'Arguably the worst Star Wars movie'),
	(5, 'The Godfather', 4, 'Francis Ford Coppola', '1972', 4, 'R', 'Widely regarded as one of the greatest films of all time'),
	(6, 'Working Title', 5, 'Example Exampleton', '2017', 5, 'NR', 'No rating for this non-existent movie.')

	set identity_insert Dvds off;
end