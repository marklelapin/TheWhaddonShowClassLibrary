CREATE PROCEDURE [dbo].[spGetFromServer]
	@UpdateIds nvarchar(max)
	,@UpdateType varchar(255)
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
						FROM dbo.PartUpdate t
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
						FROM dbo.PersonUpdate t
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
							, JSON_QUERY([Parts]) as Parts
							, JSON_QUERY([Tags]) as Tags
						FROM dbo.ScriptItemUpdate t
						WHERE t.Id IN (SELECT Id from #Ids)
						FOR JSON AUTO);
	END

RETURN;
