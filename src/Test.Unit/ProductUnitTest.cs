using System;
using System.Collections.Generic;
using Catalyte.Apparel.DTOs.Products;
using Xunit;
using Catalyte.Apparel.Providers.Providers;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.Context;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Test.Unit
{
    public class ProductUnitTest
    {
        private readonly ILogger<ProductUnitTest> _logger;
        private readonly IProductProvider _productProvider;
        private readonly IMapper _mapper;
        public ProductUnitTest(
            ILogger<ProductUnitTest> logger,
            IProductProvider productProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productProvider = productProvider;
        }
        
            [Fact]
        public void GetAllUniqueProductCategory_NoProducts_ReturnEmpty()
        {
            ProductDTO product = new ProductDTO();
            product.Category = "test";
            var actual = _productProvider.GetAllUniqueProductCategoriesAsync();
            var expected = new IEnumerable<List<string>>
            Assert.Equal(expected, actual);
        }
    }
}
