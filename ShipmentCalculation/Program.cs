using ShipmentCalculation.Services;
using ShipmentClculation.Interfaces;
using ShipmentClculation.Services;
using ShipmentClculation.Writers;
using System;
using System.Collections.Generic;
using System.IO;

namespace ShipmentCalculation
{
    class Program
    {
        public static string dataInputUrl = AppDomain.CurrentDomain.BaseDirectory + @"Input.txt";
        public static string dataOutputUrl = AppDomain.CurrentDomain.BaseDirectory + @"Output.txt";
     
        public static void OutputResult(IEnumerable<string> lines, IWriter _writer)
        {
            foreach (var line in lines)
            {
                _writer.Write(line);
            }
            _writer.Read();
        }
        public static void RunCalculation()
        {
            IFileService _fileService = new FileService();
            IWriter _writer = new ConsoleWriter();
            DataService _dataService = new DataService();

            var textLines = _fileService.Read(dataInputUrl);
            var shipments = _dataService.CreateShipments(textLines);
            var shipmentsLines = _dataService.CreateTextLines(shipments);
            _fileService.Write(shipmentsLines, dataOutputUrl);
            var lines = _fileService.Read(dataOutputUrl);
            OutputResult(lines, _writer);
           
        }
        static void Main(string[] args)
        {
            RunCalculation();
        }
    }
}
