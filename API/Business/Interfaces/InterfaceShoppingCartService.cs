﻿using Core.Entities.Domains;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceShoppingCartService
    {

        Task<IDataResult<List<ShoppingCart>>> GetShoppingCarts();
        Task<IDataResult<ShoppingCart>> GetShoppingCartById(Guid cartId);
        Task<IDataResult<ShoppingCart>> GetShoppingCartByUserId(string userId);
        Task<IResult> CreateShoppingCart(string userId);
        Task<IResult> UpdateShoppingCart(ShoppingCart shoppingCart);
        Task<IResult> DeleteShoppingCart(Guid cartId);
    }
}
