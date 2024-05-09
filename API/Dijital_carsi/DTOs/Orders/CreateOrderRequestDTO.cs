namespace Dijital_carsi.DTOs.Orders
{
    public class CreateOrderRequestDTO
    {


        public Guid ShopId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerUserId { get; set; }

    }
}
