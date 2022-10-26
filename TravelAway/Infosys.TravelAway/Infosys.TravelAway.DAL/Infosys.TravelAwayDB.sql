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
	CategoryId varchar(5) primary key,
	CategoryName varchar(20) not null unique,
	CHECK(SUBSTRING(CategoryId,1,2) = 'PC')
	)
	
Create table Packages(
	PackageId varchar(5) primary key,
	PackageName varchar(60) not null,
	PackageDesc varchar(255) not null,
	TypeOfPackage VARCHAR(15) CONSTRAINT chk_TypeOfPackage CHECK(TypeOfPackage IN ('International','Domestic')),
	CategoryId varchar(5) references PackageCategories(CategoryId) not null,
	CHECK(SUBSTRING(PackageId,1,1) = 'P')
	)

Create table PackageDetails(
	PackageDetailsId varchar(6) primary key,
	PackageId varchar(5) references Packages(PackageId) not null,
	PlacesToVisit varchar(255) not null,
	PackageDescription varchar(255) not null,
	DaysAndNight varchar(5) not null,
	Price int not null,
	Accommodation char(1) not null,
	check(Price>0),
	check(Accommodation IN ('T','F')),
	CHECK(SUBSTRING(PackageDetailsId,1,2) = 'PD')
)

Create table Customers(
	CustomerID varchar(5) primary key,
	FirstName varchar(30) not null,
	LastName varchar(30) not null,
	EmailId VARCHAR(50) CONSTRAINT [chk_EmailId] CHECK ([EmailId] LIKE '%_@__%.__%') NOT NULL UNIQUE,
	Password varchar(16) not null,
	Gender char(1) not null,
    ContactNumber varchar(10) not null,
    DateOfBirth date not null,
    Address varchar(250) not null,
	PackageDetailsId varchar(6) references PackageDetails(PackageDetailsId), 
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
start with 100
increment by 1;


--Inserts HardCoded Values for PackageCategories using PackageCategoriesSequence
INSERT INTO [dbo].[PackageCategories] VALUES(
	CONCAT('PC',NEXT VALUE FOR PackageCategoriesSequence),
	'Adventure'
),(
	CONCAT('PC',NEXT VALUE FOR PackageCategoriesSequence),
	'Nature'
),(
	CONCAT('PC',NEXT VALUE FOR PackageCategoriesSequence),
	'Religious'
),(
	CONCAT('PC',NEXT VALUE FOR PackageCategoriesSequence),
	'Village'
),(
	CONCAT('PC',NEXT VALUE FOR PackageCategoriesSequence),
	'Wildlife'
)

INSERT INTO [dbo].[Packages] VALUES(
	CONCAT('P',NEXT VALUE FOR PackageSequence),
	'Andaman & Nicobar',
	'A set of Island, known for its natural wildlife. Excellent place for water adventures',
	'Domestic',
	'PC101'
),(
	CONCAT('P',NEXT VALUE FOR PackageSequence),
	'North-East India',
	'Known as the chicken head of India. A variety of natural life and the local environment make it an awesome place',
	'Domestic',
	'PC104'
),(
	CONCAT('P',NEXT VALUE FOR PackageSequence),
	'Europe',
	'The fun of all life happens here. From streets to the monuments every thing happens here and its fun loving',
	'International',
	'PC100'
),(
	CONCAT('P',NEXT VALUE FOR PackageSequence),
	'America',
	'The place that never sleeps',
	'International',
	'PC100'
),(
	CONCAT('P',NEXT VALUE FOR PackageSequence),
	'New Zealand',
	'The most adventurous place in the world. Very sparsely populated country that makes awesome oppurtunities for adventure',
	'International',
	'PC100'
),(
	CONCAT('P',NEXT VALUE FOR PackageSequence),
	'Africa',
	'Take a deep dive to the earthly forests of Africa and explore the greens',
	'International',
	'PC104'
),(
	CONCAT('P',NEXT VALUE FOR PackageSequence),
	'Nagaland',
	'Nagaland is famous for its spiritual holiness and calm environment. The street food are a must to try on.',
	'Domestic',
	'PC102'
),(
	CONCAT('P',NEXT VALUE FOR PackageSequence),
	'Texas',
	'Texas is a village in Lubbock County, Texas, United States which is famous for its cultural heritage and pride',
	'International',
	'PC103'
)

INSERT Into [dbo].[PackageDetails] VALUES(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1001',
	'Assam, Nagaland, Sikkim, Manipur',
	'Northeast India is the easternmost region of India representing both a geographic and political administrative division of the country. It comprises eight states – Arunachal Pradesh, Assam, Manipur, Meghalaya, Mizoram, Nagaland, Tripura and Sikkim.',
	'6/7',
	28000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1001',
	'Assam, Nagaland, Sikkim, Manipur, Meghalaya, Tripura',
	'Northeast India is the easternmost region of India, comprises eight states – Arunachal Pradesh, Assam, Manipur, Meghalaya, Mizoram, Nagaland, Tripura and Sikkim.',
	'8/9',
	40000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1001',
	'Assam, Nagaland, Sikkim',
	'Northeast India is the easternmost region of India, comprises eight states – Arunachal Pradesh, Assam, Manipur, Meghalaya, Mizoram, Nagaland, Tripura and Sikkim. This package trips you to three of them',
	'4/3',
	20000,
	'F'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1000',
	'Swaraj Dweep, Port Blair, Baratang, Barren Island, Diglipur, Rangat',
	'The Andaman Islands are an Indian archipelago in the Bay of Bengal. These roughly 300 islands are known for their palm-lined, white-sand beaches, mangroves and tropical rainforests.',
	'7/6',
	56000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1000',
	'Port Blair, Baratang, Diglipur, Mayabunder',
	'The Andaman Islands are an Indian archipelago in the Bay of Bengal. These roughly 300 islands are known for their palm-lined, white-sand beaches, mangroves and tropical rainforests.',
	'6/5',
	36000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1000',
	'Swaraj Dweep, Mayabunder, Diglipur, Rangat',
	'The Andaman Islands are an Indian archipelago in the Bay of Bengal.',
	'5/4',
	32000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1002',
	'London, Paris, France, Rome, Amsterdam, Berlin, Barcelona, Prague, Athens, Venice, Madrid',
	'Europe is a landmass, located entirely in the Northern Hemisphere and mostly in the Eastern Hemisphere. Comprising the westernmost peninsulas of Eurasia.',
	'10/9',
	62000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1002',
	'London, Paris, France, Rome',
	'Europe is a landmass, located entirely in the Northern Hemisphere and mostly in the Eastern Hemisphere. Comprising the westernmost peninsulas of Eurasia.',
	'7/8',
	42000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1002',
	'Berlin, Barcelona, Prague, Athens, Venice, Madrid',
	'Europe is a landmass, located entirely in the Northern Hemisphere and mostly in the Eastern Hemisphere. Comprising the westernmost peninsulas of Eurasia.',
	'5/4',
	34000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1003',
	'New York, San Francisco, Los Angeles, Chicago',
	'The U.S. is a country of 50 states covering a vast swath of North America, with Alaska in the northwest and Hawaii extending the nation’s presence into the Pacific Ocean.',
	'6/6',
	44000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1003',
	'Washington D.C., Boston, Las Vegas, Seattle, Miami, San Diego',
	'The U.S. is a country of 50 states covering a vast swath of North America, with Alaska in the northwest and Hawaii extending the nation’s presence into the Pacific Ocean.',
	'6/6',
	42000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1003',
	'New York, San Francisco, Las Vegas, Seattle, Miami, San Diego',
	'The U.S. is a country of 50 states covering a vast swath of North America, with Alaska in the northwest and Hawaii extending the nation’s presence into the Pacific Ocean.',
	'5/4',
	42000,
	'F'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1004',
	'Auckland, Queenstown, Wellington, Christchurch, Rotorua',
	'New Zealand is an island country in the southwestern Pacific Ocean. It consists of two main landmasses—the North Island and the South Island.',
	'7/6',
	52000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1004',
	'Piopiotahi, Dunedin, Bay Of Islands, Nelson',
	'New Zealand is an island country in the southwestern Pacific Ocean. It consists of two main landmasses—the North Island and the South Island.',
	'5/4',
	48000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1004',
	'Auckland, Queenstown, Wellington, Piopiotahi, Dunedin, Nelson',
	'New Zealand is an island country in the southwestern Pacific Ocean. It consists of two main landmasses—the North Island and the South Island.',
	'8/7',
	68000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1005',
	'Cape Town, Marrakesh, Cairo, Tenerife, Johannesburg, Madeira, Nairobi, Lanzarote, Gran Canaria',
	'Africa is the world''s second-largest and second-most populous continent, after Asia in both cases.',
	'9/8',
	38000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1005',
	'Cape Town, Cairo, Tenerife, Johannesburg, Nairobi, Lanzarote',
	'Africa is the world''s second-largest and second-most populous continent, after Asia in both cases.',
	'5/4',
	44000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1005',
	'Johannesburg, Madeira, Nairobi, Lanzarote, Gran Canaria',
	'Africa is the world''s second-largest and second-most populous continent, after Asia in both cases.',
	'6/5',
	28000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1006',
	'Wokha, Tuensang, Phek, Kiphire',
	'Nagaland is a mountainous state in northeast India, bordering Myanmar. It''s home to diverse indigenous tribes, with festivals and markets celebrating the different tribes'' culture.',
	'5/4',
	28000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1006',
	'Kohima, Dimapur, Phek, Kiphire',
	'Nagaland is a mountainous state in northeast India, bordering Myanmar. It''s home to diverse indigenous tribes, with festivals and markets celebrating the different tribes'' culture.',
	'4/3',
	18000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1006',
	'Wokha, Tuensang, Dimapur, Phek, Kiphire',
	'Nagaland is a mountainous state in northeast India, bordering Myanmar. It''s home to diverse indigenous tribes, with festivals and markets celebrating the different tribes'' culture.',
	'5/4',
	43000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1007',
	'Austin, Houston, Dallas, San Antonio, El Paso, Galveston',
	'Texas is a state in the South Central region of the United States.',
	'5/4',
	43000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1007',
	'Austin, San Antonio, El Paso, Galveston',
	'Texas is a state in the South Central region of the United States.',
	'6/5',
	36000,
	'T'
),(
	CONCAT('PD', NEXT VALUE FOR PackageDetailsSequence),
	'P1007',
	'Austin, Houston, Dallas, San Antonio',
	'Texas is a state in the South Central region of the United States.',
	'4/4',
	33000,
	'T'
)

--Inserts HardCoded Values for Customers using CustomerSequence

INSERT Into [dbo].[Customers](CustomerID,FirstName,LastName,EmailId,Password,Gender,ContactNumber,DateOfBirth,Address) VALUES(
	CONCAT('C', NEXT VALUE FOR CustomerSequence),
	'Areetra',
	'Halder',
	'areetra.halder@infosys.com',
	'123456',
	'M',
	'8881480202',
	'24-MAY-2000',
	'Infosys, Pune'
),(
	CONCAT('C', NEXT VALUE FOR CustomerSequence),
	'Sujit',
	'Debnath',
	'sujit.debnath@infosys.com',
	'1285693',
	'M',
	'9679852103',
	'27-OCT-2000',
	'Kolaghat,West Bengal'
),(
	CONCAT('C', NEXT VALUE FOR CustomerSequence),
	'Vishal',
	'Shukla',
	'vishal.shukla03@infosys.com',
	'1285687',
	'M',
	'7376944196',
	'02-JAN-2000',
	'Pune,Maharastra'
),(
	CONCAT('C', NEXT VALUE FOR CustomerSequence),
	'Siddartha',
	'Morri',
	'venkata.morri@infosys.com',
	'1285690',
	'M',
	'9494258758',
	'30-JAN-2000',
	'Pune,Maharastra'
)



--select * from [dbo].[PackageCategories]
--select * from [dbo].[Packages]
--select * from [dbo].[PackageDetails]
--select * from [dbo].[Customers]

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

IF OBJECT_ID('usp_RegisterCustomer') IS NOT NULL
	DROP TABLE usp_RegisterCustomer
GO

GO
CREATE Procedure usp_RegisterCustomer (
    @FirstName varchar(30),
	@LastName varchar(30),
	@EmailId VARCHAR(50),
	@Password varchar(16),
	@Gender char(1),
    @ContactNumber varchar(10),
    @DateOfBirth date ,
    @Address varchar(250)
	)
	AS
		BEGIN 
	      DECLARE @ReturnVal INT
			   BEGIN TRY
				   IF(@FirstName LIKE('%[^a-zA-Z]%') OR LEN(@FirstName)=0)
					SET @ReturnVal=-1
				   ELSE IF(@LastName LIKE('%[^a-zA-Z]%') OR LEN(@LastName)=0)
					SET @ReturnVal=-2
				   ELSE IF(LEN(@EmailId)<8 OR LEN(@EmailId) IS NULL)
					SET @ReturnVal=-3
				   ELSE IF(LEN(@Password)<8 OR LEN(@Password)>16 OR (@Password IS NULL))
					SET @ReturnVal=-4
				   ELSE IF(LEN(@ContactNumber)>10 OR LEN(@ContactNumber)<10)
					SET @ReturnVal=-5
				   ELSE IF(@DateOfBirth>=CAST(GETDATE() AS DATE) OR (@DateOfBirth IS NULL))
			   		SET @ReturnVal=-6
				   ELSE IF(@EmailId NOT IN ((SELECT EmailId FROM [dbo].[Customers])))
					SET @ReturnVal=-7
				   ELSE 
					BEGIN
							INSERT INTO [dbo].[Customers](CustomerID,FirstName,LastName,EmailId,Password,Gender,ContactNumber,DateOfBirth,Address) VALUES
							  (
							  CONCAT('C' ,Next value for CustomerSequence),
							  @FirstName,
							  @LastName,
							  @EmailId,
							  @Password,
							  @Gender,
							  @ContactNumber,
							  @DateOfBirth,
							  @Address
							  )			
							SET @ReturnVal=1
					  END					
			END TRY
			BEGIN CATCH
				 SET @ReturnVal=-99				
			END CATCH
			Return @ReturnVal
		End
GO


--DECLARE @ReturnValue INT
--EXEC @ReturnValue = [usp_RegisterCustomer] 'Joey','Tribbani','vishalsharma@gmail.com','241522634','M','1100321321','01-JAN-2000','Hinjewadi Phase II',NULL



--select * from [dbo].[Customers]

IF OBJECT_ID('usp_Login') IS NOT NULL
	DROP TABLE usp_Login
GO

CREATE PROCEDURE usp_Login(
@EmailId VARCHAR(50),
@Password varchar(16)
)
AS BEGIN
	BEGIN TRY
		IF NOT EXISTS(select [EmailId] from [dbo].[Customers] where [EmailId]=@EmailId)
			return -1
		ELSE IF NOT EXISTS(select [EmailId] from [dbo].[Customers] where [EmailId]=@EmailId and [Password]=@Password)
			return 0
		ELSE 
			return 1
	END TRY
	BEGIN CATCH
		SELECT ERROR_LINE(),ERROR_MESSAGE()
		return -99
	END CATCH
END
GO

--Declare @returnval int
--EXEC @returnval = [usp_Login] 'venkata.morri@infosys.com','1285690'
--Select @returnval

select * from [dbo].[Customers]