using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Type = DomainModel.Type;

namespace TomaszPrusik.ModelOperations
{
    public class Operations : IOperations
    {
        public double SetTotalMarketValue(BindingList<Fund> funds, double marketValue)
        {
            var list = funds.ToList();
            if (list.Count == 0)
            {
                return marketValue;
            }
            var sumOfAllMv = funds.Sum(x => x.MarketValue);
            return sumOfAllMv;
        }

        public void UpdateStockWeight(BindingList<Fund> funds, Market market)
        {
            if (funds.Count > 1)
            {
                Parallel.ForEach(funds, fund =>
                {
                    fund.StockWeight = 0;
                    fund.StockWeight = (fund.MarketValue / market.TotalMarketValue)*100;
                });
            }
            else
            {
                funds[0].StockWeight = 100;
            }
        }

        public void UpdateFundSummary(BindingList<FundSummary> fundsSummary, BindingList<Fund> funds, Market market)
        {
            Parallel.Invoke( 
                ()=> UpdateEquitySummaryRow(fundsSummary, funds, market.TotalMarketValue),
                ()=> UpdateBondSummaryRow(fundsSummary, funds, market.TotalMarketValue),
                ()=> UpdateFundSummaryRow(fundsSummary, funds)
                );
        }

        private void UpdateBondSummaryRow(BindingList<FundSummary> fundsSummary, BindingList<Fund> funds, double marketTotalValue)
        {
            if (funds.Count == 1)
            {
                marketTotalValue = funds[0].MarketValue;
            }
            var row = fundsSummary.SingleOrDefault(x => x.Type == Type.Bond);
            var bonds = funds.Where(x => x.Type == Type.Bond).ToList();
            row.TotalNumber = funds.Count(x => x.Type == Type.Bond);
            var mvSum = bonds.Sum(x => x.MarketValue);
            row.TotalWeight = (mvSum / marketTotalValue) * 100;
            row.TotalMv = mvSum;
        }

        private void UpdateEquitySummaryRow(BindingList<FundSummary> fundsSummary, BindingList<Fund> funds, double marketTotalValue)
        {
            if (funds.Count == 1)
            {
                marketTotalValue = funds[0].MarketValue;
            }
            var row = fundsSummary.SingleOrDefault(x => x.Type == Type.Equity);
            var equities = funds.Where(x => x.Type == Type.Equity).ToList();
            row.TotalNumber = funds.Count(x => x.Type == Type.Equity);
            var mvSum = equities.Sum(x => x.MarketValue);
            row.TotalWeight = (mvSum / marketTotalValue) * 100;
            row.TotalMv = mvSum;
        }

        private void UpdateFundSummaryRow(BindingList<FundSummary> fundsSummary, BindingList<Fund> funds)
        {
            var row = fundsSummary.SingleOrDefault(x => x.Type == Type.Total);
            int bondValue = funds.Count(x => x.Type == Type.Bond);
            int equityValue = funds.Count(x => x.Type == Type.Equity);
            row.TotalNumber = bondValue + equityValue;
            row.TotalWeight = 100;
            row.TotalMv = funds.Sum(x => x.MarketValue);
        }

        public BindingList<FundSummary> InitFundSummary()
        {
            BindingList<FundSummary> newList = new BindingList<FundSummary>();
            newList.Add(new FundSummary
            {
                Type = Type.Bond,
                TotalMv = 0,
                TotalNumber = 0,
                TotalWeight = 0
            });
            newList.Add(new FundSummary
            {
                Type = Type.Equity,
                TotalMv = 0,
                TotalNumber = 0,
                TotalWeight = 0
            });
            newList.Add(new FundSummary
            {
                Type = Type.Total,
                TotalMv = 0,
                TotalNumber = 0,
                TotalWeight = 0
            });
            return newList;
        }
    }
}
