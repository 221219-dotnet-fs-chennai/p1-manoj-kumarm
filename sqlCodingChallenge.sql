CREATE SCHEMA manoj
GO

CREATE TABLE manoj.Employee
(
    [ID] int PRIMARY KEY,
    [FirstName] VARCHAR(25),
    [LastName] VARCHAR(25),
    [SSN] int,
    [DeptID] int
);
GO


CREATE TABLE manoj.Department
(
    [ID] INT NOT NULL primary key,
    [Name] VARCHAR(25),
    [Location] VARCHAR(25)
);
GO

CREATE TABLE manoj.EmpDetails
(
    [ID] INT NOT NULL identity(1,1),
    [EmployeeID] INT unique foreign key references manoj.Employee(ID),
    [Salary] MONEY,
    [Address1] VARCHAR(50),
    [Address2] VARCHAR(50),
    [City] VARCHAR(25),
    [State] VARCHAR(25),
    [Country] VARCHAR(25)
);
GO

alter table manoj.Employee 
add constraint tblEmployee_DepartmentId_FK
foreign key ([DeptID]) references manoj.Department([ID]);


insert into manoj.Department([ID], [Name], [Location]) 
values (1, 'Marketing', 'Mumbai'), (2, 'IT', 'Kerala'), (3, 'HR', 'Bangalore');

insert into manoj.Employee([ID], [FirstName], [LastName], [SSN], [DeptID]) 
values (1, 'Sara', 'Smith', 123, 1), (2, 'Mike', 'William', 789, 2), (3, 'Tim', 'Jane', 456, 3);

insert into manoj.EmpDetails([EmployeeID],[Salary], [Address1], [Address2], [City], [State], [Country])
values (1, 10000, 'no 14 lake street', 'avenue road', 'Mumbai north', 'Mumbai', 'India'),
		(2, 5000, 'no 16 lake street', 'armstring road ', 'Kerala east', 'Kerala', 'India'),
		(3, 15000, 'no 18 lake street', 'commercial road', 'Bangalore North', 'Bangalore', 'India');

select * from manoj.Employee
select * from manoj.Department
select * from manoj.EmpDetails

-- all emp in marketing dept
SELECT [FirstName], [LastName]
FROM manoj.Employee
WHERE [DeptID] =
(SELECT ID 
FROM manoj.Department 
WHERE [Name] = 'Marketing');

-- total salary in marketing dept
SELECT SUM ([Salary])
FROM manoj.EmpDetails
WHERE [EmployeeID] = 
(SELECT ID 
FROM manoj.Department 
WHERE [Name] = 'Marketing');

--report total emp by department
select manoj.Department.Name, COUNT(Employee.DeptID) AS count
from manoj.Department
inner join manoj.Employee
on manoj.Employee.DeptID = manoj.Department.ID

update manoj.Employee set [FirstName] = 'Tina' where [FirstName] = 'Sara';

--increase tina salary to 90,000
update manoj.EmpDetails set Salary = 90000 where EmployeeID = 1;













