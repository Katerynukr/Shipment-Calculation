using ShipmentClculation.Writers;
using ShipmentClculation.Enums;
using ShipmentClculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Services
{
    public class InputValidationService
    {
        private readonly IWriter _writer = new ConsoleWriter();

        public bool IsInputValid(string[] input)
        {
            if( IsValidDate(input[0]) &&
            IsValidPackageSize(input[1]) &&
            IsValidCarrierCode(input[2]))
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
        private bool IsValidDate(string dateString)
        {
            try
            {
                DateTime.Parse(dateString);
                return true;
            }
            catch (Exception)
            {
                var s=  dateString;
                _writer.Write("Date input is not valid");
                return false;
            }
        }

        private bool IsValidPackageSize(string sizeString)
        {
            try
            {
                var size = (PackageSizes) Enum.Parse(typeof(PackageSizes), sizeString);
                return true;
            }
            catch (Exception)
            {
                _writer.Write("Package size input is not valid");
                return false;
            }
        }

        private bool IsValidCarrierCode(string codeString)
        {
            try
            {
                var code = (CarrierCodes)Enum.Parse(typeof(CarrierCodes), codeString);
                return true;
            }
            catch (Exception)
            {
                _writer.Write("Carrier code input is not valid");
                return false;
            }
        }
    }
}
