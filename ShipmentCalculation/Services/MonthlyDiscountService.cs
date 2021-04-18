using ShipmentClculation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Services
{
    public static class MonthlyDiscountService
    {
        public static void UpdateDiscountsOnNewMonth(DateTime shipmentDate)
        {
            if (shipmentDate.Day == 1 )
            {
                DiscountData.DiscountAmount = 10.00M;
                DiscountData.IsLargeParcelDiscounted = false;
            }     
        }
    }
}
