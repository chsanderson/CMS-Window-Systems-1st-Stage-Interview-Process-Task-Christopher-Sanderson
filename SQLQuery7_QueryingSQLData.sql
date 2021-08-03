SELECT COUNT(case when p.ProductName = 'Composite Door' then 1 else NULL END)[DoorTotal],
COUNT(case when p.ProductName != 'Composite Door'then 1 else NULL END)[WindowTotal],
h.DateInProduction, MONTH(h.DateInProduction) AS [Month], Year(h.DateInProduction) AS [Year]
FROM Production AS p, Heading AS h
WHERE p.JobKeyID=h.JobKeyID
GROUP BY h.DateInProduction
ORDER BY h.DateInProduction DESC;