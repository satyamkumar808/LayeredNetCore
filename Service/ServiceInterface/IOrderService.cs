using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ServiceInterface
{
    public interface IOrderService
    {
        List<Orders> GetAllOrders(int userId);
        void CreateOrder(OrderViewModel orders);
    }
}
