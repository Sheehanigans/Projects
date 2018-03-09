/*
   Select the Suppliers whose contact has a title that starts with the word 
   Sales
*/

USE Northwind;
GO

select*
from Suppliers
where ContactTitle like 'Sales%'