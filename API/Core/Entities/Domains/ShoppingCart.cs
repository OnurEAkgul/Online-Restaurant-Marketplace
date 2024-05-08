using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Domains
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string CustomerUserId { get; set; } // Foreign key to link with the user
        public NormalUser NormalUser { get; set; } // Reference to the user who owns the cart
        public ICollection<CartItem> CartItems { get; set; } // Collection of items in the cart
    }
}
