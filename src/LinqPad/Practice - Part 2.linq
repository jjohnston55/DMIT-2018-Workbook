<Query Kind="Expression">
  <Connection>
    <ID>b3d3e348-43e3-4e4a-a0d2-e030fba0ffb2</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.

// A) Group employees by region and show the results in this format:
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
 */
 
from data in Regions
group data by data.Address.Region into RegionGroups
select new {
	Region = RegionGroups.Key,
	Employees = from item in RegionGroups				
				select new {
					Employees = item.FirstName + " " + item.LastName
				}
}

// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.
from cust in Customers
select new {
	CompanyName = cust.CompanyName,
	ContactName = cust.ContactName,
	ContactEmail = cust.ContactEmail
}
// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.
from emp in Employees
orderby emp.LastName ascending
select new {
	FirstName = emp.FirstName,
	LastName = emp.LastName,
	CustomerOrderCount = emp.SalesRepOrders.Count
}
// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.
from emp in Employees
orderby emp.LastName ascending
select new {
	FirstName = emp.FirstName,
	LastName = emp.LastName,
	CustomerOrderCount = emp.SalesRepOrders.Count
}
// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.
from cust in Customers
group cust by cust.Address.City into CustGroups
select new {
	CityName = CustGroups.Address.City,
	CompanyName = CustGroups.CompanyName,
	ContactName = CustGroups.ContactName,
	Title = CustGroups.ContactTitle,
	Phone = CustGroups.Phone
}
// F) List all the Suppliers, by Country
from data in Suppliers
group data by data.Address.Country into SuppGroups
select new {
	Country = SuppGroups.Key,
	Supplier = from supp in SuppGroups
				select new {
					Supplier = supp.CompanyName
					}
}






