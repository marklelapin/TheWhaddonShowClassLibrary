CREATE VIEW [dbo].[vwLatestPartUpdate]
	AS
With CTELatest(Id,Created) AS
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
