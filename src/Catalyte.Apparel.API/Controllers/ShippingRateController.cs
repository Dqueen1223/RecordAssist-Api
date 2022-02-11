using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalyte.Apparel.Providers.Interfaces;
using AutoMapper;
namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The ShippingRateController exposes endpoints for shipping rate related actions.
    /// </summary>
    [ApiController]
    [Route("/shipping-rate")]
    public class ShippingRateController : ControllerBase
    {
        private readonly ILogger<ShippingRateController> _logger;
        private readonly IShippingRateProvider _shippingRateProvider;
        private readonly IMapper _mapper;

        public ShippingRateController(
            ILogger<ShippingRateController> logger,
            IShippingRateProvider shippingRateProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _shippingRateProvider = shippingRateProvider;
        }
        [HttpGet]
        public async Task<ActionResult<decimal>> GetProductRateByNameAsync(string state)
        {
            _logger.LogInformation("Request received for GetProductsAsync");

            var rate = await _shippingRateProvider.GetProductRateByNameAsync(state);

            return Ok(rate);
        }
    }
}
