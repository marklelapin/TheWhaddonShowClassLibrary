CREATE VIEW [dbo].[vwLatestPersonUpdate]
	AS
With CTELatest(Id,Created) AS
(
SELECT Id
	,Max(Created) AS Created
FROM dbo.PersonUpdate
GROUP BY Id
)

SELECT u.*
FROM dbo.PersonUpdate u
INNER JOIN CTELatest l
ON l.Id = u.Id
AND l.Created = u.Created
