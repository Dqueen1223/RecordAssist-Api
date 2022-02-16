using Catalyte.Apparel.DTOs.Products;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

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
        public async Task GetAllUniqueProductCategoriesAsync_ReturnsNoDuplicates()
        {
            var response = await _client.GetAsync("/products/categories");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<string>>();

            Assert.True(content.Distinct().Count() == content.Count());
        }
        [Fact]
        public async Task GetAllUniqueProductTypes_ReturnsNoDuplicates()
        {
            var response = await _client.GetAsync("/products/types");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<string>>();

            Assert.True(content.Distinct().Count() == content.Count());
        }
        [Fact]
        public async Task GetProductsAsync_ReturnsLessThan1000Products()
        {
            var response = await _client.GetAsync("/products?active=true");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsAsync<List<ProductDTO>>();
            var actual = 1000;
            Assert.True(result.Count < actual);
        }
        [Fact]
        public async Task GetProductsAsync_ReturnsActiveProductsOnly()
        {
            var response = await _client.GetAsync("/products?active=true");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.True(result.Active == true);
            }
        }
        [Fact]
        public async Task GetProductsAsync_FilterByMenAndWomenDontReturnKids()
        {
            var response = await _client.GetAsync("/products?demographic=men&demographic=women");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.True(result.Demographic != "Kids");
            }
        }
        [Fact]
        public async Task GetProductsAsync_FilterByMenAndWomenReturnMenAndWomen()
        {
            var response = await _client.GetAsync("/products?demographic=men&demographic=women");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.True(result.Demographic == "Men" || result.Demographic == "Women");
            }
        }
        [Fact]
        public async Task GetProductsAsync_FilterByMenAndWomenAndNonexistantMaterialReturnsEmpty()
        {
            var response = await _client.GetAsync("/products?demographic=men&demographic=women&material=doesNotExist");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            Assert.Empty(results);
        }
        [Fact]
        public async Task GetProductsAsync_FilterByValueIgnoringUpperLowerReturnsSameResult()
        {
            var response = await _client.GetAsync("/products?demographic=wOMeN&brand=REEboK&category=bOXiNg");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //var response2 = await _client.GetAsync("/products?demographic=wOMeN&brand=REEboK");
            //Assert.Equal(HttpStatusCode.OK, response2.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            //var results2 = await response2.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.True(result.Demographic == "Women" && result.Brand == "Reebok");
            }
        }
        [Fact]
        public async Task GetProductAsync_FilterByKidsAndNikeReturnsKidsAndNike()
        {
            var response = await _client.GetAsync("/products?demographic=Kids&brand=Nike");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.True(result.Demographic == "Kids" && result.Brand == "Nike");
            }
        }
        [Fact]
        public async Task GetProductAsync_FilterByKidsOrMenAndNikeAndMinPrice100ReturnsTrue()
        {
            var response = await _client.GetAsync("/products?demographic=Kids&demographic=Men&brand=Nike&maxPrice=100");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.True((result.Demographic == "Kids" || result.Demographic == "Men") && result.Brand == "Nike" && result.Price < 100);

            }
        }
        [Fact]
        public async Task GetProductAsync_ColorCodeReturnsToHexFormatTrue()
        {
            var response = await _client.GetAsync("/products?color=637a91");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.True(result.PrimaryColorCode == "#637a91" || result.SecondaryColorCode == "#637a91");
            }
        }
        [Fact]
        public async Task GetProductAsync_ColorCodeReturnsToHexFormatFalse()
        {
            var response = await _client.GetAsync("/products?color=637a91");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.False(result.PrimaryColorCode == "637a91" || result.SecondaryColorCode == "637a91");
            }
        }
        [Fact]
        public async Task GetProductAsync_HexFormatHasCaps()
        {
            var response = await _client.GetAsync("/products?color=637A91");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var results = await response.Content.ReadAsAsync<List<ProductDTO>>();
            foreach (var result in results)
            {
                Assert.True(result.PrimaryColorCode == "#637a91" || result.SecondaryColorCode == "#637a91");
            }
        }
        [Fact]
        public async Task GetProductsCountAsync_ReturnsForAllProducts()
        {
            var response = await _client.GetAsync("/products/count");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsAsync<int>();
            Assert.True(result > 0);
        }
        [Fact]
        public async Task GetProductsCountAsync_Returns20WhenRangeSpecified()
        {
            var response = await _client.GetAsync("/products/count?range=0");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsAsync<int>();
            Assert.True(result == 20);
        }
    }
}
//gi