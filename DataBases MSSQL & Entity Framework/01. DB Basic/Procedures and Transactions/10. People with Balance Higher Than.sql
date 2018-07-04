CREATE PROC usp_GetHoldersWithBalanceHigherThan (@minBalance money)
AS
BEGIN
  WITH CTE_MinBalanceAccountHolders (HolderId) AS (
    SELECT 
	       AccountHolderId 
	  FROM Accounts
  GROUP BY AccountHolderId
    HAVING SUM(Balance) > @minBalance
  )
  SELECT 
         ah.FirstName AS [First Name],
		 ah.LastName AS [Last Name]
    FROM CTE_MinBalanceAccountHolders AS minBalanceHolders 
    JOIN AccountHolders AS ah
	  ON ah.Id = minBalanceHolders.HolderId
   ORDER BY ah.LastName, ah.FirstName 
END