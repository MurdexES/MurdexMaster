use [AcademyDB]
--  Procedures
--1
create procedure GetBuildingsWithFunding
as
begin
    select Building
    from Departments
    group by Building
    having SUM(Financing) > 100000
end

exec GetBuildingsWithFunding

--2
create procedure GetDepartmentNamesYear
as
begin
    select Groups.Name
    from Groups
    inner join Departments on Groups.DepartmentId = Departments.Id
    where Groups.Year = 5 and Departments.Name = 'Software Development'
end

exec GetDepartmentNamesYear

--3
create procedure GetProfessorAboveAvgSalary
as
begin
    select Name, Surname
    from Teachers
    where Salary > (select AVG(Salary) from Teachers where IsProfessor = 1)
end

exec GetProfessorAboveAvgSalary

--4
create procedure GetGroupsWithCurators
as
begin
  select Name
  from Groups
  inner join GroupsCurators on Groups.Id = GroupsCurators.GroupId
  group by Name
  having COUNT(GroupsCurators.CuratorId) > 1;
end

exec GetGroupsWithCurators

--5
create procedure GetSubjectWithMostLectures
as
begin
    select top 1 s.Name as SubjectName, COUNT(*) as LectureCount
    from Lectures l
    join Subjects s on l.SubjectId = s.Id
    group by s.Name
    order by LectureCount;
END

exec GetSubjectWithMostLectures

--  Functions
--1
create function GetGroupsWithHigherAvgRating(@groupName nvarchar(10))
returns table
as
return (
    select Groups.Name
    from Groups
    inner join (
        select GroupsStudents.GroupId, AVG(Students.Rating) as AvgRating
        from GroupsStudents
        inner join Students on GroupsStudents.StudentId = Students.Id
        group by GroupsStudents.GroupId
    ) GS on Groups.Id = GS.GroupId
    where GS.AvgRating > (
        select AVG(Students.Rating)
        from GroupsStudents
        inner join Students on GroupsStudents.StudentId = Students.Id
        inner join Groups on GroupsStudents.GroupId = Groups.Id
        where Groups.Name = @groupName
    )
);

select * from GetGroupsWithHigherAvgRating('D221');

--2
create function GetGroupsForYear()
returns table
as
return (
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
);

select * from GetGroupsForYear();

--3
create function GetFacultiesWithMoreFunding()
returns table (Name nvarchar(50))
as
return(
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
        where Faculties.Name = 'Computer Science')
);

select * from GetFacultiesWithMoreFunding();

--4
create function GetTeachersPerSubject()
returns table
as
return(
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
);

select * from GetTeachersPerSubject();

--5
create function GetStudentAndSubjectCounts()
returns table (NumStudents int, NumSubjects int)
as
return (
    select COUNT(distinct Students.Id) as NumStudents, COUNT(distinct Subjects.Id) as NumSubjects
    from Students
    join GroupsStudents on Students.Id = GroupsStudents.StudentId
    join Groups on GroupsStudents.GroupId = Groups.Id
    join Departments on Groups.DepartmentId = Departments.Id
    join Subjects on Departments.Id = Subjects.Id
    where Departments.Name = 'Software Development'
);

select * from GetStudentAndSubjectCounts();
