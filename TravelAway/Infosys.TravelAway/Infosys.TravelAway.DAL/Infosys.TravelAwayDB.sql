--DROP Scripts

USE [master]
GO
IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = N'TravelAwayDB'OR name = N'TravelAwayDB')))
DROP DATABASE TravelAwayDB

CREATE DATABASE TravelAwayDB
GO

USE TravelAwayDB
GO


IF OBJECT_ID('Customers') IS NOT NULL
	DROP TABLE Customers
GO
IF OBJECT_ID('PackageCategories') IS NOT NULL
	DROP TABLE PackageCategories
GO

Create table PackageCategories(
	CategoryId varchar(5) primary key,
	CategoryName varchar(20) not null unique,
    check(SUBSTRING(CategoryId, 1, 2) != 'PC')
	)

Create table Customers(
	CustomerID varchar(5) primary key,
	FirstName varchar(30) not null,
	LastName varchar(30) not null,
	EmailId VARCHAR(50) CONSTRAINT [chk_EmailId] CHECK ([EmailId] LIKE '%_@__%.__%') NOT NULL,
	Password varchar(16) not null,
	ConfirmPassword varchar(16) not null,
	Gender char(1) not null,
    ContactNumber varchar(10) not null,
    DateOfBirth date not null,
    Address varchar(250) not null,
	PackageId varchar(5), 
    check (Gender In('M', 'F')),
    check(SUBSTRING(ContactNumber, 1, 1) != '0'),
    check(SUBSTRING(PackageId, 1, 1) = 'P'),
    check(DateOfBirth < GETDATE())

   )


