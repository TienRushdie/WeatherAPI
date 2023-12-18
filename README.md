1. SELECT * FROM managers WHERE Phone IS NOT NULL;
2. SELECT COUNT(*) AS Count FROM Sells WHERE Date = '2021-06-20';
3. SELECT AVG(Sum) AS AVGSales FROM Sells WHERE ID_Prod IN (SELECT ID FROM products WHERE Name = 'Фанера');
4. SELECT m.Fio, SUM(s.Sum) AS TotalSales
    FROM managers m
    JOIN Sells s ON m.ID = s.ID_Manag
    WHERE s.ID_Prod IN (SELECT ID FROM products WHERE Name = 'ОСБ')
    GROUP BY m.Fio;
5. SELECT m.Fio, p.Name AS ProductName
    FROM managers m
    JOIN Sells s ON m.ID = s.ID_Manag
    JOIN products p ON s.ID_Prod = p.ID
    WHERE s.Date = '2021-08-22';
6. SELECT * FROM products WHERE Name LIKE '%Фанера%' AND Cost >= 1750;
7. SELECT 
    MONTH(s.Date) AS SaleMonth,
    p.Name AS ProductName,
    SUM(s.Count) AS TotalCount,
    SUM(s.Sum) AS TotalSum
    FROM Sells s
    JOIN products p ON s.ID_Prod = p.ID
    GROUP BY SaleMonth, ProductName;
8. SELECT Name, COUNT(*) AS RepCount
     FROM products
     GROUP BY Name
     HAVING COUNT(*) > 1
   
