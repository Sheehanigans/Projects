USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE Name = 'MovieCatalog')
DROP DATABASE MovieCatalog
GO 

CREATE DATABASE MovieCatalog
GO

USE MovieCatalog
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name='Rating')
DROP TABLE Rating
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name='Genre')
DROP TABLE Genre
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name='Movie')
DROP TABLE Movie
GO

CREATE TABLE Genre (
	GenreId int identity(1,1) primary key not null,
	GenreType varchar(50) not null
)
 
CREATE TABLE Rating (
	RatingId int identity(1,1) primary key not null,
	RatingName varchar(50) not null
)
 
CREATE TABLE Movie (
	MovieId int identity(1,1) primary key not null,
	RatingId int foreign key references Rating(RatingId) null,
	GenreId int foreign key references Genre(GenreId) not null,
	Title varchar(50) not null
)

USE MovieCatalog
GO

IF EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MovieInsert'
)

BEGIN 
	DROP PROCEDURE MovieInsert
END
GO

CREATE PROCEDURE MovieInsert (
   @MovieId int output,
   @GenreId int,
   @RatingId int,
   @Title Varchar(50)
)
AS
   INSERT INTO Movie (GenreId, RatingId, Title)
   VALUES (@GenreId, @RatingId, @Title)
 
   SET @MovieId = SCOPE_IDENTITY()
GO


IF EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MovieSelect'
)

BEGIN 
	DROP PROCEDURE MovieSelect
END
GO

CREATE PROCEDURE MovieSelect
AS	
	SELECT *
	FROM Movie m 
	inner join Rating r on m.RatingId = r.RatingId
	inner join Genre g on g.GenreId = m.GenreId
GO


IF EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MovieSelectById'
)

BEGIN 
	DROP PROCEDURE MovieSelectById
END
GO

CREATE PROCEDURE MovieSelectById (
	@MovieId int
)

AS 
	SELECT *
	FROM Movie m 
	WHERE m.MovieId = @MovieId
GO 

IF EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MovieUpdate'
)

BEGIN 
	DROP PROCEDURE MovieUpdate
END
GO

CREATE PROCEDURE MovieUpdate(
	@MovieId int,
   @GenreId int,
   @RatingId int,
   @Title Varchar(50)
)

AS 
	Update Movie
	SET GenreId = @GenreId, 
	RatingId = @RatingId, 
	Title = @Title
	WHERE MovieId = @MovieId
GO

IF EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MovieDelete'
)

BEGIN 
	DROP PROCEDURE MovieDelete
END
GO

CREATE PROCEDURE MovieDelete(
	@MovieId int output
)

AS 
	DELETE FROM Movie
	WHERE Movie.MovieId = @MovieId
GO


IF EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'RatingSelectAll'
)

BEGIN 
	DROP PROCEDURE RatingSelectAll
END
GO

CREATE PROCEDURE RatingSelectAll
AS 

	SELECT * 
	FROM Rating
GO


IF EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GenreSelectAll'
)

BEGIN 
	DROP PROCEDURE GenreSelectAll
END
GO

CREATE PROCEDURE GenreSelectAll
AS 

	SELECT * 
	FROM Genre
GO


SET IDENTITY_INSERT Genre ON
 
INSERT INTO Genre (GenreId, GenreType)
VALUES (1, 'Action'),
	(2, 'Horror'),
	(3, 'Kids'),
	(4, 'Mystery'),
	(5, 'Romance'),
	(6, 'Sci-Fi')
 
SET IDENTITY_INSERT Genre OFF


SET IDENTITY_INSERT Rating ON

INSERT INTO Rating (RatingId, RatingName)
VALUES (1, 'G'),
(2, 'PG'),
(3, 'PG-13'),
(4, 'R')

SET IDENTITY_INSERT Rating OFF


SET IDENTITY_INSERT Movie ON

INSERT INTO Movie (MovieId, RatingId, GenreId, Title)
VALUES (1,1,1,'Jay Jay the Jet Plane Movie'), 
(2,2,3,'The Grudge')

SET IDENTITY_INSERT Movie OFF
