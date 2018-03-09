/*
   Select the orders shipping to the USA whose freight is 
   between $10 and $20
*/

USE Northwind;
GO

select*
from Orders
where Freight between 10 and 20 and ShipCountry = 'USA'