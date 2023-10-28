CREATE PROCEDURE [dbo].[spDeleteFromServer]
	@UpdateType varchar(255),
	@Updates nvarchar(max)
AS
	DECLARE @TempTable Table (
	Id uniqueidentifier
	,Created datetime2
	)

	INSERT @TempTable

	SELECT * FROM OPENJSON(@Updates)
	WITH (
	Id uniqueidentifier
	,Created datetime2
	)

	IF @UpdateType = 'PartUpdate'
	BEGIN
		DELETE t
		FROM dbo.PartUpdate t
		INNER JOIN @TempTable f
		ON f.Id = T.Id
		and F.Created = T.Created
	END
	IF @UpdateType = 'PersonUpdate'
	BEGIN
		DELETE t
		FROM dbo.PersonUpdate t
		INNER JOIN @TempTable f
		ON f.Id = T.Id
		and F.Created = T.Created
	END
	IF @UpdateType = 'ScriptItemUpdate'
	BEGIN
		DELETE t
		FROM dbo.ScriptItemUpdate t
		INNER JOIN @TempTable f
		ON f.Id = T.Id
		and F.Created = T.Created
	END