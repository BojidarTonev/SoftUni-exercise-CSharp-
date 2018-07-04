SELECT
	  TOP 1
      AVG(Salary) AS AverageSalary
 FROM Employees
GROUP BY DepartmentID
ORDER BY AverageSalary