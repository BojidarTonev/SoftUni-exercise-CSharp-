SELECT DISTINCT LEFT(FirstName, 1) FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName