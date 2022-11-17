using ClassLibrary.Entity;
using Xunit;

namespace ClassLibrary.Test.Entity
{
    public class NormalGoodTest
    {
        [Fact]
        public void RetailPrice_ShouldBe2TimesCostPrice()
        {
            //arrange
            NormalGood product = new NormalGood();
            product.CostPrice = 10;
            //act
            double retailPrice = product.RetailPrice;
            //assert
            Assert.Equal(product.CostPrice * 2, product.RetailPrice);
        }

        [Fact]
        public void ConstructorSetsProperties()
        {
            //act
            NormalGood product = new NormalGood("p1", "Chair", 20);

            //assert
            Assert.Equal("p1", product.Id);
            Assert.Equal("Chair", product.Name);
            Assert.Equal(20, product.CostPrice);
        }
    }
}
