using MyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Test
{
    public class MathsTest
    {
        [Fact]
        public void FactorialTest()
        {
            double result = Maths.Factorial(5);
            Assert.Equal(120, result);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        public void Factorial_ParameterizedTest(int n, double expected)
        {
            //act
            double actual = Maths.Factorial(n);
            //assert
            Assert.Equal(expected, actual);
        }

    }
}
