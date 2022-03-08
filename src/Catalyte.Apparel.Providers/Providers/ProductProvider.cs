using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Catalyte.Apparel.Utilities.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly ILineItemsRepository _lineItemsRepository;

        public ProductProvider(IProductRepository productRepository, ILogger<ProductProvider> logger, ILineItemsRepository lineItemsRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _lineItemsRepository = lineItemsRepository;
        }

        /// <summary>
        /// Asynchronously retrieves nontracked product with the provided id from the database.
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <returns>The product.</returns>
        ///  /// <summary>
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
        public async Task<Product> NoTrackingGetProductByIdAsync(int productId)
        {
            Product product;

            try
            {
                product = await _productRepository.NoTrackingGetProductByIdAsync(productId);
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

        public async Task<int> GetProductsCountAsync(Nullable<bool> active, List<string> brand, List<string> category,
                                                                 List<string> color, List<string> demographic, List<string> material,
                                                                 decimal minPrice, decimal maxPrice, List<string> type, int? range)
        {
            {
                int productsCount;

                int returnProducts = 20;
                if (range == null)
                {
                    returnProducts = 100000;
                    range = 0;
                }
                // Convert input color code to hex format to match database column label
                List<string> hexColor = new List<string>();
                if (color.Count() > 0)
                {
                    foreach (var colorItem in color)
                    {
                        hexColor.Add("#" + colorItem.ToLower());
                    }
                }

                List<string> brandLower = brand.ConvertAll(x => x.ToLower());
                List<string> categoryLower = category.ConvertAll(x => x.ToLower());
                List<string> demographicLower = demographic.ConvertAll(x => x.ToLower());
                List<string> materialLower = material.ConvertAll(x => x.ToLower());
                List<string> typeLower = type.ConvertAll(x => x.ToLower());

                // Check that minPrice is not greater than maxPrice and minPrice is non-negative
                if (minPrice < 0 || maxPrice < 0)
                {
                    _logger.LogInformation("Prices cannot be negative.");
                    throw new BadRequestException("Prices cannot be negative.");
                }
                if (minPrice > maxPrice && !maxPrice.Equals(0))
                {
                    _logger.LogInformation("The minimum price cannot be greater than the maximum price.");
                    throw new BadRequestException("The minimum price cannot be greater than the maximum price.");
                }

                try
                {
                    productsCount = await _productRepository.GetProductsCountAsync(active, brandLower, categoryLower, hexColor,
                                                                 demographicLower, materialLower,
                                                                 minPrice, maxPrice, typeLower, range, returnProducts);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new ServiceUnavailableException("There was a problem connecting to the database.");
                }

                return productsCount;
            }
        }
        /// <summary>
        /// Asynchronously retrieves all products from the database.
        /// </summary>
        /// <returns>All products in the database.</returns>
        public async Task<IEnumerable<Product>> GetProductsAsync(Nullable<bool> active, List<string> brand, List<string> category,
                                                                 List<string> color, List<string> demographic, List<string> material,
                                                                 decimal minPrice, decimal maxPrice, List<string> type, int? range)
        {
            IEnumerable<Product> products;

            int returnProducts = 20;
            if (range == null)
            {
                returnProducts = 100000;
                range = 0;
            }
            // Convert input color code to hex format to match database column label
            List<string> hexColor = new List<string>();
            if (color.Count() > 0)
            {
                foreach (var colorItem in color)
                {
                    hexColor.Add("#" + colorItem.ToLower());
                }
            }

            // Check that minPrice is not greater than maxPrice and minPrice is non-negative
            if (minPrice < 0 || maxPrice < 0)
            {
                _logger.LogInformation("Prices cannot be negative.");
                throw new BadRequestException("Prices cannot be negative.");
            }
            if (minPrice > maxPrice && !maxPrice.Equals(0))
            {
                _logger.LogInformation("The minimum price cannot be greater than the maximum price.");
                throw new BadRequestException("The minimum price cannot be greater than the maximum price.");
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
                                                                 minPrice, maxPrice, typeLower, range, returnProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }
<<<<<<< HEAD
        /// <summary>
        /// Asynchronously updates product with new product information
        /// </summary>
        /// <param name="updatedProduct"></param>
        /// <returns> The updated product</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Product> UpdateProductAsync (Product updatedProduct)
=======
        public async Task<Product> UpdateProductAsync(Product updatedProduct)
>>>>>>> 9699060a1501738035f211424c34bcbc601369d1
        {
            Product newProduct;

            Product existingProduct;
            try
            {
                existingProduct = await _productRepository.NoTrackingGetProductByIdAsync(updatedProduct.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (existingProduct == null)
            {
                _logger.LogInformation($"Product with id: {updatedProduct.Id} does not exist.");
                throw new NotFoundException($"Product with id:{updatedProduct.Id} not found.");
            }
            try
            {
                newProduct = await _productRepository.UpdateProductAsync(updatedProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            List<string> errors = Validation.ProductValidation(updatedProduct);
            if (errors.Count > 0)
            {
                throw new BadRequestException(string.Join(' ', errors));
            }
            return newProduct;
        }
        /// <summary>
        /// Persists a purchase to the database.
        /// </summary>
        /// <param name="model">PurchaseDTO used to build the purchase.</param>
        /// <returns>The persisted purchase with IDs.</returns>
        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            Product savedProduct;


            List<string> errors = Validation.ProductValidation(newProduct);
            if (errors.Count > 0)
            {
                throw new BadRequestException(string.Join(' ', errors));
            }
            try
            { 
                savedProduct = await _productRepository.CreateProductAsync(newProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return savedProduct;
        }

        /// <summary>
        /// Deletes a product by the product id.
        /// </summary>
        /// <param name="id">The id of the product to be deleted</param>
        /// <returns>the deleted product object</returns>
        public async Task<Product> DeleteProductByIdAsync(int id)
        {
            Product existingProduct;
            Product deletedProduct;
            bool purchasedProduct;
            try
            {
                existingProduct = await _productRepository.GetProductByIdAsync(id);
                purchasedProduct = await CheckForPurchasesByProductIdAsync(id, existingProduct);
                if (existingProduct == null)
                {
                    _logger.LogInformation($"Product with id: {id} does not exist.");
                    throw new NotFoundException($"Product with id:{id} not found.");
                }
                else if (purchasedProduct)
                {
                    _logger.LogInformation($"Product with id: {id} has purchases associated with it.");
                    throw new BadRequestException($"Product with id: {id} has purchases associated with it.");
                }
                else
                {
                    deletedProduct = await _productRepository.DeleteProductByIdAsync(existingProduct);
                    return deletedProduct;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }



        }

        /// <summary>
        /// Helper function for DeleteProductByIdAsync to check for purchases associated with the product before deleting.
        /// </summary>
        /// <param name="productId">Id of the product to be deleted.</param>
        /// <param name="product">The product object that will be deleted.</param>
        /// <returns>A product with purchases or null if there are no purchases.</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        public async Task<bool> CheckForPurchasesByProductIdAsync(int productId, Product product)
        {
            bool purchaseLineItems;
            try
            {
                purchaseLineItems = await _lineItemsRepository.GetLineItemsByProductIdAsync(productId);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return purchaseLineItems;
        }
    }
}
