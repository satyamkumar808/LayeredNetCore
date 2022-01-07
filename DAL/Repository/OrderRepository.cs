using DAL.Interfaces;
using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersContext _context;
        public OrderRepository(OrdersContext context)
        {
            _context = context;
        }

        public void CreateOrder(OrderViewModel order)
        {
            Orders newOrder = new Orders
            {
                UserId = order.UserId,
                Address = order.Address,
                Total = order.Total,
                EstDelivery = order.EstDelivery,
                CartItems = order.CartItems
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
        }

        public List<Orders> GetAllOrders(int userId)
        {
            return _context.Orders.Where(x => x.UserId == userId).ToList();
        }
    }
}
