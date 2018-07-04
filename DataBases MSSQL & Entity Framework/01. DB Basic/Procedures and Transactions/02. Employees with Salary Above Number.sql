CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4)) AS
BEGIN
	SELECT
	       e.FirstName,
		   e.LastName
	  FROM Employees AS e
	 WHERE e.Salary >= @Number
END