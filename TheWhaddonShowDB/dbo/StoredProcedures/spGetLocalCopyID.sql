CREATE PROCEDURE [dbo].[spGetLocalCopyId]
AS
	DECLARE @CopyId uniqueidentifier
	
	IF (SELECT COUNT() FROM dbo.LocalCopyId) = 0
		BEGIN
			INSERT dbo.LocalCopyId (Id)
			
			SELECT NEWID();
		END
	
	Set @CopyId = (SELECT TOP 1 Id FROM dbo.LocalCopyId)

RETURN @CopyId
