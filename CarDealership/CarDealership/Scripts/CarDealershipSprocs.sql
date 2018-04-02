use CarDealership
go 

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StatesSelectAll')
      DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateId, StateName, StateAbbreviation
	FROM States
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetState')
      DROP PROCEDURE GetState
GO

CREATE PROCEDURE GetState (
	@StateId int
)
 AS
BEGIN
	SELECT StateId, StateName, StateAbbreviation
	FROM States s
	where s.StateId = @StateId;
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetUsedListings')
      DROP PROCEDURE GetUsedListings
GO

CREATE PROCEDURE GetUsedListings AS
BEGIN
	SELECT ListingId, l.ModelId, mo.ModelName, l.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models mo on mo.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = mo.MakeId
	inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId
	inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId
	inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId
	where  l.Condition = 2
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetNewListings')
      DROP PROCEDURE GetNewListings
GO

CREATE PROCEDURE GetNewListings AS
BEGIN
	SELECT ListingId, l.ModelId, mo.ModelName, l.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models mo on mo.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = mo.MakeId
	inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId
	inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId
	inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId
	where  l.Condition = 1
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetFeaturedListings')
      DROP PROCEDURE GetFeaturedListings
GO

CREATE PROCEDURE GetFeaturedListings AS
BEGIN
	SELECT ListingId, l.ModelId, mo.ModelName, l.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models mo on mo.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = mo.MakeId
	inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId
	inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId
	inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId
	where  l.IsFeatured = 1
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllListings')
      DROP PROCEDURE GetAllListings
GO

CREATE PROCEDURE GetAllListings AS
BEGIN
	SELECT ListingId, l.ModelId, mo.ModelName, l.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models mo on mo.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = mo.MakeId
	inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId
	inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId
	inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetSoldListings')
      DROP PROCEDURE GetSoldListings
GO

CREATE PROCEDURE GetSoldListings AS
BEGIN
	SELECT ListingId, l.ModelId, mo.ModelName, l.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models mo on mo.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = mo.MakeId
	inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId
	inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId
	inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId
	where  l.IsSold = 1;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetListingById')
      DROP PROCEDURE GetListingById
GO

CREATE PROCEDURE GetListingById (
	@ListingId int
)AS
BEGIN 
	SELECT ListingId, l.ModelId, mo.ModelName, l.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models mo on mo.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = mo.MakeId
	inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId
	inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId
	inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId
	WHERE l.ListingId = @ListingId
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetSpecials')
      DROP PROCEDURE GetSpecials
GO

create procedure GetSpecials as 
begin 
	select SpecialId, SpecialTitle, SpecialMessage
	from Specials s
end
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMakes')
      DROP PROCEDURE GetMakes
GO

create procedure GetMakes as 
begin 
	Select MakeId, MakeName, DateAdded, UserName
	From Makes
end 
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SaveMake')
      DROP PROCEDURE SaveMake
GO

CREATE PROCEDURE SaveMake (
	@MakeId int output, 
	@MakeName nvarchar (50),
	@UserName nvarchar(256),
	@DateAdded datetime2
)
AS
BEGIN 
	INSERT INTO Makes (MakeName, UserName)
	VALUES (@MakeName, @UserName)

	SET @MakeId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetModels')
      DROP PROCEDURE GetModels
GO

create procedure GetModels as
begin 
	Select ModelId, mo.ModelName, mo.MakeId, ma.MakeName, mo.DateAdded, mo.UserName
	From Models mo
	inner join Makes ma on ma.MakeId = mo.MakeId
end
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SaveModel')
      DROP PROCEDURE SaveModel
GO

CREATE PROCEDURE SaveModel (
	@ModelId int output,
	@MakeId int,
	@DateAdded datetime2,
	@UserName nvarchar(256)
)AS
BEGIN 
	INSERT INTO Models(MakeId, DateAdded, UserName)
	VALUES(@MakeId, @DateAdded, @UserName)

	SET @ModelId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetSpecials')
      DROP PROCEDURE GetSpecials
GO

create procedure GetSpecials as 
begin
	Select SpecialId, SpecialTitle, SpecialMessage
	From Specials
end 
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddContactForm')
      DROP PROCEDURE AddContactForm
GO

create procedure AddContactForm (
	@ContactFormId int output, 
	@CustomerName nvarchar(50),
	@Email nvarchar(100), 
	@Phone nvarchar (20), 
	@FormMessage nvarchar(max)
)

as 
begin 
	insert into ContactForms(CustomerName, Email, Phone, FormMessage)
	values (@CustomerName, @Email, @Phone, @FormMessage)

	set @ContactFormId = SCOPE_IDENTITY();
end 
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SaveSpecial')
      DROP PROCEDURE SaveSpecial
GO

CREATE PROCEDURE SaveSpecial(
	@SpecialId int output,
	@SpecialTitle nvarchar(50),
	@SpecialMessage nvarchar(max)
)

AS 
BEGIN 
	INSERT INTO Specials(SpecialTitle, SpecialMessage)
	VALUES (@SpecialTitle, @SpecialMessage)

	SET @SpecialId = SCOPE_IDENTITY();
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteSpecial')
      DROP PROCEDURE DeleteSpecial
GO

CREATE PROCEDURE DeleteSpecial(
	@SpecialId int
)
AS
BEGIN 
	DELETE FROM Specials 
	WHERE SpecialId = @SpecialId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SavePurchase')
      DROP PROCEDURE SavePurchase
GO

CREATE PROCEDURE SavePurchase (
	@PurchaseId int output, 
	@ListingId int, 
	@StateId int, 
	@CustomerName nvarchar(50), 
	@Phone nvarchar(20),
	@Email nvarchar(100), 
	@Street1 nvarchar (100), 
	@Street2 nvarchar (100), 
	@City nvarchar(100), 
	@ZipCode char(5), 
	@PurchasePrice decimal(10, 2), 
	@PaymentOption nvarchar(50),
	@DateAdded datetime2,
	@UserName nvarchar(256)
)AS
BEGIN 
	INSERT INTO Purchase(ListingId, StateId, CustomerName, Phone, Email, Street1, Street2, City, ZipCode, PurchasePrice, PaymentOption, DateAdded, UserName)
	VALUES(@ListingId, @StateId, @CustomerName, @Phone, @Email, @Street1, @Street2, @City, @ZipCode, @PurchasePrice, @PaymentOption, @DateAdded, @UserName);

	SET @PurchaseId = SCOPE_IDENTITY();

	UPDATE Listings SET
	IsSold = 1
	WHERE ListingId = @ListingId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SetListingToSold')
      DROP PROCEDURE SetListingToSold
GO

--CREATE PROCEDURE SetListingToSold(
--	@ListingId int, 
--	@IsSold bit
--)AS
--BEGIN 
--	UPDATE Listings SET
--	IsSold = 1
--	WHERE ListingId = @ListingId
--END 
--GO