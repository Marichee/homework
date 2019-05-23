use homewok
--view
go
create view vv_StudendGrades 
as
select StudentId as StudentId,count(Grade) as CountGrades
from Grade g
group by StudentId
go
alter view vv_StudendGrades 
as
select s.FirstName as FirstName,s.LastName as LastName,count(Grade) as CountGrades
from Grade g 
inner join Student s on g.StudentId=s.Id
group by FirstName,LastName
go
select * from vv_StudendGrades order by CountGrades desc

--second view
go
create view vv_StudentGradeDetails
as
select s.FirstName as FirstName,s.LastName as LastName,count(g.CourseId) as CountCourse
from Student s
inner join Grade g on s.Id=g.StudentId
group by FirstName,LastName
go
alter view vv_StudentGradeDetails 
as
select s.FirstName as FirstName,s.LastName as LastName,count(g.CourseId) as CountCourse
from Student s
inner join Grade g on s.Id=g.StudentId
where g.Grade>5
group by FirstName,LastName
go
select * from vv_StudentGradeDetails 

--Homework 1 
declare @FirstName nvarchar(100) set @FirstName = 'Antonio'
select * from Student where FirstName=@FirstName

declare @FemaleStudent table(StudentId int,StudentName nvarchar(50),DateOfBirth date)
insert into @FemaleStudent select Id,FirstName,DateOfBirth from Student where Gender='f'
select * from @FemaleStudent

create table #StudentList (LastName nvarchar(100),EnrolledDate date)
insert into #StudentList select LastName,EnrolledDate from Student where Gender='M' and Firstname like 'A%'
select * from #StudentList where len(LastName)=7

select * from Teacher where len(FirstName)<5 and right(FirstName,3)=right(LastName,3)

--Homework 2
go
create function dbo.fn_FormatStudentName (@StudentId int)
returns nvarchar(100)
as 
begin
declare @result nvarchar(100)
select @result=substring(StudentCardNumber,4,5)+'-'+Left(FirstName,1)+'.'+LastName
from Student where @StudentId=Id
return @result
end
go
select * ,dbo.fn_FormatStudentName(Id) from student

--Homework 3
go
create function dbo.fn_PassedExam (@CourseId int,@TeachersId int)
returns @result table(StudentFirstName nvarchar(100),StudentLastName nvarchar(100),Grade smallint,CreatedDate datetime)
as
begin
insert into @result
select s.FirstName as StudentFirstName,s.LastName as StudentLastName,g.Grade as Grade,g.CreatedDate as CreatedDate
from  Grade g
inner join Student s on g.StudentId=s.Id
inner join Teacher t on g.TeacherId=t.Id
inner join Course c on g.CourseId=c.Id
where  c.Id=@CourseId and t.Id=@TeachersId
group by s.FirstName,s.LastName,g.Grade,g.CreatedDate
return
end
go

declare @CourseId int=1
declare @TeachersId int=1
select * from dbo.fn_PassedExam(@CourseId,@TeachersId) order by CreatedDate
