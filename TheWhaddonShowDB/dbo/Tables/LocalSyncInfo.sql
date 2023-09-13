CREATE TABLE [dbo].[LocalSyncInfo]
(
	[UpdateType] VARCHAR(255) NOT NULL PRIMARY KEY, 
    [LastSyncDate] DATETIME2 NOT NULL
)
