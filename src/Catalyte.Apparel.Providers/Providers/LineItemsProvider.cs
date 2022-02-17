using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Catalyte.Apparel.Utilities.Validation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IProductProvider interface, providing service methods for products.
    /// </summary>
    public class LineItemsProvider : ILineItemsProvider
    {
            private readonly ILogger<LineItemsProvider> _logger;
            private readonly ILineItemsRepository _lineItemsRepository;

            public LineItemsProvider(ILineItemsRepository lineItemsRepository, ILogger<LineItemsProvider> logger)
            {
                _logger = logger;
                _lineItemsRepository = lineItemsRepository;
            }

            /// <summary>
            /// Asynchronously retrieves the product with the provided id from the database.
            /// </summary>
            /// <param name="productId">The id of the product to retrieve.</param>
            /// <returns>The product.</returns>
            public async Task<LineItem> GetLineItemsByProductIdAsync(int productId)
            {
                LineItem lineItem;

                try
                {
                    lineItem = await _lineItemsRepository.GetLineItemsByProductIdAsync(productId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new ServiceUnavailableException("There was a problem connecting to the database.");
                }

            if (lineItem == null || lineItem == default)
                {
                    _logger.LogInformation($"Line item with product id: {productId} could not be found.");
                    throw new NotFoundException($"Line item with product id: {productId} could not be found.");
                }

                return lineItem;
            }
    }
}
