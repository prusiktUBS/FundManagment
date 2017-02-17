using System;
using System.Collections.Generic;
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
using TomaszPrusik.ViewModels;

namespace TomaszPrusik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly FundViewModel _viewModel = new FundViewModel();

        public MainWindow()
        {
            InitializeComponent();
			this.DataContext = new FundViewModel();
		}

        

        private void AddBond_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.AddBond( _viewModel.BondPriceTextBox, 2, 2);
        }
    }
}
