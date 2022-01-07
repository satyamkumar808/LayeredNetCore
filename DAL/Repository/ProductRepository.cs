using DAL.Interfaces;
using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrdersContext _context;
        public ProductRepository(OrdersContext ordersContext)
        {
            _context = ordersContext;
        }

        public void AddProduct(ProductModel productModel)
        {
            Product product = new Product
            {
                ModelNum = productModel.ModelNum,
                Price = productModel.Price,
                Description = productModel.Description,
                Quantity = productModel.Quantity,
                DeliveryTime = productModel.DeliveryTime
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();   
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == productId);
        }
    }
}
