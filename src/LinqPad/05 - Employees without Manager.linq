<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not have a manager
// (i.e.: they do not report to anyone).
from person in Employees
//  Employee in Table<Employees>
where person.ReportsToEmployee == null
//   Employee   Employee 
select new // Creating an anonymous data type
// The curly braces section below is called the Initializer List
{
  Name = person.FirstName + " " + person.LastName
}