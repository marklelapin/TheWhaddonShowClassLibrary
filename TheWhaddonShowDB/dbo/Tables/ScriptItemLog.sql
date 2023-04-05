CREATE TABLE [dbo].[ScriptItemLog]
(
--LocalServerIdentityColumns
	[Id] uniqueidentifier
	,UpdatedLocally datetime
	,UpdatedOnServer datetime
	,ConflictID uniqueidentifier
	,IsActive bit
--Specific Column
	,ParentID uniqueidentifier
	,OrderNo int
	,[Type] varchar(255)
	,[Text] nvarchar(max)
	,Parts nvarchar(max)
	,Tags nvarchar(max)
	,PRIMARY KEY (Id,UpdatedLocally)
);

