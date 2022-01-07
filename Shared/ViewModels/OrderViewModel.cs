using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class OrderViewModel
    {
        public int  UserId { get; set; }
        public string Address { get; set; }
        public int Total { get; set; }
        public int EstDelivery { get; set; }
        public IEnumerable<CartItems> CartItems { get; set; }
    }
}
