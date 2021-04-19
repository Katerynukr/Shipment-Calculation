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
    public class InputValidationService : IInputValidationService
    {
        public bool IsInputValid(string[] input)
        {
            if (IsValidDate(input[0]) &&
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
        public bool IsValidDate(string dateString)
        {
            try
            {
                DateTime.Parse(dateString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidPackageSize(string sizeString)
        {
            try
            {
                var size = (PackageSizes)Enum.Parse(typeof(PackageSizes), sizeString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidCarrierCode(string codeString)
        {
            try
            {
                var code = (CarrierCodes)Enum.Parse(typeof(CarrierCodes), codeString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
