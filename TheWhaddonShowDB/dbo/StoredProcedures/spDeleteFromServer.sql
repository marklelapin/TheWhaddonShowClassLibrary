CREATE PROCEDURE [dbo].[spDeleteFromServer]
	@ObjectType varchar(255),
	@Objects nvarchar(max)
AS
	DECLARE @TempTable Table (
	Id uniqueidentifier
	,Created datetime2
	)

	INSERT @TempTable

	SELECT * FROM OPENJSON(@Objects)
	WITH (
	Id uniqueidentifier
	,Created datetime2
	)

	IF @ObjectType = 'PartUpdate'
	BEGIN
		DELETE t
		FROM dbo.PartUpdate t
		INNER JOIN @TempTable f
		ON f.Id = T.Id
		and F.Created = T.Created
	END
	IF @ObjectType = 'PersonUpdate'
	BEGIN
		DELETE t
		FROM dbo.PersonUpdate t
		INNER JOIN @TempTable f
		ON f.Id = T.Id
		and F.Created = T.Created
	END
	IF @ObjectType = 'ScriptItemUpdate'
	BEGIN
		DELETE t
		FROM dbo.ScriptItemUpdate t
		INNER JOIN @TempTable f
		ON f.Id = T.Id
		and F.Created = T.Created
	END