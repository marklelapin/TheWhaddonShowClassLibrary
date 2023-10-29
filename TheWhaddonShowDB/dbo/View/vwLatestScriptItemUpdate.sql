CREATE VIEW [dbo].[vwLatestScriptItemUpdate]
	AS
With CTELatest(Id,Created) AS
(
SELECT Id
	,Max(Created) AS Created
FROM dbo.ScriptItemUpdate
GROUP BY Id
)

SELECT u.*
FROM dbo.ScriptItemUpdate u
INNER JOIN CTELatest l
ON l.Id = u.Id
AND l.Created = u.Created
