using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Windows;
using WinClient.Primes.Model;
using WinClient.Primes.View;
using WinClient.Primes.ViewModel;
using WinClient.Products.Model.Service;
using WinClient.Products.View;
using WinClient.Products.ViewModel;
//using WinClient.Products.View;
//using WinClient.Products.ViewModel;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
           

            //retrieve ProductsView from the IServiceCollection, then call its Show method
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            //serviceProvider.GetService<MainWindow>().Show();
            //serviceProvider.GetService<ProductList>().Show();
            //SimpleProductsView productsView = serviceProvider.GetService<SimpleProductsView>();
            ProductsView productsView = serviceProvider.GetService<ProductsView>();
            productsView.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<MainWindow>();
            //services.AddSingleton<ProductList>();

            services.AddSingleton<ProductsView>();
            services.AddSingleton<ProductsViewModel>();

            services.AddSingleton<SimpleProductsView>();
            services.AddSingleton<SimpleProductsViewModel>();

            //string uri = "https://sdineen.uk";
            string uri = "https://localhost:44369";
            Func<IServiceProvider, RestServiceClient> factory = 
                provder => new RestServiceClient(uri);

            //the factory describes how to instantiate 
            services.AddSingleton<IRestServiceClient, RestServiceClient>(factory);
        }
    }
}
