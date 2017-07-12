USE HotelReservation
GO

CREATE TABLE RoomType (
	RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
	RoomType NVARCHAR(20),
	RoomTypeRate MONEY
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
	OccupancyLimit SMALLINT,
	RoomTypeID INT,
	CONSTRAINT FK_Room_RoomType
		FOREIGN KEY (RoomTypeID)
		REFERENCES RoomType(RoomTypeID),
	AmenitiesID INT,
	CONSTRAINT FK_Room_Amenities
		FOREIGN KEY (AmenitiesID)
		REFERENCES Amenities(AmenitiesID)
)
GO

CREATE TABLE RoomAddOns(
	RoomAddOnsID INT IDENTITY(1,1) PRIMARY KEY,
	RoomID INT,
	CONSTRAINT FK_Room_RoomAddOns
		FOREIGN KEY (RoomID)
		REFERENCES Room(RoomID),
	AddOnID INT,
	CONSTRAINT FK_AddOn_RoomAddOns
		FOREIGN KEY (AddOnID)
		REFERENCES AddOns(AddOnID)
)
GO

CREATE TABLE Bill(
	BillID INT IDENTITY(1,1) PRIMARY KEY,
	Subtotal MONEY,
	Total MONEY,
	Tax MONEY
)
GO

CREATE TABLE BillDetail(
	BillDetailID INT IDENTITY(1,1) PRIMARY KEY,
	BillID INT,
	CONSTRAINT FK_Bill_BillDetail
		FOREIGN KEY (BillID)
		REFERENCES Bill(BillID),
	RoomAddOnsID INT
	CONSTRAINT FK_RoomAddOn_BillDetail
		FOREIGN KEY (RoomAddOnsID)
		REFERENCES RoomAddOns(RoomAddOnsID)
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
	CustomerGuestsID INT,
	CONSTRAINT FK_CustomerGuests_Reservation
		FOREIGN KEY (CustomerGuestsID)
		REFERENCES CustomerGuests(CustomerGuestsID),
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