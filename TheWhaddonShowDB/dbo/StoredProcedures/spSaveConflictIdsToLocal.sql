CREATE PROCEDURE [dbo].[spSaveConflictIdsToLocal]
	@Conflicts nvarchar(max),
	@UpdateType varchar(255)
AS
	DECLARE @ConflictsTable Table(
	ConflictId uniqueidentifier
	,UpdateId uniqueidentifier
	,UpdateCreated datetime2
	)

	INSERT @ConflictsTable

	SELECT * FROM OPENJSON(@Conflicts)
	WITH (
	ConflictId uniqueidentifier
	,UpdateId uniqueidentifier
	,UpdateCreated datetime2
	)

	If @UpdateType = 'PartUpdate'
	BEGIN
		Update t
		set t.ConflictId = c.ConflictId
		FROM dbo.PartUpdate t
		INNER JOIN @ConflictsTable c
		ON t.Id = c.UpdateId
		AND t.Created = c.UpdateCreated
	END;

	If @UpdateType = 'PersonUpdate'
	BEGIN
		Update t
		set t.ConflictId = c.ConflictId
		FROM dbo.PersonUpdate t
		INNER JOIN @ConflictsTable c
		ON t.Id = c.UpdateId
		AND t.Created = c.UpdateCreated
	END;

	If @UpdateType = 'ScriptItemUpdate'
	BEGIN
		Update t
		set t.ConflictId = c.ConflictId
		FROM dbo.ScriptItemUpdate t
		INNER JOIN @ConflictsTable c
		ON t.Id = c.UpdateId
		AND t.Created = c.UpdateCreated
	END;
