use [MedicalDB]

CREATE TABLE Department
(
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Building int NOT NULL CHECK (Building >= 1 AND Building <= 5),
  Name nvarchar(100) NOT NULL CHECK (Name <> '') UNIQUE
);

CREATE TABLE Doctors
(
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY ,
  Name NVARCHAR(MAX) NOT NULL CHECK (Name <> ''),
  Premium MONEY NOT NULL CHECK (Premium >= 0) DEFAULT 0,
  Salary MONEY NOT NULL CHECK (Salary > 0),
  Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> '')
);

CREATE TABLE DoctorsExaminations
(
  Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
  EndTime TIME NOT NULL CHECK ( EndTime >= '08:00:00' AND EndTime <= '18:00:00'),
  StartTime TIME NOT NULL CHECK (StartTime >= '08:00:00' AND StartTime <= '18:00:00'),
  DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors([Id]),
  ExaminationId INT NOT NULL FOREIGN KEY REFERENCES Examinations([Id]),
  WardId INT NOT NULL FOREIGN KEY REFERENCES Wards([Id]),
  Name NVARCHAR(100) NOT NULL CHECK (Name <> '') UNIQUE
);

CREATE TABLE Examinations
(
  Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
  Name NVARCHAR(100) NOT NULL CHECK (Name <> '') UNIQUE
);

CREATE TABLE Wards
(
  Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
  Name NVARCHAR(20) NOT NULL CHECK (Name <> '') UNIQUE,
  Places INT NOT NULL CHECK (Places >= 1),
  DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department([Id])
);

--1
select count(Wards) as WardsNumber from Wards where Places > 10

--2
select Department.Building, count(Wards.Id) as NumWards FROM Department inner join Wards on Department.Id = Wards.DepartmentId group by Department.Building

--3
select Department.Name, count(Wards.Id) as NumWards from Department inner join Wards ON Department.Id = Wards.DepartmentId group by Department.Name

--4
select d.Name, sum(do.Salary + do.Premium) as TotalBonus from Department d inner join Wards w on d.Id = w.DepartmentId inner join DoctorsExaminations de on w.Id = de.WardId inner join Doctors do on de.DoctorId = do.Id group by d.Name

--5
select d.Name from Department d inner join Wards w on d.Id = w.DepartmentId inner join DoctorsExaminations de on w.Id = de.WardId group by d.Name having count(distinct de.DoctorId) >= 5

--6
select count(*) as NumDoctors, sum(Salary + Premium) as TotalSalary from Doctors

--7
select AVG(Salary + Premium) as AverageSalary from Doctors

--8
select Name from Wards where Places = (select min(Places) from Wards)

--9
select d.Building, SUM(w.Places) as TotalPlaces from Department d inner join Wards w on d.Id = w.DepartmentId where d.Building in (1, 6, 7, 8) group by d.Building having SUM(w.Places) > 100 and COUNT(case when w.Places > 10 then 1 else null end) > 0
