using ShipmentClculation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipmentClculation.Models.Base;
using ShipmentClculation.Data;
using ShipmentClculation.Services;

namespace ShipmentClculation.Models
{
    public class ValidShipment : Shipment
    {
        public DateTime VintDate { get; set; }
        public PackageSizes PackageSize { get; set; }
        public CarrierCodes CarrierCode { get; set; }
        public PricingRule Rule { get; set; }

        public ValidShipment(DateTime vintDate, PackageSizes packageSize, CarrierCodes carrierCode)
        {
            VintDate = vintDate;
            MonthlyDiscountService.UpdateDiscountsOnNewMonth(VintDate);
            PackageSize = packageSize;
            CarrierCode = carrierCode;
            SetPricingRule(PackageSize, CarrierCode);
        }

        public void SetPricingRule(PackageSizes size, CarrierCodes code)
        {
            switch (code)
            {
                case CarrierCodes.LP:
                    switch (size)
                    {
                        case PackageSizes.S:
                            Rule = new Regular(size, code);
                            break;
                        case PackageSizes.M:
                            Rule = new Regular(size, code);
                            break;
                        case PackageSizes.L:
                            if (DiscountData.LargaParcelCount == 3)
                            {
                                Rule = new PromotionLargeParcel(size, code);
                            }
                            else
                            {
                                Rule = new Regular(size, code);
                            }
                            DiscountData.LargaParcelCount++;
                            break;
                    }
                    break;
                case CarrierCodes.MR:
                    switch (size)
                    {
                        case PackageSizes.S:
                            Rule = new PromotionSmallParcel(size, code);
                            break;
                        case PackageSizes.M:
                            Rule = new Regular(size, code);
                            break;
                        case PackageSizes.L:
                            Rule = new Regular(size, code);
                            break;
                    }
                    break;
            }
        }
    }
}
