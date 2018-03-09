/*
	Get the count of how many employees 
	report to someone else in the company 
	without using a WHERE clause.
*/

USE Northwind;
GO

select count(*) ManagedEmployees
from Employees e1
inner join Employees e2 on e1.EmployeeID = e2.ReportsTo