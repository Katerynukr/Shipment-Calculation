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
    public class PromotionPriceSmallParcelTests
    {
        [Fact]
        public void GeneratePricing_GivenSizeAndCarrieCode_ReturnsPriceAndDiscount()
        {
            var size = PackageSizes.S;
            var carrierCode = CarrierCodes.MR;
            var result = new PromotionPriceSmallParcel(size, carrierCode);

            result.Discount.Should().Be(0.50M);
            result.Price.Should().Be(1.50M);
        }
    }
}
