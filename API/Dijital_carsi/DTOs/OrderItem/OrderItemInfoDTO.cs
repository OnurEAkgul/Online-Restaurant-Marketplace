using Core.Entities.Domains;
using Dijital_carsi.DTOs.Product;
namespace Dijital_carsi.DTOs.OrderItem
{
    public class OrderItemInfoDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }   // Foreign key to link with product
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        // Navigation properties
        public ProductInfoDTO ProductInfo { get; set; }


    }
}
