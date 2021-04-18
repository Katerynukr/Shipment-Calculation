using ShipmentClculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Writers
{
    public class ConsoleWriter : IWriter
    {

        public void Write(string input)
        {
            Console.WriteLine(input);
        }
    }
}

