CREATE PROC usp_GetTownsStartingWith (@Name VARCHAR(10)) AS
BEGIN
	  SELECT
	         t.Name AS [Town]
	    FROM Towns AS t
	   WHERE t.Name LIKE CONCAT(@Name, '%')
END
