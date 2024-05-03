using Core.Entities.Domains;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceShopOwnerService
    {
        Task<IDataResult<ShopOwner>> GetShopOwnerById(string ownerId);
        Task<IResult> CreateShopOwner(ShopOwner shopOwner, string password);
        Task<IResult> UpdateShopOwner(ShopOwner shopOwner);
        Task<IResult> DeleteShopOwner(string ownerId);
    }
}
