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
IF OBJECT_ID('Packages') IS NOT NULL
	DROP TABLE Packages
GO
IF OBJECT_ID('PackageCategories') IS NOT NULL
	DROP TABLE PackageCategories
GO
IF OBJECT_ID('PackageDetails') IS NOT NULL
	DROP TABLE PackageDetails
GO

Create table PackageCategories(
	CategoryId varchar(5) primary key,
	CategoryName varchar(20) not null unique,
    check(SUBSTRING(CategoryId, 1, 2) = 'PC')
	)

Create table Packages(
	PackageId varchar(5) primary key,
	PackageName varchar(30) not null,
	CategoryId varchar(5) references PackageCategories(CategoryId),
    check(SUBSTRING(PackageId, 1, 1) = 'P')
	)

Create table PackageDetails(
	PackageDetailsId varchar(5) primary key,
	PackageId varchar(5) references Packages(PackageId),
	PlacesToVisit varchar(30) not null,
	PackageDescription varchar(255) not null,
	DaysAndNight varchar(5) not null,
	Price int not null,
	Accommodation char(1) not null,
    check(SUBSTRING(PackageDetailsId, 1, 2) = 'PD'),
	check(Price>0)
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


