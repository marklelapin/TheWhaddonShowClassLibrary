CREATE TABLE [dbo].[HealthCheck]
(
	[Type] varchar(255)
	,[DateTime] datetime2
	,ResponseTime int
	,ExpectedStatusCode int 
	,ActualStatusCode int
	,Primary Key(Type,DateTime)
)
