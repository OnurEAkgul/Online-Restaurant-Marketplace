using Core.Entities.Domains;

namespace Dijital_carsi.DTOs.CartItem
{
    public class CartItemRequestDTO
    {

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        

    }
}
