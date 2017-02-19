using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.interfaces;

namespace DomainModel
{
    public class FundService : IFundService
    {
        private readonly double _equityTc = Convert.ToDouble(ConfigurationManager.AppSettings["equityTc"]);
        private readonly double _bondTc = Convert.ToDouble(ConfigurationManager.AppSettings["bondTc"]);        

        public double SetMarketValue(double price, double quantity)
        {
            var marketValue = price * quantity;
            return marketValue;
        }

        public double SetTransactionCost(double marketValue, Type type)
        {
            if (type == Type.Equity)
                return SetEquityTransactionCost(marketValue);

            return SetBondTransactionCost(marketValue);
        }

        private double SetBondTransactionCost(double marketValue)
        {
            var bondTransactionCost = marketValue * _bondTc;
            return bondTransactionCost;
        }

        private double SetEquityTransactionCost(double marketValue)
        {
            var equityTransactionCost = marketValue * _equityTc;
            return equityTransactionCost;
        }

        public double SetStockWeight(double marketValue, double totalMarketValue)
        {
            return marketValue / totalMarketValue;
        }
    }
}
