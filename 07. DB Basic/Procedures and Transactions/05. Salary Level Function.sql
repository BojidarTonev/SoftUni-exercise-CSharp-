CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Result VARCHAR(10) = 'High'
	IF(@Salary < 30000) SET @Salary = 'Low'
	ELSE IF (@Salary <= 50000)  SET @Salary = 'Average'
	RETURN @Result
END

