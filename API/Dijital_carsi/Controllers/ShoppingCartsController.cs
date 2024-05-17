using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using DataAccess.EntityFramework;
using Dijital_carsi.DTOs.CartItem;
using Dijital_carsi.DTOs.Common;
using Dijital_carsi.DTOs.ShoppingCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly InterfaceShoppingCartService _shoppingCartService;


        public ShoppingCartsController(InterfaceShoppingCartService shoppingCartService)
        {

            _shoppingCartService = shoppingCartService;
        }


        //---------------GET----------------

        //GET ALL
        [HttpGet("GetAllShoppingCarts")]
        public async Task<IActionResult> GetAllShoppingCarts()
        {
            try
            {
                var result = await _shoppingCartService.GetShoppingCarts();

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(CartItems => new ShoppingCartInfoDTO
                {
                    CustomerUserId = CartItems.CustomerUserId,
                    Id = CartItems.Id,
                }).ToList();


                var response = new CommonResponseDTO<List<ShoppingCartInfoDTO>>()
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

        //GET BY CART ID
        [HttpGet("GetShoppingCartById/{ShoppingCartId:Guid}")]
        public async Task<IActionResult> GetShoppingCartById([FromRoute] Guid ShoppingCartId)
        {
            try
            {
                var result = await _shoppingCartService.GetShoppingCartById(ShoppingCartId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }
                if (result.Data != null) {
                    var resultData = new ShoppingCartInfoDTO
                    {
                        CustomerUserId = result.Data.CustomerUserId,
                        Id = result.Data.Id,
                    };
                
                


                var response = new CommonResponseDTO<ShoppingCartInfoDTO>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };
        }

        //GET BY USERID
        [HttpGet("GetShoppingCartByUserId/{UserId}")]
        public async Task<IActionResult> GetShoppingCartByUserId([FromRoute] string UserId)
        {
            try
            {
                var result = await _shoppingCartService.GetShoppingCartByUserId(UserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                if (!result.Success)
                {
                    return BadRequest(result);
                }
                if (result.Data != null)
                {
                    var resultData = new ShoppingCartInfoDTO
                    {
                        CustomerUserId = result.Data.CustomerUserId,
                        Id = result.Data.Id,
                    };




                    var response = new CommonResponseDTO<ShoppingCartInfoDTO>()
                    {
                        Data = resultData,
                        Message = result.Message,
                        Successful = result.Success
                    };

                    return Ok(response);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };
        }


        //---------------POST----------------

        //CREATE NEW CART
        [HttpPost("CreateShoppingCart/{UserId}")]
        public async Task<IActionResult> CreateShoppingCart([FromRoute] string UserId)
        {
            try
            {
                var result = await _shoppingCartService.CreateShoppingCart(UserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        //---------------PUT----------------

        //UPDATE CART
        [HttpPut("UpdateShoppingCart/{ShoppingCartId:guid}")]
        public async Task<IActionResult> UpdateShoppingCart([FromRoute] Guid ShoppingCartId, [FromQuery] string UserId=null) {
            try
            {
                var UpdateRequest = new ShoppingCart { };
                if (UserId != null)
                {
                     UpdateRequest.Id = ShoppingCartId;
                     UpdateRequest.CustomerUserId= UserId;
                }

                 UpdateRequest.Id= ShoppingCartId;
                
                var result = await _shoppingCartService.UpdateShoppingCart(UpdateRequest);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



        //---------------DELETE----------------

        //DELETE CART
        [HttpDelete("DeleteShoppingCart/{ShoppingCartId:Guid}")]
        public async Task<IActionResult> DeleteShoppingCart([FromRoute] Guid ShoppingCartId) {
            try
            {
                
                if(ShoppingCartId==null)
                    return BadRequest("Invalid Request");
                var result = await _shoppingCartService.DeleteShoppingCart(ShoppingCartId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
