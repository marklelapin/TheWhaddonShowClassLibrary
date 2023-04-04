CREATE TABLE [dbo].[PersonLog]
(
--LocalServerIdentityColumns
	[Id] uniqueidentifier
	,UpdatedLocally datetime
	,UpdatedOnServer datetime
	,ConflictID uniqueidentifier
	,IsActive bit
--Specific Column
	,FirstName varchar(255) NOT NULL
	,LastName varchar(255) NULL
	,Email varchar(255) NULL
	,PictureRef varchar(255) nULL
	,IsActor bit NULL
	,IsSinger bit NULL
	,IsWriter bit NULL
	,isBand bit NULL
	,IsTechnical bit NULL
	,Tags nvarchar(max) NULL
)	


