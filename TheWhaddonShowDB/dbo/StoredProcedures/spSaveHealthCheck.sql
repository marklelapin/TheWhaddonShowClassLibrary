CREATE PROCEDURE [dbo].spSaveHealthCheck
	@Type varchar(255),
	@DateTime datetime2,
	@ResponseTime int,
	@ExpectedStatusCode int,
	@ActualStatusCode int,
	@Result varchar(50)
AS
	INSERT dbo.HealthCheck ([Type], [DateTime], [ResponseTime], [ExpectedStatusCode], [ActualStatusCode], Result)
	
	SELECT @Type,@DateTime,@ResponseTime,@ExpectedStatusCode,@ActualStatusCode,@Result

RETURN 0
