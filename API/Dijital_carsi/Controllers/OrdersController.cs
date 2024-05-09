using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using Dijital_carsi.DTOs.Common;
using Dijital_carsi.DTOs.OrderItem;
using Dijital_carsi.DTOs.Orders;
using Dijital_carsi.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        //------------------FINISHED---------------------


        private readonly InterfaceOrderService _orderService;

        public OrdersController(InterfaceOrderService orderService)
        {

            _orderService = orderService;
        }


        
        //---------------GET----------------

        //GET ALL
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var result = await _orderService.GetAllOrders();

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Order => new OrderInfoDTO
                {
                    CustomerUserId = Order.CustomerUserId,
                    Id = Order.Id,
                    IsCompleted = Order.IsCompleted,
                    OrderDate = Order.OrderDate,
                    ShopId = Order.ShopId,
                    ShopName = Order.Shops.Name,
                    TotalAmount = Order.OrderItems.Sum(OrderItem=>OrderItem.UnitPrice*OrderItem.Quantity),

                }).ToList();

                // Calculate total price for all items in the order



                var response = new CommonResponseDTO<List<OrderInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success,

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //GET ALL BY USER ID
        [HttpGet("GetAllOrdersByUserId/{UserId}")]
        public async Task<IActionResult> GetAllOrdersByUserId([FromRoute] string UserId)
        {
            try
            {
                var result = await _orderService.GetAllOrdersByUserId(UserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Order => new OrderInfoDTO
                {
                    CustomerUserId = Order.CustomerUserId,
                    Id = Order.Id,
                    IsCompleted = Order.IsCompleted,
                    OrderDate = Order.OrderDate,
                    ShopId = Order.ShopId,
                    ShopName = Order.Shops.Name,
                    TotalAmount = Order.OrderItems.Sum(OrderItem => OrderItem.UnitPrice * OrderItem.Quantity),

                }).ToList();

                // Calculate total price for all items in the order



                var response = new CommonResponseDTO<List<OrderInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success,

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //GET ALL BY SHOP ID
        [HttpGet("GetAllOrdersByShopId/{ShopId:guid}")]
        public async Task<IActionResult> GetAllOrdersByShopId([FromRoute] Guid ShopId)
        {
            try
            {
                var result = await _orderService.GetAllOrdersByShopId(ShopId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Order => new OrderInfoDTO
                {
                    CustomerUserId = Order.CustomerUserId,
                    Id = Order.Id,
                    IsCompleted = Order.IsCompleted,
                    OrderDate = Order.OrderDate,
                    ShopId = Order.ShopId,
                    ShopName = Order.Shops.Name,
                    TotalAmount = Order.OrderItems.Sum(OrderItem => OrderItem.UnitPrice * OrderItem.Quantity),

                }).ToList();

                // Calculate total price for all items in the order



                var response = new CommonResponseDTO<List<OrderInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success,

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //GET BY ORDER ID
        [HttpGet("GetOrderById/{OrderId:guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid OrderId)
        {
            try
            {
                var result = await _orderService.GetOrderById(OrderId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = new OrderInfoDTO
                {
                    CustomerUserId = result.Data.CustomerUserId,
                    Id = result.Data.Id,
                    IsCompleted = result.Data.IsCompleted,
                    OrderDate = result.Data.OrderDate,
                    ShopId = result.Data.ShopId,
                    ShopName = result.Data.Shops.Name,
                    TotalAmount = result.Data.OrderItems.Sum(OrderItem => OrderItem.UnitPrice * OrderItem.Quantity),

                };

                // Calculate total price for all items in the order



                var response = new CommonResponseDTO<OrderInfoDTO>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success,

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //GET BY USER ID
        [HttpGet("GetOrderByUserId/{UserId}")]
        public async Task<IActionResult> GetOrderByUserId([FromRoute] string UserId)
        {
            try
            {
                var result = await _orderService.GetOrderByUserId(UserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = new OrderInfoDTO
                {
                    CustomerUserId = result.Data.CustomerUserId,
                    Id = result.Data.Id,
                    IsCompleted = result.Data.IsCompleted,
                    OrderDate = result.Data.OrderDate,
                    ShopId = result.Data.ShopId,
                    ShopName = result.Data.Shops.Name,
                    TotalAmount = result.Data.OrderItems.Sum(OrderItem => OrderItem.UnitPrice * OrderItem.Quantity),

                };

                // Calculate total price for all items in the order



                var response = new CommonResponseDTO<OrderInfoDTO>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success,

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //GET ACTIVE ORDERS BY USER ID
        [HttpGet("GetActiveOrdersByUserId/{UserId}")]
        public async Task<IActionResult> GetActiveOrdersByUserId([FromRoute] string UserId)
        {
            try
            {
                var result = await _orderService.GetActiveOrdersByUserId(UserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Order => new OrderInfoDTO
                {
                    CustomerUserId = Order.CustomerUserId,
                    Id = Order.Id,
                    IsCompleted = Order.IsCompleted,
                    OrderDate = Order.OrderDate,
                    ShopId = Order.ShopId,
                    ShopName = Order.Shops.Name,
                    TotalAmount = Order.OrderItems.Sum(OrderItem => OrderItem.UnitPrice * OrderItem.Quantity),


                }).ToList();

                // Calculate total price for all items in the order



                var response = new CommonResponseDTO<List<OrderInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success,

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //GET ACTIVE BY SHOP ID
        [HttpGet("GetActiveOrdersByShopId/{ShopId:guid}")]
        public async Task<IActionResult> GetActiveOrdersByShopId([FromRoute] Guid ShopId)
        {
            try
            {
                var result = await _orderService.GetActiveOrdersByShopId(ShopId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Order => new OrderInfoDTO
                {
                    CustomerUserId = Order.CustomerUserId,
                    Id = Order.Id,
                    IsCompleted = Order.IsCompleted,
                    OrderDate = Order.OrderDate,
                    ShopId = Order.ShopId,
                    ShopName = Order.Shops.Name,
                    TotalAmount = Order.OrderItems.Sum(OrderItem => OrderItem.UnitPrice * OrderItem.Quantity),


                }).ToList();

                // Calculate total price for all items in the order



                var response = new CommonResponseDTO<List<OrderInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success,

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }



        //---------------POST----------------

        //CREATE ORDER
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestDTO request)
        {
            try
            {
                if (request == null)
                    return BadRequest("Invalid request");

                var CreateRequest = new Order
                {
                    CustomerUserId = request.CustomerUserId,
                    OrderDate = request.OrderDate,
                    IsCompleted = false,
                    ShopId = request.ShopId,

                };
                var Result = await _orderService.CreateOrder(CreateRequest);

                if (!Result.Success)
                    return BadRequest(Result.Message);

                return Ok(Result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //---------------PUT----------------

        //UPDATE ORDER
        [HttpPut("UpdateOrder/{OrderId:guid}")]
        public async Task<IActionResult> UpdateOrder(CreateOrderRequestDTO request, [FromRoute] Guid OrderId)
        {
            try
            {
                if (request == null)
                    return BadRequest("Invalid request");

                var UpdateRequest = new Order
                {
                    Id = OrderId,
                    CustomerUserId = request.CustomerUserId,
                    OrderDate = request.OrderDate,
                    IsCompleted = false,
                    ShopId = request.ShopId,

                };
                var Result = await _orderService.UpdateOrder(UpdateRequest);

                if (!Result.Success)
                    return BadRequest(Result.Message);

                return Ok(Result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }
        
        //---------------DELETE----------------

        //DELETE ORDER
        [HttpDelete("DeleteOrder/{OrderId:guid}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid OrderId)
        {
            try
            {
                if (OrderId == null)
                    return BadRequest("Invalid request");


                var Result = await _orderService.DeleteOrder(OrderId);

                if (!Result.Success)
                    return BadRequest(Result.Message);

                return Ok(Result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

    }
}
