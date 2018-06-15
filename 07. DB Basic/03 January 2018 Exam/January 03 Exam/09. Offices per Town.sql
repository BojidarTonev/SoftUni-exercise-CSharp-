SELECT t.Name AS [TownName], COUNT(o.TownId) AS [OfficesNumber] FROM Towns AS t
JOIN Offices AS o ON o.TownId = t.Id
GROUP BY t.Name
ORDER BY [OfficesNumber] DESC, [TownName]