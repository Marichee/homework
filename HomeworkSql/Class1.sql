
drop table if exists Student;
drop table if exists Teacher;
drop table if exists Grade;
drop table if exists Course;
drop table if exists AchievementType;
drop table if exists GradeDetails;
Create table Student(
Id int identity not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
DateOfBirth date null,
EnrolledDate date null,
Gender nchar(1) not null,
NationalIdNumber nvarchar(20) null,
StudentCardNumber nvarchar(20) not null,
Constraint Pk_Student primary key clustered
(
Id asc
))

Create table Teacher(
Id int identity not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
DateOfBirth date not null,
AcademicRank nvarchar(50) not null,
HireDate date not null,
constraint Pk_Teacher primary key clustered
(
Id asc
))

Create table Grade(
Id int identity not null,
CourseId int  null,
StudentId int not null,
TeacherId int not null,
Grade  smallint not null,
Comment nvarchar(max) null,
CreatedDate datetime not null,
constraint Pk_Grade primary key clustered
(
Id asc
))

Create table Course(
Id int identity(0,1) not null,
Name nvarchar(50) not null,
Credit int not null,
AcademicYear smallint not null,
Semester smallint not null,
constraint Pk_Course primary key clustered
(
Id asc
))

Create table AchievementType(
 Id int identity(0,1) not null,
 Name nvarchar(50) not null,
 Description nvarchar(max) null,
 ParticipationRate smallint not null,
 constraint Pk_AchievementType primary key clustered
 (
 Id asc
 ))

 Create table GradeDetails(
 Id int identity not null,
 GradeId int not null,
 AchievementTypeId int not null,
 AchievementPoints smallint  null,
 AchievementMaxPoints smallint not null,
 AchievementDate datetime not null,
 constraint Pk_GradeDetails primary key clustered
 (
 Id asc
 ))