using ShipmentClculation.Data;
using ShipmentClculation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Models.Base
{
    public abstract class PricingRule
    {
        public decimal Price { get; set; }
        public abstract void GeneratePricing(PackageSizes size, CarrierCodes carrierCode);
    }
}
