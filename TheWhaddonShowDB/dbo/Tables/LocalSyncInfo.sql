CREATE TABLE [dbo].[LocalSyncInfo]
(
	[ObjectType] VARCHAR(255) NOT NULL PRIMARY KEY, 
    [LastSyncDate] DATETIME2 NOT NULL
)
