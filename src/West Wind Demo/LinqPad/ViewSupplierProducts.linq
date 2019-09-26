<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from company in Suppliers
select new
{
	CompanyName = company.CompanyName,
	Contact = company.ContactName,
	PhoneNumber = company.Phone,
	ProductSummary = from item in Products
					 select new
					 {
					 	ProductName = item.ProductName,
						CategoryName = item.Category.CategoryName,
						UnitPrice = item.UnitPrice,
						QtyPerUnit = item.QuantityPerUnit
					 }
}