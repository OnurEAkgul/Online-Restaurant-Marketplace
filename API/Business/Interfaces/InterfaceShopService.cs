using Core.Entities.Domains;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceShopService
    {

        Task<IResult> CreateShopAsync(Shop shop);
        Task<IResult> UpdateShopAsync(Shop shop);
        Task<IResult> DeleteShopAsync(Shop shop);
        Task<IDataResult<Shop>> GetShopByIdAsync(Guid shopId);
        Task<IDataResult<List<Shop>>> GetShopsByNameAsync(string name);
        Task<IDataResult<List<Shop>>> GetShopsByStatusAsync(bool isOpen);
        Task<IDataResult<List<Shop>>> GetAllShops();
        Task<IResult> ToggleShopStatusAsync(Guid shopId, bool isOpen);
    }
}
