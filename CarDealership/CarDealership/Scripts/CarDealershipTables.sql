use CarDealership
go

if exists (select * from sys.tables where name='SaleInformation')
	drop table SaleInformation
go

if exists (select * from sys.tables where name='Listings')
	drop table Listings
go

if exists (select * from sys.tables where name='Models')
	drop table Models
go

if exists (select * from sys.tables where name='Makes')
	drop table Makes
go

if exists (select * from sys.tables where name='InteriorColors')
	drop table InteriorColors
go

if exists (select * from sys.tables where name='ExteriorColors')
	drop table ExteriorColors
go

if exists (select * from sys.tables where name='BodyStyles')
	drop table BodyStyles
go 

if exists (select * from sys.tables where name='States')
	drop table States
go

if exists (select * from sys.tables where name='Specials')
	drop table Specials
go

if exists (select * from sys.tables where name='ContactForms')
	drop table ContactForms
go

create table Makes(
	MakeId int identity (1,1) not null primary key,
	MakeName nvarchar(50) not null,
	DateAdded datetime2 not null default(getdate()), 
	UserId nvarchar(128) not null foreign key references AspNetUsers(Id)
)

create table Models(
	ModelId int identity (1,1) not null primary key, 
	MakeId int not null foreign key references Makes(MakeId),
	ModelName nvarchar(50) not null, 
	ModelYear char (4) not null,
	DateAdded datetime2 not null default(getdate()),
	UserId nvarchar(128) not null foreign key references AspNetUsers(Id)
)

create table InteriorColors(
	InteriorColorId int identity (1,1) not null primary key, 
	InteriorColorName nvarchar(50) not null,
)

create table ExteriorColors(
	ExteriorColorId int identity (1,1) not null primary key, 
	ExteriorColorName nvarchar(50) not null,
)

create table BodyStyles(
	BodyStyleId int identity (1,1) not null primary key, 
	BodyStyleName nvarchar (50) not null,
)

create table Listings(
	ListingId int identity (1,1) not null primary key, 
	ModelId int not null foreign key references Models(ModelId),
	BodyStyleId int not null foreign key references BodyStyles(BodyStyleId),
	InteriorColorId int not null foreign key references InteriorColors(InteriorColorId),
	ExteriorColorId int not null foreign key references ExteriorColors(ExteriorColorId),
	[Type] int not null,
	Transmission int not null, 
	Mileage char(7) not null, 
	VIN nvarchar (128) not null, 
	MSRP decimal (10, 2) not null, 
	SalePrice decimal (10,2) null, 
	VehicleDescription nvarchar (max) null, 
	ImageFileUrl nvarchar (max) null, 
	IsFeatured bit not null,
)

create table States(
	StateId int identity (1,1) not null primary key, 
	StateName nvarchar (15) not null,
	StateAbbreviation char(2) not null,
)

create table SaleInformation(
	SaleId int identity (1,1) not null primary key, 
	UserId nvarchar(128) not null foreign key references AspNetUsers(Id),
	ListingId int not null foreign key references Listings(ListingId), 
	StateId int not null foreign key references States(StateId),
	CustomerName nvarchar(50) not null, 
	Phone nvarchar(20) not null, 
	Email nvarchar(100) not null, 
	Street1 nvarchar (100) not null, 
	Street2 nvarchar (100) null, 
	ZipCode char (5) not null, 
	PurchasePrice decimal (10, 2) not null,
	PaymentOption nvarchar(50) not null
)

create table Specials(
	SpeicalId int identity (1,1) not null primary key, 
	SpecialTitle nvarchar(50) not null, 
	SpecialDescription nvarchar(max) not null, 	
)

create table ContactForms(
	ContactFormId int identity (1,1) not null, 
	CustomerName nvarchar (50) not null, 
	Email nvarchar (100) not null, 
	Phone nvarchar(20) not null, 
	FromMessage nvarchar(max) not null,
)