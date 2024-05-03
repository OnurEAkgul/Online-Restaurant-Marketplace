using Business.Interfaces;
using Core.Entities.Domains;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class ShopOwnerManager:InterfaceShopOwnerService
    {

        private readonly UserManager<ShopOwner> _userManager;

        public ShopOwnerManager(UserManager<ShopOwner> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IDataResult<ShopOwner>> GetShopOwnerById(string ownerId)
        {
            var shopOwner = await _userManager.FindByIdAsync(ownerId);
            if (shopOwner == null)
                return new ErrorDataResult<ShopOwner>(null, "Shop owner not found.");

            return new SuccessDataResult<ShopOwner>(shopOwner, "Shop owner retrieved successfully.");
        }

        public async Task<IResult> CreateShopOwner(ShopOwner shopOwner, string password)
        {
            var result = await _userManager.CreateAsync(shopOwner, password);
            if (result.Succeeded)
                return new SuccessResult("Shop owner created successfully.");
            else
                return new ErrorResult($"Error creating shop owner: {string.Join(", ", result.Errors)}");
        }

        public async Task<IResult> UpdateShopOwner(ShopOwner shopOwner)
        {
            var result = await _userManager.UpdateAsync(shopOwner);
            if (result.Succeeded)
                return new SuccessResult("Shop owner updated successfully.");
            else
                return new ErrorResult($"Error updating shop owner: {string.Join(", ", result.Errors)}");
        }

        public async Task<IResult> DeleteShopOwner(string ownerId)
        {
            var shopOwner = await _userManager.FindByIdAsync(ownerId);
            if (shopOwner == null)
                return new ErrorResult("Shop owner not found.");

            var result = await _userManager.DeleteAsync(shopOwner);
            if (result.Succeeded)
                return new SuccessResult("Shop owner deleted successfully.");
            else
                return new ErrorResult($"Error deleting shop owner: {string.Join(", ", result.Errors)}");
        }
    }
}
