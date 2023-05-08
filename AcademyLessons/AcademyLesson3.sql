use [AcademyDB]

create table Assistant
(
  [Id] int identity(1,1) not null primary key ,
  [TeacherId] int not null foreign key references Teachers([Id])
);

create table Curators
(
  [Id] int identity(1,1) not null primary key ,
  [TeacherId] int not null  foreign key references Teachers([Id])
);

create table Deans
(
  [Id] int identity(1,1) not null primary key ,
  [TeacherId] int not null foreign key references Teachers([Id])
);

create table Departments
(
  [Id] int identity(1,1) not null primary key ,
  [Building] int not null check (Building >= 1 and Building <= 5),
  [Name] nvarchar(100) not null check (Name <> '') unique ,
  [FacultyId] int not null foreign key references Faculties([Id]),
  [HeadId] int not null foreign key references Heads([Id]),
);

create table Faculties
(
  [Id] int identity(1,1) not null primary key ,
  [Building] int not null check (Building >= 1 and Building <= 5),
  [Name] nvarchar(100) not null check (Name <> '') unique ,
  [DeanId] int not null foreign key references Deans([Id])
);

create table Groups
(
  [Id] int identity(1,1) not null primary key ,
  [Name] nvarchar(10) not null check (Name <> '') unique ,
  [Year] int not null check (Year >= 1 and Year <= 5) ,
  [DepartmentId] int not null foreign key references Departments([Id])
);

create table GroupsCurators
(
    [Id] int identity(1,1) not null primary key ,
    [CuratorId] int not null foreign key references Curators([Id]) ,
    [GroupId] int not null foreign key references Groups([Id])
);

create table GroupsLectures
(
  [Id] int identity(1,1) not null primary key ,
  [GroupId] int not null foreign key references Groups([Id]) ,
  [LectureId] int not null foreign key references Lectures([Id])
);

create table Heads
(
  [Id] int identity(1,1) not null primary key ,
  [TeacherId] int not null foreign key references Teachers([Id])
);

create table LectureRooms
(
  [Id] int identity(1,1) not null primary key ,
  [Building] int not null check (Building >= 1 and Building <= 5) ,
  [Name] nvarchar(10) not null check (Name <> '') unique ,
);

create table Lectures
(
  [Id] int identity(1,1) not null primary key ,
  [SubjectId] int not null foreign key references Subjects([Id]) ,
  [TeacherId] int not null foreign key references Teachers([Id])
);

create table Schedules
(
  [Id] int identity(1,1) not null primary key ,
  [Class] int not null check (Class >= 1 and Class <= 8) ,
  [DayOfWeek] int not null check (DayOfWeek >= 1 and DayOfWeek <= 7) ,
  [Week] int not null check (Week >= 1 and Week <= 52) ,
  [LectureId] int not null foreign key references Lectures([Id]) ,
  [LectureRoomsId] int not null foreign key references LectureRooms([Id])
);

create table Subjects
(
  [Id] int identity(1,1) not null primary key ,
  [Name] nvarchar(100) not null check (Name <> '') unique
);

create table Teachers
(
  [Id] int identity(1,1) not null primary key ,
  [Name] nvarchar(max) not null check (Name <> '') ,
  [Surname] nvarchar(max) not null check (Name <> '')
);

--1
select LectureRooms.Name as LectureRoomName
from Lectures
inner join Teachers on Lectures.TeacherId = Teachers.Id
inner join Schedules on Lectures.Id = Schedules.LectureId
inner join LectureRooms on Schedules.LectureRoomsId = LectureRooms.Id
where Teachers.Name = 'Edward' and Teachers.Surname = 'Hopper';

--2
select Teachers.Surname as AssistantName
from Teachers
inner join Heads on Teachers.Id = Heads.TeacherId
inner join Departments on Heads.Id = Departments.HeadId
inner join Groups on Departments.Id = Groups.DepartmentId
inner join Assistant on Assistant.TeacherId
where Groups.Name = 'F505';

--3
select * from Lectures
inner join Subjects on Lectures.Id = Subjects.Id
inner join GroupsLectures on Lectures.Id = GroupsLectures.LectureId
inner join Groups on GroupsLectures.GroupId = Groups.Id
inner join Teachers on Lectures.TeacherId = Teachers.Id
where Groups.Year = 5 and Teachers.Name = 'Alex' and Teachers.Surname = 'Carmack';

--4
select Surname
from Teachers
where not exists
(
    select *
    from Lectures
    inner join Schedules on Lectures.Id = Schedules.LectureId
    where Lectures.TeacherId = Teachers.Id and Schedules.DayOfWeek = 1
);

--5
select Name, Building from LectureRooms
where not exists
(
  select *
  from Lectures
  inner join Schedules on Lectures.Id = Schedules.LectureId
  where Schedules.DayOfWeek = 3 and Schedules.Week = 2 and Schedules.Class = 3
);

--6
select Teachers.Name, Teachers.Surname from Teachers
inner join Deans on Teachers.Id = Deans.TeacherId
inner join Faculties on Deans.Id = Faculties.DeanId
where Faculties.Name = 'Computer Science' and not exists
(
  select * from Teachers
  inner join Heads on Teachers.Id = Heads.TeacherId
  inner join Departments on Heads.Id = Departments.HeadId
  where Departments.Name = 'Software Development'
);

--7
select distinct Building
from (
    select Building from Faculties
    union
    select Building from Departments
    union
    select Building from LectureRooms
) as buildings;

--8
select Name, Surname
from
(
    select Teachers.Name, Teachers.Surname, 'DeanCase' as position
    from Faculties
    inner join Deans on Faculties.DeanId = Deans.Id
    inner join Teachers on Deans.TeacherId = Teachers.Id

    union

    select Teachers.Name, Teachers.Surname, 'Heads' as position
    from Departments
    inner join Heads on Departments.HeadId = Heads.Id
    inner join Teachers on Heads.TeacherId = Teachers.Id

    union

    select Teachers.Name, Teachers.Surname, 'Teachers' as position
    from Lectures
    inner join Teachers on Lectures.TeacherId = Teachers.Id

    union

    select Teachers.Name, Teachers.Surname, 'Curators' as position
    from Curators
    inner join Teachers on Curators.TeacherId = Teachers.Id

    union

    select Teachers.Name, Teachers.Surname, 'Assistants' as position
    from Teachers
    inner join Assistant on Teachers.Id = Assistant.TeacherId
) as all_teachers
order by
    case position
      when 'Deans' then 1
      when 'Head' then 2
      when 'Teachers' then 3
      when 'Curator' then 4
      when 'Assistant' then 5
    end;

--9
select distinct DayOfWeek from Schedules
inner join LectureRooms on Schedules.LectureRoomsId = LectureRooms.Id
where LectureRooms.Name = 'A311' and LectureRooms.Name = 'A104' and LectureRooms.Building = 6;
