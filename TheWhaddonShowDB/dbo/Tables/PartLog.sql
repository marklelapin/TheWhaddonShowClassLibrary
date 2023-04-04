CREATE TABLE [dbo].[PartLog]
(
--LocalServerIdentityColumns
	[Id] uniqueidentifier
	,UpdatedLocally datetime
	,UpdatedOnServer datetime
	,ConflictID uniqueidentifier
	,IsActive bit
--Specific Column
	,[Name] varchar(255) NOT NULL
	,PersonID uniqueidentifier
	,Tags nvarchar(max) NULL
)

