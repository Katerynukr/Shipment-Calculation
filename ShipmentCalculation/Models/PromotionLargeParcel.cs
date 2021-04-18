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
    public class PromotionLargeParcel : PricingRule
    {
        public decimal Discount { get; set; }

        public PromotionLargeParcel(PackageSizes size, CarrierCodes carrierCode)
        {
            GeneratePricing(size, carrierCode);
        }

        public override void GeneratePricing(PackageSizes size, CarrierCodes carrierCode)
        {
            var regularPrice = GetProviderPrice(size, carrierCode);
            var discount = regularPrice;
            if (!DiscountData.IsLargeParcelDiscounted)
            {
                if (DiscountData.DiscountAmount >= discount)
                {
                    Price = regularPrice - discount;
                    Discount = discount;
                    DiscountData.DiscountAmount -= discount;
                    DiscountData.IsLargeParcelDiscounted = true;
                }
                else
                {
                    discount = DiscountData.DiscountAmount;
                    Price -= discount;
                    Discount = discount;
                    DiscountData.DiscountAmount = 0.0M;
                    DiscountData.IsLargeParcelDiscounted = true;
                }
            }
        }
        public decimal GetProviderPrice(PackageSizes size, CarrierCodes carrierCode)
        {
            var providerPrice = PriceData.ProvidersPrices.FirstOrDefault(p => p.Provider == carrierCode && p.Size == size);
            return providerPrice.Price;
        }
    }
}
