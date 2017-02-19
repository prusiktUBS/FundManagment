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
using TomaszPrusik.ModelOperations;
using Type = DomainModel.Type;

namespace TomaszPrusik.ViewModels
{
    public class FundViewModel
    {
        public FundViewModel()
        {
            FundSummary = _operations.InitFundSummary();
        }
        private readonly IFundService _fundService = ServiceLocator.Current.GetInstance<IFundService>();
        private readonly IOperations _operations = ServiceLocator.Current.GetInstance<IOperations>();

        public BindingList<Fund> Funds = new BindingList<Fund>();
        public BindingList<FundSummary> FundSummary;

        public Market _Market = new Market(100);
        
        public void AddBond(string name, double price, double quantity)
        {
            var marketValue = _fundService.SetMarketValue(price, quantity);
            var transactionCost = _fundService.SetTransactionCost(marketValue, Type.Bond);
            var stockWeight = _fundService.SetStockWeight(marketValue, _Market.TotalMarketValue);
            AddToTheFund(Type.Bond, name, price, quantity, marketValue, transactionCost, stockWeight);
            _Market.TotalMarketValue = _operations.SetTotalMarketValue(Funds, marketValue);
            _operations.UpdateStockWeight(Funds, _Market);
            SetState(Funds);
        }
        public void AddEquity(string name, double price, double quantity)
        {
            var marketValue = _fundService.SetMarketValue(price, quantity);
            var transactionCost = _fundService.SetTransactionCost(marketValue, Type.Equity);
            var stockWeight = _fundService.SetStockWeight(marketValue, _Market.TotalMarketValue);
            AddToTheFund(Type.Equity, name, price, quantity, marketValue, transactionCost, stockWeight);
            _Market.TotalMarketValue = _operations.SetTotalMarketValue(Funds, marketValue);            
            _operations.UpdateStockWeight(Funds, _Market);
            SetState(Funds);
        }
        private void SetState(BindingList<Fund> funds)
        {
            if (funds.Last().Type == Type.Bond)
            {
                SetStateForBond(funds.Last());
            }
            else
            {
                SetStateForEquity(funds.Last());
            }
        }

        private void SetStateForEquity(Fund entry)
        {
            if (entry.TransactionCost >= 200000)
            {
                entry.State = 1;
            }
            else
            {
                entry.State = 0;
            }
        }

        private void SetStateForBond(Fund entry)
        {
            if (entry.TransactionCost >= 100000)
            {
                entry.State = 1;
            }
            else
            {
                entry.State = 0;
            }
        }
        
        private int _id = 0;
        private void AddToTheFund(Type type, string name, double price, double quantity, double marketValue, double transactionCost, double stockWeight)
        {
            if (Funds.Count == 0)
            {
                _id = 1;
            }
            Funds.Add(new Fund(_id, type, name, price, quantity, marketValue, transactionCost, stockWeight));            
            _id = _id++;
        }

        public void UpdateSummaryTable()
        {
            _operations.UpdateFundSummary(FundSummary,Funds,_Market);
        }
    }
}
