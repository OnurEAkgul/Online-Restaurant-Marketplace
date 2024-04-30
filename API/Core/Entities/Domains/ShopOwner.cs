using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Domains
{
    public class ShopOwner : IdentityUser
    {
        public ICollection<Shop> Shops { get; set; }
    }
}
