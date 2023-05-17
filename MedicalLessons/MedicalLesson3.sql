use [MedicalDB]

create table Department
(
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Building int NOT NULL CHECK (Building >= 1 AND Building <= 5),
  Financing money NOT NULL CHECK (Financing >=  0) DEFAULT 0,
  Name nvarchar(100) NOT NULL CHECK (Name <> '') UNIQUE
);

create table Diseases
(
  Id int identity(1,1) not null primary key,
  Name nvarchar(100) not null check (Name <> '') unique
);

create table Doctors
(
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY ,
  Name NVARCHAR(MAX) NOT NULL CHECK (Name <> ''),
  Salary MONEY NOT NULL CHECK (Salary > 0),
  Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> '')
);

create table DoctorsExaminations
(
  Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
  DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors([Id]),
  ExaminationId INT NOT NULL FOREIGN KEY REFERENCES Examinations([Id]),
  WardId INT NOT NULL FOREIGN KEY REFERENCES Wards([Id]),
  DiseaseId int not null foreign key references Diseases([Id]),
  Date date not null,
);

create table Examinations
(
  Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
  Name NVARCHAR(100) NOT NULL CHECK (Name <> '') UNIQUE
);

create table Wards
(
  Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
  Name NVARCHAR(20) NOT NULL CHECK (Name <> '') UNIQUE,
  Places INT NOT NULL CHECK (Places >= 1),
  DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department([Id])
);

create table Interns
(
  Id int identity (1,1) not null primary key ,
  DoctorId int not null foreign key references Doctors([Id])
);

create table Professors
(
  Id int identity (1,1) not null primary key ,
  DoctorId int not null foreign key references Doctors([Id])
);

--1
select Wards.Name, Places
from Wards
join Department on Wards.DepartmentId = Department.Id
where Department.Building = 5 and Wards.Places >= 5
and EXISTS (
  select 1
  from Wards
  where DepartmentId = Department.Id and Places > 15
);

--2
select distinct Department.Name
from Department
join Wards on Department.Id = Wards.DepartmentId
join DoctorsExaminations on Wards.Id = DoctorsExaminations.WardId
join Examinations on DoctorsExaminations.ExaminationId = Examinations.Id
where DoctorsExaminations.Date >= DATEADD(week, -1, GETDATE());

--3
select Diseases.Name
FROM Diseases
where not EXISTS (
  select 1
  from DoctorsExaminations
  where DoctorsExaminations.DiseaseId = Diseases.Id
);

--4
select Doctors.Name, Doctors.Surname
from Doctors
where not EXISTS (
  select 1
  from DoctorsExaminations
  where DoctorsExaminations.DoctorId = Doctors.Id
);

--5
select Department.Name
from Department
where not EXISTS (
  select 1
  from Wards
  inner join DoctorsExaminations on Wards.Id = DoctorsExaminations.WardId
  WHERE Wards.DepartmentId = Department.Id
);
