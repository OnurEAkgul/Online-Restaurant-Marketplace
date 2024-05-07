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

        //GET ALL
        [HttpGet("GetAllShoppingCarts")]
        public async Task<IActionResult> GetAllShoppingCarts()
        {
            return Ok();
        }

        //GET BY CART ID
        [HttpGet("GetShoppingCartById/{id:Guid}")]
        public async Task<IActionResult> GetShoppingCartById([FromRoute] Guid id) { return Ok(); }

        //GET BY USERID
        [HttpGet("GetShoppingCartByUserId/{userId}")]
        public async Task<IActionResult> GetShoppingCartByUserId([FromRoute] string userId) { return Ok(); }

        //CREATE NEW CART
        [HttpPost("CreateShoppingCart/{userId}")]
        public async Task<IActionResult> CreateShoppingCart([FromRoute] string userId)
        {
            try
            {
                var result = await Service.CreateShoppingCart(userId);

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

        //UPDATE CART
        [HttpPut("UpdateShoppingCart")]
        public async Task<IActionResult> UpdateShoppingCart() { return Ok(); }

        //DELETE CART
        [HttpDelete("DeleteShoppingCart/{id:Guid}")]
        public async Task<IActionResult> DeleteShoppingCart([FromRoute] Guid id) { return Ok(); }

    }
}
