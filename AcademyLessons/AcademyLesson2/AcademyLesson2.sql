use [AcademyDB]

CREATE TABLE GroupsTB (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(10) NOT NULL UNIQUE,
    Rating int NOT NULL CHECK (Rating >= 0 AND Rating <= 5),
    Year int NOT NULL CHECK (Year >= 1 AND Year <= 5)
);

CREATE TABLE DepartmentsTB (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Financing money NOT NULL DEFAULT 0,
    Name nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE FacultiesTB (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Dean nvarchar(max) NOT NULL CHECK (Dean <> ''),
  Name nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE TeachersTB (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  EmploymentDate date NOT NULL CHECK (EmploymentDate >= '1990-01-01'),
  IsAssistant bit NOT NULL DEFAULT 0,
  IsProfessor bit NOT NULL DEFAULT 0,
  Position nvarchar(max) NOT NULL CHECK (Position <> ''),
  Name nvarchar(max) NOT NULL CHECK (Name <> ''),
  Premium money NOT NULL DEFAULT 0 CHECK (Premium >= 0),
  Salary money NOT NULL CHECK (Salary > 0),
  Surname nvarchar(max) NOT NULL CHECK (Surname <> '')
);


--1
SELECT Name, Financing, Id FROM DepartmentsTB ORDER BY Id DESC;

--2
SELECT Name AS 'Group Name', Rating AS 'Group Rating' FROM GroupsTB;

--3
SELECT Surname, (Premium / Salary * 100) AS 'Percent of Premium Rate', (1 + Premium / Salary) * 100 AS 'Percent of Total Rate' FROM TeachersTB;

--4
SELECT CONCAT('The dean of faculty ', Name, ' is ', Dean, '.') AS 'Faculty Info' FROM FacultiesTB;

--5
SELECT Surname FROM TeachersTB WHERE IsProfessor = 1 AND Salary > 1050;

--6
SELECT Name FROM DepartmentsTB WHERE Financing < 11000 OR Financing > 25000;

--7
SELECT Name FROM FacultiesTB WHERE Name <> 'Computer Science';

--8
SELECT Surname, Position FROM TeachersTB WHERE IsProfessor = 0;

--9
SELECT Surname, Position, Salary, Premium FROM TeachersTB WHERE IsAssistant = 1 AND Premium BETWEEN 160 AND 550;

--10
SELECT Surname, Salary FROM TeachersTB WHERE IsAssistant = 1;

--11
SELECT Surname, Position FROM TeachersTB WHERE EmploymentDate < '2000-01-01';

--12
SELECT Name AS 'Name of Department' FROM DepartmentsTB WHERE Name < 'Software Development' ORDER BY Name ASC;

--13
SELECT Surname FROM TeachersTB WHERE IsAssistant = 1 AND Salary + Premium <= 1200;

--14
SELECT Name AS 'Group Name' FROM GroupsTB WHERE Year = 5 AND Rating BETWEEN 2 AND 4;

--15
SELECT Surname, Salary FROM TeachersTB WHERE IsAssistant = 1 AND (Salary < 550 OR Premium < 200);
