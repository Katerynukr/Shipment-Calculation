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
    public class PromotionPriceSmallParcel : PricingRule
    {
        public PromotionPriceSmallParcel(PackageSizes size, CarrierCodes carrierCode)
        {
            GeneratePricing(size, carrierCode);
        }

        public override void GeneratePricing(PackageSizes size, CarrierCodes carrierCode)
        {
            var regularPrice = GetProviderPrice(size, carrierCode);
            var lowerstPrice = GetLowestPrice(regularPrice);
            var discount = GetPriceDifference(regularPrice, lowerstPrice);
            if (DiscountData.DiscountAmount >= discount)
            {
                SetPricingValuesWithMaxDiscount(lowerstPrice, discount);
            }
            else
            {
                SetPricingValuesWithAvilableDiscount(regularPrice, discount);
            }
        }

        public decimal GetProviderPrice(PackageSizes size, CarrierCodes carrierCode)
        {
            var providerPrice = PriceData.ProvidersPrices.FirstOrDefault(p => p.Provider == carrierCode && p.Size == size);
            return providerPrice.Price;
        }

        public decimal GetLowestPrice(decimal regularPrice)
        {
            var lowestPrice = regularPrice;
            foreach (var provider in PriceData.ProvidersPrices)
            {
                if (provider.Price < lowestPrice)
                    lowestPrice = provider.Price;
            }
            return lowestPrice;
        }

        public decimal GetPriceDifference(decimal regularPrice, decimal lowestPrice)
        {
            var difference = regularPrice - lowestPrice;
            return difference;
        }

        private void SetPricingValuesWithMaxDiscount(decimal lowerstPrice, decimal discount)
        {
            Price = lowerstPrice;
            Discount = discount;
            DiscountData.DiscountAmount -= discount;
        }

        private void SetPricingValuesWithAvilableDiscount(decimal regularPrice, decimal discount)
        {
            discount = DiscountData.DiscountAmount;
            Price = regularPrice - discount;
            Discount = discount;
            DiscountData.DiscountAmount = 0.0M;
        }
    }
}
