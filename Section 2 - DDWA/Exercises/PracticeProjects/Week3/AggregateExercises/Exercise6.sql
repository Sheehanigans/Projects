/*
	Get the count of how many unique countries
	are represented by our suppliers.
*/

USE Northwind;
GO

select count (distinct(Country)) UniqueCountries
from Suppliers