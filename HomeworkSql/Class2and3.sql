Use Homewok

--Class 2
 
 --Homework 1
 select * from Student where FirstName='Antonio'
 select * from Student where DateOfBirth >'1999-01-01'
 select * from Student where Gender ='M'
 select * from Student where LastName like 'T%'
 select * from Student where EnrolledDate > '1998-01-01' and EnrolledDate< '1998-02-01'
 select * from Student where LastName like 'J%' and EnrolledDate > '1998-01-01' and EnrolledDate< '1998-02-01' 

  --Homework 2
 select * from Student where FirstName ='Antonio' order by LastName 
 select * from Student order by FirstName
 select * from Student where Gender='M' order by EnrolledDate desc

  --Homework 3
 select FirstName from Teacher union all select FirstName from Student 
 select LastName from Teacher union select FirstName from Student
 select FirstName from Teacher intersect select FirstName from Student

  --Homework 4  alter table GradeDetails add constraint Pk_GradeDetails_AchievementMaxPoints default 100 for AchievementMaxPoints
 alter table GradeDetails with check add constraint CHK_GradeDetails_AchievementPoints check (AchievementPoints>AchievementMaxPoints)
 alter table GradeDetails with check add constraint GradeDetails_UC_AchievementType unique (AchievementType)

 --Homework 5
 alter table GradeDetails add constraint Fk_GradeDetails_AchievementTypeId foreign key (Id) references AchievementType(Id)
 alter table Grade add constraint Fk_Grade_CourseId foreign key (Id) references Course(Id)
 alter table Grade add constraint Fk_Grade_StudentId foreign key (Id) references Student(Id)
 alter table Grade add constraint Fk_Grade_TeachersId foreign key (Id) references Teacher(Id)

 --Homework 6
 select c.Name as CourseName,a.Name as AchievementName from AchievementType c cross join Course a
 select t.FirstName as TeacherName from  Teacher t  inner join  Grade g on t.Id=g.TeacherId
 select t.FirstName as TeacherName from Teacher t left join Grade g on t.id=g.TeacherId where g.TeacherId is null
 select t.FirstName as TeacherName from Grade g right join Teacher t on g.TeacherId=t.Id where g.TeacherId is null

 --Class 3

 --Homework 1
 select Sum(Grade) as AllGrades from Grade
 select TeacherId,Sum(Grade) as AllGrades from Grade group by TeacherId
 select TeacherId,Sum(Grade) as AllGrades from Grade where StudentId<100 group by TeacherId 
 select StudentId,Max(Grade) as MaxGrade,avg(Grade) as AverageGrade from Grade group by StudentId

 --Homework 2
 select TeacherId,Sum(Grade) as AllGrades from Grade group by TeacherId having Sum(Grade) > 200
 select TeacherId,Sum(Grade) as AllGrades from Grade where StudentId<100 group by TeacherId having Sum(Grade) > 50
 select StudentId,Count(Grade) as CountGrade, Max(Grade) as MaxGrade,avg(Grade) as AverageGrade from Grade group by StudentId having Max(Grade)=Avg(Grade)
 select StudentId,s.FirstName as FirstName,s.LastName as LastName,Count(Grade) as CountGrade, Max(Grade) as MaxGrade,avg(Grade) as AverageGrade   from Grade g
 inner join Student s on s.Id=g.StudentId
  group by StudentId,s.FirstName,s.LastName having Max(Grade)=Avg(Grade)