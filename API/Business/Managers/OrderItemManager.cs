using Business.Interfaces;
using Core.Entities.Domains;
using Core.Utilities.Results;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class OrderItemManager : InterfaceOrderItemService
    {
        private readonly InterfaceOrderItemDAL _orderItemDAL;

        public OrderItemManager(InterfaceOrderItemDAL orderItemDAL)
        {
            _orderItemDAL = orderItemDAL;
        }

        public async Task<IDataResult<OrderItem>> GetOrderItemById(Guid orderItemId)
        {
            try
            {
                var orderItem = await _orderItemDAL.GetAsync(oi => oi.Id == orderItemId);
                if (orderItem == null)
                    return new ErrorDataResult<OrderItem>(null, "Order item not found.");

                return new SuccessDataResult<OrderItem>(orderItem, "Order item retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OrderItem>(null, $"Error retrieving order item: {ex.Message}");
            }
        }

        public async Task<IResult> AddOrderItem(OrderItem orderItem)
        {
            try
            {
                await _orderItemDAL.AddAsync(orderItem);
                return new SuccessResult("Order item added successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error adding order item: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateOrderItem(OrderItem orderItem)
        {
            try
            {
                await _orderItemDAL.UpdateAsync(orderItem);
                return new SuccessResult("Order item updated successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error updating order item: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteOrderItem(Guid orderItemId)
        {
            try
            {
                var orderItem = new OrderItem { Id = orderItemId };
                await _orderItemDAL.DeleteAsync(orderItem);
                return new SuccessResult("Order item deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error deleting order item: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<OrderItem>>> GetOrderItemsByOrderId(Guid orderId)
        {
            try
            {
                var orderItem = await _orderItemDAL.GetAllAsync(oi => oi.OrderId == orderId);
                if (orderItem.Count == 0)
                    return new ErrorDataResult<List<OrderItem>>(null, "Order item not found.");

                return new SuccessDataResult<List<OrderItem>>(orderItem, "Order item retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<OrderItem>>(null, $"Error retrieving order item: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<OrderItem>>> GetOrderItems()
        {
            try
            {
                var orderItem = await _orderItemDAL.GetAllAsync();
                if (orderItem.Count == 0)
                    return new ErrorDataResult<List<OrderItem>>(null, "Order item not found.");

                return new SuccessDataResult<List<OrderItem>>(orderItem, "Order item retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<OrderItem>>(null, $"Error retrieving order item: {ex.Message}");
            }
        }
    }
}
