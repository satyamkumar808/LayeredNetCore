using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ServiceInterface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product GetProductById(int productId);

        void AddProduct(ProductModel productModel);
    }
}
