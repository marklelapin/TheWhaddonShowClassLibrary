CREATE TABLE [dbo].[Part]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY
	,[Name] varchar(255) NOT NULL
	,PersonID int REFERENCES Person(Id) NULL
	,Tags nvarchar(max) NULL
)

