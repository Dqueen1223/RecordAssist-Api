using Catalyte.Apparel.DTOs.ShippingRate;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Integration
{
    public class ShippingRateIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task ValidStateCorrelatingTo5DollarFeeReturnsOk()
        {
            var response = await _client.GetAsync("shipping-rate?state=Illinois");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var results = await response.Content.ReadAsAsync<decimal>();
            Assert.Equal(5.0M, results);
        }
    }
}