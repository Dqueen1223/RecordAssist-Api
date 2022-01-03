﻿using AutoMapper;
﻿using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            _logger.LogInformation("Request received for GetProductsAsync");

            var products = await _productProvider.GetProductsAsync();
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetProductByIdAsync for id: {id}");

            var product = await _productProvider.GetProductByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(productDTO);
        }

        [HttpGet("brands/{brand}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByBrandAsync(string brand)
        {
            _logger.LogInformation($"Request received for GetProductsByBrandAsync for brand: {brand}");

            var products = await _productProvider.GetProductsByBrandAsync(brand);
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("categories/{category}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByCategoryAsync(string category)
        {
            _logger.LogInformation($"Request received for GetProductsByCategoryAsync for category: {category}");

            var products = await _productProvider.GetProductsByCategoryAsync(category);
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("colors/{color}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByColorAsync(string color)
        {
            _logger.LogInformation($"Request received for GetProductsByColorAsync for color: {color}");

            var products = await _productProvider.GetProductsByColorAsync(color);
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("demographics/{demographic}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByDemographicAsync(string demographic)
        {
            _logger.LogInformation($"Request received for GetProductsByDemographicAsync for demographic: {demographic}");

            var products = await _productProvider.GetProductsByDemographicAsync(demographic);
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("materials/{material}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByMaterialAsync(string material)
        {
            _logger.LogInformation($"Request received for GetProductsByMaterialAsync for material: {material}");

            var products = await _productProvider.GetProductsByMaterialAsync(material);
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("prices/{price}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByPriceAsync(decimal price)
        {
            _logger.LogInformation($"Request received for GetProductsByPriceAsync for price: {price}");

            var products = await _productProvider.GetProductsByPriceAsync(price);
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("types/{type}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByTypeAsync(string type)
        {
            _logger.LogInformation($"Request received for GetProductsByTypeAsync for type: {type}");

            var products = await _productProvider.GetProductsByTypeAsync(type);
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }
    }
}
