using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public User User { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public int Total { get; set; }
        public int  EstDelivery { get; set; }
        public virtual IEnumerable<CartItems> CartItems { get; set; }
    }
}
