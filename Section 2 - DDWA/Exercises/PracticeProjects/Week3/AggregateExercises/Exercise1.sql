/*
	Find the average freight paid for orders 
	placed by companies in the USA
*/

USE Northwind;
GO

select CompanyName,
avg (Freight) as AvgFreight
from Orders o
inner join Customers c on o.CustomerID = c.CustomerID
where c.Country = 'USA'
group by c.CompanyName