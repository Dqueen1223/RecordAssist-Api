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
using Catalyte.Apparel.API.Controllers;
using Catalyte.Apparel.Data.Repositories;
using Catalyte.Apparel.Data.Interfaces;
using Moq;
namespace Test.Unit
{
    public class ProductUnitTest
    {
        private readonly Mock<IProductRepository> _repositoryMock = new();
        private readonly Mock<IProductProvider> _productProviderMock = new();
        private readonly Mock<ILogger<ProductProvider>> _loggerMock = new();

        [Fact]
        public async Task GetAllUniqueProductCategory_NoProducts_ReturnEmpty()
        {
            var test = new List<string> {"test","test2"};
            //arrange
            _repositoryMock.Setup(repo => repo.GetAllUniqueProductCategoriesAsync())
                .ReturnsAsync(test);

            var provider = new ProductProvider(_repositoryMock.Object, _loggerMock.Object);

            //Act
            var actual = await provider.GetAllUniqueProductCategoriesAsync();

            //Assert
            Assert.Equal(test,actual);
        }
      }
        /*[Fact]
        public async Task GetAllUniqueProductCategory_duplicateCatgories_returnSingleCategory() 
        {
            //arrange
            var testList = new List<string>() { "test" };

            _productProviderMock.Setup(repo => repo.GetAllUniqueProductCategoriesAsync())
                    .ReturnsAsync(testList);

            var controller = new ProductsController(_loggerMock.Object, _productProviderMock.Object, mapper);


            //act
            var actual = await controller.GetAllUniqueProductCategoriesAsync();

            //Assert
            Assert.Equal(testList, actual.Value);
        }*/
}

