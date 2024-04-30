using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Domains
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }   // Foreign key to link with product
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        // Navigation properties
        public Product Products { get; set; }  // Reference to the ordered product
    }
}
