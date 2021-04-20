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
        string[] Read(string url);
        void Write(IEnumerable<string> shipmentsLines, string url);
    }
}
