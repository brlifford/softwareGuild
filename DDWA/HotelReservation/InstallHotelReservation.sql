
use [master]
go

if exists (select * from sysdatabases where name='HotelReservation')
		drop database HotelReservation
go



CREATE DATABASE HotelReservation
GO

USE HotelReservation
GO



if exists (select * from sysobjects where id = object_id('dbo.RoomType') and sysstat & 0xf = 3)
	drop table "dbo"."RoomType"
GO

if exists (select * from sysobjects where id = object_id('dbo.Amenities') and sysstat & 0xf = 3)
	drop table "dbo"."Amenities"
GO

if exists (select * from sysobjects where id = object_id('dbo.RoomTypeAmenities') and sysstat & 0xf = 3)
	drop table "dbo"."RoomTypeAmenities"
GO



if exists (select * from sysobjects where id = object_id('dbo.Customer') and sysstat & 0xf = 3)
	drop table "dbo"."Customer"
GO

if exists (select * from sysobjects where id = object_id('dbo.Guests') and sysstat & 0xf = 3)
	drop table "dbo"."Guests"
GO


if exists (select * from sysobjects where id = object_id('dbo.CustomerGuests') and sysstat & 0xf = 3)
	drop table "dbo"."CustomerGuests"
GO

if exists (select * from sysobjects where id = object_id('dbo.PromoCode') and sysstat & 0xf = 3)
	drop table "dbo"."PromoCode"
GO


if exists (select * from sysobjects where id = object_id('dbo.AddOns') and sysstat & 0xf = 3)
	drop table "dbo"."AddOns"
GO

if exists (select * from sysobjects where id = object_id('dbo.AddOnsRate') and sysstat & 0xf = 3)
	drop table "dbo"."AddOnsRate"
GO


if exists (select * from sysobjects where id = object_id('dbo.Room') and sysstat & 0xf = 3)
	drop table "dbo"."Room"
GO

if exists (select * from sysobjects where id = object_id('dbo.RoomRate') and sysstat & 0xf = 3)
	drop table "dbo"."Room"
GO

if exists (select * from sysobjects where id = object_id('dbo.RoomAddOns') and sysstat & 0xf = 3)
	drop table "dbo"."RoomAddOns"
GO



if exists (select * from sysobjects where id = object_id('dbo.Bill') and sysstat & 0xf = 3)
	drop table "dbo"."Bill"
GO

if exists (select * from sysobjects where id = object_id('dbo.BillDetails') and sysstat & 0xf = 3)
	drop table "dbo"."BillDetails"
GO


if exists (select * from sysobjects where id = object_id('dbo.Reservation') and sysstat & 0xf = 3)
	drop table "dbo"."Reservation"
GO



USE HotelReservation
GO

CREATE TABLE RoomType (
	RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
	RoomType NVARCHAR(20),
	OccupancyLimit SMALLINT
)
GO

CREATE TABLE Amenities (
	AmenitiesID INT IDENTITY(1,1) PRIMARY KEY,
	AmenityType NVARCHAR(20)
)
GO

CREATE TABLE RoomTypeAmenities (
	RoomTypeAmenitiesID INT IDENTITY(1,1) PRIMARY KEY,
	RoomTypeID INT,
	CONSTRAINT FK_RoomType_RoomTypeAmenities
		FOREIGN KEY (RoomTypeID)
		REFERENCES RoomType(RoomTypeID),
	AmenitiesID INT,
	CONSTRAINT FK_Amenities_RoomTypeAmenities
		FOREIGN KEY(AmenitiesID)
		REFERENCES Amenities(AmenitiesID)
)
GO

CREATE TABLE Customer(
	CustomerID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(30),
	LastName NVARCHAR(30),
	Phone VARCHAR(10),
	Email NVARCHAR(50)
)
GO

CREATE TABLE Guests(
	GuestID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(30),
	LastName NVARCHAR(30)
)
GO

CREATE TABLE CustomerGuests(
	CustomerGuestsID INT IDENTITY(1,1) PRIMARY KEY,
	CustomerID INT,
	CONSTRAINT FK_Customer_CustomerGuests
		FOREIGN KEY (CustomerID)
		REFERENCES Customer(CustomerID),
	GuestID INT,
	CONSTRAINT FK_Guests_CustomerGuests
		FOREIGN KEY (GuestID)
		REFERENCES Guests(GuestID),
)
GO

CREATE TABLE PromoCode(
	PromoCodeID INT IDENTITY(1,1) PRIMARY KEY,
	PromoCodeDateStart DATETIME2,
	PromoCodeDateEnd DATETIME2,
	PercentOff DECIMAL,
	DollarOff MONEY
)
GO


CREATE TABLE AddOns(
	AddOnID INT IDENTITY(1,1) PRIMARY KEY,
	AddOnName NVARCHAR(50),
	AddOnPrice MONEY
)
GO

CREATE TABLE AddOnsRate(
	AddOnsRateID INT IDENTITY(1,1) PRIMARY KEY,
	AddOnID INT,
	CONSTRAINT FK_AddOns_AddOnsRate
		FOREIGN KEY (AddOnID)
		REFERENCES AddOns(AddOnID),
	AddOnDateStart DATETIME2,
	AddOnDateEnd DATETIME2
)
GO

CREATE TABLE Room(
	RoomID INT IDENTITY(1,1) PRIMARY KEY,
	[Floor] SMALLINT,
	RoomTypeID INT,
	CONSTRAINT FK_RoomType_Room
		FOREIGN KEY (RoomTypeID)
		REFERENCES RoomType(RoomTypeID)
)
GO

CREATE TABLE RoomRate(
	RoomRateID int identity(1,1) primary key,
	RoomID int,
		constraint FK_Room_RoomRate
		foreign key (RoomID)
		references Room(RoomID),
	RoomRateStart datetime2,
	RoomRateEnd datetime2
)
GO

CREATE TABLE RoomAddOns(
	RoomAddOnID INT IDENTITY(1,1) PRIMARY KEY,
	RoomID INT,
	CONSTRAINT FK_Room_RoomAddOns
		FOREIGN KEY (RoomID)
		REFERENCES Room(RoomID),
	AddOnID INT,
	CONSTRAINT FK_AddOns_RoomAddOns
		FOREIGN KEY (AddOnID)
		REFERENCES AddOns(AddOnID)
)
GO

CREATE TABLE Bill(
	BillID INT IDENTITY(1,1) PRIMARY KEY,
	TotalDays INT,
	Subtotal MONEY,
	Total MONEY,
	Tax MONEY
)
GO

CREATE TABLE BillDetails(
	BillDetailID INT IDENTITY(1,1) PRIMARY KEY,
	DailyRate MONEY,
	Discount DECIMAL,
	BillID INT,
	CONSTRAINT FK_Bill_BillDetails
		FOREIGN KEY (BillID)
		REFERENCES Bill(BillID),
	RoomAddOnID INT
	CONSTRAINT FK_RoomAddOns_BillDetails
		FOREIGN KEY (RoomAddOnID)
		REFERENCES RoomAddOns(RoomAddOnID)
)
GO

CREATE TABLE Reservation(
	ReservationID INT IDENTITY(1,1) PRIMARY KEY,
	CustomerID INT,
	CONSTRAINT FK_Customer_Reservation
		FOREIGN KEY (CustomerID)
		REFERENCES Customer(CustomerID),
	ReservationDateStart DATETIME2,
	ReservationDateEnd DATETIME2,
	PromoCodeID INT,
	CONSTRAINT FK_PromoCode_Reservation
		FOREIGN KEY (PromoCodeID)
		REFERENCES PromoCode(PromoCodeID),
	BillID INT,
	CONSTRAINT FK_Bill_Reservation
		FOREIGN KEY (BillID)
		REFERENCES Bill(BillID)
)
GO

INSERT INTO Customer(FirstName, LastName, Phone, Email)
VALUES ('Brad', 'Lifford', 5555551255, 'brlifford@somewhere.com'), ('Clare', 'Hahneman', NULL, NULL), ('Bob', 'Smith', 555-1234 ,NULL), ('Cate', 'Honzl', NULL, NULL)
GO

INSERT INTO RoomType(RoomType, OccupancyLimit)
VALUES('Single', 1), ('Double', 2), ('QueenSuite', 2), ('KingSuite', 4), ('King', 3)
GO

INSERT INTO Amenities(AmenityType)
VALUES ('MiniFridge'), ('Microwave'), ('Flat-screenTV'), ('SpaBath'), ('Concierge')
GO

INSERT INTO Room([Floor], RoomTypeID)
VALUES (1, 1), (2, 2), (3, 3)

INSERT INTO Bill(Total, Tax)
VALUES(355, 0.725), (130, 0.725), (60, 0.725), (195, 0.725)
GO

INSERT INTO BillDetails(BillID, DailyRate, Discount)
VALUES(1, 65, -25), (2, 65, 0), (3, 60, -10), (4, 65, -20)
GO

INSERT INTO Reservation(CustomerID, ReservationDateStart, ReservationDateEnd, BillID)
VALUES(1, '8/14/2017', '8/22/2017', 1), (2, '8/10/2017', '8/12/2017', 2), (3, '9/9/2017', '9/10/2017', 3), (4, '10/12/2017', '10/15/2017', 4)
GO