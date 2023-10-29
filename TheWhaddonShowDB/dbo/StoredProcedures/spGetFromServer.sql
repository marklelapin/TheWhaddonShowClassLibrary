CREATE PROCEDURE [dbo].[spGetFromServer]
	@UpdateIds nvarchar(max)
	,@UpdateType varchar(255)
	,@LatestOnly bit = 0
	,@Output nvarchar(max) OUTPUT
AS
	
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
		END;


	IF @UpdateType = 'PartUpdate'
	BEGIN
		Set @Output = (SELECT t.Id
							, [ConflictId]
							, [Created]
							, [UpdatedOnServer]
							, [CreatedBy]
							, [IsActive]
							, [Name]
							, [PersonId]
							, JSON_QUERY([Tags]) as Tags
						FROM dbo.ifPartUpdate(@LatestOnly) t
						WHERE t.Id IN (SELECT Id from #Ids)
						FOR JSON AUTO);
	END

	IF @UpdateType = 'PersonUpdate'
	BEGIN
		Set @Output = (SELECT t.Id
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
						FROM dbo.ifPersonUpdate(@LatestOnly) t
						WHERE t.Id IN (SELECT Id from #Ids)
						FOR JSON AUTO);
	END

	IF @UpdateType = 'ScriptItemUpdate'
	BEGIN
		Set @Output = (SELECT t.Id
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
						FROM dbo.ifScriptItemUpdate(@LatestOnly) t
						WHERE t.Id IN (SELECT Id from #Ids)
						FOR JSON AUTO);
	END

RETURN;
