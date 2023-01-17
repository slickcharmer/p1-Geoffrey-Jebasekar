-- create schema project0;
create table project0.TrainerSignup(
userid int NOT NULL,
firstname varchar(15) not null,
lastname VARCHAR(15) not null,
emailId VARCHAR(25) not NULL,
[password] VARCHAR(15) not NULL,
phoneno BIGINT not null,
age TINYINT not NULL,
city VARCHAR(15) not null,
constraint [PK_Signup] PRIMARY KEY(userid) 

);
-- drop table project0.TrainerSignup;
create table project0.[Login]
(
    [UserLoginId] int not null,
    emaild VARCHAR(25) not null,
    [password] VARCHAR(25) not null,
    CONSTRAINT [FK_Login]FOREIGN KEY( UserLoginid ) REFERENCES project0.TrainerSignup(userid) on DELETE CASCADE on UPDATE CASCADE



);

CREATE TABLE project0.Education
(
    trainerid int not null,
    educationType VARCHAR(20) not null,
    instituteName VARCHAR(50) not null,
    stream VARCHAR(20) not NULL,
    startYear VARCHAR(4) not null,
    endYear VARCHAR(4) not null,
    [percentage] VARCHAR(4) not NULL,
    CONSTRAINT [FK_Education] FOREIGN KEY(trainerid) REFERENCES project0.TrainerSignup(userid) on DELETE CASCADE on UPDATE CASCADE

);

create table project0.Companies
(
    trainerid int not NULL,
    companyName VARCHAR(25) not null,
    Title VARCHAR(10) not null,
    industry VARCHAR(20) not null,
    employementType VARCHAR(15) not NULL,
    [location] VARCHAR(20) not null,
    startYear VARCHAR(4) not null,
    endYear VARCHAR(4) not NULL
    CONSTRAINT [FK_Companies] FOREIGN KEY(trainerid) REFERENCES project0.TrainerSignup(userid) on delete CASCADE on UPDATE CASCADE

);

CREATE table project0.Skills
(
    trainerid int not NULL,
    skill VARCHAR(15) not null,
    Profeciency int not NULL CHECK(Profeciency>=1 & Profeciency<=5),
    CONSTRAINT [FK_Skills] FOREIGN key(trainerid) REFERENCES project0.TrainerSignup(userid) on DELETE cascade on UPDATE CASCADE



);