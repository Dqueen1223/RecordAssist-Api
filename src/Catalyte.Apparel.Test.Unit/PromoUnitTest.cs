using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Unit
{
    public class PromoUnitTest
    {
        private readonly Mock<ILogger<PromoProvider>> _loggerMock = new();
        private readonly Mock<IPromoProvider> _providerMock = new();
        private readonly Mock<IPromoRepository> _repositoryMock = new();

        [Fact]
        public async Task CreatePromoAsync_Created()
        {
            Promo promo = new();
            promo.Code = "abc123";
            promo.Discount = 20;
            promo.StartDate = DateTime.Parse("10/11/2021");
            promo.EndDate = DateTime.Parse("10/11/2022");
            promo.Type = "%";

            _repositoryMock.Setup(repo => repo.CreatePromoAsync(promo)).ReturnsAsync(promo);
            var promoProvider = new PromoProvider(_repositoryMock.Object, _loggerMock.Object);
            var actual = await promoProvider.CreatePromoAsync(promo);
            Assert.Equal(promo, actual);
        }
        [Fact]
        public async Task CreatePromoAsync_BadRequest()
        {
            Promo promo = new();
            promo.Code = "";
            promo.Discount = 0;
            try
            {
                _repositoryMock.Setup(repo => repo.CreatePromoAsync(promo)).ReturnsAsync(promo);
                var promoProvider = new PromoProvider(_repositoryMock.Object, _loggerMock.Object);
                var actual = await promoProvider.CreatePromoAsync(promo);
                Assert.True(false);
            }
            catch (BadRequestException)
            {
                Assert.True(true);
            }
        }
    }
}


