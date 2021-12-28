using Catalyte.Apparel.DTOs.Products;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Catalyte.Apparel.Test.Integration
{
    public class ProductIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetProducts_Returns200()
        {
            var response = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProductById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/products/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<ProductDTO>();
            Assert.Equal(1, content.Id);
        }
        [Fact]
        public async Task GetAllUniqueProductCategoriesAsync()
        {
            var response = await _client.GetAsync("/products/categories");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<string>>();
            var expected = new List<string> {"Golf", "Soccer", "Basketball", "Hockey", "Football", "Running",
            "Baseball", "Skateboarding", "Boxing", "Weightlifting"};
            expected.Sort();
            content.Sort();

            Assert.Equal(expected,content);
        }
        [Fact]
        public async Task GetAllUniqueProductTypesc()
        {
            var response = await _client.GetAsync("/products/types");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<string>>();
            var expected = new List<string> {"Pant", "Short", "Shoe", "Glove", "Jacket", "Tank Top", "Sock", "Sunglasses",
            "Hat", "Helmet", "Belt", "Visor", "Shin Guard", "Elbow Pad", "Headband", "Wristband", "Hoodie", "Flip Flop", 
            "Pool Noodle"};
            expected.Sort();
            content.Sort();

            Assert.Equal(expected, content);
        }
    }
}
