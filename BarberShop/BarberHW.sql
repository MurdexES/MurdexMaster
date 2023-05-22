use [BarberDB]

CREATE TABLE Barbers (
  BarberId INT IDENTITY (1,1) PRIMARY KEY,
  FullName NVARCHAR(MAX) NOT NULL CHECK (FullName <> ''),
  Gender BIT NOT NULL,
  ContactPhone NVARCHAR(20) NOT NULL,
  Email NVARCHAR(100) NOT NULL,
  BirthDate DATE NOT NULL CHECK (BirthDate < GETDATE()),
  EmploymentDate DATE NOT NULL,
  Position NVARCHAR(20) NOT NULL
);

-- Создание таблицы "Services"
CREATE TABLE Services (
  ServiceId INT IDENTITY (1,1) PRIMARY KEY,
  BarberId INT FOREIGN KEY REFERENCES Barbers(BarberId),
  ServiceName NVARCHAR(100) NOT NULL,
  Price DECIMAL(10, 2) NOT NULL,
  DurationMinutes INT NOT NULL
);

-- Создание таблицы "Feedbacks"
CREATE TABLE Feedbacks (
  FeedbackId INT IDENTITY (1,1) PRIMARY KEY,
  BarberId INT FOREIGN KEY REFERENCES Barbers(BarberId),
  CustomerName NVARCHAR(100) NOT NULL,
  Feedback NVARCHAR(MAX) NOT NULL
);

-- Создание таблицы "Ratings"
CREATE TABLE Ratings (
  RatingId INT IDENTITY (1,1) PRIMARY KEY,
  BarberId INT FOREIGN KEY REFERENCES Barbers(BarberId),
  CustomerName NVARCHAR(100) NOT NULL,
  Rating NVARCHAR(20) NOT NULL
);

-- Создание таблицы "Clients"
CREATE TABLE Clients (
  ClientId INT IDENTITY (1,1) PRIMARY KEY,
  FullName NVARCHAR(MAX) NOT NULL CHECK (FullName <> ''),
  ContactPhone NVARCHAR(20) NOT NULL,
  Email NVARCHAR(100) NOT NULL
);

-- Создание таблицы "ClientFeedbacks"
CREATE TABLE ClientFeedbacks (
  FeedbackId INT IDENTITY (1,1) PRIMARY KEY,
  ClientId INT FOREIGN KEY REFERENCES Clients(ClientId),
  BarberId INT FOREIGN KEY REFERENCES Barbers(BarberId),
  Feedback NVARCHAR(MAX) NOT NULL
);

-- Создание таблицы "ClientRatings"
CREATE TABLE ClientRatings (
  RatingId INT IDENTITY (1,1) PRIMARY KEY,
  ClientId INT FOREIGN KEY REFERENCES Clients(ClientId),
  BarberId INT FOREIGN KEY REFERENCES Barbers(BarberId),
  Rating NVARCHAR(20) NOT NULL
);

-- Создание таблицы "Visits"
CREATE TABLE Visits (
  VisitId INT PRIMARY KEY,
  ClientId INT FOREIGN KEY REFERENCES Clients(ClientId),
  BarberId INT FOREIGN KEY REFERENCES Barbers(BarberId),
  ServiceId INT FOREIGN KEY REFERENCES Services(ServiceId),
  VisitDate DATE NOT NULL CHECK (VisitDate < GETDATE()),
  TotalCost DECIMAL(10, 2) NOT NULL,
  Rating NVARCHAR(20) NOT NULL,
  Feedback NVARCHAR(MAX) NOT NULL
);

--Part 1
--1
CREATE FUNCTION LongestWorking()
RETURNS TABLE
AS
RETURN
    SELECT TOP 1 * FROM Barbers
    ORDER BY EmploymentDate;

--2
CREATE FUNCTION BarberWithMostClients(@StartDate DATE, @EndDate DATE)
RETURNS TABLE
AS
RETURN
    SELECT TOP 1 Barbers.* FROM Barbers
    INNER JOIN Visits ON Barbers.BarberId = Visits.BarberId
    WHERE Visits.VisitDate BETWEEN @StartDate AND @EndDate
    GROUP BY Barbers.BarberId, Barbers.FullName, Barbers.Gender, Barbers.ContactPhone, Barbers.Email, Barbers.BirthDate, Barbers.EmploymentDate, Barbers.Position
    ORDER BY COUNT(Visits.VisitId);

--3
CREATE FUNCTION ClientWithMostVisits()
RETURNS TABLE
AS
RETURN
    SELECT TOP 1 Clients.* FROM Clients
    INNER JOIN Visits ON Clients.ClientId = Visits.ClientId
    GROUP BY Clients.ClientId, Clients.FullName, Clients.ContactPhone, Clients.Email
    ORDER BY COUNT(Visits.VisitId);

--4
CREATE FUNCTION ClientWithMaxSpending()
RETURNS TABLE
AS
RETURN
    SELECT TOP 1 Clients.* FROM Clients
    INNER JOIN Visits ON Clients.ClientId = Visits.ClientId
    GROUP BY Clients.ClientId, Clients.FullName, Clients.ContactPhone, Clients.Email
    ORDER BY SUM(Visits.TotalCost);

--5
CREATE FUNCTION LongestDurationService()
RETURNS TABLE
AS
RETURN
    SELECT TOP 1 * FROM Services
    ORDER BY DurationMinutes;

--Part2
--1
CREATE FUNCTION MostPopularBarber()
RETURNS TABLE
AS
RETURN
    SELECT TOP 1 Barbers.* FROM Barbers
    INNER JOIN Visits ON Barbers.BarberId = Visits.BarberId
    GROUP BY Barbers.BarberId, Barbers.FullName, Barbers.Gender, Barbers.ContactPhone, Barbers.Email, Barbers.BirthDate, Barbers.EmploymentDate, Barbers.Position
    ORDER BY COUNT(Visits.VisitId);

--2
CREATE PROCEDURE TopBarbersByRevenue(@Month INT, @Year INT)
AS
BEGIN
    SELECT TOP 3 Barbers.* FROM Barbers
    INNER JOIN Visits ON Barbers.BarberId = Visits.BarberId
    WHERE MONTH(Visits.VisitDate) = @Month AND YEAR(Visits.VisitDate) = @Year
    GROUP BY Barbers.BarberId, Barbers.FullName, Barbers.Gender, Barbers.ContactPhone, Barbers.Email, Barbers.BirthDate, Barbers.EmploymentDate, Barbers.Position
    ORDER BY SUM(Visits.TotalCost);
END;

--3
CREATE PROCEDURE TopBarbersByRating()
AS
BEGIN
    SELECT TOP 3 Barbers.* FROM Barbers
    INNER JOIN Ratings ON Barbers.BarberId = Ratings.BarberId
    INNER JOIN Visits ON Barbers.BarberId = Visits.BarberId
    GROUP BY Barbers.BarberId, Barbers.FullName, Barbers.Gender, Barbers.ContactPhone, Barbers.Email, Barbers.BirthDate, Barbers.EmploymentDate, Barbers.Position
    HAVING COUNT(Visits.VisitId) >= 30
    ORDER BY AVG(CONVERT(DECIMAL(5,2), Ratings.Rating)) DESC;
END;

--8
CREATE TRIGGER PreventJuniorBarberOverflow
ON Barbers
AFTER INSERT
AS
BEGIN
    IF (SELECT COUNT(*) FROM Barbers WHERE Position = 'Junior Barber') > 5
    BEGIN
        RAISERROR('This is the max limit', 16, 1);
        ROLLBACK;
    END;
END;

--9
CREATE FUNCTION ClientsWithoutFeedback()
RETURNS TABLE
AS
RETURN
    SELECT Clients.* FROM Clients
    LEFT JOIN ClientFeedbacks ON Clients.ClientId = ClientFeedbacks.ClientId
    LEFT JOIN ClientRatings ON Clients.ClientId = ClientRatings.ClientId
    WHERE ClientFeedbacks.FeedbackId IS NULL AND ClientRatings.RatingId IS NULL;

--10
CREATE FUNCTION InactiveClients()
RETURNS TABLE
AS
RETURN
    SELECT Clients.* FROM Clients
    LEFT JOIN Visits ON Clients.ClientId = Visits.ClientId
    WHERE Visits.VisitId IS NULL OR Visits.VisitDate < DATEADD(YEAR, -1, GETDATE());
