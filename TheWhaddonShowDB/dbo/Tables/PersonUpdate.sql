CREATE TABLE [dbo].[PersonUpdate]
(
--LocalServerIdentityColumns
	[Id] uniqueidentifier NOT NULL
	,ConflictId uniqueidentifier
	,Created datetime2 NOT NULL
	,CreatedBy varchar(255)
	,UpdatedOnServer datetime2
	,IsActive bit
--Specific Column
	,FirstName varchar(255) NOT NULL
	,LastName varchar(255) NULL
	,Email varchar(255) NULL
	,PictureRef varchar(max) nULL
	,IsActor bit NULL
	,IsSinger bit NULL
	,IsWriter bit NULL
	,isBand bit NULL
	,IsTechnical bit NULL
	,Tags nvarchar(max) NULL
	,Primary Key(Id,Created)
)	


