using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IProductProvider interface, providing service methods for products.
    /// </summary>
    public class ShippingRateProvider : IShippingRateProvider
    {
        private readonly ILogger<ShippingRateProvider> _logger;
        private readonly IShippingRateRepository _shippingRateRepository;

        public ShippingRateProvider(IShippingRateRepository shippingRateRepository, ILogger<ShippingRateProvider> logger)
        {
            _logger = logger;
            _shippingRateRepository = shippingRateRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the product with the provided id from the database.
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <returns>The product.</returns>
        public async Task<decimal> GetProductRateByNameAsync(string state)
        {
            decimal productRate;

            try
            {
                productRate = await _shippingRateRepository.GetProductRateByNameAsync(state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return productRate;
        }

    }
}
