using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Domains
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }  // Foreign key to link with customer (if applicable)
        public Guid ShopId { get; set; }      // Foreign key to link with shop
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }  // Indicates if the order is completed
        public string NormalUserId { get; set; }
        public NormalUser NormalUser { get; set; }

        // Navigation properties
        public Shop Shops { get; set; }         // Reference to the shop where the order is placed
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
