SELECT m.Model, m.Seats, v.Mileage FROM Models AS m
JOIN Vehicles AS v ON v.ModelId = m.Id
JOIN Orders AS ord ON ord.VehicleId = v.Id
WHERE ord.VehicleId
ORDER BY v.Mileage, m.Seats DESC, m.Id

------ne izliza po nqkvi prichini