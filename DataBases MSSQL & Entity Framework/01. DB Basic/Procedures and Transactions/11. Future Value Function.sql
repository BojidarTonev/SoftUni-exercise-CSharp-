CREATE FUNCTION ufn_CalculateFutureValue (@sum money, @annualIntRate float, @years int)
RETURNS money
AS
BEGIN
  RETURN @sum * POWER(1 + @annualIntRate, @years);  
END;