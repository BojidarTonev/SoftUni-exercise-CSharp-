CREATE DATABASE TripService
GO
USE TripService
GO

---0.1 DDL

CREATE TABLE Cities(
	Id INT IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
	CONSTRAINT PK_Cities PRIMARY KEY (Id) 
)

CREATE TABLE Hotels(
	Id INT IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
	CONSTRAINT PK_Hotels PRIMARY KEY (Id)
	CONSTRAINT FK_Hotels_Cities FOREIGN KEY (CityId) REFERENCES Cities(Id)
)

CREATE TABLE Rooms(
	Id INT IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL
	CONSTRAINT PK_Rooms PRIMARY KEY (Id)
	CONSTRAINT FK_Rooms_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels(Id)
)

CREATE TABLE Trips(
	Id INT IDENTITY,
	RoomId INT NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE
	CONSTRAINT PK_Trips PRIMARY KEY (Id)
	CONSTRAINT FK_Trips_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id),
	CONSTRAINT CK_BookDate CHECK(BookDate < ArrivalDate),
	CONSTRAINT CK_ArrivalDate CHECK(ArrivalDate < ReturnDate),
)

CREATE TABLE Accounts(
	Id INT IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY (Id),
	CONSTRAINT FK_Accounts_Cities FOREIGN KEY (CityId) REFERENCES Cities(Id)
)

CREATE TABLE AccountsTrips(
	AccountId INT NOT NULL,
	TripId INT NOT NULL,
	Luggage INT CHECK(Luggage >= 0) NOT NULL 
	CONSTRAINT PK_AccountsTrips PRIMARY KEY (AccountId, TripId)
	CONSTRAINT FK_AccountsTrips_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
	CONSTRAINT FK_AccountsTrips_Trips FOREIGN KEY (TripId) REFERENCES Trips(Id)
)

---02. Insert

INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

---03. Update

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)

---04. Delete

DELETE FROM AccountsTrips
WHERE AccountId = 47

---05. Bulgarian Cities

SELECT
       Id,
       Name
  FROM Cities
 WHERE CountryCode = 'BG'
 ORDER BY Name

  ---6. People Born After 1991
 
 SELECT
        CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName, ''), IIF(a.MiddleName IS NULL, a.LastName ,' '+a.LastName)) AS [Full Name],
		YEAR(a.BirthDate) AS [BirthYear]
   FROM Accounts AS a
  WHERE YEAR(a.BirthDate) > 1991
  ORDER BY YEAR(a.BirthDate) DESC, a.FirstName

    ---07. EEE-Mails 

  SELECT 
         a.FirstName,
		 a.LastName,
		 FORMAT(a.BirthDate, 'MM-dd-yyyy') As [BirthDate],
		 c.Name AS [Hometown],
		 a.Email
    FROM Accounts AS a
    JOIN Cities AS c
      ON c.Id = a.CityId
   WHERE LEFT(a.Email, 1) = 'e'
   ORDER BY c.Name DESC

---08. City Statistics 


SELECT
       c.Name,
	   COUNT(h.Id) AS [Hotels]
  FROM Cities AS c
  LEFT JOIN Hotels AS h
    ON h.CityId = c.Id
 GROUP BY c.Name
 ORDER BY [Hotels] DESC, c.Name

---09. Expensive First Class Rooms 

 SELECT
        r.Id,
		r.Price,
		h.Name AS [Hotel],
		c.Name AS [City]
   FROM Rooms AS r
   JOIN Hotels AS h  
     ON h.Id = r.HotelId
   JOIN Cities AS c
     ON c.Id = h.CityId
  WHERE r.Type = 'First Class'
  ORDER BY r.Price DESC, r.Id

---10. Longest and Shortest Trips 

 WITH w (AccountId, FullName, TripDuration) AS(
      SELECT
	         a.Id AS [AccountId],
			 CONCAT(a.FirstName, ' ', a.LastName) AS [FullName],
			 DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS [TripDuration]
	    FROM Accounts AS a 
		JOIN AccountsTrips AS at
		  ON at.AccountId = a.Id 
		JOIN Trips AS t
		  ON t.Id = at.TripId
	 WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
 )

 SELECT 
        w.AccountId,
		w.FullName,
		MAX(w.TripDuration) AS [LongestTrip],
		MIN(w.TripDuration) AS [ShortestTrip]
   FROM w AS w
  GROUP BY w.AccountId, w.FullName
  ORDER BY [LongestTrip] DESC, w.AccountId

---11. Metropolis 
  
 WITH w (Id, Accounts) AS(
	SELECT  TOP 5
	       c.Id,
		   COUNT(a.Id)  AS [Accounts]
	  FROM Cities AS c
	  JOIN Accounts AS a
	    ON a.CityId = c.Id
	 GROUP BY c.Id
	 ORDER BY Accounts DESC
 )

 SELECT
        w.Id,
		c.Name AS [City],
		c.CountryCode AS [Country],
		w.Accounts
   FROM w AS w
   JOIN Cities AS c
     ON w.Id = c.Id

---12. Romantic Getaways



---13. Lucrative Destinations --X

WITH w (Id, TotalRevenue, Trips) AS(
	SELECT
	   TOP 10
	       c.Id,
		   SUM(h.BaseRate + r.Price) AS [TotalRevenue],
		   COUNT(t.Id) AS [Trips]
	  FROM Cities AS c
	  JOIN Hotels AS h
	    ON h.CityId = c.Id
	  JOIN Rooms AS r
	    ON r.HotelId = h.Id
	  JOIN Trips AS t
	    ON t.RoomId = r.Id
	 GROUP BY c.Id, t.BookDate
	HAVING YEAR(t.BookDate) = 2016
)



---14. Trip Revenues 

WITH w (Id, Revenue) AS (
	SELECT
	       t.Id,
		   CASE
		   WHEN t.CancelDate IS NULL THEN SUM(h.BaseRate + r.Price)
		   ELSE 0
		   END AS [Revenue]
	 FROM Trips AS t
	 JOIN Rooms AS r
	   ON r.Id = t.RoomId
	 JOIN Hotels AS h
	   ON h.Id = r.HotelId
    GROUP BY t.Id, t.CancelDate
)

SELECT
       t.Id,
	   h.Name AS [HotelName],
	   r.Type AS [RoomType],
	   w.Revenue
  FROM Trips AS t
  JOIN w AS w
    ON t.Id = w.Id
  JOIN Rooms AS r
    ON r.Id = t.RoomId
  JOIN Hotels AS h
    ON h.Id = r.HotelId
 ORDER BY [RoomType], t.Id

---15. Top Travelers



---16. Luggage Fee

SELECT 
       at.AccountId,
	   COUNT(at.Luggage)
  FROM AccountsTrips AS at
  GROUP BY at.AccountId
  

---17. GDPR Violation --X

SELECT
       t.Id,
	    CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName, ''), IIF(a.MiddleName IS NULL, a.LastName ,' '+a.LastName)) AS [Name],
	   c2.Name AS [From],
	   c.Name AS [To],
	   CASE 
	     WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
		 ELSE 'Canceled'
         END AS [Duration]	   
  FROM Trips AS t
  JOIN AccountsTrips AS at
    ON at.TripId = t.Id
   JOIN Accounts AS a
     ON a.Id = at.AccountId
   JOIN Rooms AS r
     ON r.Id = t.RoomId
  JOIN Hotels AS h
    ON h.Id = r.HotelId
  JOIN Cities AS c
    ON c.Id = h.CityId
  JOIN Cities as c2
    ON c2.Id = a.CityId
  ORDER BY [Name]

---18. Available Room
GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @RoomId INT, @RoomType NVARCHAR(30), @NumberOfBeds INT, @Result NVARCHAR(100)
	SET @RoomId = (SELECT 
	                  TOP 1
	                      r.Id 
				     FROM Rooms AS r
					 JOIN Trips AS t
					   ON t.RoomId = r.Id
					WHERE (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate)
					      OR (@Date BETWEEN t.ArrivalDate AND t.ReturnDate AND t.CancelDate IS NULL)					      
						  AND r.HotelId = @HotelId
						  AND r.Beds >= @People
				    ORDER BY r.Price DESC)

	IF(@RoomId <> 0)
	 BEGIN
		DECLARE @TotalPrice DECIMAL(15, 2), @HotelBaseRate DECIMAL(15, 2), @RoomPrice DECIMAL(15, 2)
		SET @HotelBaseRate = (SELECT BaseRate FROM Hotels AS h JOIN Rooms AS r ON r.HotelId = h.Id  WHERE h.Id = @HotelId AND r.Id = @RoomId)
		SET @RoomPrice = (SELECT Price FROM Rooms AS r WHERE r.Id = @RoomId) 
		SET @TotalPrice = (@HotelBaseRate + @RoomPrice) * @People

	   SET @RoomType = (SELECT r.Type FROM Rooms AS r WHERE r.Id = @RoomId) 
	   SET @NumberOfBeds = (SELECT r.Beds FROM Rooms AS r WHERE r.Id = @RoomId) 
	   SET @Result = CONCAT('Room ', @RoomId, ': ', @RoomType, ' (', @NumberOfBeds, ' beds) - $', @TotalPrice)
	 END

	ELSE
	BEGIN
	   SET @Result = 'No rooms available'
	END		
				     
    	   RETURN @Result
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
---19. Switch rooms

CREATE PROC usp_SwitchRooms(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @TargetRoomHotelId INT, @ActualTripHotelId INT, @NumberOfBeds INT, @TripAccounts INT
	SET @TargetRoomHotelId = (SELECT r.HotelId FROM Rooms AS r WHERE r.Id = @TargetRoomId)
	SET @ActualTripHotelId = (SELECT 
	                                 r.HotelId 
							    FROM Rooms AS r 
								JOIN Trips AS t 
								  ON t.RoomId = r.Id 
							   WHERE t.Id = @TripId) 

	IF(@TargetRoomHotelId != @ActualTripHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!',16, 1)
		RETURN
	END

	SET @NumberOfBeds = (SELECT r.Beds FROM Rooms AS r WHERE r.Id = @TargetRoomId)
	SET @TripAccounts = (SELECT
	                            COUNT(a.Id)
						   FROM Accounts AS a
						   JOIN Hotels AS h
						     ON h.CityId = a.CityId
						   JOIN Rooms AS r
						     ON r.HotelId = h.Id
							WHERE r.Id = @TargetRoomId)

	IF(@NumberOfBeds < @TripAccounts)
	BEGIN
	   RAISERROR('Not enough beds in target room!', 16, 2)
	   RETURN
	END

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId

END


---20. Cancel Trip
GO

CREATE TRIGGER tr_DeleteTrip ON Trips
INSTEAD OF DELETE 
AS
BEGIN

	UPDATE Trips
	SET CancelDate = GETDATE()
	WHERE CancelDate IS NULL AND Id IN ()
	
END
