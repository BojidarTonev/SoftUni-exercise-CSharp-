SELECT c.Name as [CategoryName], COUNT(e.Id) AS [Employees Number] FROM Categories as c
INNER JOIN Departments AS d ON d.Id = c.DepartmentId
INNER JOIN Employees AS e ON e.DepartmentId = d.Id
GROUP BY c.Name
ORDER BY [CategoryName]

SELECT * FROM Employees
