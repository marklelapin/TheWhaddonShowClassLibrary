CREATE TABLE [dbo].[ScriptHistory]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY
	,ParentId int NULL REFERENCES ScriptHistory(Id)
	,OrderNo int
	,ItemTypeId int
	,
)
