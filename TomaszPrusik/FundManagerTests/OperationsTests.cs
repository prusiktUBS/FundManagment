using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using NUnit.Framework;
using TomaszPrusik.ModelOperations;
using TomaszPrusik.ViewModels;
using Type = DomainModel.Type;

namespace FundManagerTests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void SetTotalMarketValue_AcceptFunds_ShouldReturnSumOfAllMV()
        {
            var funds = new BindingList<Fund>();
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            Operations operations = new Operations();
            var totalMarketValue = operations.SetTotalMarketValue(funds, 1);
            Assert.AreEqual(36, totalMarketValue);
        }

        [Test]
        public void SetTotalMarketValue_IfListIsEmptyReturnPriceMultiplyByQuantity()
        {
            var funds = new BindingList<Fund>();
            Operations operations = new Operations();
            FundService fundService = new FundService();

            var value = operations.SetTotalMarketValue(funds, fundService.SetMarketValue(10, 1));
            Assert.AreEqual(10, value);
        }

        [Test]
        public void UpdateStockWeight_TakeAllEntriesAndUpdateStockWeight()
        {
            var funds = new BindingList<Fund>();
            Operations operations = new Operations();
            Market market = new Market(1);
            FundService fundService = new FundService();
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            market.TotalMarketValue = operations.SetTotalMarketValue(funds, 1);
            operations.UpdateStockWeight(funds, market);
            Assert.AreNotEqual(100, funds[0].StockWeight);
            Assert.AreEqual(25, funds[1].StockWeight);
            Assert.AreEqual(25, funds[2].StockWeight);
            Assert.AreEqual(25, funds[3].StockWeight);
        }
        [Test]
        public void UpdateStockWeight_OnlyOneEntry_Return100()
        {
            var funds = new BindingList<Fund>();
            Operations operations = new Operations();
            Market market = new Market(1);
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 10));
            market.TotalMarketValue = operations.SetTotalMarketValue(funds, 1);
            operations.UpdateStockWeight(funds, market);
            Assert.AreEqual(funds[0]._StockWeight, 100);
        }

        [Test]
        public void UpdateFundSummary_UpdateSummaryTableAfterAddingBondData()
        {
            Operations operations = new Operations();
            DI.Register();
            var fundViewModel = new FundViewModel();
            var funds = new BindingList<Fund>();
            var market = new Market(1);
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            operations.UpdateFundSummary(fundViewModel.FundSummary, funds, market);

            Assert.AreEqual(
                fundViewModel.FundSummary.SingleOrDefault(x => x.Type == Type.Total).TotalNumber, 4);            
        }

        [Test]
        public void UpdateFundSummary_UpdateSummaryTableAfterAddingMixData()
        {
            Operations operations = new Operations();
            DI.Register();
            var fundViewModel = new FundViewModel();
            var funds = new BindingList<Fund>();
            var market = new Market(1);
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Equity, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            operations.UpdateFundSummary(fundViewModel.FundSummary, funds, market);

            Assert.AreEqual(
                fundViewModel.FundSummary.SingleOrDefault(x => x.Type == Type.Equity)._TotalNumber, 1);
        }

        [Test]
        public void UpdateFundSummary_UpdateSummaryTableFirstTime()
        {
            Operations operations = new Operations();
            DI.Register();
            var fundViewModel = new FundViewModel();
            var funds = new BindingList<Fund>();
            var market = new Market(1);
            funds.Add(new Fund(1, Type.Bond, "Bond 1", 12, 1, 12, 0.24, 100));
            operations.UpdateFundSummary(fundViewModel.FundSummary, funds, market);

            Assert.AreEqual(
                fundViewModel.FundSummary.SingleOrDefault(x => x.Type == Type.Bond)._TotalNumber, 1);
        }
    }
}
