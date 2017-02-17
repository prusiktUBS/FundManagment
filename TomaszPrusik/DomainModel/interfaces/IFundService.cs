using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.interfaces
{
    public interface IFundService
    {
        double SetMarketValue(double price, int quantity);
        double SetTransactionCost(double marketValue, Type type);
        double SetStockWeight(double marketValue, double totalMarketValue);
    }
}
