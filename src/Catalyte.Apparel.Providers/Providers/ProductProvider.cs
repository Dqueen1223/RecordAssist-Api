using AutoMapper;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities;
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
        /// Asynchronously retrieves all products from the database.
        /// </summary>
        /// <returns>All products in the database.</returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }

        /// <summary>
        /// Asynchronously retrieves the products with the provided brand from the database.
        /// </summary>
        /// <param name="productBrand">The brand of the products to retrieve.</param>
        /// <returns>The products with the given brand.</returns>
        public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string productBrand)
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsByBrandAsync(productBrand);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }

        /// <summary>
        /// Asynchronously retrieves the products with the provided category from the database.
        /// </summary>
        /// <param name="productCategory">The category of the products to retrieve.</param>
        /// <returns>The products with the given category.</returns>
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string productCategory)
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsByCategoryAsync(productCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }

        /// <summary>
        /// Asynchronously retrieves the products with the provided color from the database.
        /// </summary>
        /// <param name="productColor">The color of the products to retrieve.</param>
        /// <returns>The products with the given color.</returns>
        public async Task<IEnumerable<Product>> GetProductsByColorAsync(string productColor)
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsByColorAsync(productColor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }

        /// <summary>
        /// Asynchronously retrieves the products with the provided demographic from the database.
        /// </summary>
        /// <param name="productDemographic">The demographic of the products to retrieve.</param>
        /// <returns>The products with the given demographic.</returns>
        public async Task<IEnumerable<Product>> GetProductsByDemographicAsync(string productDemographic)
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsByDemographicAsync(productDemographic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }

        /// <summary>
        /// Asynchronously retrieves the products with the provided material from the database.
        /// </summary>
        /// <param name="productMaterial">The material of the products to retrieve.</param>
        /// <returns>The products with the given material.</returns>
        public async Task<IEnumerable<Product>> GetProductsByMaterialAsync(string productMaterial)
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsByMaterialAsync(productMaterial);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }

        /// <summary>
        /// Asynchronously retrieves the products with the provided price from the database.
        /// </summary>
        /// <param name="productPrice">The price of the products to retrieve.</param>
        /// <returns>The products with the given price.</returns>
        public async Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal productPrice)
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsByPriceAsync(productPrice);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return products;
        }

        /// <summary>
        /// Asynchronously retrieves the products with the provided type from the database.
        /// </summary>
        /// <param name="productType">The type of the products to retrieve.</param>
        /// <returns>The products with the given type.</returns>
        public async Task<IEnumerable<Product>> GetProductsByTypeAsync(string productType)
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.GetProductsByTypeAsync(productType);
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
