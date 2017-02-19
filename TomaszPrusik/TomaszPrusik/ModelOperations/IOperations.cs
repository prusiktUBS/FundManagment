using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace TomaszPrusik.ModelOperations
{
    public interface IOperations
    {
        double SetTotalMarketValue(BindingList<Fund> funds, double marketValue);
        void UpdateStockWeight(BindingList<Fund> funds, Market market);
        void UpdateFundSummary(BindingList<FundSummary> fundsSummary, BindingList<Fund> funds, Market market);
        BindingList<FundSummary> InitFundSummary();
    }
}
