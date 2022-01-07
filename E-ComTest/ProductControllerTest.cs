using DAL.Interfaces;
using E_Com_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceInterface;
using System;
using Xunit;

namespace E_ComTest
{
    public class ProductControllerTest
    {
        private readonly ProductsController _productController;
        private readonly IProductService _productService;

        public ProductControllerTest()
        {
            _productService = new ProductServiceFake();
            _productController = new ProductsController(_productService);
        }

        [Fact]
        public void GetAllProductsTest()
        {
            // Act
            var okResult = _productController.AllProducts();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

    }
}
