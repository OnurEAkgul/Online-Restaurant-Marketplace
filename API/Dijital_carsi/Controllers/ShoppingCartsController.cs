using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly InterfaceShoppingCartService Service;


        public ShoppingCartsController(InterfaceShoppingCartService shoppingCartService)
        {

            Service = shoppingCartService;
        }
        
        
        //---------------GET----------------
        
        //GET ALL
        [HttpGet("GetAllShoppingCarts")]
        public async Task<IActionResult> GetAllShoppingCarts()
        {
            return Ok();
        }

        //GET BY CART ID
        [HttpGet("GetShoppingCartById/{ShoppingCartId:Guid}")]
        public async Task<IActionResult> GetShoppingCartById([FromRoute] Guid ShoppingCartId) { return Ok(); }

        //GET BY USERID
        [HttpGet("GetShoppingCartByUserId/{UserId}")]
        public async Task<IActionResult> GetShoppingCartByUserId([FromRoute] string UserId) { return Ok(); }
        
        
        //---------------POST----------------
       
        //CREATE NEW CART
        [HttpPost("CreateShoppingCart/{UserId}")]
        public async Task<IActionResult> CreateShoppingCart([FromRoute] string UserId)
        {
            try
            {
                var result = await Service.CreateShoppingCart(UserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
        
        //---------------PUT----------------
        
        //UPDATE CART
        [HttpPut("UpdateShoppingCart/{ShoppingCartId:guid}")]
        public async Task<IActionResult> UpdateShoppingCart([FromRoute] Guid ShoppingCartId) { return Ok(); }
        
        
        
        //---------------DELETE----------------
        
        //DELETE CART
        [HttpDelete("DeleteShoppingCart/{ShoppingCartId:Guid}")]
        public async Task<IActionResult> DeleteShoppingCart([FromRoute] Guid ShoppingCartId) { return Ok(); }

    }
}
