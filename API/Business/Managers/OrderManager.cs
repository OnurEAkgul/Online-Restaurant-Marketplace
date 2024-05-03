using Business.Interfaces;
using Core.Entities.Domains;
using Core.Utilities.Results;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class OrderManager : InterfaceOrderService
    {
        private readonly InterfaceOrderDAL _orderDAL;

        public OrderManager(InterfaceOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public async Task<IDataResult<Order>> GetOrderById(Guid orderId)
        {
            try
            {
                var order = await _orderDAL.GetAsync(o => o.Id == orderId);
                if (order == null)
                    return new ErrorDataResult<Order>(null, "Order not found.");

                return new SuccessDataResult<Order>(order, "Order retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Order>(null, $"Error retrieving order: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Order>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderDAL.GetAllAsync();
                return new SuccessDataResult<List<Order>>(orders, "All orders retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Order>>(null, $"Error retrieving all orders: {ex.Message}");
            }
        }

        public async Task<IResult> CreateOrder(Order order)
        {
            try
            {
                await _orderDAL.AddAsync(order);
                return new SuccessResult("Order created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error creating order: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateOrder(Order order)
        {
            try
            {
                await _orderDAL.UpdateAsync(order);
                return new SuccessResult("Order updated successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error updating order: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteOrder(Guid orderId)
        {
            try
            {
                var order = new Order { Id = orderId };
                await _orderDAL.DeleteAsync(order);
                return new SuccessResult("Order deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error deleting order: {ex.Message}");
            }
        }

        public async Task<IDataResult<Order>> GetOrderByUserId(string id)
        {
            try
            {
                var order = await _orderDAL.GetAsync(o => o.NormalUserId == id);
                if (order == null)
                    return new ErrorDataResult<Order>(null, "Order not found.");

                return new SuccessDataResult<Order>(order, "Order retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Order>(null, $"Error retrieving order: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Order>>> GetAllOrdersByUserId(string id)
        {
            try
            {
                var orders = await _orderDAL.GetAllAsync(o => o.NormalUserId == id);
                if (orders.Count == 0)
                {
                    return new ErrorDataResult<List<Order>>(null, "No orders found for the user.");
                }
                return new SuccessDataResult<List<Order>>(orders, "All orders retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Order>>(null, $"Error retrieving all orders: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Order>>> GetAllOrdersByShopId(Guid id)
        {
            try
            {
                var orders = await _orderDAL.GetAllAsync(o => o.ShopId == id);
                if (orders.Count == 0)
                {
                    return new ErrorDataResult<List<Order>>(null, "No orders found for the shop ID.");
                }

                return new SuccessDataResult<List<Order>>(orders, "All orders retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Order>>(null, $"Error retrieving all orders: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Order>>> GetActiveOrdersByShopId(Guid id)
        {
            try
            {
                Expression<Func<Order, bool>> filter = o => o.ShopId == id && o.IsCompleted == false;
                var orders = await _orderDAL.GetAllAsync(filter);
                if (orders.Count == 0)
                {
                    return new ErrorDataResult<List<Order>>(null, "No active orders found for the shop ID.");
                }

                return new SuccessDataResult<List<Order>>(orders, "All orders retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Order>>(null, $"Error retrieving all orders: {ex.Message}");
            }
        }
        public async Task<IDataResult<List<Order>>> GetActiveOrdersByUserId(Guid id)
        {
            try
            {
                Expression<Func<Order, bool>> filter = o => o.CustomerId == id && o.IsCompleted == false;
                var orders = await _orderDAL.GetAllAsync(filter);
                if (orders.Count == 0)
                {
                    return new ErrorDataResult<List<Order>>(null, "No active orders found for the shop ID.");
                }

                return new SuccessDataResult<List<Order>>(orders, "All orders retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Order>>(null, $"Error retrieving all orders: {ex.Message}");
            }
        }
    }
}
