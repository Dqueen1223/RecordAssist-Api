﻿using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Integration
{
    public class PromoIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetPromo_Returns200()
        {
            var responce = await _client.GetAsync("/promo/getstuff");
            Assert.Equal(HttpStatusCode.OK, responce.StatusCode);
        }
    }
}
