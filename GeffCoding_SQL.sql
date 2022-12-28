-- CREATE SCHEMA geffcoding

-- Creating tables
CREATE table geffcoding.Department(
    id int not NULL IDENTITY(1,1),
    name VARCHAR(20),
    location VARCHAR(20),
    CONSTRAINT [PK_Dept] PRIMARY KEY(id)

)

create table geffcoding.Employee(
    id int not NULL IDENTITY(1,1),
    firstname VARCHAR(25),
    lastname VARCHAR(25),
    ssn VARCHAR(9),
    deptId INT,
    CONSTRAINT [FK_Employee] FOREIGN KEY([deptId]) REFERENCES geffcoding.Department(id),
    CONSTRAINT [PK_Employee] PRIMARY KEY(id)


)


CREATE TABLE geffcoding.EmpDetails(
    id int not NULL IDENTITY(1,1),
    employeeId INT,
    salary bigint,
    address1 VARCHAR(25),
    address2 VARCHAR(25),
    city VARCHAR(20),
    state VARCHAR(20),
    country VARCHAR(20),
    CONSTRAINT [FK_EmpDetails] FOREIGN KEY([employeeId]) REFERENCES geffcoding.Employee(id),
    CONSTRAINT [PK_EmpDetails] PRIMARY KEY(id)

    
);

-- Inserting Values

-- Adding department marketing
insert into geffcoding.Department VALUES('Marketing','Chennai')


-- Adding employee Tina Smith
insert into geffcoding.Employee VALUES('Tina','Smith','323456781',1)


-- Selecting all the values from every table
select * FROM geffcoding.Department
SELECT * from geffcoding.Employee
SELECT * from geffcoding.EmpDetails



update geffcoding.Employee set ssn='123456783' WHERE id=3


insert into geffcoding.EmpDetails VALUES(5,'10000','no.47','1st cross street','Alberquque','New Mexico','America')

SELECT * from geffcoding.Employee
SELECT firstname as Marketing from geffcoding.Employee  WHERE deptId=1

-- List all employees in marketing
SELECT * from geffcoding.Employee INNER JOIN geffcoding.Department ON geffcoding.Employee.deptId = geffcoding.Department.id AND deptId=1;





alter table geffcoding.EmpDetails
   alter column salary bigint 

alter table geffcoding.EmpDetails
    drop COLUMN salary

alter table geffcoding.EmpDetails
   add salary bigint

update geffcoding.EmpDetails set salary=70000 WHERE id=4



-- Report total salary of Marketing
SELECT SUM(salary) as totalsalary_Marketing from geffcoding.EmpDetails inner join geffcoding.Employee ON geffcoding.Employee.id=geffcoding.EmpDetails.employeeId AND deptId=1



-- Report total employees by Department
SELECT * from geffcoding.Employee INNER JOIN geffcoding.Department ON geffcoding.Employee.deptId = geffcoding.Department.id

--Increase salary of Tina Smith to $90000
update geffcoding.EmpDetails set salary=90000 WHERE id=4
SELECT * from geffcoding.EmpDetails


