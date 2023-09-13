CREATE PROCEDURE [dbo].[spSaveLastSyncDate]
	@UpdateType varchar(255),
	@LastSyncDate datetime2
AS
	DELETE 
	FROM dbo.LocalSyncInfo 
	WHERE UpdateType = @UpdateType
	
	INSERT dbo.LocalSyncInfo (UpdateType,LastSyncDate)

	VALUES(@UpdateType,@LastSyncDate)

RETURN 0
