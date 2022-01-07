using DAL.Interfaces;
using Service.ServiceInterface;
using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ServiceRepository
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void CreateOrder(OrderViewModel orders)
        {
            _orderRepository.CreateOrder(orders);
        }

        public List<Orders> GetAllOrders(int userId)
        {
            return _orderRepository.GetAllOrders(userId);
        }
    }
}
