using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        //---------------GET----------------
        
        //GET ALL
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok();

        }
       
        //GET ALL BY USER ID
        [HttpGet("GetAllOrdersByUserId/{UserId}")]
        public async Task<IActionResult> GetAllOrdersByUserId([FromRoute] string UserId)
        {
            return Ok();

        }
        
        //GET ALL BY SHOP ID
        [HttpGet("GetAllOrdersByShopId/{ShopId:guid}")]
        public async Task<IActionResult> GetAllOrdersByShopId([FromRoute] Guid ShopId)
        {
            return Ok();

        }
        
        //GET BY ORDER ID
        [HttpGet("GetOrderById/{OrderId:guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid OrderId)
        {
            return Ok();

        }

        //GET BY USER ID
        [HttpGet("GetOrderByUserId/{UserId}")]
        public async Task<IActionResult> GetOrderByUserId([FromRoute] string UserId)
        {
            return Ok();

        }

        //GET ACTIVE ORDERS BY USER ID
        [HttpGet("GetActiveOrdersByUserId/{UserId}")]
        public async Task<IActionResult> GetActiveOrdersByUserId([FromRoute] string UserId)
        {
            return Ok();

        }

        //GET ACTIVE BY SHOP ID
        [HttpGet("GetActiveOrdersByShopId/{ShopId:guid}")]
        public async Task<IActionResult> GetActiveOrdersByShopId([FromRoute] Guid ShopId)
        {
            return Ok();

        }
        
       

        //---------------POST----------------

        //CREATE ORDER
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder()
        {
            return Ok();

        }

        //---------------PUT----------------

        //UPDATE ORDER
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder()
        {
            return Ok();

        }
        //---------------DELETE----------------

        //DELETE ORDER
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder()
        {
            return Ok();

        }





    }
}
