use Northwind
go

select distinct FirstName, LastName
from Employees
inner join EmployeeTerritories on Employees.EmployeeID = EmployeeTerritories.EmployeeID
inner join Territories on Territories.TerritoryID = EmployeeTerritories.TerritoryID
inner join Region on Region.RegionID = Territories.RegionID

inner join Orders on Orders.EmployeeID = Employees.EmployeeID
inner join [Order Details] on [Order Details].OrderID = Orders.OrderID
inner join Products on Products.ProductID = [Order Details].ProductID
inner join Suppliers on Suppliers.SupplierID = Products.SupplierID

where Region.RegionDescription = 'Eastern'
and Suppliers.CompanyName = 'Exotic Liquids'



--OR DO IT WITH A SUB SELECT

select distinct FirstName, LastName
from Employees e 
inner join EmployeeTerritories et on e.EmployeeID = et.EmployeeID
inner join Territories t on t.TerritoryID = et.TerritoryID
inner join Region r on r.RegionID = t.RegionID
where r.RegionDescription = 'Eastern'
and e.EmployeeID in (
	select EmployeeID
	from Orders o
	inner join [Order Details] od on od.OrderID = o.OrderID
	inner join Products p on p.ProductID = od.ProductID
	inner join Suppliers s on s.SupplierID = p.SupplierID
	where s.CompanyName = 'Exotic Liquids')