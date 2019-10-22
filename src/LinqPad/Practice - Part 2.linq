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
from place in Regions
select new {
	Region = place.RegionDescription,
	// Getting employees and removing duplicates
	Employees = (from area in place.Territories
				from manager in area.EmployeeTerritories
				select manager.Employee.FirstName + " " + manager.Employee.LastName).Distinct(),
	// Grouping employees
	Employees2 = from area in place.Territories
				from manager in area.EmployeeTerritories
				group manager by manager.Employee into areaManagers
				select areaManagers.Key.FirstName + " " + areaManagers.Key.LastName
}
// B) List all the Customers sorted by Company Name. Include the Customer's company name, contact name, and other contact information in the result.
from cust in Customers
select new {
	CompanyName = cust.CompanyName,
	Contact = new {
					Name = cust.ContactName,
					Title = cust.ContactTitle,
					Email = cust.ContactEmail,
					Phone = cust.Phone,
					Fax = cust.Fax
				}
}
// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.
from emp in Employees
orderby emp.LastName, emp.FirstName
select new {
	emp.FirstName,
	emp.LastName,
	CustomerOrderCount = emp.SalesRepOrders.Count()
}
// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.
from cust in Customers
group cust by cust.Address.City into CustGroups
select new {
	CityName = CustGroups.Key,
	Customers = from buyer in CustGroups
	select new {
		buyer.CompanyName,
		buyer.ContactName,
		buyer.ContactTitle,
		buyer.Phone
	}
}
// F) List all the Suppliers, by Country
from data in Suppliers
group data by data.Address.Country into SuppGroups
select new {
	Country = SuppGroups.Key,
	Supplier = from supp in SuppGroups
			   select supp.CompanyName
}