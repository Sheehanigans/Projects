use MovieCatalogue
go

create table Genre(
	GenreID int identity (1,1) primary key,
	GenreName varchar(30) not null,
)

create table Director(
	DirectorID int identity (1,1) primary key, 
	FirstName varchar (30) not null, 
	LastName varchar (30) not null, 
	BirthDate DateTime null
)

create table Rating (
	RatingID int identity (1,1) primary key, 
	RatingName varchar(5) not null
)

create table Movie(
	MovieID int identity (1,1) primary key, 
	GenreID int foreign key references Genre(GenreID) not null,
	DirectorID int foreign key references Director(DirectorID) null, 
	RatingID int foreign key references Rating(RatingID) not null, 
	Title varchar(128) not null, 
	ReleaseDate DateTime
)

create table Actor(
	ActorID int identity (1,1) primary key, 
	FirstName varchar (30) not null, 
	LastName varchar (30) not null, 
	BirthDate DateTime
)

create table CastMembers(
	CastMemberId int identity (1,1) primary key, 
	ActorID int foreign key references Actor(ActorID) not null, 
	MovieID int foreign key references Movie(MovieID) not null, 
	[Role] varchar (50) not null,
)
