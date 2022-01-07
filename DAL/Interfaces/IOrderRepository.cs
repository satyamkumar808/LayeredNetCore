using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRepository
    {
        List<Orders> GetAllOrders(int userId);
        void CreateOrder(OrderViewModel orders);
    }
}
