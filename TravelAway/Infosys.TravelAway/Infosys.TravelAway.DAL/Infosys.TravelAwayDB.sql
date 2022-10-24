--DROP Scripts if database exists

USE [master]
GO
IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = N'TravelAwayDB'OR name = N'TravelAwayDB')))
DROP DATABASE TravelAwayDB


--Create database and USE it
CREATE DATABASE TravelAwayDB
GO

USE TravelAwayDB
GO

--If table exists, then remove them
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

--Scripts to Create Tables
Create table PackageCategories(
	CategoryId int primary key,
	CategoryName varchar(20) not null unique
	)

Create table Packages(
	PackageId int primary key,
	PackageName varchar(60) not null,
	PackageDesc varchar(255) not null,
	TypeOfPackage VARCHAR(15) CONSTRAINT chk_TypeOfPackage CHECK(TypeOfPackage IN ('International','Domestic')),
	CategoryId int references PackageCategories(CategoryId)
	)

Create table PackageDetails(
	PackageDetailsId int primary key,
	PackageId int references Packages(PackageId),
	PlacesToVisit varchar(50) not null,
	PackageDescription varchar(255) not null,
	DaysAndNight varchar(5) not null,
	Price int not null,
	Accommodation char(1) not null,
	check(Price>0)
)


Create table Customers(
	CustomerID int primary key,
	FirstName varchar(30) not null,
	LastName varchar(30) not null,
	EmailId VARCHAR(50) CONSTRAINT [chk_EmailId] CHECK ([EmailId] LIKE '%_@__%.__%') NOT NULL,
	Password varchar(16) not null,
	Gender char(1) not null,
    ContactNumber varchar(10) not null,
    DateOfBirth date not null,
    Address varchar(250) not null,
	PackageId int references Packages(PackageId), 
    check (Gender In('M', 'F')),
    check(SUBSTRING(ContactNumber, 1, 1) != '0'),
    check(DateOfBirth < GETDATE())
   )

--Checks if sequences of each table are present or not, if present then drop them
IF OBJECT_ID('CustomerSequence') IS NOT NULL
	DROP SEQUENCE CustomerSequence
GO
IF OBJECT_ID('PackageDetailsSequence') IS NOT NULL
	DROP SEQUENCE PackageDetailsSequence
GO
IF OBJECT_ID('PackageSequence') IS NOT NULL
	DROP SEQUENCE PackageSequence
GO
IF OBJECT_ID('PackageCategoriesSequence') IS NOT NULL
	DROP SEQUENCE PackageCategoriesSequence
GO

--Create sequence of each table
Create SEQUENCE CustomerSequence
start with 1000
increment by 1;

Create SEQUENCE PackageDetailsSequence
start with 1000
increment by 1;

Create SEQUENCE PackageSequence
start with 1000
increment by 1;

Create SEQUENCE PackageCategoriesSequence
start with 1000
increment by 1;


--Inserts HardCoded Values for PackageCategories using PackageCategoriesSequence
INSERT INTO [dbo].[PackageCategories] VALUES(
	NEXT VALUE FOR PackageCategoriesSequence,
	'Adventure'
),(
	NEXT VALUE FOR PackageCategoriesSequence,
	'Nature'
),(
	NEXT VALUE FOR PackageCategoriesSequence,
	'Religious'
),(
	NEXT VALUE FOR PackageCategoriesSequence,
	'Village'
),(
	NEXT VALUE FOR PackageCategoriesSequence,
	'Wildlife'
)

INSERT INTO [dbo].[Packages] VALUES(
	NEXT VALUE FOR PackageSequence,
	'Andaman & Nicobar',
	'A set of Island, known for its natural wildlife. Excellent place for water adventures',
	'Domestic',
	1001
),(
	NEXT VALUE FOR PackageSequence,
	'North-East India',
	'Known as the chicken head of India. A variety of natural life and the local environment make it an awesome place',
	'Domestic',
	1004
),(
	NEXT VALUE FOR PackageSequence,
	'Europe',
	'The fun of all life happens here. From streets to the monuments every thing happens here and its fun loving',
	'International',
	1000
),(
	NEXT VALUE FOR PackageSequence,
	'America',
	'The place that never sleeps',
	'International',
	1000
),(
	NEXT VALUE FOR PackageSequence,
	'New Zealand',
	'The most adventurous place in the world. Very sparsely populated country that makes awesome oppurtunities for adventure',
	'International',
	1000
),(
	NEXT VALUE FOR PackageSequence,
	'Africa',
	'Take a deep dive to the earthly forests of Africa and explore the greens',
	'International',
	1004
),(
	NEXT VALUE FOR PackageSequence,
	'Nagaland',
	'Nagaland is famous for its spiritual holiness and calm environment. The street food are a must to try on.',
	'Domestic',
	1002
),(
	NEXT VALUE FOR PackageSequence,
	'Buffalo Springs, Texas',
	'Buffalo Springs is a village in Lubbock County, Texas, United States which is famous for its cultural heritage and pride',
	'International',
	1003
)


--select * from [dbo].[PackageCategories]
--select * from [dbo].[Packages]


--INSERT into [dbo].[Customers] VALUES(
--	Next value for CustomerSequence,
--	'Areetra',
--	'Halder',
--	'areetra.halder@infosys.com',
--	'123456',
--	'M',
--	'8881480202',
--	'24-MAY-2000',
--	'INfosys, Pune',
--	1
--	)
