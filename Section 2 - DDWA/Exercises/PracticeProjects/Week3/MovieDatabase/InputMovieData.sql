use MovieCatalogue
go

insert into Actor(FirstName, LastName, BirthDate)
values ('Bill', 'Murray', '9/21/1950'),
('Dan', 'Aykroyd','7/1/1952'),
('John','Candy','10/31/1950'),
('Steve','Martin',''),
('Sylvester','Stallone','')

insert into Director(FirstName, LastName, BirthDate)
values ('Ivan','Reitman','10/27/1946'),
('Ted','Kotcheff','')


insert into Rating(RatingName)
values ('G'),
('PG'),
('PG-13'),
('R')


insert into Genre(GenreName)
values ('Action'),
('Comedy'),
('Drama'),
('Horror')

insert into Movie(GenreID, DirectorID, RatingID, Title, ReleaseDate)
values ('1','2','4','Rambo: First Blood','10/22/1982'),
		('2', null ,'4','Planes, Trains & Automobiles','11/25/1987'),
		('2','1','2','Ghostbusters',''),
		('2', null ,'2','The Great Outdoors','6/17/1988')

insert into CastMembers (ActorID, MovieID, Role)
values ('5','1','John Rambo'),
('4','2','Neil Page'),
('3','2','Del Griffith'),
('1','3','Dr. Peter Venkman'),
('2','3','Dr. Raymond Stanz'),
('2','4','Roman Craig'),
('3','4','Chet Ripley')
