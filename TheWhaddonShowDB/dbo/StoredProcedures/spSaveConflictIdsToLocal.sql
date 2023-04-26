CREATE PROCEDURE [dbo].[spSaveConflictIdsToLocal]
	@Conflicts nvarchar(max),
	@ObjectType varchar(255)
AS
	DECLARE @ConflictsTable Table(
	ConflictId uniqueidentifier
	,ObjectId uniqueidentifier
	,ObjectCreated datetime2
	)

	INSERT @ConflictsTable

	SELECT * FROM OPENJSON(@Conflicts)
	WITH (
	ConflictId uniqueidentifier
	,ObjectId uniqueidentifier
	,ObjectCreated datetime2
	)

	If @ObjectType = 'PartUpdate'
	BEGIN
		Update t
		set t.ConflictId = c.ConflictId
		FROM dbo.PartUpdate t
		INNER JOIN @ConflictsTable c
		ON t.Id = c.ObjectId
		AND t.Created = c.ObjectCreated
	END;

	If @ObjectType = 'PersonUpdate'
	BEGIN
		Update t
		set t.ConflictId = c.ConflictId
		FROM dbo.PersonUpdate t
		INNER JOIN @ConflictsTable c
		ON t.Id = c.ObjectId
		AND t.Created = c.ObjectCreated
	END;

	If @ObjectType = 'ScriptItemUpdate'
	BEGIN
		Update t
		set t.ConflictId = c.ConflictId
		FROM dbo.ScriptItemUpdate t
		INNER JOIN @ConflictsTable c
		ON t.Id = c.ObjectId
		AND t.Created = c.ObjectCreated
	END;
