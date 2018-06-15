SELECT t.Name AS [TownName], o.Name AS [OfficeName], o.ParkingPLaces FROM Offices AS o
JOIN Towns AS t ON o.TownId = t.Id
WHERE o.ParkingPlaces > 25
ORDER BY [TownName], o.Id