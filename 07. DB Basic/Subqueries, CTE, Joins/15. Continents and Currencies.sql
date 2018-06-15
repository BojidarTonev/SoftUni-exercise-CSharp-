WITH cu (ContinentCode, CurrencyCode, CurrencyUsage) AS
(
           SELECT
			      c.ContinentCode,
				  c.CurrencyCode,
				  COUNT(c.CurrencyCode) AS [CurrencyUsage]
			 FROM Countries AS c
			GROUP BY c.ContinentCode, c.CurrencyCode
			HAVING COUNT(c.CurrencyCode) > 1
)   
    
SELECT
       ContMax.ContinentCode,
	   ccy.CurrencyCode, 
	   ContMax.CurrencyUsage 
  FROM
       (SELECT 
	           ContinentCode, 
		       MAX(CurrencyUsage) AS CurrencyUsage
          FROM cu 
         GROUP BY ContinentCode) AS ContMax
   JOIN cu AS ccy 
     ON (ContMax.ContinentCode = ccy.ContinentCode AND ContMax.CurrencyUsage = ccy.CurrencyUsage)
  ORDER BY ContMax.ContinentCode
      