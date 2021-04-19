using ShipmentClculation.Data;
using ShipmentClculation.Enums;
using ShipmentClculation.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Models
{
    public class RegularPrice : PricingRule
    {
        public RegularPrice(PackageSizes size, CarrierCodes carrierCode)
        {
            GeneratePricing(size, carrierCode);
        }

        public override void GeneratePricing(PackageSizes size, CarrierCodes carrierCode)
        {
            Price = GetProviderPrice(size, carrierCode);
        }
        public decimal GetProviderPrice(PackageSizes size, CarrierCodes carrierCode)
        {
            var providerPrice = PriceData.ProvidersPrices.FirstOrDefault(p => p.Provider == carrierCode && p.Size == size);
            return providerPrice.Price;
        }
    }
}
