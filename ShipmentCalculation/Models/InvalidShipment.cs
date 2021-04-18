using ShipmentClculation.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Models
{
    public class InvalidShipment : Shipment
    {
        public string ShipmentData { get; set; }
    }
}
