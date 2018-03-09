/*
	Find the gross total of all orders (sum of quantity * unit price) 
	for each customer, order it in descending order by the total.
*/

USE Northwind;
GO

select sum (od.UnitPrice * od.Quantity) as GrossTotal, CompanyName
from [Order Details] od
inner join Orders o on o.OrderID = od.OrderID
inner join Customers c on c.CustomerID = o.CustomerID
group by CompanyName
order by GrossTotal desc
