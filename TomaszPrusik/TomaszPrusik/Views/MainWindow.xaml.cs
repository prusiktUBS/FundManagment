using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DomainModel;
using TomaszPrusik.Validation;
using TomaszPrusik.ViewModels;
using Type = DomainModel.Type;

namespace TomaszPrusik
{
    public partial class MainWindow : Window
    {
        readonly FundViewModel _viewModel = new FundViewModel();
        readonly Validations _validation= new Validations();

        private int b = 1;
        private int z = 1;
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            FundDisplayGrid.ItemsSource = _viewModel.Funds;
            FundSummaryGrid.ItemsSource = _viewModel.FundSummary;
        }

        private void DisplayConfirmation()
        {
            MessageBox.Show("Entry Added");
        }

        private void CleanTextBoxes()
        {
            BondQuantityTextBox.Text = String.Empty;
            BondPriceTextBox.Text = String.Empty;
            EquityPriceTextBox.Text = String.Empty;
            EquityQuantityTextBox.Text = String.Empty;
        }

        private void AddBond_OnClick(object sender, RoutedEventArgs e)
        {
            if (_validation.Validate(BondPriceTextBox.Text, BondQuantityTextBox.Text))
            {
                _viewModel.AddBond(@"Bond " + b.ToString(), double.Parse(BondPriceTextBox.Text), double.Parse(BondQuantityTextBox.Text));
                _viewModel.UpdateSummaryTable();
                DisplayConfirmation();
                CleanTextBoxes();
                b = b + 1;
            }
            else
            {
                DisplayValidationBox();
            }
        }

        private void DisplayValidationBox()
        {
            MessageBox.Show("Incorrect input");
        }

        private void AddEquity_OnClick(object sender, RoutedEventArgs e)
        {
            if (_validation.Validate(EquityPriceTextBox.Text, EquityQuantityTextBox.Text))
            {
                _viewModel.AddEquity(@"Equity " + z.ToString(), double.Parse(EquityPriceTextBox.Text),
                    double.Parse(EquityQuantityTextBox.Text));
                _viewModel.UpdateSummaryTable();
                DisplayConfirmation();
                CleanTextBoxes();
                z = z + 1;
            }
            else
            {
                DisplayValidationBox();
            }
        }
    }
}
