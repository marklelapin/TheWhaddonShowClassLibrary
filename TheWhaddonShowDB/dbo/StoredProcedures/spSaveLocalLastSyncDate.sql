CREATE PROCEDURE [dbo].[spSaveLocalLastSyncDate]
	@ObjectType varchar(255)
	,@LastSyncDate DateTime2
	
AS
	DELETE 
	FROM dbo.LocalSyncInfo 
	WHERE ObjectType = @ObjectType

	INSERT dbo.LocalSyncInfo
	Values(@ObjectType, @LastSyncDate)

RETURN 0