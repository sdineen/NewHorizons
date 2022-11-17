using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WinClient.Products.ViewModel;

namespace WinClient.Products.View
{
    /// <summary>
    /// Interaction logic for SimpleProductsView.xaml
    /// </summary>
    public partial class SimpleProductsView : Window
    {
        public SimpleProductsView(SimpleProductsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
