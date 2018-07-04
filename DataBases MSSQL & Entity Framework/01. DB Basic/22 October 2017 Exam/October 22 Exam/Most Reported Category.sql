SELECT c.Name AS [CategoryName], COUNT(c.Id) FROM Categories AS c
INNER JOIN Departments as d ON d.Id = c.DepartmentId
INNER JOIN Employees as e ON e.DepartmentId = d.Id
GROUP BY c.Name
ORDER BY [CategoryName]
