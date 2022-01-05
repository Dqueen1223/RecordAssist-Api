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
namespace Catalyte.Apparel.Test.Unit
{
    public class PurchaseUnitTest
    {
        private readonly Mock<IPurchaseRepository> _purchaseRepositoryMock = new();
        private readonly Mock<ILogger<PurchaseProvider>> _purchaseLoggerMock = new();
        private readonly Mock<IProductProvider> _productProvider = new();
        [Fact]
        public async Task GetAllPurchasesByEmailAsync_ReturnsAllPurchases()
        {
            //Arrange
            List<Purchase> purchases = new();
            Purchase purchase1 = new();
            purchase1.BillingEmail = "Customer@home.com";
            purchases.Add(purchase1);
            Purchase purchase2 = new();
            purchase2.BillingEmail = "Customer@home.com";
            purchases.Add(purchase2);

            _purchaseRepositoryMock.Setup(repo => repo.GetAllPurchasesByEmailAsync("Customer@home.com"))
            .ReturnsAsync(purchases);

            var purchaseProvider = new PurchaseProvider(_purchaseRepositoryMock.Object, _purchaseLoggerMock.Object, _productProvider.Object, null);
            //Act
            var actual = await purchaseProvider.GetAllPurchasesByEmailAsync("Customer@home.com");
            //Assert
            Assert.Equal(purchases, actual);
        }
        [Fact]
        public async Task GetAllPurchasesByEmailAsync_NonExistingEmail_ReturnsEmptyArray()
        {
            //Arrange
            List<Purchase> purchases = new();

            _purchaseRepositoryMock.Setup(repo => repo.GetAllPurchasesByEmailAsync("Customer@home.com"))
            .ReturnsAsync(purchases);

            var purchaseProvider = new PurchaseProvider(_purchaseRepositoryMock.Object, _purchaseLoggerMock.Object, _productProvider.Object, null);
            //Act
            var actual = await purchaseProvider.GetAllPurchasesByEmailAsync("Customer@home.com");
            //Assert
            Assert.Empty(actual);
        }
        [Fact]
        public async Task GetAllPurchasesByEmailAsync_NoEmail_Returns404mMessage()
        {
            //Arrange 
            _purchaseRepositoryMock.Setup(repo => repo.GetAllPurchasesByEmailAsync(null))
           .ThrowsAsync(new NotFoundException("No email specified for request."));

            var purchaseProvider = new PurchaseProvider(_purchaseRepositoryMock.Object, _purchaseLoggerMock.Object, _productProvider.Object, null);
            //Act
            Task actual() => purchaseProvider.GetAllPurchasesByEmailAsync(null);
            //Arrange
            await Assert.ThrowsAsync<NotFoundException>(actual);
        }
    }
}
