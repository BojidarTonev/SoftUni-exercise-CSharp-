SELECT * FROM Orders
SELECT * FROM Clients

SELECT sub.Names, sub.Class FROM
(SELECT TOP 1000000
        CONCAT(c.FirstName, ' ', c.LastName) AS [Names], m.Class AS [Class], c.Id AS [Id]
		FROM Clients AS c
		JOIN Orders AS o ON c.Id = o.ClientId
		LEFT JOIN Vehicles AS v ON o.VehicleId = v.Id
		JOIN Models AS m ON v.ModelId = m.Id
		GROUP BY c.FirstName, c.LastName, m.Class, c.Id
		ORDER BY COUNT(o.VehicleId)
) AS sub
ORDER BY Names, Class, sub.[Id]



----------NEINEN
