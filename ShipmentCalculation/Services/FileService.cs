using ShipmentClculation.Services;
using ShipmentClculation.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipmentClculation.Models.Base;
using ShipmentClculation.Models;

namespace ShipmentClculation.Services
{
    public class FileService : IFileService
    {
        private readonly IMappingService _mappingService;
        private readonly InputValidationService _inputValidationService;
        private readonly string _dataInputUrl = AppDomain.CurrentDomain.BaseDirectory + @"Input.txt";
        private readonly string _dataOutputUrl = AppDomain.CurrentDomain.BaseDirectory + @"Output.txt";

        public FileService()
        {
            _mappingService = new MappingService();
            _inputValidationService = new InputValidationService();
        }

        public IEnumerable<Shipment> Read()
        {
            var shipments = new List<Shipment>();

            var lines = File.ReadAllLines(_dataInputUrl);
            foreach (var line in lines)
            {
                string[] data = line.Split(' ');
                var isValidData = _inputValidationService.IsInputValid(data);
                if (!isValidData)
                {
                    var shipment = _mappingService.MapInvalidInputToObject(data);
                    shipments.Add(shipment);
                }
                else
                {
                    var shipment = _mappingService.MapValidInputToObject(data);
                    shipments.Add(shipment);
                }
            }
            var jsonString = File.ReadAllText(_dataInputUrl);

            return shipments;
        }

        public void Write(IEnumerable<Shipment> shipments)
        {
            var lines = new List<string>();
            foreach(var shipment in shipments)
            {
                var line = "";
                if (shipment.GetType().Equals(typeof(ValidShipment)))
                {
                   line = _mappingService.MapValidObjectToString((ValidShipment)shipment);
                }
                else if (shipment.GetType().Equals(typeof(InvalidShipment)))
                {
                    line = _mappingService.MapInvalidObjectToString((InvalidShipment)shipment);
                }
                lines.Add(line); 
            }
            File.WriteAllLines(_dataOutputUrl, lines);
        }
    }
}
