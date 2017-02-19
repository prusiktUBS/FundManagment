using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Market
    {
        public double TotalMarketValue { get; set; }

        public Market(double initialValue)
        {
            TotalMarketValue = initialValue;
        }
    }

}
