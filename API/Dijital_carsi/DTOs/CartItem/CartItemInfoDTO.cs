using Core.Entities.Domains;
using Dijital_carsi.DTOs.Product;

namespace Dijital_carsi.DTOs.CartItem
{
    public class CartItemInfoDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        
        public ProductItemInfoDTO Product { get; set; }
        public int Quantity { get; set; }
        public Guid ShoppingCartId { get; set; }

        public decimal TotalAmount { get; set; }

    }
}
