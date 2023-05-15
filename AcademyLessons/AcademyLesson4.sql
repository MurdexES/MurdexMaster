use [AcademyDB]

create table Curators
(
  [Id] int identity (1,1) not null primary key ,
  [Name] nvarchar(max) not null check (Name <> '') ,
  [Surname] nvarchar(max) not null check (Surname <> '')
);

create table Departments
(
  [Id] int identity (1,1) not null primary key ,
  [Building] int not null check (Building >= 1 and Building <= 5),
  [Financing] money not null check (Financing >= 0) default 0,
  [Name] nvarchar(100) not null check (Name <> '') unique ,
  [FacultyId] int not null foreign key references Faculties([Id])
);

create table Faculties
(
  [Id] int identity (1,1) not null primary key ,
  [Name] nvarchar(100) not null check (Name <> '')
);

create table Groups
(
  [Id] int identity (1,1) not null primary key ,
  [Name] nvarchar(10) not null check (Name <> '') unique ,
  [Year] int not null check (Year >= 1 and Year <= 5),
  [DepartmentId] int not null foreign key references Departments([Id])
);

create table GroupsCurators
(
  [Id] int identity (1,1) not null primary key ,
  [CuratorId] int not null foreign key references Curators([Id]),
  [GroupId] int not null foreign key references Groups([Id])
);

create table GroupsLectures
(
  [Id] int identity (1,1) not null primary key ,
  [GroupId] int not null foreign key references Groups([Id]),
  [LectureId] int not null foreign key references Lectures([Id])
);

create table GroupsStudents
(
  [Id] int identity (1,1) not null primary key ,
  [GroupId] int not null foreign key references Groups([Id]),
  [StudentId] int not null foreign key references Students([Id])
);

create table Lectures
(
  [Id] int identity (1,1) not null primary key ,
  [Date] date not null check (Date <= getdate()),
  [SubjectId] int not null foreign key references Subjects([Id]),
  [TeachersId] int not null foreign key references Teachers([Id])
);

create table Students
(
  [Id] int identity (1,1) not null primary key ,
  [Name] nvarchar(max) not null check (Name <> ''),
  [Rating] int not null check (Rating >= 0 and Rating <= 5),
  [Surname] nvarchar(max) not null check (Surname <> '')
);

create table Subjects
(
  [Id] int identity (1,1) not null primary key ,
  [Name] nvarchar(100) not null check (Name <> '') unique
);

create table Teachers
(
   [Id] int identity (1,1) not null primary key ,
   [IsProfessor] bit not null default 0,
   [Name] nvarchar(max) not null check (Name <> ''),
   [Salary] money not null check (Salary > 0),
   [Surname] nvarchar(max) not null check (Surname <> '')
);

--1
select Building from Departments group by Building having SUM(Financing) > 100000

--2
select Groups.Name from Groups
inner join Departments on Groups.DepartmentId = Departments.Id
where Groups.Year = 5 and Departments.Name = 'Software Development'

--3
select Groups.Name from Groups
inner join (
  select GroupsStudents.GroupId, AVG(Students.Rating) as AvgRating
  from GroupsStudents
  inner join Students on GroupsStudents.StudentId = Students.Id
  group by GroupsStudents.GroupId
) GS  on Groups.Id = GS .GroupId
where GS .AvgRating > (
  select AVG(Students.Rating)
  from GroupsStudents
  inner join Students on GroupsStudents.StudentId = Students.Id
  inner join Groups on GroupsStudents.GroupId = Groups.Id
  where Groups.Name = 'D221'
)

--4
select Name, Surname from Teachers
where Salary > (select AVG(Salary) from Teachers where IsProfessor = 1)

--5
select Name from Groups
inner join GroupsCurators on Groups.Id = GroupsCurators.GroupId
group by Name having Count(GroupsCurators.CuratorId) > 1

--6
select Groups.Name
from Groups
inner join GroupsStudents on Groups.Id = GroupsStudents.GroupId
inner join Students on GroupsStudents.StudentId = Students.Id
inner join (
    select GroupsStudents.GroupId, AVG(Students.Rating) as AvgRating
    from Students
    inner join GroupsStudents on Students.Id = GroupsStudents.StudentId
    group by GroupsStudents.GroupId
) as gs ON Groups.Id = gs.GroupId
inner join (
    select min(Students.Rating) as MinRating
    from Students
    inner join GroupsStudents on Students.Id = GroupsStudents.StudentId
    inner join Groups on GroupsStudents.GroupId = Groups.Id
    where Groups.Year = 5
) as minrat on gs.AvgRating < minrat.MinRating

--7
select Faculties.Name
from Faculties
where (
    select SUM(Departments.Financing)
    from Departments
    where Departments.FacultyId = Faculties.Id
) > (
    select SUM(Departments.Financing)
    from Departments
    join Faculties on Faculties.Id = Departments.FacultyId
    where Faculties.Name = 'Computer Science'
);

--8
select Subjects.Name,  CONCAT(Teachers.Name, ' ', Teachers.Surname) from Lectures
join Subjects on Lectures.SubjectId = Subjects.Id
join Teachers on Lectures.TeachersId = Teachers.Id
group by Subjects.Name, Teachers.Name, Teachers.Surname
having COUNT(*) = (
    select MAX(LecturesCount)
    from (
        select COUNT(*) AS LecturesCount
        from Lectures
        group by SubjectId, TeachersId
    ) as Counts
)

--9
select top 1 s.Name as SubjectName, COUNT(*) as LectureCount
from Lectures l
join Subjects s on l.SubjectId = s.Id
group by s.Name
order by LectureCount;

--10
select COUNT(distinct Students.Id) as NumStudents, COUNT(distinct Subjects.Id) as NumSubjects
from Students
join GroupsStudents on Students.Id = GroupsStudents.StudentId
join Groups on GroupsStudents.GroupId = Groups.Id
join Departments on Groups.DepartmentId = Departments.Id
join Subjects on Departments.Id = Subjects.Id
where Departments.Name = 'Software Development';
