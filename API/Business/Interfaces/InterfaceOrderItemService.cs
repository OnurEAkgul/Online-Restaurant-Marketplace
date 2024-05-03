using Core.Entities.Domains;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceOrderItemService
    {
        Task<IDataResult<OrderItem>> GetOrderItemById(Guid orderItemId);
        Task<IResult> AddOrderItem(OrderItem orderItem);
        Task<IResult> UpdateOrderItem(OrderItem orderItem);
        Task<IResult> DeleteOrderItem(Guid orderItemId);
    }
}
