using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit
{
    public class ShippingRateUnitTest
    {
        private readonly Mock<IShippingRateRepository> _repositoryMock = new();
        private readonly Mock<IShippingRateProvider> _shippingRateProviderMock = new();
        private readonly Mock<ILogger<ShippingRateProvider>> _loggerMock = new();

        
        [Fact]
        public async Task GetShippingRate_ReturnsCurrectly()
        {
            //arrange 
            string stateName = "Alaska";
            _repositoryMock.Setup(repo => repo.GetProductRateByNameAsync("Alaska"))
                .ReturnsAsync(10.0M);

            var provider = new ShippingRateProvider(_repositoryMock.Object, _loggerMock.Object);

            //act
            var actual = await provider.GetProductRateByNameAsync(stateName);

            //assert 
            Assert.Equal(10.0M, actual);

        }
    }
}

