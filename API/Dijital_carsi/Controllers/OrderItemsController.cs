using Business.Interfaces;
using Dijital_carsi.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly InterfaceOrderItemService _orderItemService;

        public OrderItemsController(InterfaceOrderItemService orderItemService)
        {

            _orderItemService = orderItemService;
        }
        //---------------GET----------------
        //GET ALL
        [HttpGet("GetAllOrderItems")]
        public async Task<IActionResult> GetAllOrderItems()
        {
            return Ok();

        }

        //GET ORDER ITEMS BY ORDER ID
        [HttpGet("GetOrderItemsByOrderId/{OrderId:guid}")]
        public async Task<IActionResult> GetOrderItemsByOrderId([FromRoute] Guid OrderId)
        {
            return Ok();

        }

        //GET ORDER BY ORDER ITEM ID        
        [HttpGet("GetOrderItemById/{OrderItemId:guid}")]
        public async Task<IActionResult> GetOrderItemById([FromRoute] Guid OrderItemId)
        {
            return Ok();

        }




        //---------------POST----------------

        //ADD ORDER ITEM
        [HttpPost("AddOrderItem")]
        public async Task<IActionResult> AddOrderItem()
        {
            return Ok();

        }


        //---------------PUT----------------

        //UPDATE ORDER ITEM
        [HttpPut("UpdateOrderItem/{OrderItemId:guid}")]
        public async Task<IActionResult> UpdateOrderItem([FromRoute] Guid OrderItemId)
        {
            return Ok();

        }



        //---------------DELETE----------------


        //DELETE ORDER ITEM
        [HttpDelete("DeleteOrderItem/{OrderItemId:guid}")]
        public async Task<IActionResult> DeleteOrderItem([FromRoute] Guid OrderItemId)
        {
            return Ok();

        }




    }
}
