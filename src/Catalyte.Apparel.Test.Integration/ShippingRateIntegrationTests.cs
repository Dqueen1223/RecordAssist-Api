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
        [Fact]
        public async Task ValidStateCorrelatingTo10DollarFeeReturnsOk()
        {
            var response = await _client.GetAsync("shipping-rate?state=Alaska");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var results = await response.Content.ReadAsAsync<decimal>();
            Assert.Equal(10.0M, results);
        }
        [Fact]
        public async Task InvalidStateReturns0()
        {
            var response = await _client.GetAsync("shipping-rate?state=Alaskadf");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var results = await response.Content.ReadAsAsync<decimal>();
            Assert.Equal(0.0M, results);
        }
    }
}