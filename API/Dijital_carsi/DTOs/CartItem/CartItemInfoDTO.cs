using Core.Entities.Domains;

namespace Dijital_carsi.DTOs.CartItem
{
    public class CartItemInfoDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        
        public int Quantity { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
