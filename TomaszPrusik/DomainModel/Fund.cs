using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DomainModel.Annotations;

namespace DomainModel
{
    public class Fund : BaseEntity, INotifyPropertyChanged
    {
        public Type Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double MarketValue { get; set; }
        public double TransactionCost { get; set; }
        public double _StockWeight { get; set; }
        public int State { get; set; }
        public Fund(int id,Type type, string name, double price, double quantity, double marketValue, double transactionCost, double stockWeight)
        {
            Id = id;
            Type = type;
            Name = name;
            Price = price;
            Quantity = quantity;
            MarketValue = marketValue;
            TransactionCost = transactionCost;
            _StockWeight = stockWeight;
        }

        public double StockWeight
        {
            get { return _StockWeight; }
            set
            {
                _StockWeight = value;
                OnPropertyChanged("_StockWeight");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
