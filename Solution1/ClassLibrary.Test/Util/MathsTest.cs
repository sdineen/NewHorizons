using ClassLibrary.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ClassLibrary.Test.Util
{
    public class MathsTest
    {
        [Fact]
        public void Factorial_ShouldReturnCorrectValues()
        {
            //act
            double actual = Maths.Factorial(5);
            //assert
            Assert.Equal(120, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        public void Factorial_ParameterizedTest(int n, double expected)
        {
            //act
            double actual = Maths.LinqFactorial(n);
            //assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        public void RecursiveFactorialTest(int n, double expected)
        {
            //act
            double actual = Maths.RecursiveFactorial(n);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Factorial_NegativeArgument_ShouldThrowArgumentOutOfRangeException()
        {
            //act
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Maths.Factorial(-1));
        }

        [Theory]
        [InlineData(10, 2, 45)]
        [InlineData(52, 4, 270725)]
        public void Combination_ParameterizedTest(int n, int r, double expected)
        {
            //act
            double actual = Maths.Combination(n, r);
            //assert
            Assert.Equal(expected, actual, 5); //precision in decimal places
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(47, true)]
        [InlineData(48, false)]
        public void IsPrimeTest(int n, bool expected)
        {
            //act
            bool actual = Maths.IsPrime(n);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Fibonacci_ShouldReturnCorrectSequence()
        {
            int[] expected = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            int[] actual = Maths.Fibonacci(10);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1e1, 4)]
        [InlineData(1e2, 25)]
        [InlineData(1e3, 168)]
        [InlineData(1e4, 1229)]
        [InlineData(1e5, 9592)]
        [InlineData(1e6, 78498)]
       // [InlineData(1e7, 664579)]
        public void PrimesCountTest(int limit, int count)
        {
            //act
            int actual = Maths.PrimesCount(limit);
            //assert
            Assert.Equal(count, actual);
        }

        [Theory]
        [InlineData(1e1, 4)]
        [InlineData(1e2, 25)]
        [InlineData(1e3, 168)]
        [InlineData(1e4, 1229)]
        [InlineData(1e5, 9592)]
        [InlineData(1e6, 78498)]
       // [InlineData(1e7, 664579)]
        public async void PrimesCountAsyncTest(int limit, int count)
        {
            //act
            int actual = await Maths.PrimesCountAsync(limit);
            //assert
            Assert.Equal(count, actual);
        }


    }
}
