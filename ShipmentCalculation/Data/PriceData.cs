using ShipmentClculation.Enums;
using ShipmentClculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Data
{
    public static class PriceData
    {
        public static List<ProviderPrice> ProvidersPrices = new()
        {
            new ProviderPrice()
            {
                Provider = CarrierCodes.LP,
                Size = PackageSizes.S,
                Price = 1.50M
            },
            new ProviderPrice()
            {
                Provider = CarrierCodes.LP,
                Size = PackageSizes.M,
                Price = 4.90M
            },
            new ProviderPrice()
            {
                Provider = CarrierCodes.LP,
                Size = PackageSizes.L,
                Price = 6.90M
            },
            new ProviderPrice()
            {
                Provider = CarrierCodes.MR,
                Size = PackageSizes.S,
                Price = 2.00M
            },
            new ProviderPrice()
            {
                Provider = CarrierCodes.MR,
                Size = PackageSizes.M,
                Price = 3.00M
            },
            new ProviderPrice()
            {
                Provider = CarrierCodes.MR,
                Size = PackageSizes.L,
                Price = 4.00M
            }
        };
    }
}
