using ShipmentClculation.Interfaces;
using ShipmentClculation.Services;
using ShipmentClculation.Writers;
using System;
using System.IO;

namespace ShipmentCalculation
{
    class Program
    {
        public static string dataInputUrl = AppDomain.CurrentDomain.BaseDirectory + @"Input.txt";
        public static string dataOutputUrl = AppDomain.CurrentDomain.BaseDirectory + @"Output.txt";
        public static void RunCalculation()
        {
            IFileService _fileService = new FileService();
            IWriter _writer = new ConsoleWriter();
            var shipments = _fileService.ReadInput(dataInputUrl);
            _fileService.Write(shipments, dataOutputUrl);
            var lines = _fileService.ReadOutput(dataOutputUrl);
            foreach (var line in lines)
            {
                _writer.Write(line);
            }
            _writer.Read();
        }
        static void Main(string[] args)
        {
            RunCalculation();
        }
    }
}
