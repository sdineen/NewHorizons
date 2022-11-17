using ClassLibrary.Entity;
using WinClient.Products.Model.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;

namespace WinClient.Products.ViewModel
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; //use to notify change in Bound properties
        private IRestServiceClient restServiceClient; //call web service
        private bool authenticated; //asign from Login button handler


        //Inject dependency on Web Service
        public ProductsViewModel(IRestServiceClient restServiceClient)
        {
            this.restServiceClient = restServiceClient;
            LoadProducts();
            LinkCommands();
        }

        private async void LoadProducts()
        {
            try
            {
                Products = await restServiceClient.SelectByNameAsync(Search);
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex.Message);
            }
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

        //Bound to Text property of Username TextBox
        public string Username { get; set; } = "acc1";

        //Bound to Password property of Username TextBox
        public string Password { get; set; } = "test";

        //Bound to SelectedItem property of DataGrid
        public Product SelectedProduct { get; set; }


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


        //Bound to ItemsSource property of Basket DataGrid
        private IEnumerable<LineItem> lineItems;

        public IEnumerable<LineItem> LineItems
        {
            get => lineItems;
            set
            {
                lineItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LineItems"));
            }
        }

        private void LinkCommands()
        {
            //Initialize LoginCommand property with CustomCommand
            //Login is an Action that determines what the command does 
            //CanLogin is a predicate that determines whether the component is enabled
            LoginCommand = new CustomCommand(Login, CanLogin);
            AddProductCommand = new CustomCommand(AddProduct, CanAddProduct);
            PurchaseCommand = new CustomCommand(Purchase, CanPurchase);
        }

        //Bound to Command property of Login Button
        public CustomCommand LoginCommand { get; private set; }

        //Bound to Command property of Add Button
        public CustomCommand AddProductCommand { get; private set; }
        //Bound to Command property of Purchase Button
        public CustomCommand PurchaseCommand { get; private set; }

        private async void Login(object obj)
        {
            authenticated = await restServiceClient.Authenticate(Username, Password);
            if (authenticated)
            {
                Order order = await restServiceClient.GetBasket(Username).ConfigureAwait(false);
                LineItems = order.LineItems;
            }
        }
        private bool CanLogin(object obj) =>
            !authenticated && !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);


        private async void AddProduct(object obj)
        {
            Order order = await restServiceClient.AddProductToOrder(SelectedProduct.Id, Username);
            LineItems = order.LineItems;
        }
        private bool CanAddProduct(object obj) =>
            authenticated && SelectedProduct != null;

        private async void Purchase(object obj)
        {
            bool confirmed = await restServiceClient.ConfirmOrder(Username);
            if (confirmed)
            {
                LineItems = null;
            }
        }
        private bool CanPurchase(object obj) =>
            LineItems != null && LineItems.Count() > 0;

    }
}

