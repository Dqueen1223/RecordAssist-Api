using Catalyte.Apparel.DTOs.Reviews;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Integration
{
    public class ReviewIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetReviews_Returns200()
        {
            var response = await _client.GetAsync("/reviews");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetReviewById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/reviews/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<ReviewsDTO>();
            Assert.Equal(1, content.Id);
        }
    }
}
                                                                                                             //gi