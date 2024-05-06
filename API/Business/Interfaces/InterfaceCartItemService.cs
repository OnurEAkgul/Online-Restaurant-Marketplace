using Core.Entities.Domains;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceCartItemService
    {
        Task<IDataResult<List<CartItem>>> GetCartItems();
        Task<IDataResult<List<CartItem>>> GetCartItemsByShoppingCartId(Guid ShoppingCartId);
        Task<IDataResult<CartItem>> GetCartItemById(Guid cartItemId);
        Task<IResult> AddCartItem(CartItem cartItem);
        Task<IResult> UpdateCartItem(CartItem cartItem);
        Task<IResult> DeleteCartItem(Guid cartItemId);
    }
}
