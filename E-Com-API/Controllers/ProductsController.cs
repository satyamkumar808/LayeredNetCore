using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceInterface;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Com_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("allProducts")]
        public IActionResult AllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpPost]
        [Route("addProduct")]
        public IActionResult AddProduct(ProductModel product)
        {
            _productService.AddProduct(product);
            return Ok(new { message = "Product Added successfully"});
        }
    }
}
