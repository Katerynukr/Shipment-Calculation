using ShipmentClculation.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Interfaces
{
    public interface IFileService
    {
        IEnumerable<Shipment> ReadInput(string url);
        void Write(IEnumerable<Shipment> shipments, string url);
        string[] ReadOutput(string url);
    }
}
