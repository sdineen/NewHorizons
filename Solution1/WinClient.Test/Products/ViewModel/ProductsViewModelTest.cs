using ClassLibrary.Entity;
using Moq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using WinClient.Products.Model.Service;
using WinClient.Products.ViewModel;
using Xunit;

namespace WinClient.Test.Products.ViewModel
{
    public class ProductsViewModelTest
    {
        [Fact]
        public void SearchPropertySetter_ShouldCallProductsPropertySetter()
        {
            //arrange
            Mock<IRestServiceClient> doc = new Mock<IRestServiceClient>();
            
            IEnumerable<Product> products = new List<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42)};

            doc.Setup(client => client.SelectByNameAsync("")).Returns(Task.FromResult(products));
            SimpleProductsViewModel viewModel = new SimpleProductsViewModel(doc.Object);

            // Act
            viewModel.Search = ""; //set the Search property

            // Assert
            Assert.Equal(products, viewModel.Products); //get the Products property
        }

        [Fact]
        public void ProductsProperty_ShouldRaisePropertyChangedEvent()
        {
            //arrange
            Mock<IRestServiceClient> doc = new Mock<IRestServiceClient>();
            SimpleProductsViewModel viewModel = new SimpleProductsViewModel(doc.Object);

            //add a delegate instance to the ViewModel's PropertyChanged event to enable tracking
            bool eventRaised = false;
            PropertyChangedEventArgs eventArgs = null;
            ((INotifyPropertyChanged)viewModel).PropertyChanged +=
                (object sender, PropertyChangedEventArgs e) => { eventRaised = true; eventArgs = e; };

            // Act
            viewModel.Products = null; //sets Products property

            // Assert
            Assert.True(eventRaised);
            Assert.Equal("Products", eventArgs.PropertyName);
        }

    }
}

