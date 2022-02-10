using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The ProductsController exposes endpoints for product related actions.
    /// </summary>
    [ApiController]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductProvider _productProvider;
        private readonly IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductProvider productProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productProvider = productProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync(Nullable<bool> active, [FromQuery] List<string> brand,
                                                                                  [FromQuery] List<string> category,
                                                                                  [FromQuery] List<string> color,
                                                                                  [FromQuery] List<string> demographic,
                                                                                  [FromQuery] List<string> material,
                                                                                  decimal minPrice, decimal maxPrice, 
                                                                                  [FromQuery] List<string> type, int?range)
        {
            _logger.LogInformation("Request received for GetProductsAsync");

            var products = await _productProvider.GetProductsAsync(active, brand, category, color,
                                                                   demographic, material,
                                                                   minPrice,maxPrice, type, range);

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }
        [HttpGet("/products/count")]
        public async Task<ActionResult<int>> GetProductsCountAsync(Nullable<bool> active, [FromQuery] List<string> brand,
                                                                                  [FromQuery] List<string> category,
                                                                                  [FromQuery] List<string> color,
                                                                                  [FromQuery] List<string> demographic,
                                                                                  [FromQuery] List<string> material,
                                                                                  decimal minPrice, decimal maxPrice,
                                                                                  [FromQuery] List<string> type, int? range)
        {
            _logger.LogInformation("Request received for GetProductsAsync");

            var productsCount = await _productProvider.GetProductsCountAsync(active, brand, category, color,
                                                                   demographic, material,
                                                                   minPrice, maxPrice, type, range);

            return Ok(productsCount);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetProductByIdAsync for id: {id}");

            var product = await _productProvider.GetProductByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(productDTO);
        }
        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateProductAsync(int id,
                        [FromBody] ProductDTO Product)
        {
            _logger.LogInformation("Request received for update user");

            var productToUpdate = _mapper.Map<Product>(Product);
            {
                _logger.LogInformation("Request recived for update product");
            }
            var updatedProduct = await _productProvider.UpdateProductAsync(id, productToUpdate);
            var productDTO = _mapper.Map<ProductDTO>(updatedProduct);

            return Ok(productDTO);
        }
        [HttpGet("/products/categories")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllUniqueProductCategoriesAsync()
        {
            _logger.LogInformation($"Request received for GetAllUniqueProductCategoriesAsync");
            var productCategories = await _productProvider.GetAllUniqueProductCategoriesAsync();
            return Ok(productCategories);

        }

        [HttpGet("/products/types")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllUniqueProductTypesAsync()
        {
            _logger.LogInformation($"Request received for GetAllUniqueProductTypesAsync");
            var productTypes = await _productProvider.GetAllUniqueProductTypesAsync();
            return Ok(productTypes);

        }

    }
}
