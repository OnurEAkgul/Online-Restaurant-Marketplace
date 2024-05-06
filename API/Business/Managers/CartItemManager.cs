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

        public CartItemManager(InterfaceCartItemDAL cartItemDAL)
        {
            _cartItemDAL = cartItemDAL;
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
                await _cartItemDAL.AddAsync(cartItem);
                return new SuccessResult("Cart item added successfully.");
            }
            catch (Exception ex)
            {
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
