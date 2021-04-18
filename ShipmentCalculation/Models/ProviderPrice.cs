using ShipmentClculation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Models
{
    public class ProviderPrice
    {
        public CarrierCodes Provider { get; set; }
        public PackageSizes Size { get; set; }
        public decimal Price { get; set; }
    }
}
