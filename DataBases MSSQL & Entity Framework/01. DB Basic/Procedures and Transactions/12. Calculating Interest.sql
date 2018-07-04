CREATE PROC usp_CalculateFutureValueForAccount (@accountId int, @interestRate float)
AS
BEGIN
  DECLARE @years int = 5;
  SELECT
    a.Id AS [Account Id],
    ah.FirstName AS [First Name],
    ah.LastName AS [Last Name], 
    a.Balance AS [Current Balance],
    dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, @years) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a ON ah.Id = a.AccountHolderId
  WHERE a.Id = @accountId
END