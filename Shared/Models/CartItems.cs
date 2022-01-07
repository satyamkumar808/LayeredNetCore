using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class CartItems
    {
        [Key]
        public int CartItemId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public Orders Oreder { get; set; }
    }
}
