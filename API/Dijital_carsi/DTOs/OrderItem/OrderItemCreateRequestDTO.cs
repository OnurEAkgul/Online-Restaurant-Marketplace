namespace Dijital_carsi.DTOs.OrderItem
{
    public class OrderItemCreateRequestDTO
    {
        public Guid ProductId { get; set; }   // Foreign key to link with product
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid OrderId { get; set; }

    }
}
