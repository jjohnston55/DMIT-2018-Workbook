<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not manage anyone.
from person in Employees
//   Employee   Table<Employees> 
where person.ReportsToChildren.Count == 0
//    Employee  IEnumerable<Employees>
//				  - interface = a "contract" regarding methods
select new
{
  Name = person.FirstName + " " + person.LastName,
  Manager = person.ReportsToEmployee.FirstName + " " + person.ReportsToEmployee.LastName
}