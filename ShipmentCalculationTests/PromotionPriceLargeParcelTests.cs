using FluentAssertions;
using ShipmentClculation.Enums;
using ShipmentClculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShipmentCalculationTests
{
    public class PromotionPriceLargeParcelTests
    {
        [Fact]
        public void GeneratePricing_GivenSizeAndCarrieCode_ReturnsPriceAndDiscount()
        {
            var size = PackageSizes.L;
            var carrierCode = CarrierCodes.LP;
            var result = new PromotionPriceLargeParcel(size, carrierCode);

            result.Discount.Should().Be(6.90M);
            result.Price.Should().Be(0.00M);
        }
    }
}
