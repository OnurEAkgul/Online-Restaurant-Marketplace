using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Domains
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string LogoUrl { get; set; }
        public bool IsOpen { get; set; }
        public string ShopOwnerId { get; set; }
        public ShopOwner ShopOwner { get; set; }

        // Navigation property(if using Entity Framework Core)
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
