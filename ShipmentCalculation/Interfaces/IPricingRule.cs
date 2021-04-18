using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentClculation.Interfaces
{
    public interface IPricingRule
    {
        public static decimal MonthlyDiscount = 10.00M;
        void GeneratePricing();
    }
}
