namespace Dijital_carsi.DTOs.OrderItem
{
    public class OrderItemsResponseDTO
    {
        public OrderItemInfoDTO OrderItem { get; set; } // Single order item
        public List<OrderItemInfoDTO> OrderItems { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public string Message { get; set; }
        public bool Successful { get; set; }
    }
}
