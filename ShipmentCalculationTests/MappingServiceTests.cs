using FluentAssertions;
using ShipmentClculation.Enums;
using ShipmentClculation.Models;
using ShipmentClculation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShipmentCalculationTests
{
    public class MappingServiceTests
    {
        [Fact]
        public void MapValidInputToObject_GivenStringArray_ReturnsValidShipment()
        {
            string[] data =
            {
                "2020-12-12",
                "S",
                "LP"
            };
            var mappingService = new MappingService();
            var result = mappingService.MapValidInputToObject(data);

            result.Should().NotBeNull();
        }

        [Fact]
        public void MapInvalidInputToObject_GivenStringArray_ReturnsInvalidShipment()
        {
            string[] data = { "This", "is invalid", "object" };
            var mappingService = new MappingService();
            var result = mappingService.MapInvalidInputToObject(data);

            result.Should().NotBeNull();
            result.Should().BeOfType<InvalidShipment>();
        }

        [Fact]
        public void MapInvalidObjectToString_GivenObject_ReturnsString()
        {
            var shipment = new InvalidShipment() {
                ShipmentData = "This is invalid object"
            };
            var mappingService = new MappingService();
            var result = mappingService.MapInvalidObjectToString(shipment);

            result.Should().NotBeNull();
            result.Should().EndWith("Ignored");
        }

        [Fact]
        public void MapValidObjectToString_GivenObject_ReturnsString()
        {
            var shipment = new ValidShipment(new DateTime(2020 - 12 - 12), PackageSizes.S, CarrierCodes.MR);
            var mappingService = new MappingService();
            var result = mappingService.MapValidObjectToString(shipment);

            result.Should().NotBeNull();
            result.Should().BeOfType<string>();
        }
    }
}
