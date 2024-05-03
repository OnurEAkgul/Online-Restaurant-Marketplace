using Core.Entities.Domains;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceOrderService
    {
        Task<IDataResult<Order>> GetOrderById(Guid orderId);
        Task<IDataResult<List<Order>>> GetAllOrders();
        Task<IResult> CreateOrder(Order order);
        Task<IResult> UpdateOrder(Order order);
        Task<IResult> DeleteOrder(Guid orderId);
        Task<IDataResult<Order>> GetOrderByUserId(string id);
        Task<IDataResult<List<Order>>> GetActiveOrdersByUserId(Guid id);
        Task<IDataResult<List<Order>>> GetAllOrdersByUserId(string id);
        Task<IDataResult<List<Order>>> GetActiveOrdersByShopId(Guid id);
        Task<IDataResult<List<Order>>> GetAllOrdersByShopId(Guid id);
    }
}
