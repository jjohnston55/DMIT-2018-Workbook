<Query Kind="Expression">
  <Connection>
    <ID>b3d3e348-43e3-4e4a-a0d2-e030fba0ffb2</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.

//A) List all the customer company names for those with more than 5 orders.
from customer in Customers
where customer.Orders.Count() > 5
select customer.CompanyName
//B) Get a list of all the region names
from region in Regions
select region.RegionDescription
//C) Get a list of all the territory names
from territory in Territories
select territory.TerritoryDescription
//D) List all the regions and the number of territories in each region
from region in Regions
select new {
	Name = region.RegionDescription,
	TerritoryCount = region.Territories.Count()
}
//E) List all the region and territory names in a "flat" list
from place in Territories
select new {
	RegionName = place.Region.RegionDescription,
	TerritoryName = place.TerritoryDescription
}
//F) List all the region and territory names as an "object graph"
//   - use a nested query
from region in Regions
select new {
	RegionName = region.RegionDescription,
	TerritoryName = from territory in region.Territories
					select territory.TerritoryDescription
}
//G) List all the product names that contain the word "chef" in the name.
from item in Products
where item.ProductName.Contains("chef")
select item.ProductName
//H) List all the discontinued products, specifying the product name and unit price.
from item in Products
where item.Discontinued
select new {
	item.ProductName,
	item.UnitPrice
}
//I) List the company names of all Suppliers in North America (Canada, USA, Mexico)
from company in Suppliers
where company.Address.Country.Contains("Canada") || company.Address.Country.Contains("USA") || company.Address.Country.Contains("Mexico")
select company.CompanyName