IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
BEGIN
   DROP PROCEDURE DbReset
END
GO

CREATE PROCEDURE DbReset
AS
BEGIN 
	DELETE FROM Listings;
	DELETE FROM States;
	DELETE FROM BathroomTypes;
	DELETE FROM AspNetUsers WHERE id = '00000000-0000-0000-0000-000000000000';


	INSERT INTO States (StateId, StateName)
	VALUES('OH', 'Ohio'),
	('KY', 'Kentucky'), 
	('MN', 'Minnesota')

	SET IDENTITY_INSERT BathroomTypes ON;

	INSERT INTO BathroomTypes (BathroomTypeId, BathroomtypeName)
	VALUES (1, 'Indoor'), 
	(2, 'Outdoor'),
	(3, 'None')

	SET IDENTITY_INSERT BathroomTypes Off

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, StateId, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES ('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 'OH', 0, 0, 0, 'test');

	SET IDENTITY INSERT Listings ON
	INSERT INTO Listings(ListingId, UserId, StateId, BathroomTypeId, Nickname, City, Rate, SqaureFootage, HasElectric, HasHeat, ImageFileName)
	VALUES (1, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test Shack 1', 'Cleveland', 120, 400, 0, 1, 'placeholder.png');
	SET IDENTITY INSERT Listings OFF


END
GO