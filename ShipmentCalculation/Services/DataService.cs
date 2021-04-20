using ShipmentClculation.Interfaces;
using ShipmentClculation.Models;
using ShipmentClculation.Models.Base;
using ShipmentClculation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentCalculation.Services
{
    public class DataService
    {

        private readonly InputValidationService _inputValidationService;
        private readonly IMappingService _mappingService;

        public DataService()
        {
            _mappingService = new MappingService();
            _inputValidationService = new InputValidationService();
        }
        public string[] SplitTextInput(string text)
        {
            return text.Split(' ');
        }

        private bool CheckInputValidation(string[] data)
        {
            return _inputValidationService.IsInputValid(data);
        }

        public IEnumerable<Shipment> CreateShipments(string[] textLines)
        {
            var shipments = new List<Shipment>();

            foreach(var line in textLines)
            {
                var data = SplitTextInput(line);
                var isValidData = CheckInputValidation(data);
                Shipment shipment = isValidData ? CreateValidShipment(data) : CreateInvalidShipment(data);
                shipments.Add(shipment);
            }
           
            return shipments;
        }

        private ValidShipment CreateValidShipment(string[] data)
        {
            return _mappingService.MapValidInputToObject(data);
        }

        private InvalidShipment CreateInvalidShipment(string[] data)
        {
            return _mappingService.MapInvalidInputToObject(data);
        }

        public IEnumerable<string> CreateTextLines(IEnumerable<Shipment> shipments)
        {
            var lines = new List<string>();
            foreach (var shipment in shipments)
            {
                var line = "";
                if (shipment.GetType().Equals(typeof(ValidShipment)))
                    line = CreateValidInputShipmentString((ValidShipment)shipment);
                else if (shipment.GetType().Equals(typeof(InvalidShipment)))
                    line = CreateInvalidInputShipmentString((InvalidShipment)shipment);
                lines.Add(line);
            }
            return lines;
        }

        private string CreateValidInputShipmentString(ValidShipment shipment)
        {
            return _mappingService.MapValidObjectToString(shipment);
        }

        private string CreateInvalidInputShipmentString(InvalidShipment shipment)
        {
            return _mappingService.MapInvalidObjectToString(shipment);
        }
    }
}
