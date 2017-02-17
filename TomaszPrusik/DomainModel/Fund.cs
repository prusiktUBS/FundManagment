using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Fund : BaseEntity
    {
        public Type Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double MarketValue { get; set; }
        public double TransactionCost { get; set; }
        public double StockWeight { get; set; }

        public Fund(Type type, string name, double price, int quantity, double marketValue, double transactionCost, double stockWeight)
        {
            Type = type;
            Name = name;
            Price = price;
            Quantity = quantity;
            MarketValue = marketValue;
            TransactionCost = transactionCost;
            StockWeight = stockWeight;
        }
    }
}
