/*
	Write a query to show every combination of employee and location.
*/

USE SWCCorp;
GO

select *
from Employee e
cross join [Location] l