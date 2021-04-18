using ShipmentClculation.Models;

namespace ShipmentClculation.Interfaces
{
    public interface IMappingService
    {
        ValidShipment MapValidInputToObject(string[] data);
        InvalidShipment MapInvalidInputToObject(string[] data);
        string MapValidObjectToString(ValidShipment shipment);
        string MapInvalidObjectToString(InvalidShipment shipment);
    }
}