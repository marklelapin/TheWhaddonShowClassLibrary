CREATE PROCEDURE [dbo].[spGetChangesFromLocal]
	@UpdateType varchar(255)
	,@Output nvarchar(max) OUTPUT
AS
	
	IF @UpdateType = 'PartUpdate'
	BEGIN
		SEt @Output = (SELECT [Id]
							, [ConflictId]
							, [Created]
							, [UpdatedOnServer]
							, [CreatedBy]
							, [IsActive]
							, [Name]
							, [PersonId]
							, JSON_QUERY([Tags]) as Tags
						FROM dbo.PartUpdate t
						WHERE t.UpdatedOnServer IS NULL
						FOR JSON AUTO)
	END
	IF @UpdateType = 'PersonUpdate'
	BEGIN
		SEt @Output = (SELECT [Id]
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
						WHERE t.UpdatedOnServer IS NULL
						FOR JSON AUTO)
	END
	IF @UpdateType = 'ScriptItemUpdate'
	BEGIN
		SEt @Output = (SELECT [Id]
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
						WHERE t.UpdatedOnServer IS NULL
						FOR JSON AUTO)
	END
RETURN 
