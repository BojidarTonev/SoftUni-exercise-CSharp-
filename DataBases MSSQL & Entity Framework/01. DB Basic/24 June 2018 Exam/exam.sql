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
  
 


---12. Romantic Getaways





---13. Lucrative Destinations





---14. Trip Revenues





---15. Top Travelers


SELECT
       a.Id AS [AccountId],
	   a.Email AS [Email],
	   c.CountryCode,
	   COUNT(at.TripId)
  FROM Accounts AS a
  JOIN Cities AS c
    ON c.Id = a.CityId
  JOIN AccountsTrips AS at
    ON at.AccountId = a.Id
 GROUP BY a.Id, a.Email, c.CountryCode



---18. Available Room

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @TotalPrice DECIMAL(15, 2), @HotelBaseRate DECIMAL(15, 2), @RoomPrice DECIMAL(15, 2)
	SET @HotelBaseRate = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
	SET @RoomPrice = (SELECT Price FROM Rooms WHERE HotelId = @HotelId) 
	SET @TotalPrice = (@HotelBaseRate + @RoomPrice) * @People

	DECLARE @RoomId INT, @RoomType NVARCHAR(30), @NumberOfBeds INT, @Result NVARCHAR(100)
	SET @RoomId = (SELECT 
	                      r.Id 
				     FROM Rooms AS r
					 JOIN Trips AS t
					   ON t.RoomId = r.Id
					WHERE (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate)
					      AND t.CancelDate IS NULL 
						  AND r.HotelId = @HotelId
						  AND r.Beds >= @People)

	IF(@RoomId IS NULL)
	 BEGIN
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


---20. Cancel Tip
GO

CREATE TRIGGER tr_DeleteTrip ON Trips
INSTEAD OF DELETE 
AS
BEGIN
	DECLARE @Id INT, @CancelDate DATE, @Result DATE
	SET @Id = (SELECT Id FROM deleted)
	SET @CancelDate = (SELECT CancelDate FROM deleted)

	IF(@CancelDate IS NULL)
	BEGIN
		SET @Result = GETDATE()
		UPDATE Trips
		SET CancelDate = @Result
		WHERE Id = @Id
	END
	
END
