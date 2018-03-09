/*
   Write a single query to display only the name and number of 
   units in stock for the products Laughing Lumberjack Lager, 
   Outback Lager, and Ravioli Angelo
*/

USE Northwind;
GO

select ProductName, UnitsInStock
from Products
where ProductName in ('Laughing Lumberjack Lager', 'Outback Lager', 'Ravioli Angelo')


