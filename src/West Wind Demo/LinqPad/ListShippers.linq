<Query Kind="Program">
  <Connection>
    <ID>b3d3e348-43e3-4e4a-a0d2-e030fba0ffb2</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	var output = ListShippers();
	output.Dump();
}

public List<ShipperSelection> ListShippers()
        {
            //throw new NotImplementedException();
            // TODO: Get all the shippers from the Db
			var result = from shipper in Shippers
						 orderby shipper.CompanyName
						 select new ShipperSelection
						 {
						 	ShipperId = shipper.ShipperID,
							Shipper = shipper.CompanyName
						 };
			return result.ToList();
        }
		
public class ShipperSelection
    {
        public int ShipperId { get; set; }
        public string Shipper { get; set; }
    }