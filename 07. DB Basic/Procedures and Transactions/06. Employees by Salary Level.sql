CREATE PROC usp_EmployeesBySalaryLevel (@LevelOfSalary VARCHAR(10)) AS
BEGIN
      SELECT 
	         e.FirstName,
			 e.LastName
	    FROM Employees AS e
	   WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @LevelOfSalary
END