using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Catalyte.Apparel.Data.Repositories;
using Catalyte.Apparel.API.Controllers;
namespace Test.Unit
{
    public class ProductUnitTest
    {
        private readonly Mock<IProductRepository> _repositoryMock = new();
        private readonly Mock<IProductProvider> _productProviderMock = new();
        private readonly Mock<ILogger<ProductProvider>> _loggerMock = new();

        [Fact]
        public async Task GetAllUniqueProductCategory_returnListOfStrings()
        {
            var test = new List<string> { "test", "test2" };
            //arrange
            _repositoryMock.Setup(repo => repo.GetAllUniqueProductCategoriesAsync())
                .ReturnsAsync(test);

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object);

            //Act
            var actual = await provider.GetAllUniqueProductCategoriesAsync();

            //Assert
            Assert.Equal(test, actual);
        }

        [Fact]
        public async Task GetAllUniqueProductCategory_returnException()
        {
            //arrange
            _repositoryMock.Setup(repo => repo.GetAllUniqueProductCategoriesAsync())
                    .ThrowsAsync(new ServiceUnavailableException("error"));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object);


            //act
            Task actual() => provider.GetAllUniqueProductCategoriesAsync();

            //Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(actual);
        }

        [Fact]
        public async Task GetAllUniqueProductType_returnListOfStrings()
        {
            //arrange
            _repositoryMock.Setup(repo => repo.GetAllUniqueProductTypesAsync())
                    .ThrowsAsync(new ServiceUnavailableException("error"));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object);


            //act
            Task actual() => provider.GetAllUniqueProductTypesAsync();

            //Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(actual);
        }

        [Fact]
        public async Task GetAllUniqueProductType_returnException()
        {
            //arrange
            _repositoryMock.Setup(repo => repo.GetAllUniqueProductTypesAsync())
                    .ThrowsAsync(new ServiceUnavailableException("error"));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object);


            //act
            Task actual() => provider.GetAllUniqueProductTypesAsync();

            //Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(actual);
        }
        [Fact]
        public async Task GetProductsAsync_returnsException()
        {
            //arrange 
            _repositoryMock.Setup(repo => repo.GetProductsAsync(true, null, null, null, null, null, 0, null))
                .ThrowsAsync(new ServiceUnavailableException("There was a problem connecting to the database."));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object);

            //act
            Task actual() => provider.GetProductsAsync(true, null, null, null, null, null, 0, null);

            //assert 
            await Assert.ThrowsAsync<ServiceUnavailableException>(actual);
        }
    }
}

