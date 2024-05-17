using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using Dijital_carsi.DTOs.Category;
using Dijital_carsi.DTOs.Common;
using Dijital_carsi.DTOs.OrderItem;
using Dijital_carsi.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {


        //------------------FINISHED---------------------

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
            try
            {
                var result = await _orderItemService.GetOrderItems();

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(OrderItems => new OrderItemInfoDTO
                {
                    Id = OrderItems.Id,
                   
                    OrderId = OrderItems.OrderId,
                    ProductId = OrderItems.ProductId,

                    ProductInfo = new ProductInfoDTO
                    {
                        Id=OrderItems.ProductId,
                        CategoryId = OrderItems.Products.CategoryId,
                        CategoryName = OrderItems.Products.Category.Name,
                        Name = OrderItems.Products.Name,
                        Description = OrderItems.Products.Description,
                        ImageUrl = OrderItems.Products.ImageUrl,
                        Price = OrderItems.Products.Price,
                        ShopId=OrderItems.Products.ShopId,
                        ShopName=OrderItems.Products.Shops.Name
                    },

                    Quantity = OrderItems.Quantity,
                    UnitPrice = OrderItems.UnitPrice,

                    TotalPrice = OrderItems.Quantity * OrderItems.UnitPrice, // Calculate total price per item
                }).ToList();

                // Calculate total price for all items in the order
                decimal totalOrderPrice = resultData.Sum(item => item.TotalPrice);



                var response = new OrderItemsResponseDTO()
                {
                    OrderItems = resultData,
                    Message = result.Message,
                    Successful = result.Success,
                    TotalOrderPrice = totalOrderPrice
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //GET ORDER ITEMS BY ORDER ID
        [HttpGet("GetOrderItemsByOrderId/{OrderId:guid}")]
        public async Task<IActionResult> GetOrderItemsByOrderId([FromRoute] Guid OrderId)
        {
            try
            {
                var result = await _orderItemService.GetOrderItemsByOrderId(OrderId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(OrderItems => new OrderItemInfoDTO
                {
                    Id = OrderItems.Id,
                  
                    OrderId = OrderItems.OrderId,
                    ProductId = OrderItems.ProductId,

                    ProductInfo = new ProductInfoDTO
                    {
                        Id = OrderItems.ProductId,
                        CategoryId = OrderItems.Products.CategoryId,
                        CategoryName = OrderItems.Products.Category.Name,
                        Name = OrderItems.Products.Name,
                        Description = OrderItems.Products.Description,
                        ImageUrl = OrderItems.Products.ImageUrl,
                        Price = OrderItems.Products.Price,
                        ShopId = OrderItems.Products.ShopId,
                        ShopName = OrderItems.Products.Shops.Name
                    },

                    Quantity = OrderItems.Quantity,
                    UnitPrice = OrderItems.UnitPrice,
                    TotalPrice = OrderItems.Quantity * OrderItems.UnitPrice, // Calculate total price per item
                }).ToList();

                // Calculate total price for all items in the order
                decimal totalOrderPrice = resultData.Sum(item => item.TotalPrice);


                var response = new OrderItemsResponseDTO()
                {
                    OrderItems = resultData,
                    Message = result.Message,
                    Successful = result.Success,
                    TotalOrderPrice = totalOrderPrice,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        //GET ORDER ITEM BY ORDER ITEM ID        
        [HttpGet("GetOrderItemById/{OrderItemId:guid}")]
        public async Task<IActionResult> GetOrderItemById([FromRoute] Guid OrderItemId)
        {
            try
            {
                var result = await _orderItemService.GetOrderItemById(OrderItemId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = new OrderItemInfoDTO
                {
                    Id = result.Data.Id,
                    
                    OrderId = result.Data.OrderId,
                    ProductId = result.Data.ProductId,

                    ProductInfo = new ProductInfoDTO
                    {
                        Id = result.Data.ProductId,
                        CategoryId = result.Data.Products.CategoryId,
                        CategoryName = result.Data.Products.Category.Name,
                        Name = result.Data.Products.Name,
                        Description = result.Data.Products.Description,
                        ImageUrl = result.Data.Products.ImageUrl,
                        Price = result.Data.Products.Price,
                        ShopId = result.Data.Products.ShopId,
                        ShopName = result.Data.Products.Shops.Name
                    },

                    Quantity = result.Data.Quantity,
                    UnitPrice = result.Data.UnitPrice,
                    TotalPrice = result.Data.Quantity * result.Data.UnitPrice, // Calculate total price per item
                };

                // Calculate total price for all items in the order
                decimal totalOrderPrice = resultData.TotalPrice;


                var response = new OrderItemsResponseDTO()
                {
                    OrderItem = resultData,
                    Message = result.Message,
                    Successful = result.Success,
                    TotalOrderPrice = totalOrderPrice,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }




        //---------------POST----------------

        //ADD ORDER ITEM
        [HttpPost("AddOrderItem")]
        public async Task<IActionResult> AddOrderItem(OrderItemCreateRequestDTO request)
        {
            try
            {

                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var CreateRequest = new OrderItem
                {
                    OrderId = request.OrderId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                };

                var result = await _orderItemService.AddOrderItem(CreateRequest);
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

        //UPDATE ORDER ITEM
        [HttpPut("UpdateOrderItem/{OrderItemId:guid}")]
        public async Task<IActionResult> UpdateOrderItem([FromRoute] Guid OrderItemId, OrderItemCreateRequestDTO request)
        {
            try
            {

                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var UpdateRequest = new OrderItem
                {
                    Id= OrderItemId,
                    OrderId = request.OrderId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                };

                var result = await _orderItemService.UpdateOrderItem(UpdateRequest);
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


        //DELETE ORDER ITEM
        [HttpDelete("DeleteOrderItem/{OrderItemId:guid}")]
        public async Task<IActionResult> DeleteOrderItem([FromRoute] Guid OrderItemId)
        {
            try
            {

                if (OrderItemId == null)
                {
                    return BadRequest("Invalid request");
                }


                var result = await _orderItemService.DeleteOrderItem(OrderItemId);
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
