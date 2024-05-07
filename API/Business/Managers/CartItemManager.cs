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
    public class CartItemManager:InterfaceCartItemService
    {
        private readonly InterfaceCartItemDAL _cartItemDAL;
        private readonly Func<Task<InterfaceShoppingCartService>> _shoppingCartServiceFactory;

        public CartItemManager(InterfaceCartItemDAL cartItemDAL, Func<Task<InterfaceShoppingCartService>> shoppingCartServiceFactory)
        {
            _cartItemDAL = cartItemDAL;
            _shoppingCartServiceFactory = shoppingCartServiceFactory;
        }

        public async Task<IDataResult<CartItem>> GetCartItemById(Guid cartItemId)
        {
            try
            {
                var cartItem = await _cartItemDAL.GetAsync(ci => ci.Id == cartItemId);
                if (cartItem == null)
                    return new ErrorDataResult<CartItem>(null, "Cart item not found.");

                return new SuccessDataResult<CartItem>(cartItem, "Cart item retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CartItem>(null, $"Error retrieving cart item: {ex.Message}");
            }
        }

        public async Task<IResult> AddCartItem(CartItem cartItem)
        {
            try
            {
                var shoppingCartService = await _shoppingCartServiceFactory();
                // Retrieve or create the shopping cart for the user
                var shoppingCartResult = await shoppingCartService.GetShoppingCartByUserId(cartItem.ShoppingCart.NormalUserId);
                if (!shoppingCartResult.Success)
                {
                    // Create a new shopping cart if none exists
                    var createCartResult = await shoppingCartService.CreateShoppingCart(cartItem.ShoppingCart.NormalUserId);
                    if (!createCartResult.Success)
                    {
                        // Failed to create shopping cart
                        return new ErrorResult($"Failed to create shopping cart: {createCartResult.Message}");
                    }
                    // Update the cart item with the newly created shopping cart ID
                    cartItem.ShoppingCartId = createCartResult.Data.Id;
                }
                else
                {
                    // Use the existing shopping cart ID
                    cartItem.ShoppingCartId = shoppingCartResult.Data.Id;
                }

                // Add the cart item to the database
                await _cartItemDAL.AddAsync(cartItem);
                return new SuccessResult("Cart item added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception for troubleshooting
                return new ErrorResult($"Error adding cart item: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateCartItem(CartItem cartItem)
        {
            try
            {
                await _cartItemDAL.UpdateAsync(cartItem);
                return new SuccessResult("Cart item updated successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error updating cart item: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteCartItem(Guid cartItemId)
        {
            try
            {
                var cartItem = new CartItem { Id = cartItemId };
                await _cartItemDAL.DeleteAsync(cartItem);
                return new SuccessResult("Cart item deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error deleting cart item: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<CartItem>>> GetCartItems()
        {
            try
            {
                var cartItem = await _cartItemDAL.GetAllAsync();
                if (cartItem.Count == 0)
                    return new ErrorDataResult<List<CartItem>>(null, "Cart items not found.");

                return new SuccessDataResult<List<CartItem>>(cartItem, "Cart items retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CartItem>>(null, $"Error retrieving cart item: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<CartItem>>> GetCartItemsByShoppingCartId(Guid ShoppingCartId)
        {
            
            try
            {
                var cartItem = await _cartItemDAL.GetAllAsync(ci => ci.ShoppingCartId == ShoppingCartId);
                if (cartItem.Count == 0)
                    return new ErrorDataResult<List<CartItem>>(null, "Cart items not found.");

                return new SuccessDataResult<List<CartItem>>(cartItem, "Cart items retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CartItem>>(null, $"Error retrieving cart item: {ex.Message}");
            }
        }
    }
}
