CREATE PROCEDURE [dbo].[spGetChangesFromServer]
	@LastSyncDate datetime2
	,@ObjectType varchar(255)
	,@Output nvarchar(max) OUTPUT
AS

/* DECLARE @LastSyncDate datetime = '2023-04-01'
--*/
	IF @ObjectType = 'PartUpdate'
	BEGIN
		Set @Output = (SELECT [Id]
							, [ConflictId]
							, [Created]
							, [UpdatedOnServer]
							, [CreatedBy]
							, [IsActive]
							, [Name]
							, [PersonId]
							, JSON_QUERY([Tags]) as Tags
						FROM dbo.PartUpdate
						WHERE UpdatedOnServer > @LastSyncDate
						FOR JSON AUTO)
	END;
	IF @ObjectType = 'PersonUpdate'
	BEGIN
		Set @Output = (SELECT [Id]
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
						FROM dbo.PersonUpdate
						WHERE UpdatedOnServer > @LastSyncDate
						FOR JSON AUTO)
	END;
	IF @ObjectType = 'ScriptItemUpdate'
	BEGIN
		Set @Output = (SELECT [Id]
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
						FROM dbo.ScriptItemUpdate
						WHERE UpdatedOnServer > @LastSyncDate
						FOR JSON AUTO)
	END;
RETURN


