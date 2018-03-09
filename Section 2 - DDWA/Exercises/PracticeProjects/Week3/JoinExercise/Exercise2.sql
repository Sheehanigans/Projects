/*
	Get the Company Name, Order Date, and each order details 
	Product name for USA customers only.
*/

USE Northwind;
GO

select distinct c.CompanyName, o.OrderDate, p.ProductName, od.* --gets all order details
from [Order Details] od
inner join Orders o on od.OrderID = o.OrderID
inner join Products p on p.ProductID = od.ProductID
inner join Customers c on o.CustomerID = c.CustomerID

where c.Country = 'USA'
