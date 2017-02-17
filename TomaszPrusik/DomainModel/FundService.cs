using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.interfaces;

namespace DomainModel
{
    public class FundService : IFundService
    {
        private readonly double _equityTc;
        private readonly double _bondTc;

        public FundService(double equityTc, double bondTc)
        {
            _equityTc = equityTc;
            _bondTc = bondTc;
        }

        public double SetMarketValue(double price, int quantity)
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
