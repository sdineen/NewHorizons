using System;
using System.Collections.Generic;
using System.Text;
using WinClient.Primes.Model;
using Xunit;

namespace WinClient.Test.Primes.Model
{
    public class PrimesModelTest
    {
        [Theory]
        [InlineData(1e1, 4)]
        [InlineData(1e2, 25)]
        [InlineData(1e3, 168)]
        [InlineData(1e4, 1229)]
        [InlineData(1e5, 9592)]
        [InlineData(1e6, 78498)]
        [InlineData(1e7, 664579)]
        public async void PrimeCountAsyncTest(int limit, int count)
        {
            //arramge
            PrimesModel primesModel = new PrimesModel();
            //act
            int actual = await primesModel.CountAsync(limit);
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
        [InlineData(1e7, 664579)]
        public void PrimeCountTest(int limit, int count)
        {
            //arramge
            PrimesModel primesModel = new PrimesModel();
            //act
            int actual = primesModel.Count(limit);
            //assert
            Assert.Equal(count, actual);
        }


    }
}
