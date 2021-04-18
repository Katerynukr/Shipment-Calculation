using ShipmentClculation.Interfaces;
using ShipmentClculation.Services;
using System;
using System.IO;

namespace ShipmentCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string date = DateTime.Now.ToString();
            
            Console.WriteLine(date);
            Console.ReadLine();*/
            IFileService service = new FileService();
            var shipments = service.Read();
            service.Write(shipments);
            
            var lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Output.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            service.Read();
        }
    }
}
