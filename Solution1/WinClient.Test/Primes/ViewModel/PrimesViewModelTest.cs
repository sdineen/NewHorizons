using Moq;
using System.ComponentModel;
using WinClient.Primes.Model;
using WinClient.Primes.ViewModel;
using Xunit;

namespace WinClient.Test.Primes.ViewModel
{
    public class PrimesViewModelTest
    {
        [Fact]
        public void ResultProperty_ShouldRaiseEventNamedResult()
        {
            //arrange
            Mock<IPrimesModel> primesModelMock = new Mock<IPrimesModel>();
            PrimesViewModel viewModel = new PrimesViewModel(primesModelMock.Object);

            //add a delegate instance to the ViewModel's PropertyChanged event to enable tracking
            bool eventRaised = false;
            PropertyChangedEventArgs eventArgs = null;
            ((INotifyPropertyChanged)viewModel).PropertyChanged +=
                (object sender, PropertyChangedEventArgs e) => { eventRaised = true; eventArgs = e; };

            // Act
            viewModel.Result = "168";

            // Assert
            Assert.True(eventRaised);
            Assert.Equal("Result", eventArgs.PropertyName);
        }

        [Fact]
        public void LimitProperty_SetTo1000_ShouldCallCountAsyncMethodOfPrimesModel()
        {
            //arrange
            Mock<IPrimesModel> primesModelMock = new Mock<IPrimesModel>();
            PrimesViewModel viewModel = new PrimesViewModel(primesModelMock.Object);

            //act
            viewModel.Limit = 1000;

            //assert
            primesModelMock.Verify(pm => pm.CountAsync(1000));
        }

        [Fact]
        public void LimitProperty_SetTo1000_ResultPropertyShouldContain168()
        {
            //arrange
            Mock<IPrimesModel> primesModelMock = new Mock<IPrimesModel>();
            primesModelMock.Setup(pm => pm.CountAsync(1000)).ReturnsAsync(168);
            primesModelMock.Setup(pm => pm.CountAsync(1000000)).ReturnsAsync(78498);
            PrimesViewModel viewModel = new PrimesViewModel(primesModelMock.Object);

            //act
            viewModel.Limit = 1000;

            //assert
            Assert.Contains("168", viewModel.Result);
        }

        [Fact]
        public void StartButton_ShouldCallCountMethodOfPrimesModel()
        {
            //arrange
            Mock<IPrimesModel> primesModelMock = new Mock<IPrimesModel>();
            PrimesViewModel viewModel = new PrimesViewModel(primesModelMock.Object);

            // Act
            viewModel.StartCommand.Execute(null);

            // Assert
            primesModelMock.Verify(pm => pm.CountAsync(It.IsAny<int>()));

        }

        [Fact]
        public void StartButton_WhenLimitIs1000_ResultPropertyContains168()
        {
            //arrange
            Mock<IPrimesModel> primesModelMock = new Mock<IPrimesModel>();
            primesModelMock.Setup(pm => pm.CountAsync(1000)).ReturnsAsync(168);
            primesModelMock.Setup(pm => pm.CountAsync(1000000)).ReturnsAsync(78498);
            PrimesViewModel viewModel = new PrimesViewModel(primesModelMock.Object);
            viewModel.Limit = 1000;
            viewModel.Result = null;

            // Act
            viewModel.StartCommand.Execute(null);

            // Assert
            Assert.Contains("168", viewModel.Result);
        }

    }
}
