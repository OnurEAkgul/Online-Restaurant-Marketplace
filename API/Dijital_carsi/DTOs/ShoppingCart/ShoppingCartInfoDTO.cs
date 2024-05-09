namespace Dijital_carsi.DTOs.ShoppingCart
{
    public class ShoppingCartInfoDTO
    {
        public Guid Id { get; set; }
        public string CustomerUserId { get; set; } // Foreign key to link with the user
    }
}
