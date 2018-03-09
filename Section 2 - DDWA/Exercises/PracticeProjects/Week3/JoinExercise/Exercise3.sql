/*
	Get all the order information for any order where Chai was sold.
*/

USE Northwind;
GO

select o.*, p.*, od.*
from Products p
inner join [Order Details] od on p.ProductID = od.ProductID
inner join Orders o on o.OrderID = od.OrderID
where p.ProductName = 'Chai'