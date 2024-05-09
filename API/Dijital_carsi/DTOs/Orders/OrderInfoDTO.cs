using Core.Entities.Domains;

namespace Dijital_carsi.DTOs.Orders
{
    public class OrderInfoDTO
    {
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }      // Foreign key to link with shop
        public string ShopName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }  // Indicates if the order is completed
        public string CustomerUserId { get; set; }

    }
}
