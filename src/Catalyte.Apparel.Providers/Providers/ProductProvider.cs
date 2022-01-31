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
    public class ProductProvider : IProductProvider
    {
        private readonly ILogger<ProductProvider> _logger;
        private readonly IProductRepository _productRepository;

        public ProductProvider(IProductRepository productRepository, ILogger<ProductProvider> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the product with the provided id from the database.
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <returns>The product.</returns>
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            Product product;

            try
            {
                product = await _productRepository.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (product == null || product == default)
            {
                _logger.LogInformation($"Product with id: {productId} could not be found.");
                throw new NotFoundException($"Product with id: {productId} could not be found.");
            }

            return product;
        }
        /// <summary>
        /// Asynchronously retrieves all unique product categories in the database 
        /// </summary>
        /// <returns>list of strings of categories</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        public async Task<List<string>> GetAllUniqueProductCategoriesAsync()
        {
            List<string> categories;

            try
            {
                categories = await _productRepository.GetAllUniqueProductCategoriesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return categories;
        }
        /// <summary>
        /// Asynchronously retrieves all unique product types in the database 
        /// </summary>
        /// <returns>list of strings of categories</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        public async Task<List<string>> GetAllUniqueProductTypesAsync()
        {
            List<string> categories;

            try
            {
                categories = await _productRepository.GetAllUniqueProductTypesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return categories;
        }


        /// <summary>
        /// Asynchronously retrieves all products from the database.
        /// </summary>
        /// <returns>All products in the database.</returns>
        public async Task<IEnumerable<Product>> GetProductsAsync(Nullable<bool> active, List<string> brand, List<string> category,
                                                                 List<string> color, List<string> demographic, List<string> material,
                                                                 decimal minPrice, decimal maxPrice, List<string> type)
        {
            IEnumerable<Product> products;

            // Convert input color code to hex format to match database column label
            List<string> hexColor = new List<string>();
            if (color.Count() > 0)
            {
                foreach(var colorItem in color)
                {
                    hexColor.Add("#" + colorItem.ToLower());
                }
            }

            // Check that minPrice is not greater than maxPrice and minPrice is non-negative
            if (minPrice > maxPrice && !maxPrice.Equals(0))
            {
                throw new ArgumentOutOfRangeException("The minimum price cannot be greater than the maximum price.");
            }
            if (minPrice < 0 || maxPrice < 0)
            {
                throw new ArgumentOutOfRangeException("Prices cannot be negative.");
            }

            // Convert all strings to lowercase for simplified query parameter matching
            List<string> brandLower = brand.ConvertAll(x => x.ToLower());
            List<string> categoryLower = category.ConvertAll(x => x.ToLower());
            List<string> demographicLower = demographic.ConvertAll(x => x.ToLower());
            List<string> materialLower = material.ConvertAll(x => x.ToLower());
            List<string> typeLower = type.ConvertAll(x => x.ToLower());

            try
            {
                products = await _productRepository.GetProductsAsync(active, brandLower, categoryLower, hexColor,
                                                                 demographicLower, materialLower,
                                                                 minPrice, maxPrice, typeLower);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }

    }
}
