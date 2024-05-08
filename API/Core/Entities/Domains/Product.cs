using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Domains
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; } // Foreign key for Category
        public Category Category { get; set; } // Navigation property to Category
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        // Foreign key property (if using Entity Framework Core)
        public Guid ShopId { get; set; }
        public Shop Shops { get; set; }



    }
}
