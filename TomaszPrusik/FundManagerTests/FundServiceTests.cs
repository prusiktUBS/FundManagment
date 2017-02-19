using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Type = DomainModel.Type;

namespace FundManagerTests
{
    [TestFixture()]
    public class FundServiceTests
    {
        [Test]
        public void SetMarketValue_MultiplyPriceAndQuantity()
        {
            FundService fs = new FundService();
            var value = fs.SetMarketValue(10, 2);
            Assert.AreEqual(20,value);
        }

        [Test]
        public void SetTransactionCost_MultiplyMVandEquityValue()
        {
            FundService fs = new FundService();
            var mv = fs.SetMarketValue(10, 2);
            var value = fs.SetTransactionCost(mv, Type.Equity);
            Assert.AreEqual(0.1, value);
        }

        [Test]
        public void SetTransactionCost_MultiplyMVandBondValue()
        {
            FundService fs = new FundService();
            var mv = fs.SetMarketValue(10, 2);
            var value = fs.SetTransactionCost(mv, Type.Bond);
            Assert.AreEqual(0.4,value);
        }

        [Test]
        public void SetStockWeight_DivideMVAndTotalSumOfAllMV()
        {
            FundService fs = new FundService();
            var mv = fs.SetMarketValue(10, 1);
            var sw = fs.SetStockWeight(mv, 10);
            Assert.AreEqual(1,sw);
        }
    }
}
