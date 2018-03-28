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
	SELECT ListingId, l.ModelId, mo.ModelName, mo.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
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
	SELECT ListingId, l.ModelId, mo.ModelName, mo.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
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
	SELECT ListingId, l.ModelId, mo.ModelName, mo.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
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
	SELECT ListingId, l.ModelId, mo.ModelName, mo.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
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
	SELECT ListingId, l.ModelId, mo.ModelName, mo.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
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
	Select MakeId, MakeName, DateAdded, UserId
	From Makes 
end 
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetModels')
      DROP PROCEDURE GetModels
GO

create procedure GetModels as
begin 
	Select ModelId, mo.MakeId, ModelName, ma.MakeName, ModelYear, mo.DateAdded, mo.UserId
	From Models mo
	inner join Makes ma on ma.MakeId = mo.MakeId
end
go

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
