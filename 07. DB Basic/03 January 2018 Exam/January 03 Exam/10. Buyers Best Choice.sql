SELECT m.Manufacturer, m.Model, COUNT(ord.VehicleId) AS [TimesOrdered] FROM Models AS m
RIGHT JOIN Vehicles AS v ON m.Id = v.ModelId
LEFT JOIN Orders AS ord ON ord.VehicleId = v.Id
GROUP BY m.Model, m.Manufacturer
ORDER BY [TimesOrdered] DESC, m.Manufacturer DESC, m.Model


