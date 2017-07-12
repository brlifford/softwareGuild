USE HotelReservation
GO

INSERT INTO Customer(FirstName, LastName)
VALUES ('Brad', 'Lifford'), ('Clare', 'Hahneman'), ('Bob', 'Smith'), ('Cate', 'Honzl')
GO

INSERT INTO RoomType(RoomType, RoomTypeRate, OccupancyLimit)
VALUES('Single', 45, 1), ('Double', 60, 2), ('QueenSuite', 75, 2), ('KingSuite', 90, 4), ('King', 65, 3)
GO

INSERT INTO Amenities(AmenityType)
VALUES ('MiniFridge'), ('Microwave'), ('Flat-screenTV'), ('SpaBath'), ('Concierge')
GO

INSERT INTO Bill(Total, Tax)
VALUES(355, 0.725), (130, 0.725), (60, 0.725), (195, 0.725)
GO

INSERT INTO BillDetail(BillID, DailyRate, [Days], Discount)
VALUES(1, 65, 7, -25), (2, 65, 2, 0), (3, 60, 1, -10), (4, 65, 3, -20)
GO

INSERT INTO Reservation(CustomerID, ReservationDateStart, ReservationDateEnd, BillID)
VALUES(1, '8/14/2017', '8/22/2017', 1), (2, '8/10/2017', '8/12/2017', 2), (3, '9/9/2017', '9/10/2017', 3), (4, '10/12/2017', '10/15/2017', 4)
GO


INSERT INTO Room([Floor], RoomTypeID, AmenitiesID)
VALUES(1, 1, 1),(2, 2, 2), (3, 3, 4), (4, 4, 6), (5, 5, 5)
GO