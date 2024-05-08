using Dijital_carsi.DTOs.Category;

namespace Dijital_carsi.DTOs.Product
{
    public class ProductInfoDTO
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; } // Foreign key for Category
        //public CategoryInfoDTO Category { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        // Foreign key property (if using Entity Framework Core)
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }


    }
}
