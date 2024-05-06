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

namespace Business.Managers
{
    public class ShoppingCartManager : InterfaceShoppingCartService
    {
        private readonly InterfaceShoppingCartDAL _shoppingCartDAL;

        public ShoppingCartManager(InterfaceShoppingCartDAL shoppingCartDAL)
        {
            _shoppingCartDAL = shoppingCartDAL;
        }

        public async Task<IDataResult<ShoppingCart>> GetShoppingCartById(Guid cartId)
        {
            try
            {
                var shoppingCart = await _shoppingCartDAL.GetAsync(sc => sc.Id == cartId);
                if (shoppingCart == null)
                    return new ErrorDataResult<ShoppingCart>(null, "Shopping cart not found.");

                return new SuccessDataResult<ShoppingCart>(shoppingCart, "Shopping cart retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ShoppingCart>(null, $"Error retrieving shopping cart: {ex.Message}");
            }
        }

        public async Task<IDataResult<ShoppingCart>> GetShoppingCartByUserId(string userId)
        {
            try
            {
                var shoppingCarts = await _shoppingCartDAL.GetAsync(c => c.NormalUserId == userId);
                return new SuccessDataResult<ShoppingCart>(shoppingCarts, "Shopping carts retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ShoppingCart>(null, $"Error retrieving shopping carts: {ex.Message}");
            }
        }

        public async Task<IResult> CreateShoppingCart(string userId)
        {
            try
            {
                var shoppingCart = new ShoppingCart
                {
                    Id = Guid.NewGuid(),
                    NormalUserId = userId
                };

                await _shoppingCartDAL.AddAsync(shoppingCart);
                return new SuccessResult("Shopping cart created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error creating shopping cart: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            try
            {
                await _shoppingCartDAL.UpdateAsync(shoppingCart);
                return new SuccessResult("Shopping cart updated successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error updating shopping cart: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteShoppingCart(Guid cartId)
        {
            try
            {
                var shoppingCart = new ShoppingCart { Id = cartId };
                await _shoppingCartDAL.DeleteAsync(shoppingCart);
                return new SuccessResult("Shopping cart deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error deleting shopping cart: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<ShoppingCart>>> GetShoppingCarts()
        {
            try
            {
                var shoppingCart = await _shoppingCartDAL.GetAllAsync();
                if (shoppingCart == null)
                    return new ErrorDataResult<List<ShoppingCart>> (null, "Shopping cart not found.");

                return new SuccessDataResult<List<ShoppingCart>> (shoppingCart, "Shopping cart retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ShoppingCart>> (null, $"Error retrieving shopping cart: {ex.Message}");
            }
        }
    }

}
