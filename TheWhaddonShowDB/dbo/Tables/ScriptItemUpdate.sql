CREATE TABLE [dbo].[ScriptItemUpdate]
(
--LocalServerIdentityColumns
	[Id] uniqueidentifier
	,ConflictId uniqueidentifier
	,Created datetime2
	,CreatedBy varchar(255)
	,UpdatedOnServer datetime2
	,IsActive bit
--Specific Column
	,ParentID uniqueidentifier
	,OrderNo int
	,[Type] varchar(255)
	,[Text] nvarchar(max)
	,[PartIds] nvarchar(max)
	,Tags nvarchar(max)
	,PRIMARY KEY (Id,Created)
);

