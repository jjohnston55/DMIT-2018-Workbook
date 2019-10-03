using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.EntityCustomization
{
    public class SupplierSummary
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<SupplierProduct> ProductSummary { get; set; }
    }
}
