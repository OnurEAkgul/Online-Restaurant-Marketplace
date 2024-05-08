using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        //GET
        [HttpGet("GetOrderById/{id:guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            return Ok();

        }

        [HttpGet("GetOrderByUserId/{id}")]
        public async Task<IActionResult> GetOrderByUserId([FromRoute] string id)
        {
            return Ok();

        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok();

        }

        [HttpGet("GetActiveOrdersByUserId/{id}")]
        public async Task<IActionResult> GetActiveOrdersByUserId([FromRoute] string id)
        {
            return Ok();

        }

        [HttpGet("GetAllOrdersByUserId/{id}")]
        public async Task<IActionResult> GetAllOrdersByUserId([FromRoute] string id)
        {
            return Ok();

        }

        [HttpGet("GetActiveOrdersByShopId/{id:guid}")]
        public async Task<IActionResult> GetActiveOrdersByShopId([FromRoute] Guid id)
        {
            return Ok();

        }
        
        [HttpGet("GetAllOrdersByShopId/{id:guid}")]
        public async Task<IActionResult> GetAllOrdersByShopId([FromRoute] Guid id)
        {
            return Ok();

        }



        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder()
        {
            return Ok();

        }

        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder()
        {
            return Ok();

        }

        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder()
        {
            return Ok();

        }





    }
}
