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
        private readonly InterfaceCartItemDAL _cartItemDAL;
        private readonly Func<Task<InterfaceCartItemService>> _cartItemServiceFactory;

        public ShoppingCartManager(InterfaceShoppingCartDAL shoppingCartDAL, InterfaceCartItemDAL cartItemDAL, Func<Task<InterfaceCartItemService>> cartItemServiceFactory)
        {
            _shoppingCartDAL = shoppingCartDAL;
            _cartItemDAL = cartItemDAL;
            _cartItemServiceFactory = cartItemServiceFactory;
        }
        public async Task<IDataResult<ShoppingCart>> GetShoppingCartById(Guid cartId)
        {
            try
            {
                var cartItemService = await _cartItemServiceFactory();
                var shoppingCart = await _shoppingCartDAL.GetAsync(sc => sc.Id == cartId);
                if (shoppingCart == null)
                    return new ErrorDataResult<ShoppingCart>(null, "Shopping cart not found.");

                // Check if the retrieved shopping cart has associated cart items
                var cartItemsResult = await cartItemService.GetCartItemsByShoppingCartId(cartId);
                if (!cartItemsResult.Success || cartItemsResult.Data.Count == 0)
                {
                    // No associated cart items found, delete the shopping cart
                    await _shoppingCartDAL.DeleteAsync(shoppingCart);

                    return new SuccessDataResult<ShoppingCart>(null, "Shopping cart deleted due to no associated cart items.");
                }

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
                var cartItemService = await _cartItemServiceFactory();
                var shoppingCart = await _shoppingCartDAL.GetAsync(c => c.CustomerUserId == userId);

                if (shoppingCart == null)
                {
                    return new ErrorDataResult<ShoppingCart>(null, "Shopping cart not found.");
                }

                // Check if the shopping cart has any associated cart items
                var cartItemsResult = await cartItemService.GetCartItemsByShoppingCartId(shoppingCart.Id);
                if (!cartItemsResult.Success || cartItemsResult.Data.Count == 0)
                {
                    // No associated cart items found, delete the shopping cart
                    await _shoppingCartDAL.DeleteAsync(shoppingCart);
                    return new SuccessDataResult<ShoppingCart>(null, "Shopping cart deleted due to no associated cart items.");
                }

                // Shopping cart retrieved successfully
                return new SuccessDataResult<ShoppingCart>(shoppingCart, "Shopping cart retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ShoppingCart>(null, $"Error retrieving shopping cart: {ex.Message}");
            }
        }


        public async Task<IDataResult<ShoppingCart>> CreateShoppingCart(string userId)
        {
            try
            {
                // Check if a shopping cart already exists for the user
                var existingCarts = await _shoppingCartDAL.GetAllAsync(c => c.CustomerUserId == userId);

                if (existingCarts != null && existingCarts.Any())
                {
                    var shoppingCart = new ShoppingCart
                    {
                        Id = existingCarts.First().Id,
                        CustomerUserId = userId
                    };
                    // A shopping cart already exists for the user
                    return new SuccessDataResult<ShoppingCart>(shoppingCart, "A shopping cart already exists for the user.");
                }
                else
                {
                    var shoppingCart = new ShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        CustomerUserId = userId
                    };

                    await _shoppingCartDAL.AddAsync(shoppingCart);
                    return new SuccessDataResult<ShoppingCart>(shoppingCart, "Shopping cart created successfully.");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ShoppingCart>(null,$"Error creating shopping cart: {ex.Message}");
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
                var cartItemService = await _cartItemServiceFactory();
                // Retrieve the shopping cart by ID
                var shoppingCartResult = await this.GetShoppingCartById(cartId);
                if (!shoppingCartResult.Success)
                {
                    // Shopping cart not found
                    return new ErrorResult($"Shopping cart not found: {shoppingCartResult.Message}");
                }

                // Check if the shopping cart has associated cart items
                var cartItemsResult = await cartItemService.GetCartItemsByShoppingCartId(cartId);
                if (!cartItemsResult.Success)
                {
                    // No associated cart items found, directly delete the shopping cart
                    await _shoppingCartDAL.DeleteAsync(shoppingCartResult.Data); // Delete shopping cart
                    return new SuccessResult("Shopping cart deleted successfully.");
                }

                // If there are associated cart items, delete them first
                foreach (var cartItem in cartItemsResult.Data)
                {
                    await _cartItemDAL.DeleteAsync(cartItem); // Delete each cart item
                }

                // After deleting all cart items, delete the shopping cart
                await _shoppingCartDAL.DeleteAsync(shoppingCartResult.Data);

                return new SuccessResult("Shopping cart and associated cart items deleted successfully.");
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
