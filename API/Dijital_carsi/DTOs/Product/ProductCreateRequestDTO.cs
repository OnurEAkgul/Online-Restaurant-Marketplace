namespace Dijital_carsi.DTOs.Product
{
    public class ProductCreateRequestDTO
    {

        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; } // Foreign key for Category
        
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        // Foreign key property (if using Entity Framework Core)
        public Guid ShopId { get; set; }
        



    }
}
