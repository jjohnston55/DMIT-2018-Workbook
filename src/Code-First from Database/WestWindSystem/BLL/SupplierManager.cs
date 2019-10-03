using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.EntityCustomization;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class SupplierManager
    {
        public List<SupplierSummary> ListSupplierProducts()
        {
            using (var context = new WestWindContext())
            {
                var results = from company in context.Suppliers
                              select new SupplierSummary
                              {
                                  CompanyName = company.CompanyName,
                                  ContactName = company.ContactName,
                                  Phone = company.Phone,
                                  ProductSummary = from item in company.Products
                                                   select new SupplierProduct
                                                   {
                                                       ProductName = item.ProductName,
                                                       CategoryName = item.Category.CategoryName,
                                                       UnitPrice = item.UnitPrice,
                                                       QuantityPerUnit = item.QuantityPerUnit
                                                   }
                              };
                return results.ToList();
            }
        }
    }
}
