/*
   From the Orders table select all the order information for the 
   customer with id of QUEDE
*/

USE Northwind;
GO

select *
from Orders
where CustomerID = 'QUEDE'