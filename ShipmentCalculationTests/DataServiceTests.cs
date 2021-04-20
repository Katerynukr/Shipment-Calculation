using FluentAssertions;
using ShipmentCalculation.Services;
using ShipmentClculation.Enums;
using ShipmentClculation.Models;
using ShipmentClculation.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShipmentCalculationTests
{
    public class DataServiceTests
    {
        [Fact]
        public void CreateShipments_GivenStringArray_ReturnShipmentList()
        {
            string[] data = { "2015-02-01 M MR", "2015-02-02 S MR", "2015-02-03 L LP" };
            var dataService = new DataService();
            var result = dataService.CreateShipments(data);

            result.Should().NotBeEmpty();
            result.First().Should().BeOfType<InvalidShipment>();
            result.Should().BeOfType<Shipment>();
            result.Count().Should().Be(3);
        }


        [Fact]

        public void CreateTextLines_GivenShipmetnsList_ReturnsStringList()
        {
            var shipments = new List<Shipment>()
            {
                new ValidShipment(new DateTime(2020-12-12), PackageSizes.M, CarrierCodes.LP),
                new InvalidShipment()
                {
                 ShipmentData = "invalid data"
                }
            };
            var dataService = new DataService();
            var result = dataService.CreateTextLines(shipments);

            result.Should().NotBeEmpty();
            result.Count().Should().Be(2);
        }
    }
}
