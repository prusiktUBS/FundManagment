using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TomaszPrusik.DependencyInjection;
using TomaszPrusik.ModelOperations;
using TomaszPrusik.ViewModels;
using Type = DomainModel.Type;

namespace FundManagerTests
{
    [TestFixture()]
    class FundViewModelTests
    {
        [Test]
        public void AddBond_AddsNewBonToGrid()
        {
            DI.Register();
            FundViewModel viewModel = new FundViewModel();

            viewModel.AddBond("Bond 1", 12, 1);
            Assert.AreEqual("Bond 1", viewModel.Funds[0].Name);
            Assert.AreEqual(1, viewModel.Funds.Count);
        }

        [Test]
        public void AddEquity_AddsNewEquityToGrid()
        {
            DI.Register();
            FundViewModel viewModel = new FundViewModel();

            viewModel.AddEquity("Equity 1", 12, 1);
            Assert.AreEqual("Equity 1", viewModel.Funds[0].Name);
            Assert.AreEqual(1, viewModel.Funds.Count);
        }

        [Test]
        public void SetBondState_SetColorForRed1()
        {
            DI.Register();
            FundViewModel viewModel = new FundViewModel();

            viewModel.AddBond("bond 1", 10, 1000000);
            Assert.AreEqual(1, viewModel.Funds[0].State);
        }
        [Test]
        public void SetBondState_SetColorForGreen()
        {
            DI.Register();
            FundViewModel viewModel = new FundViewModel();

            viewModel.AddBond("bond 1", 10, 100);
            Assert.AreEqual(0, viewModel.Funds[0].State);
        }

        [Test]
        public void SetEquityState_SetColorRed1()
        {
            DI.Register();
            FundViewModel viewModel = new FundViewModel();

            viewModel.AddEquity("equity 1", 1000, 1000000);
            Assert.AreEqual(1, viewModel.Funds[0].State);
        }

        [Test]
        public void SetEquityState_SetColorGreen0()
        {
            DI.Register();
            FundViewModel viewModel = new FundViewModel();

            viewModel.AddEquity("equity 1", 10, 1000000);
            Assert.AreEqual(0, viewModel.Funds[0].State);
        }

        [Test]
        public void UpdateSummaryTable_UpdateTableAfterAddingEntry()
        {
            DI.Register();
            FundViewModel viewModel = new FundViewModel();
            viewModel.AddBond("Bond 1",10,10);
            viewModel.UpdateSummaryTable();

            Assert.AreEqual(
                viewModel.FundSummary.SingleOrDefault(x=>x.Type== Type.Total)._TotalMv, 100);
        }
    }
}
