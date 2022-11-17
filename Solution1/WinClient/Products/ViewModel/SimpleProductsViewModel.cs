using ClassLibrary.Entity;
using WinClient.Products.Model.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace WinClient.Products.ViewModel
{
    public class SimpleProductsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; //use to notify change in Bound properties
        private IRestServiceClient restServiceClient; //call web service

        //Inject dependency on Web Service
        public SimpleProductsViewModel(IRestServiceClient restServiceClient)
        {
            this.restServiceClient = restServiceClient;
            LoadProducts();
        }

        private async void LoadProducts()
        {
            Products = await restServiceClient.SelectByNameAsync(Search);
        }

        //Bound to Text property of Search TextBox. Updates DataGrid
        private string search;
        public string Search
        {
            get => search;
            set
            {
                search = value;
                LoadProducts();
            }
        }

        //Bound to ItemsSource property of Products DataGrid
        private IEnumerable<Product> products;
        public IEnumerable<Product> Products
        {
            get => products;
            set
            {
                products = value;
                //PropertyChanged null if there are no subscribers to the event, 
                //due to DataContext not being set
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Products"));
            }
        }
    }
}
