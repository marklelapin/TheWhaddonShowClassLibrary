CREATE TABLE [dbo].[PartUpdate]
(
--LocalServerIdentityColumns
	[Id] uniqueidentifier NOT NULL
	,ConflictId uniqueidentifier
	,[Created] datetime2 NOT NULL
	,CreatedBy varchar(255)
	,UpdatedOnServer datetime2
	,IsActive bit
--Specific Column
	,[Name] varchar(255) NOT NULL
	,[PersonId] uniqueidentifier
	,Tags nvarchar(max) NULL
	,PRIMARY KEY (ID,Created)
)

