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
select Wards.Name, Wards.Places from Wards
inner join Department on Wards.DepartmentId = Department.Id
where Building = 5 and Wards.Places >= 5 and
exist(
    select 1 from Wards
    where Building = 5 and Wards.Places >= 15
)

--2


--3


--4


--5
