use [MedicalDB]

CREATE TABLE Department
(
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Building int NOT NULL CHECK (Building >= 1 AND Building <= 5),
  Financing money NOT NULL CHECK (Financing >=  0) DEFAULT 0,
  Floor int NOT NULL CHECK (Floor >= 1),
  Name nvarchar(100) NOT NULL CHECK (Name <> '') UNIQUE
);

CREATE TABLE Diseases
(
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY ,
  Name nvarchar(100) NOT NULL CHECK (Name <> '') UNIQUE ,
  Severity int NOT NULL  CHECK (Severity >= 1) DEFAULT 1
);

CREATE TABLE Doctors
(
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY ,
  Name NVARCHAR(MAX) NOT NULL CHECK (Name <> ''),
  Phone CHAR(10) NOT NULL ,
  Premium MONEY NOT NULL CHECK (Premium >= 0) DEFAULT 0,
  Salary MONEY NOT NULL CHECK (Salary > 0),
  Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> '')
);

CREATE TABLE Examinations
(
  Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
  DayOfWeek INT NOT NULL CHECK (DayOfWeek >= 1 AND DayOfWeek <= 7),
  EndTime TIME NOT NULL CHECK ( EndTime >= '08:00:00' AND EndTime <= '18:00:00'),
  StartTime TIME NOT NULL CHECK (StartTime >= '08:00:00' AND StartTime <= '18:00:00'),
  Name NVARCHAR(100) NOT NULL CHECK (Name <> '') UNIQUE
);

CREATE TABLE Wards
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
    Building INT NOT NULL CHECK (Building >= 1 AND Building <= 5),
    Floor INT NOT NULL CHECK (Floor >= 1),
    Name NVARCHAR(20) NOT NULL CHECK (Name <> '') UNIQUE
);

--1
SELECT * FROM Wards;

--2
SELECT Surname, Phone FROM Doctors;

--3
SELECT DISTINCT Floor FROM Wards;

--4
SELECT Name AS "Name of Disease", Severity AS "Severity of Disease" FROM Diseases;

--5
SELECT d.Surname, e.Name AS "Examination", w.Name AS "Ward" FROM Doctors d JOIN Examinations e ON d.Id = e.Id JOIN Wards w ON w.Floor = e.DayOfWeek;

--6
SELECT Name FROM Department WHERE Building = 5 AND Financing < 30000;

--7
SELECT Name FROM Department WHERE Building = 3 AND Financing BETWEEN 12000 AND 15000;

--8
SELECT Name FROM Wards WHERE Building IN (4, 5) AND Floor = 1;

--9
SELECT Name, Building, Financing FROM Department WHERE Building IN (3, 6) AND (Financing < 11000 OR Financing > 25000);

--10
SELECT Surname FROM Doctors WHERE (Salary + Premium) > 1500;

--11
SELECT Surname FROM Doctors WHERE Salary/2 > 3*Premium;

--12
SELECT DISTINCT Name FROM Examinations WHERE DayOfWeek <= 3 AND StartTime >= '12:00:00' AND EndTime <= '15:00:00';

--13
SELECT Department.Name, Department.Building FROM Department WHERE Department.Building IN (1, 3, 8, 10);

--14
SELECT Diseases.Name FROM Diseases WHERE Diseases.Severity NOT IN (1, 2);

--15
SELECT Department.Name FROM Department WHERE Department.Building NOT IN (1, 3);

--16
SELECT Department.Name FROM Department WHERE Department.Building IN (1, 3);

--17
SELECT Doctors.Surname FROM Doctors WHERE Doctors.Surname LIKE 'N%';
