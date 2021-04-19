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
    public class RegularPriceTests
    {
        [Fact]
        public void GeneratePricing_GivenSizeAndCarrieCode_ReturnsPriceAndDiscount()
        {
            var size = PackageSizes.M;
            var carrierCode = CarrierCodes.MR;
            var result = new RegularPrice(size,carrierCode);

            result.Discount.Should().BeNull();
            result.Price.Should().Be(3.00M);
        }
    }
}
