CREATE PROCEDURE [dbo].[spGetFromLocal]
	@UpdateIds nvarchar(max)
	,@UpdateType varchar(255)
	,@LatestOnly bit = 0 --Determines whether or not to just send back the latest update
	,@UnSyncedCopyId uniqueidentifier = NULL --If null will do nothing. If a CopyID is present it will return all updates that have been synced to that CopyID
	,@Output nvarchar(max) OUTPUT
AS
	
	IF @UnSyncedCopyId IS NOT NULL
	BEGIN
		Set @LatestOnly = 0
	END


	IF OBJECT_ID('tempdb..#Ids') IS NOT NULL
	DROP TABLE #Ids

	CREATE TABLE #Ids (
	Id uniqueidentifier
	)
	
	IF ISNULL(@UpdateIds,'') != ''
	BEGIN
		INSERT #Ids
		SELECT DISTINCT CAST(value AS uniqueidentifier)
				FROM STRING_SPLIT(@UpdateIds,',')
	END


	IF @UpdateType = 'PartUpdate'
	BEGIN
		Set @Output = (SELECT [t].[Id]
						, [ConflictId]
							, [Created]
							, [UpdatedOnServer]
							, [CreatedBy]
							, [IsActive]
							, [Name]
							, [PersonId]
							, JSON_QUERY([Tags]) as Tags
						FROM dbo.ifPartUpdate(@LatestOnly,@UnSyncedCopyId) t
						WHERE t.Id IN (SELECT Id FROM #Ids)
						OR ISNULL(@UpdateIds,'') = ''
						FOR JSON AUTO);
	END;

	
	IF @UpdateType = 'PersonUpdate'
	BEGIN
		Set @Output = (SELECT [t].[Id]
							, [ConflictId]
							, [Created]
							, [UpdatedOnServer]
							, [CreatedBy]
							, [IsActive]
							, [FirstName]
							, [LastName]
							, [Email]
							, [PictureRef]
							, [IsActor]
							, [IsSinger]
							, [IsWriter]
							, [IsBand]
							, [IsTechnical]
							, JSON_QUERY([Tags]) as Tags
						FROM dbo.ifPersonUpdate(@LatestOnly,@UnSyncedCopyId) t
						WHERE t.Id IN (SELECT Id FROM #Ids)
						OR ISNULL(@UpdateIds,'') = ''
						FOR JSON AUTO);
	END;

	
	IF @UpdateType = 'ScriptItemUpdate'
	BEGIN
		Set @Output = (SELECT [t].[Id]
						, [ConflictId]
							, [Created]
							, [UpdatedOnServer]
							, [CreatedBy]
							, [IsActive]
							, [ParentId]
							, [OrderNo]
							, [Type]
							, [Text]
							, JSON_QUERY([PartIds]) as PartIds
							, JSON_QUERY([Tags]) as Tags
						FROM dbo.ifScriptItemUpdate(@LatestOnly,@UnSyncedCopyId) t
						WHERE t.Id IN (SELECT Id FROM #Ids)
						OR ISNULL(@UpdateIds,'') = ''
						FOR JSON AUTO);
	END;

RETURN;