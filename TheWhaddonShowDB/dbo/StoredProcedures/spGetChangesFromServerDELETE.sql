﻿CREATE PROCEDURE [dbo].[spGetChangesFromServer]
	@LastSyncDate datetime2
	,@UpdateType varchar(255)
	,@Output nvarchar(max) OUTPUT
AS

/* DECLARE @LastSyncDate datetime = '2023-04-01'
--*/
	IF @UpdateType = 'PartUpdate'
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
	IF @UpdateType = 'PersonUpdate'
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
	IF @UpdateType = 'ScriptItemUpdate'
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
							, JSON_QUERY([PartIds]) as PartIds
							, JSON_QUERY([Tags]) as Tags
						FROM dbo.ScriptItemUpdate
						WHERE UpdatedOnServer > @LastSyncDate
						FOR JSON AUTO)
	END;
RETURN


