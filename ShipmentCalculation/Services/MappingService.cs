using ShipmentClculation.Models;
using ShipmentClculation.Enums;
using ShipmentClculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipmentClculation.Models.Base;

namespace ShipmentClculation.Services
{
    public class MappingService : IMappingService
    { 
        public ValidShipment MapValidInputToObject(string[] data)
        {
            var date = ParseStringToDate(data[0]);
            var size = ParseStringToPackageSize(data[1]);
            var code = ParseStringToCarrierCode(data[2]);
            var shipment = new ValidShipment(date, size, code);
            return shipment;
        }

        private DateTime ParseStringToDate(string dateString)
        {
            return DateTime.Parse(dateString);
        }

        private PackageSizes ParseStringToPackageSize(string sizeString)
        {
            return (PackageSizes)Enum.Parse(typeof(PackageSizes), sizeString);
        }

        private CarrierCodes ParseStringToCarrierCode(string codeString)
        {
            return (CarrierCodes)Enum.Parse(typeof(CarrierCodes), codeString);
        }

        public InvalidShipment MapInvalidInputToObject(string[] data)
        {
            string dataString = string.Join(' ', data);
            return new InvalidShipment()
            {
                ShipmentData = dataString
            };
        }

        public string MapValidObjectToString(ValidShipment shipment)
        {
            string[] data ={
                ParseDateToString(shipment.VintDate),
                ParsePackageSizeToString(shipment.PackageSize),
                ParseCarrierCodeToString(shipment.CarrierCode),
                ParsePriceToString(shipment.Rule),
                ParseDiscountToString(shipment.Rule)

            };
            return string.Join(' ', data);
        }

        private string ParseDateToString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        private string ParseCarrierCodeToString(CarrierCodes code)
        {
            return Enum.GetName(code);
        }

        private string ParsePriceToString(PricingRule rule)
        {
            return rule.Price.ToString();
        }

        private string ParseDiscountToString(PricingRule rule)
        {
            if (rule.Discount != null)
                return rule.Discount.ToString();
            else
                return "-";
        }

        private string ParsePackageSizeToString(PackageSizes size)
        {
            return Enum.GetName(size);
        }

        public string MapInvalidObjectToString(InvalidShipment shipment)
        {
            var ignoreMessage = " Ignored";
            var data = shipment.ShipmentData + ignoreMessage;
            return data;
        }
    }
}
