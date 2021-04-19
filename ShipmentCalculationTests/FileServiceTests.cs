using FluentAssertions;
using Moq;
using ShipmentClculation.Enums;
using ShipmentClculation.Interfaces;
using ShipmentClculation.Models;
using ShipmentClculation.Models.Base;
using ShipmentClculation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShipmentCalculationTests
{
    public class FileServiceTests
    {
        [Fact]
        public void ReadInput_GivenInputUrl_ReternsListOfShipments()
        {
            string dataInputUrl = AppDomain.CurrentDomain.BaseDirectory + @"Input.txt";
            var fileService = new FileService();
            var result = fileService.ReadInput(dataInputUrl);

            result.Should().NotBeEmpty();
            result.First().Should().BeOfType<ValidShipment>();
            result.Count().Should().Be(21);
        }

        [Fact]
        public void ReadOutput_GivenOutputUrl_ReturnsArrayOfString()
        {
            string dataOutputUrl = AppDomain.CurrentDomain.BaseDirectory + @"Output.txt";
            var shipments = new List<Shipment>(){
                new ValidShipment(new DateTime(2002-12-12), PackageSizes.S, CarrierCodes.LP),
                new InvalidShipment()
                {
                    ShipmentData = "Invalid Shipment"
                }
            };
            var fileService = new FileService();
            fileService.Write(shipments, dataOutputUrl);
            var result = fileService.ReadOutput(dataOutputUrl);

            result.Should().NotBeEmpty();
            result.Count().Should().Be(2);
            result.First().Should().BeOfType<string>();
        }
    }
}
