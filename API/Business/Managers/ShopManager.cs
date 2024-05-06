using Business.Interfaces;
using Core.Entities.Domains;
using Core.Utilities.Results;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ShopManager : InterfaceShopService
    {

        private readonly InterfaceShopDAL shopDAL;

        public ShopManager(InterfaceShopDAL shopDAL)
        {
            this.shopDAL = shopDAL;
        }

        public async Task<IResult> CreateShopAsync(Shop shop)
        {
            try { 
            await shopDAL.AddAsync(shop);
            return new SuccessResult("Shop has been created successfully");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Shop>(null, $"An error has been occured while creating the shop: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteShopAsync(Shop shop)
        {

            try { 
            await shopDAL.DeleteAsync(shop); 
            return new SuccessResult("Shop has been deleted successfully");
        }   catch (Exception ex) {

                return new ErrorDataResult<Shop>(null, $"An error has been occured while deleting the shop: {ex.Message}");
            }
            }

        
        public async Task<IResult> UpdateShopAsync(Shop shop)
        {
            try
            {
                var _shop = await shopDAL.GetAsync(s => s.Id == shop.Id);
                if (_shop == null)
                {
                    return new ErrorResult("Shop not found");
                }
                // Update the properties of the retrieved shop entity with the new values
                _shop.Name = shop.Name ?? _shop.Name;
                _shop.Description = shop.Description ?? _shop.Description;
                _shop.Location = shop.Location ?? _shop.Location;
                _shop.ContactEmail = shop.ContactEmail ?? _shop.ContactEmail;
                _shop.ContactPhone = shop.ContactPhone ?? _shop.ContactPhone;
                _shop.LogoUrl = shop.LogoUrl ?? _shop.LogoUrl;

                // Save changes to the database
                await shopDAL.UpdateAsync(_shop);

                return new SuccessResult("Shop updated successfully");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Shop>(shop, $"An error has been occured while updating the shop: {ex.Message}");
            }
        }

        public async Task<IResult> ToggleShopStatusAsync(Guid shopId, bool isOpen)
        {
            try
            {
                // Retrieve the existing shop entity from the database
                var shop = await shopDAL.GetAsync(s => s.Id == shopId);
                if (shop == null)
                {
                    return new ErrorResult("Shop not found");
                }

                // Update the IsOpen property only if the status has changed
                if (shop.IsOpen != isOpen)
                {
                    shop.IsOpen = isOpen;
                    await shopDAL.UpdateAsync(shop);
                }

                return new SuccessResult($"Shop status set to {(isOpen ? "open" : "closed")} successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occurred while toggling shop status: {ex.Message}");
            }
        }

        public async Task<IDataResult<Shop>> GetShopByIdAsync(Guid shopId)
        {
            try
            {
                var shop = await shopDAL.GetAsync(s => s.Id == shopId);
                return shop != null
                    ? new SuccessDataResult<Shop>(shop, "Shop has been retrieved successfully")
                    : new ErrorDataResult<Shop>(null, "Shop not found");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Shop>(null, $"An error has been occured while retrieveing the shop: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Shop>>> GetShopsByNameAsync(string name)
        {
            try
            {
                var shop = await shopDAL.GetAllAsync(s => s.Name == name);
                if (shop.Count == 0)
                    return new ErrorDataResult<List<Shop>> (null, "Shop not found.");

                return new SuccessDataResult<List<Shop>>(shop, "Shops has been retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Shop>>(null, $"Error retrieving cart item: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Shop>>> GetShopsByStatusAsync(bool isOpen)
        {
            try
            {
                var shop = await shopDAL.GetAllAsync(s => s.IsOpen == isOpen);
                if (shop.Count == 0)
                    return new ErrorDataResult<List<Shop>>(null, "Shop not found.");

                return new SuccessDataResult<List<Shop>>(shop, "Shops has been retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Shop>>(null, $"Error retrieving cart item: {ex.Message}");
            }
        }
    }
}
