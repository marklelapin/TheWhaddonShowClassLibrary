CREATE TABLE [dbo].[ServerSyncInfo]
(
	[CopyId] uniqueidentifier NOT NULL
	,[UpdateId] uniqueidentifier NOT NULL
	,[UpdateCreated] datetime2 NOT NULL
	PRIMARY KEY (CopyID,UpdateId,UpdateCreated)
)
