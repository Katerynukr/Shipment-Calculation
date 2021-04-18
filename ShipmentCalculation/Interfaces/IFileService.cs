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
        IEnumerable<Shipment> Read();
        void Write(IEnumerable<Shipment> shipments);
    }
}
