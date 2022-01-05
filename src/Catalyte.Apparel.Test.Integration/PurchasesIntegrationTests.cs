using Catalyte.Apparel.DTOs.Purchases;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Integration
{
    public class PurchaseIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetAllPurchasesByEmailAsync_ValidEmail_ReturnsOK()
        {
            var response = await _client.GetAsync("/Purchases?email=customer@home.com");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var results = await response.Content.ReadAsAsync<List<PurchaseDTO>>();
            foreach (var result in results)
            {
                Assert.Equal("customer@home.com", result.BillingAddress.Email);
            }
        }
        [Fact]
        public async Task GetAllPurchasesByEmailAsync_NonExistingEmail_ReturnsAnEmptyArray()
        {
            var response = await _client.GetAsync("/Purchases?email=custome3r@home.com");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadAsAsync<List<PurchaseDTO>>();
            Assert.Empty(result);
        }
        [Fact]

        public async Task GetAllPurchasesByEmailAsync_NoEmail_Returns404()
        {
            var response = await _client.GetAsync("/Purchases");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}