using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DomainModel;
using DomainModel.interfaces;
using Microsoft.Practices.ServiceLocation;
using Type = DomainModel.Type;

namespace TomaszPrusik.ViewModels
{
    public class FundViewModel : INotifyPropertyChanged
    {
        private readonly IFundService _fundService = ServiceLocator.Current.GetInstance<IFundService>();

        public List<Fund> Funds = new List<Fund>();
        public double TotalMarketValue = 0;

        public void AddBond(string name, double price, int quantity)
        {
            var marketValue = _fundService.SetMarketValue(price, quantity);
            var transactionCost = _fundService.SetTransactionCost(marketValue, Type.Bond);
            var stockWeight = _fundService.SetStockWeight(marketValue, TotalMarketValue);
            AddToTheFund(Type.Bond, name, price, quantity, marketValue, transactionCost, stockWeight);
        }

        public void AddEquity(string name, double price, int quantity)
        {
            var marketValue = _fundService.SetMarketValue(price, quantity);
            var transactionCost = _fundService.SetTransactionCost(marketValue, Type.Equity);
            var stockWeight = _fundService.SetStockWeight(marketValue, TotalMarketValue);
            AddToTheFund(Type.Equity, name, price, quantity, marketValue, transactionCost, stockWeight);
        }

        private void AddToTheFund(Type type, string name, double price, int quantity, double marketValue, double transactionCost, double stockWeight)
        {
            Funds.Add(new Fund(type, name,price,quantity,marketValue,transactionCost,stockWeight));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
