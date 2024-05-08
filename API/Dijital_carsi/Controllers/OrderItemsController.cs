using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {

        [HttpGet("GetOrderItemsByOrderId/{id:guid}")]
        public async Task<IActionResult> GetOrderItemsByOrderId([FromRoute] Guid id)
        {
            return Ok();

        }
        [HttpGet("GetOrderItemById/{id:guid}")]
        public async Task<IActionResult> GetOrderItemById([FromRoute] Guid id)
        {
            return Ok();

        }

        [HttpGet("GetAllOrderItems")]
        public async Task<IActionResult> GetAllOrderItems()
        {
            return Ok();

        }

        [HttpPost("AddOrderItem")]
        public async Task<IActionResult> AddOrderItem()
        {
            return Ok();

        }

        [HttpPut("UpdateOrderItem")]
        public async Task<IActionResult> UpdateOrderItem()
        {
            return Ok();

        }

        [HttpDelete("DeleteOrderItem")]
        public async Task<IActionResult> DeleteOrderItem()
        {
            return Ok();

        }




    }
}
