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
	SELECT ListingId, m.ModelId, BodyStyleId, InteriorColorId, ExteriorColorId, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models m on m.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = m.ModelId
	where  l.Condition = 2
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetNewListings')
      DROP PROCEDURE GetNewListings
GO

CREATE PROCEDURE GetNewListings AS
BEGIN
	SELECT ListingId, l.ModelId, l.BodyStyleId, l.InteriorColorId, l.ExteriorColorId, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models m on m.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = m.ModelId
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
	SELECT ListingId, m.ModelId, l.BodyStyleId, l.InteriorColorId, l.ExteriorColorId, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold, l.DateAdded
	FROM Listings l 
	inner join Models m on m.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = m.ModelId
	inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId
	inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId
	inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId
	where  l.IsFeatured = 1
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetSpecials')
      DROP PROCEDURE GetSpecials
GO

create procedure GetSpecials as 
begin 
	select SpeicalId, SpecialTitle, SpecialMessage
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