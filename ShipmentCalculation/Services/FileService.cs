using ShipmentClculation.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipmentClculation.Models.Base;

namespace ShipmentClculation.Services
{
    public class FileService : IFileService
    {
        private readonly IMappingService _mappingService;
        private readonly InputValidationService _inputValidationService;

        public FileService()
        {
            _mappingService = new MappingService();
            _inputValidationService = new InputValidationService();
        }

        public string[] Read(string url)
        {
            var shipments = new List<Shipment>();

            return File.ReadAllLines(url);
        }

        public void Write(IEnumerable<string> lines, string url)
        {
            File.WriteAllLines(url, lines);
        }
    }
}
