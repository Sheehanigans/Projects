/*
   Select the orders whose freight is more than $100.00
*/

USE Northwind;
GO

select *
from Orders
where Freight > 100.00