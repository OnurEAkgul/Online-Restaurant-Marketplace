using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using Dijital_carsi.DTOs.CartItem;
using Dijital_carsi.DTOs.Category;
using Dijital_carsi.DTOs.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {

        //------------------FINISHED---------------------


        private readonly InterfaceCartItemService _cartItemService;
        public CartItemsController(InterfaceCartItemService cartItemService)
        {


            _cartItemService = cartItemService;
        }

        //---------------GET----------------
        
        //GET ITEMS BY CART ID
        [HttpGet("GetCartItemsByShoppingCartId/{ShoppingCartId:guid}")]
        public async Task<IActionResult> GetCartItemsByShoppingCartId([FromRoute] Guid ShoppingCartId)
        {
            try
            {
                var result = await _cartItemService.GetCartItemsByShoppingCartId(ShoppingCartId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(CartItems => new CartItemInfoDTO
                {
                    Id = CartItems.Id,
                    ProductId = CartItems.ProductId,
                    Quantity = CartItems.Quantity,
                    ShoppingCartId = ShoppingCartId
                }).ToList();


                var response = new CommonResponseDTO<List<CartItemInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //GET ITEMS BY USER ID
        [HttpGet("GetCartItemsByUserId/{UserId}")]
        public async Task<IActionResult> GetCartItemsByUserId([FromRoute] string UserId)
        {
            try
            {
                var result = await _cartItemService.GetCartItemsByUserId(UserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(CartItems => new CartItemInfoDTO
                {
                    Id = CartItems.Id,
                    ProductId = CartItems.ProductId,
                    Quantity = CartItems.Quantity,
                    ShoppingCartId = CartItems.ShoppingCartId,
                    Product = new ProductItemInfoDTO()
                    {
                        ImageUrl = CartItems.Product.ImageUrl,
                        Name = CartItems.Product.Name,
                        Price = CartItems.Product.Price,

                    },
                    TotalAmount = CartItems.Product.Price * CartItems.Quantity

                }).ToList();

                
                var response = new CommonResponseDTO<List<CartItemInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //GET ITEMS BY ITEM ID
        [HttpGet("GetCartItemById/{ItemId:guid}")]
        public async Task<IActionResult> GetCartItemById([FromRoute] Guid ItemId)
        {
            try
            {
                var result = await _cartItemService.GetCartItemById(ItemId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = new CartItemInfoDTO
                {
                    Id = ItemId,
                    ProductId = result.Data.ProductId,
                    Quantity = result.Data.Quantity,
                    ShoppingCartId = result.Data.ShoppingCartId,

                };

                var response = new CommonResponseDTO<CartItemInfoDTO>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }; 

        }

        //GET ALL
        [HttpGet("GetAllCartItems")]
        public async Task<IActionResult> GetAllCartItems()
        {

            try
            {
                var result = await _cartItemService.GetCartItems();

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(CartItems => new CartItemInfoDTO
                {
                    Id = CartItems.Id,
                    ProductId = CartItems.ProductId,
                    Quantity = CartItems.Quantity,
                    ShoppingCartId = CartItems.ShoppingCartId
                }).ToList();


                var response = new CommonResponseDTO<List<CartItemInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }
        
        
        //---------------POST----------------
        
        //ADD CART ITEM
        [HttpPost("AddCartItem/{UserId}")]
        public async Task<IActionResult> AddCartItem([FromRoute] string UserId, CartItemRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var CreateRequest = new CartItem
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                     

                };

                var CreateResult = await _cartItemService.AddCartItem(UserId, CreateRequest);
                if (!CreateResult.Success)
                {
                    return BadRequest(CreateResult);
                }


                return Ok(CreateResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }
        
        
        //---------------PUT----------------
        
        //UPDATE CART ITEM
        [HttpPut("UpdateCartItem/{ShoppingCartId:Guid}/{ItemId:Guid}")]
        public async Task<IActionResult> UpdateCartItem([FromRoute] Guid ShoppingCartId, [FromRoute] Guid ItemId, CartItemRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var UpdateRequest = new CartItem
                {
                    Id = ItemId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    ShoppingCartId = ShoppingCartId
                };

                var UpdateResult = await _cartItemService.UpdateCartItem(UpdateRequest);
                if (!UpdateResult.Success)
                {
                    return BadRequest(UpdateResult);
                }


                return Ok(UpdateResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }
        
        
        //---------------DELETE----------------
        
        //DELETE CART ITEM
        [HttpDelete("DeleteCartItem/{ItemId:guid}")]
        public async Task<IActionResult> DeleteCartItem([FromRoute] Guid ItemId)
        {
            try
            {
                if (ItemId == null)
                {
                    return BadRequest("Invalid request");
                }



                var UpdateResult = await _cartItemService.DeleteCartItem(ItemId);
                if (!UpdateResult.Success)
                {
                    return BadRequest(UpdateResult);
                }


                return Ok(UpdateResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }



    }
}
