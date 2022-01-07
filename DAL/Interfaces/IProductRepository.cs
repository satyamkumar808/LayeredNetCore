using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product GetProductById(int productId);

        void AddProduct(ProductModel productModel);
    }
}
