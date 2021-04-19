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
    }
}
