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

namespace Test.Unit
{
    public class ProductUnitTest
    {
        private readonly Mock<ILineItemsRepository> _lineItemsRepoMock = new();
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

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);

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

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);


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

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);


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

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);


            //act
            Task actual() => provider.GetAllUniqueProductTypesAsync();

            //Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(actual);
        }

        [Fact]
        public async Task GetProductsAsync_returnsException()
        {
            //arrange 
            List<string> emptyStringList = new List<string>();
            _repositoryMock.Setup(repo => repo.GetProductsAsync(true, emptyStringList, emptyStringList, emptyStringList,

                emptyStringList, emptyStringList, 0, 100, emptyStringList, 0, 100000))
                .ThrowsAsync(new ServiceUnavailableException("There was a problem connecting to the database."));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);

            //act
            Task actual() => provider.GetProductsAsync(true, emptyStringList, emptyStringList, emptyStringList,
                emptyStringList, emptyStringList, 0, 100, emptyStringList, null);

            //assert 
            await Assert.ThrowsAsync<ServiceUnavailableException>(actual);
        }

        [Fact]
        public async Task GetProductAsync_NegativeReturnsArgumentOutOfRange()
        {
            //Arrange 
            var stringEmptyList = new List<string>();
            _repositoryMock.Setup(repo => repo.GetProductsAsync(true, stringEmptyList, stringEmptyList, stringEmptyList, stringEmptyList, stringEmptyList, -25, 0, stringEmptyList, null, 100000))
           .ThrowsAsync(new BadRequestException("Prices cannot be negative."));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);
            //Act
            Task actual() => provider.GetProductsAsync(true, stringEmptyList, stringEmptyList, stringEmptyList, stringEmptyList, stringEmptyList, -25, 0, stringEmptyList, null);

            //Arrange
            await Assert.ThrowsAsync<BadRequestException>(actual);
        }

        [Fact]
        public async Task GetProductAsync_MinGreaterThanMaxReturnsBadArgumentException()
        {
            //Arrange 
            var stringEmptyList = new List<string>();
            _repositoryMock.Setup(repo => repo.GetProductsAsync(true, stringEmptyList, stringEmptyList, stringEmptyList, stringEmptyList, stringEmptyList, 250, 100, stringEmptyList, null, 100000))
           .ThrowsAsync(new BadRequestException("The minimum price cannot be greater than the maximum price."));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);
            //Act
            Task actual() => provider.GetProductsAsync(true, stringEmptyList, stringEmptyList, stringEmptyList, stringEmptyList, stringEmptyList, 250, 100, stringEmptyList, null);

            //Arrange
            await Assert.ThrowsAsync<BadRequestException>(actual);
        }

        [Fact]
        public async Task GetProductsCountAsync_ReturnsInt()
        {
            //arrange 
            List<string> emptyStringList = new List<string>();
            _repositoryMock.Setup(repo => repo.GetProductsCountAsync(true, emptyStringList, emptyStringList, emptyStringList,
                emptyStringList, emptyStringList, 0, 100, emptyStringList, null, 1000))
                .ReturnsAsync(0);

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);

            //act
            var actual = await provider.GetProductsCountAsync(true, emptyStringList, emptyStringList, emptyStringList,
                emptyStringList, emptyStringList, 0, 100, emptyStringList, null);

            //assert 
            Assert.Equal(0, actual);

        }

        [Fact]
        public async Task DeleteProductByIdAsync_ReturnsNotFound()
        {
            //arrange 
            Product product = new();
            var productId = 1;

            _repositoryMock.Setup(repo => repo.DeleteProductByIdAsync(product))
                .ThrowsAsync(new NotFoundException($"Product with id:{productId} not found."));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);

            //act
            Task actual() => provider.DeleteProductByIdAsync(productId);

            //assert 
            await Assert.ThrowsAsync<NotFoundException>(actual);
        }

        [Fact]
        public async Task DeleteProductByIdAsync_ReturnsHasPurchases()
        {
            //arrange 
            Product product = new();
            var productId = 1;

            _lineItemsRepoMock.Setup(repo => repo.GetLineItemsByProductIdAsync(productId))
                .ReturnsAsync(true);
            _repositoryMock.Setup(repo => repo.GetProductByIdAsync(productId)).ReturnsAsync(product);
            _repositoryMock.Setup(repo => repo.DeleteProductByIdAsync(product)).ThrowsAsync(new BadRequestException($"Product with id: {productId} has purchases associated with it."));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);

            //act
            Task actual() => provider.DeleteProductByIdAsync(productId);

            //assert 
            await Assert.ThrowsAsync<BadRequestException>(actual);
        }

        [Fact]
        public async Task DeleteProductByIdAsync_DeletesProduct()
        {
            //arrange 
            var product = new Product
            {
                Id = 1
            };

            _lineItemsRepoMock.Setup(repo => repo.GetLineItemsByProductIdAsync(product.Id))
                .ReturnsAsync(false);
            _repositoryMock.Setup(repo => repo.GetProductByIdAsync(product.Id)).ReturnsAsync(product);
            _repositoryMock.Setup(repo => repo.DeleteProductByIdAsync(product)).ReturnsAsync(product);

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);

            //act
            var actual = await provider.DeleteProductByIdAsync(product.Id);

            //assert 
            Assert.Equal(product.Id, actual.Id);
        }

        [Fact]
        public async Task CheckForPurchasesByProductId_ReturnsUnavailable()
        {
            //arrange 
            var product = new Product
            {
                Id = 1
            };

            _lineItemsRepoMock.Setup(repo => repo.GetLineItemsByProductIdAsync(product.Id))
                .ThrowsAsync(new ServiceUnavailableException("There was a problem connecting to the database."));

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object, _lineItemsRepoMock.Object);

            //act
            Task actual() => provider.CheckForPurchasesByProductIdAsync(product.Id, product);

            //assert 
            await Assert.ThrowsAsync<ServiceUnavailableException>(actual);
        }
    }
}

