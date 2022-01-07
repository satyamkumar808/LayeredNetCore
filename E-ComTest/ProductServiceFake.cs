using DAL.Interfaces;
using Service.ServiceInterface;
using Shared.Models;
using Shared.ViewModels;
using System.Collections.Generic;

namespace E_ComTest
{
    internal class ProductServiceFake : IProductService
    {
        private readonly List<Product> _productList;

        public ProductServiceFake()
        {
            _productList = new List<Product>()
            {
                new Product(){ProductId = 1, DeliveryTime= 5, Description= "Chair", ModelNum=1000, Price= 500, Quantity=100},
                new Product(){ProductId = 2, DeliveryTime= 3, Description= "Table", ModelNum=10001, Price= 400, Quantity=100}
            };
        }
        public void AddProduct(ProductModel productModel)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            return _productList;
        }

        public Product GetProductById(int productId)
        {
            return _productList.Find(p => p.ProductId == productId);
        }
    }
}