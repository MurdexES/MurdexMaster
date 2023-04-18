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
  Name nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE TeachersTB (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  EmploymentDate date NOT NULL CHECK (EmploymentDate >= '1990-01-01'),
  Name nvarchar(max) NOT NULL CHECK (Name <> ''),
  Premium money NOT NULL DEFAULT 0 CHECK (Premium >= 0),
  Salary money NOT NULL CHECK (Salary > 0),
  Surname nvarchar(max) NOT NULL CHECK (Surname <> '')
);

