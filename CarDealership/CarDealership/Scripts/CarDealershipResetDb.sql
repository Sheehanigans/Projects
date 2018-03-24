use CarDealership
go

if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ResetDb')
		drop procedure ResetDb
go

create procedure ResetDb as 
begin 
	delete from SaleInformation;
	delete from States;
	delete from Specials;
	delete from ContactForms;
	delete from Listings;
	delete from Models;
	delete from Makes;
	delete from BodyStyles;
	delete from InteriorColors;
	delete from ExteriorColors;
	delete from AspNetUserRoles where UserId in('00000000-0000-0000-0000-111111111111');
	delete from AspNetUsers where Id in ('00000000-0000-0000-0000-111111111111');


	set identity_insert States on;
	insert into States(StateId, StateName, StateAbbreviation)
	values (1, 'Minnesota', 'MN'), 
	(2,'Wisconsin','WI')
	set identity_insert States off;

	set identity_insert Specials on; 
	insert into Specials(SpeicalId, SpecialTitle, SpecialMessage)
	values(1, 'MEGA SALE ON COOL CARS', 'THE COOLEST CARS have some MEGA SaLeS')
	set identity_insert Specials off;

	set identity_insert ContactForms on; 
	insert into ContactForms(ContactFormId, CustomerName, Email, Phone, FormMessage)
	values (1, 'Sally', 'Sally@gmail.com', '651-488-8888', 'HEY I would like a new moped, ya got one?')
	set identity_insert ContactForms off;

	set identity_insert ExteriorColors on;
	insert into ExteriorColors(ExteriorColorId, ExteriorColorName)
	values(1, 'Leprechaun Green'), 
	(2, 'Stone White')
	set identity_insert ExteriorColors off;

	set identity_insert InteriorColors on;
	insert into InteriorColors (InteriorColorId, InteriorColorName)
	values (1, 'Velvet Wonderland'), 
	(2, 'Strapping Leather')
	set identity_insert InteriorColors off; 

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName)
	VALUES('00000000-0000-0000-0000-111111111111', 0, 0, 'sales@test.com', 0, 0, 0, 'TestSales', 'Brian', 'Meehan')

	insert into AspNetUserRoles(UserId, RoleId)
	values ('00000000-0000-0000-0000-111111111111', '1c719ce0-0249-458d-9934-ee35b12cbd01')

	set identity_insert Makes on; 
	insert into Makes(MakeId, MakeName, UserId)
	values (1, 'Jeep', '7149e0c5-34c1-4a33-b283-bfe66a66bc27'),
	(2, 'Mazda', '7149e0c5-34c1-4a33-b283-bfe66a66bc27'),
	(3, 'Delorian', '7149e0c5-34c1-4a33-b283-bfe66a66bc27')
	set identity_insert Makes off; 
	
	set identity_insert Models on; 
	insert into Models(ModelId, MakeId, ModelName, ModelYear, UserId)
	values(1, 2, 'CX-3', 2019, '7149e0c5-34c1-4a33-b283-bfe66a66bc27'), 
	(2, 1, 'Wrangler', 1995, '7149e0c5-34c1-4a33-b283-bfe66a66bc27'),
	(3, 3, 'Docs Car', 1980, '7149e0c5-34c1-4a33-b283-bfe66a66bc27')
	set identity_insert Models off;

	set identity_insert BodyStyles on;
	insert into BodyStyles(BodyStyleId, BodyStyleName)
	values (1, 'Offroad SUV'), 
	(2, 'Subcompact SUV'),
	(3, 'Sudan')
	set identity_insert BodyStyles off;

	set identity_insert Listings on;
	insert into Listings (ListingId, ModelId, BodyStyleId, InteriorColorId, ExteriorColorId, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold)
	values(1, 1, 2, 1, 1, 1, 2, 25000, 'FTW12345BLAHHEY69', 30000.00, 29000.00, 'This little guy is a lot of fun', 'cx3.png', 0, 0), 
	(2, 2, 1, 2, 2, 2, 1, 200000, 'JEEP229900HEYYO', 15000.00, 14000.00, 'Hey did you see that road there? Yeah neither did I.', 'jeep.jpg', 1, 0),
	(3, 3, 3, 2, 2, 2, 1, 1000000, 'BACKTOTHEFUTURE', 400000.00, 399555.00, 'The reverse is broken and smells like lightning', 'delorian.jpg', 0, 1)
	set identity_insert Listings off; 

	set identity_insert SaleInformation on;
	insert into SaleInformation(SaleId, UserId, ListingId, StateId, CustomerName, Phone, Email, Street1, ZipCode, PurchasePrice, PaymentOption)
	values (1, '7149e0c5-34c1-4a33-b283-bfe66a66bc27', 1, 1, 'Ryan', '612-750-7473', 'ryan@ryan.com', '3117 Free Ave', '55408', 25000.00, 'Bank Finance')
	set identity_insert SaleInformation off;

end 
