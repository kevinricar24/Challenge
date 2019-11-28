CREATE DATABASE [Challenge]
GO
PRINT 'Challenge DATABASE CREATED'		

USE [Challenge]
GO
PRINT 'Challenge DATABASE USED'

BEGIN

CREATE TABLE Employee(
	Id   INT IDENTITY(1, 1) NOT NULL, 
	FirstName NVARCHAR(50) NULL,
	LastName NVARCHAR(50) NULL,
	PRIMARY KEY (Id) 
	)
PRINT 'Employee TABLE CREATED'

CREATE TABLE TimeSheet(
	Id   INT IDENTITY(1, 1) NOT NULL,
	EmployeeId INT NOT NULL,
	DateWorked DATETIME NULL,
	HoursWorked INT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (EmployeeId) REFERENCES Employee(Id) ON DELETE CASCADE
	)
PRINT 'TimeSheet TABLE CREATED'

insert into Employee (FirstName, LastName) values ('Kevin','Sejin')
insert into Employee (FirstName, LastName) values ('Dario','Ricardo')

END