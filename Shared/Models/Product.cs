using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int ModelNum { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int DeliveryTime { get; set; }

        public virtual IEnumerable<CartItems> CartItems { get; set; }
    }
}
