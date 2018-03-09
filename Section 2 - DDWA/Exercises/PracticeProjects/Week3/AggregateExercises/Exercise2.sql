/*
	Find the gross total (sum of quantity * unit price) for 
	all orders placed by B's Beverages and Chop-suey Chinese.
*/

USE Northwind;
GO

select sum (od.UnitPrice * od.Quantity) as GrossTotal
from [Order Details] od
inner join Orders o on o.OrderID = od.OrderID
inner join Customers c on c.CustomerID = o.CustomerID
where c.CompanyName = 'B''s Beverages' and c.CompanyName = 'Chop-suey Chinese'
