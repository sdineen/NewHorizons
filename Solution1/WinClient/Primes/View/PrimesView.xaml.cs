using System.Windows;
using WinClient.Primes.ViewModel;

namespace WinClient.Primes.View
{
    /// <summary>
    /// Interaction logic for PrimeCounterView.xaml
    /// </summary>
    public partial class PrimesView : Window
    {
        public PrimesView(PrimesViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
