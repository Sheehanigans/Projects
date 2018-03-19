IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StatesSelectAll')
BEGIN
   DROP PROCEDURE StatesSelectAll
END
GO

CREATE PROCEDURE StatesSelectAll
AS
BEGIN 
	SELECT StateId, StateName
	FROM States
END
GO


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BathroomTypesSelectAll')
BEGIN
   DROP PROCEDURE BathroomTypesSelectAll
END
GO

CREATE PROCEDURE BathroomTypesSelectAll AS 
BEGIN
	SELECT BathroomTypeId, BathroomTypeName
	FROM BathroomTypes
	ORDER BY BathroomtypeName
END 

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsInsert')
BEGIN
   DROP PROCEDURE ListingsInsert
END
GO

CREATE PROCEDURE ListingsInsert (
	@ListingId int output,
	@UserId nvarchar(128),
	@StateId char (2),
	@BathroomTypeId int, 
	@Nickname nvarchar (50),
	@City nvarchar (50),
	@Rate decimal (7,2), 
	@SquareFootage decimal (7,2),
	@HasElectric bit, 
	@HasHeat bit, 
	@ImageFileName varchar(50)
)
AS
BEGIN
	INSERT INTO Listings (UserId, StateId, BathroomTypeId, Nickname, City, Rate, SqaureFootage, HasElectric, HasHeat, ImageFileName)
	VALUES (@UserId, @StateId, @BathroomTypeId, @Nickname, @City, @Rate, @SquareFootage, @HasElectric, @HasHeat, @ImageFileName);

	SET @ListingId = SCOPE_IDENTITY();
END 


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsUpdate')
BEGIN
   DROP PROCEDURE ListingsUpdate
END
GO

CREATE PROCEDURE ListingsUpdate (
	@ListingId int,
	@UserId nvarchar(128),
	@StateId char (2),
	@BathroomTypeId int, 
	@Nickname nvarchar (50),
	@City nvarchar (50),
	@Rate decimal (7,2), 
	@SquareFootage decimal (7,2),
	@HasElectric bit, 
	@HasHeat bit, 
	@ImageFileName varchar(50)
)
AS
BEGIN
	UPDATE Listings SET UserId = @UserId, 
	StateId = @StateId,
	BathroomTypeId = @BathroomTypeId, 
	Nickname = @Nickname, 
	City = @City, 
	Rate = @Rate, 
	SqaureFootage = @SquareFootage, 
	HasElectric = @HasElectric, 
	HasHeat = @HasHeat, 
	ImageFileName = @ImageFileName
	
	WHERE ListingId = @ListingId
END 


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsDelete')
BEGIN
   DROP PROCEDURE ListingsDelete
END
GO

CREATE PROCEDURE ListingsDelete (
	@ListingId int
)
AS 
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Contacts WHERE ListingId = @ListingId
	DELETE FROM Favorites WHERE ListingId = @ListingId
	DELETE FROM Listings WHERE ListingId = @ListingId

	COMMIT TRANSACTION
END 
GO