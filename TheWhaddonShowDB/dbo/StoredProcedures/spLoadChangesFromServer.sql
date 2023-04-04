CREATE PROCEDURE [dbo].[spLoadChangesFromServer]
	@ObjectType varchar(255),
	@LastSyncDate DateTime
AS

IF @ObjectType = 'PartUpdate'
BEGIN
	RETURN (SELECT [Id], [UpdatedLocally], [UpdatedOnServer], [ConflictID], [IsActive], [Name], [PersonID], [Tags]
			FROM dbo.PartLog
			WHERE UpdatedOnServer > @LastSyncDate
			FOR JSON AUTO);
END

IF @ObjectType = 'PersonUpdate'
BEGIN
	RETURN (SELECT [Id], [UpdatedLocally], [UpdatedOnServer], [ConflictID], [IsActive], [FirstName], [LastName], [Email], [PictureRef], [IsActor], [IsSinger], [IsWriter], [isBand], [IsTechnical], [Tags]
			FROM dbo.PersonLog
			WHERE UpdatedOnServer > @LastSyncDate
			FOR JSON AUTO);
END

IF @ObjectType = 'ScriptItemUpdate'
BEGIN
	RETURN (SELECT [Id], [UpdatedLocally], [UpdatedOnServer], [ConflictID], [IsActive], [ParentID], [OrderNo], [Type], [Parts], [Tags]
			FROM dbo.ScriptItemLog
			WHERE UpdatedOnServer > @LastSyncDate
			FOR JSON AUTO);
END






