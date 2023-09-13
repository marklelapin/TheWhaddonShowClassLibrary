CREATE TABLE [dbo].[PartUpdateHistory]
(
--LocalServerIdentityColumns
	[Id] uniqueidentifier
	,ConflictId uniqueidentifier
	,[Created] datetime2
	,CreatedBy varchar(255)
	,UpdatedOnServer datetime2
	,IsActive bit
--Specific Column
	,[Name] varchar(255) NOT NULL
	,[PersonId] uniqueidentifier
	,Tags nvarchar(max) NULL
,Primary Key (Id,Created)
)

