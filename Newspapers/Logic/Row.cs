using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newspapers.Logic
{
    public class Row
    {
        public double day { get; set; }
        public double rndDemand { get; set; } = -1;
        public double demand { get; set; } = -1;
        public double rndOrdered { get; set; } = -1;
        public double order { get; set; } = -1;
        public double cost { get; set; } = -1;
        public double repayment {get; set; } = -1;
        public double lostSalesCost { get; set; } = -1;
        public double dailyNetCost { get; set; } = -1;
        public double dailyAveregeCost { get; set; } = -1;
    }
}
