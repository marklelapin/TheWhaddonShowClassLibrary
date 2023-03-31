CREATE TABLE [dbo].[Person]
(
	Id INT identity(1,1) NOT NULL PRIMARY KEY
	,FirstName varchar(255) NOT NULL
	,LastName varchar(255) NULL
	,Email varchar(255) NULL
	,PhoneNo varchar(255) NULL
	,PictureRef varchar(255) nULL
	,IsActive bit NOT NULL
	,IsActor bit NULL
	,IsWriter bit NULL
	,isBand bit NULL
	,IsTechnical bit NULL
	,Tags nvarchar(max) NULL
)	


