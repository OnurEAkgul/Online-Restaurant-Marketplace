using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {

        [HttpGet("GetCartItemsByShoppingCartId/{id:guid}")]
        public async Task<IActionResult> GetCartItemsByShoppingCartId([FromRoute] Guid id)
        {
            return Ok();

        }
        
        [HttpGet("GetCartItemById/{id:guid}")]
        public async Task<IActionResult> GetCartItemById([FromRoute] Guid id)
        {
            return Ok();

        }
        
        [HttpGet("GetAllCartItems")]
        public async Task<IActionResult> GetAllCartItems()
        {
            return Ok();

        }

        [HttpPost("AddCartItem")]
        public async Task<IActionResult> AddCartItem()
        {
            return Ok();

        }

        [HttpPut("UpdateCartItem")]
        public async Task<IActionResult> UpdateCartItem()
        {
            return Ok();

        }

        [HttpDelete("DeleteCartItem")]
        public async Task<IActionResult> DeleteCartItem()
        {
            return Ok();

        }



    }
}
