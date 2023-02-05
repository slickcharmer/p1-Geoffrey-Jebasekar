create database TutorApp
create table Signup(

firstname varchar(15) not null,
lastname VARCHAR(15) not null,
emailId VARCHAR(25) not NULL,
[password] VARCHAR(15) not NULL,
phoneno VARCHAR(10) not null,
age int not NULL,
city VARCHAR(15) not null,
constraint [PK_Signup] PRIMARY KEY(emailId) 

);

create table [Login]
(

    emailid VARCHAR(25) not null,
    [password] VARCHAR(25) not null,
	CONSTRAINT [PK_LOGIN] PRIMARY KEY(emailid), 
    CONSTRAINT [FK_Login]FOREIGN KEY( emailid ) REFERENCES Signup(emailId) on DELETE CASCADE on UPDATE CASCADE



);

CREATE TABLE Education
(

    id int IDENTITY(1,1),
    emailid VARCHAR(25) not NULL,
    educationType VARCHAR(20) not null,
    instituteName VARCHAR(50) not null,
    stream VARCHAR(20) not NULL,
    startYear VARCHAR(4) not null,
    endYear VARCHAR(4) not null,
    [percentage] VARCHAR(4) not NULL,
	CONSTRAINT[PK_EDUCATION] PRIMARY KEY(id),
    CONSTRAINT [FK_Education] FOREIGN KEY(emailid) REFERENCES Signup(emailId) on DELETE CASCADE on UPDATE CASCADE

);

create table Companies
(
    id int IDENTITY(1,1),
    emailid VARCHAR(25) not NULL,
    companyName VARCHAR(25) not null,
    title VARCHAR(50) not null,
    [location] VARCHAR(20) not null,
    -- startYear VARCHAR(4) not null,
    -- endYear VARCHAR(4) not NULL,
	experience int not null,
	CONSTRAINT[PK_COMPANIES] PRIMARY KEY(id),
    CONSTRAINT [FK_Companies] FOREIGN KEY(emailid) REFERENCES Signup(emailid) on delete CASCADE on UPDATE CASCADE

);

CREATE table Skills
(
    id int IDENTITY(1,1),
    emailid VARCHAR(25) not NULL,
    skill VARCHAR(15) not null,
    profeciency int not NULL ,
	CONSTRAINT [PK_SKILLS] PRIMARY KEY(id),
    CONSTRAINT [FK_Skills] FOREIGN key(emailid) REFERENCES Signup(emailId) on DELETE cascade on UPDATE CASCADE



);

alter table Signup alter COLUMN age int not null
alter TABLE Signup alter COLUMN phoneno VARCHAR(10) not null


SELECT Signup.firstname,Signup.lastname,Signup.emailId,Signup.age,Education.educationType,Education.instituteName,Education.stream,Education.percentage,
Companies.companyName,Companies.Title,Companies.location,Skills.skill,Skills.Profeciency From Signup 
JOIN Education on Signup.emailId = Education.emailid join Companies on Education.emailId = Companies.emailid JOIN Skills 
on Companies.emailId = Skills.emailid WHERE Signup.emailId = 'geffshelby@gmail.com'

SELECT firstname,lastname,phoneno,age,city from Signup where emailid = 'geffshelby@gmail.com'

update Skills set skill='{skills.skill}',Profeciency='{skills.profeciencyInSkill}' where emailid='{emailid}' and skill='{skill}'


select * from Signup
SELECT * from Login
select * from Education
select * from Companies
select * from Skills
ALTER TABLE LOGIN add CONSTRAINT Unique_Email UNIQUE(emailid)

SELECT @@SERVERNAME AS 'Server Name'

insert into Signup values ('Geff','Shelby','geffshelby@gmail.com','12345678','9876505432',21,'Chennai');
insert into Login values('geffshelby@gmail.com','12345678');
insert into Education values('geffshelby@gmail.com','UG','Loyola','IT','2023','2025','80');
insert into Companies values('geffshelby@gmail.com','Amazon','Developer','Bangalore','3');
insert into Skills values('geffshelby@gmail.com','C++',5);

delete from Education where emailid = 'geffshelby@gmail.com' and instituteName = 'Loyola' and id=6

alter table Education 
alter column percentage varchar(10) not null

-- string query_1 = $"update Companies set companyName='{experience.companyName}',Title='{experience.title}',industry='{experience.industry}',employementType='{experience.employementType}',location='{experience.location}',startYear='{experience.startYear}',endYear='{experience.endYear}' where emailid='{emailid}' and companyName='{companyName}' ";