using FluentAssertions;
using ShipmentClculation.Data;
using ShipmentClculation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShipmentCalculationTests
{
    public class MonthlyDiscountServiceTests
    {
       [Fact]
        public void UpdateDiscountsOnNewMonth_GivenDate_UpdateDiscountData()
        {
            DiscountData.IsLargeParcelDiscounted = true;
            DiscountData.DiscountAmount = 0.50M;
            DateTime date = new DateTime(2020, 12, 01);
            MonthlyDiscountService.UpdateDiscountsOnNewMonth(date);

            var result1 = DiscountData.IsLargeParcelDiscounted;
            var result2 = DiscountData.DiscountAmount;

            result1.Should().BeFalse();
            result2.Should().Be(10.00M);
        }
    }
}
