using DAL.Interfaces;
using Service.ServiceInterface;
using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ServiceRepository
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(ProductModel product)
        {
            _productRepository.AddProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
