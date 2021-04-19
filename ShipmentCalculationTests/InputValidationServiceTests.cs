using FluentAssertions;
using ShipmentClculation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShipmentCalculationTests
{
    public class InputValidationServiceTests
    {
        [Theory]
        [InlineData("2015-02-29", false)]
        [InlineData("2015-02-09", true)]
        [InlineData("20135-02-29", false)]
        [InlineData("2015-12-39", false)]
        public void IsValidDate_GivenDateString(string dateString, bool expected)
        {
            var valiadtionService = new InputValidationService();
            var result = valiadtionService.IsValidDate(dateString);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("P", false)]
        [InlineData("S", true)]
        [InlineData("KADABRA", false)]
        [InlineData("M", true)]
        public void IsValidPackageSize_GivenSizeString(string sizeString, bool expected)
        {
            var valiadtionService = new InputValidationService();
            var result = valiadtionService.IsValidPackageSize(sizeString);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("HG", false)]
        [InlineData("LP", true)]
        [InlineData("KADABRA", false)]
        [InlineData("MR", true)]
        public void IsValidCarrierCode_GiveCarrieCodeString(string codeString, bool expected)
        {
            var valiadtionService = new InputValidationService();
            var result = valiadtionService.IsValidCarrierCode(codeString);

            result.Should().Be(expected);
        }


        [Fact]        
        public void IsInputValid_GivenStringArray()
        {
            string[] data = { "2020-12-12", "S", "MR" };
            var valiadtionService = new InputValidationService();
            var result = valiadtionService.IsInputValid(data);

            result.Should().BeTrue();
        }
    }
}
