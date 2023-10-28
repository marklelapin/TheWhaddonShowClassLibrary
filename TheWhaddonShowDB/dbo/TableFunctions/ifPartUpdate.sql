CREATE FUNCTION [dbo].[ifPartUpdate]
(
	@Latest bit
	,@UnsyncedCopyId uniqueidentifier = NULL --if null will return all if copyid is present will only return unsynced.
)
RETURNS TABLE
AS RETURN
(
	WITH CTELatest(Id,Created) AS
		(
		SELECT Id
			,Max(Created) AS Created
		FROM dbo.PartUpdate
		GROUP BY Id
		)

	SELECT u.*
	FROM dbo.PartUpdate u
	INNER JOIN CTELatest l
	ON l.Id = u.Id
	AND l.Created = u.Created
	WHERE @Latest = 1
	
	UNION
	
	SELECT u.*
	FROM dbo.PartUpdate u
	WHERE @Latest = 0
	AND @UnsyncedCopyId IS NULL

	UNION

	SELECT u.*
	FROM dbo.PartUpdate u
	LEFT JOIN dbo.ServerSyncInfo s
	ON s.UpdateId = u.Id
	AND s.UpdateCreated = u.Created
	AND s.CopyId = @UnsyncedCopyID
	WHERE s.UpdateId IS NULL
	AND @Latest = 0
	AND @UnsyncedCopyId IS NOT NULL

)